﻿using BuildingManagerDomain.Entities;
using BuildingManagerIDataAccess;
using BuildingManagerIDataAccess.Exceptions;
using BuildingManagerILogic;
using BuildingManagerILogic.Exceptions;
using BuildingManagerLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Diagnostics.CodeAnalysis;

namespace BuildingManagerLogicTest
{
    [TestClass]

    public class BuildingLogicTest
    {
        private Building _building;
        private Guid sessionToken;
        private Guid companyId;
        private Guid userId;
        private Owner owner;

        [TestInitialize]
        public void Initialize()
        {
            owner = new Owner
            {
                Name = "John",
                LastName = "Doe",
                Email = "owner@email.com",
            };
            _building = new Building()
            {
                Id = new Guid(),
                ManagerId = Guid.NewGuid(),
                Name = "Building 1",
                Address = "Address",
                Location = "City",
                ConstructionCompanyId = Guid.NewGuid(),
                CommonExpenses = 1000,
                Apartments = new List<Apartment>
                {
                    new Apartment
                    {
                        Floor = 1,
                        Number = 1,
                        Rooms = 3,
                        Bathrooms = 2,
                        HasTerrace = true,
                        Owner = owner
                    }
                }
            };

            sessionToken = Guid.NewGuid();
            companyId = Guid.NewGuid();
            userId = Guid.NewGuid();
        }

        [TestMethod]
        public void CreateBuildingSuccessfully()
        {
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            userLogic.Setup(x => x.GetUserIdFromSessionToken(It.IsAny<Guid>())).Returns(userId);
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            constructionCompanyLogicMock.Setup(x => x.GetCompanyIdFromUserId(It.IsAny<Guid>())).Returns(companyId);
            buildingRespositoryMock.Setup(x => x.CreateBuilding(It.IsAny<Building>())).Returns(_building);
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);

            var result = buildingLogic.CreateBuilding(_building, sessionToken);

            buildingRespositoryMock.VerifyAll();
            constructionCompanyLogicMock.VerifyAll();
            Assert.AreEqual(_building, result);

        }

        [TestMethod]
        public void ListBuildingsSuccessfully()
        {
            BuildingResponse buildingResponse = new BuildingResponse(_building.Id, _building.Name, _building.Address, _building.ManagerId.ToString());
            var buildingsList = new List<BuildingResponse> { buildingResponse };
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            userLogic.Setup(x => x.GetUserIdFromSessionToken(It.IsAny<Guid>())).Returns(userId);
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            buildingRespositoryMock.Setup(x => x.CreateBuilding(It.IsAny<Building>())).Returns(_building);
            buildingRespositoryMock.Setup(x => x.ListBuildings()).Returns(buildingsList);
            constructionCompanyLogicMock.Setup(x => x.GetCompanyIdFromUserId(It.IsAny<Guid>())).Returns(companyId);
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);
            buildingLogic.CreateBuilding(_building, sessionToken);

            var result = buildingLogic.ListBuildings();

            buildingRespositoryMock.VerifyAll();
            constructionCompanyLogicMock.VerifyAll();
            Assert.AreEqual(buildingsList, result);

        }

        [TestMethod]
        public void CreateBuildingWithAlreadyInUseName()
        {
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            userLogic.Setup(x => x.GetUserIdFromSessionToken(It.IsAny<Guid>())).Returns(userId);
            constructionCompanyLogicMock.Setup(x => x.GetCompanyIdFromUserId(It.IsAny<Guid>())).Returns(companyId);
            buildingRespositoryMock.Setup(x => x.CreateBuilding(It.IsAny<Building>())).Throws(new ValueDuplicatedException(""));
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);
            Exception exception = null;
            try
            {
                buildingLogic.CreateBuilding(_building, sessionToken);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(DuplicatedValueException));
        }

        [TestMethod]
        public void CreateBuildingWithApartmentWithSameFloorAndNumberTest()
        {
            Building buildingWithApartmentWithSameFloorAndNumber = new Building()
            {
                Id = new Guid(),
                ManagerId = new Guid(),
                Name = "Building 1",
                Address = "Address",
                Location = "City",
                ConstructionCompanyId = Guid.NewGuid(),
                CommonExpenses = 1000,
                Apartments = new List<Apartment>
                {
                    new Apartment
                    {
                        Floor = 2,
                        Number = 1,
                        Rooms = 3,
                        Bathrooms = 2,
                        HasTerrace = true,
                        Owner = new Owner
                        {
                            Name = "John",
                            LastName = "Doe",
                            Email = "jhon@gmail.com"
                        }
                    },
                    new Apartment
                    {
                        Floor = 2,
                        Number = 1,
                        Rooms = 1,
                        Bathrooms = 2,
                        HasTerrace = true,
                        Owner = new Owner
                        {
                            Name = "John",
                            LastName = "Eod",
                            Email = "jhoneod@gmail.com"
                        }
                    }
                }
            };
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            userLogic.Setup(x => x.GetUserIdFromSessionToken(It.IsAny<Guid>())).Returns(userId);
            constructionCompanyLogicMock.Setup(x => x.GetCompanyIdFromUserId(It.IsAny<Guid>())).Returns(companyId);
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);
            Exception exception = null;

            try
            {
                buildingLogic.CreateBuilding(buildingWithApartmentWithSameFloorAndNumber, sessionToken);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(DuplicatedValueException));
        }

        [TestMethod]
        public void CreateBuildingWithApartmentWithSameOwnerEmailTest()
        {
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            userLogic.Setup(x => x.GetUserIdFromSessionToken(It.IsAny<Guid>())).Returns(userId);
            constructionCompanyLogicMock.Setup(x => x.GetCompanyIdFromUserId(It.IsAny<Guid>())).Returns(companyId);
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);
            Exception exception = null;

            Building buildingWithSameOwnerEmail = new Building()
            {
                Id = new Guid(),
                ManagerId = new Guid(),
                Name = "Building 2",
                Address = "Address",
                Location = "City",
                ConstructionCompanyId = Guid.NewGuid(),
                CommonExpenses = 1000,
                Apartments = new List<Apartment>
                {
                    new Apartment
                    {
                        Floor = 1,
                        Number = 1,
                        Rooms = 3,
                        Bathrooms = 2,
                        HasTerrace = true,
                        Owner = new Owner
                        {
                            Name = "John",
                            LastName = "Doe",
                            Email = "jhon@gmail.com"
                        }
                    },
                    new Apartment
                    {
                        Floor = 2,
                        Number = 3,
                        Rooms = 1,
                        Bathrooms = 2,
                        HasTerrace = true,
                        Owner = new Owner
                        {
                            Name = "John",
                            LastName = "Eod",
                            Email = "jhon@gmail.com"
                        }
                    }
                }
            };

            try
            {
                buildingLogic.CreateBuilding(buildingWithSameOwnerEmail, sessionToken);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(DuplicatedValueException));
        }

        [TestMethod]
        public void DeleteBuildingSuccessfully()
        {
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            userLogic.Setup(x => x.GetUserIdFromSessionToken(It.IsAny<Guid>())).Returns(userId);
            constructionCompanyLogicMock.Setup(x => x.IsUserAssociatedToCompany(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns(true);
            buildingRespositoryMock.Setup(x => x.DeleteBuilding(It.IsAny<Guid>())).Returns(_building);
            buildingRespositoryMock.Setup(x => x.GetConstructionCompanyFromBuildingId(It.IsAny<Guid>())).Returns(companyId);
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);

            var result = buildingLogic.DeleteBuilding(_building.Id, sessionToken);

            buildingRespositoryMock.VerifyAll();
            Assert.AreEqual(_building, result);
        }

        [TestMethod]
        public void GetConstructionCompanyIdFromBuildingIdTest()
        {
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            buildingRespositoryMock.Setup(x => x.GetConstructionCompanyFromBuildingId(It.IsAny<Guid>())).Returns(companyId);
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);

            var result = buildingLogic.GetConstructionCompanyFromBuildingId(_building.Id);

            buildingRespositoryMock.VerifyAll();
            Assert.AreEqual(companyId, result);
        }

        [TestMethod]
        public void GetConstructionCompanyFromInvalidBuildingIdTest()
        {
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            userLogic.Setup(x => x.GetUserIdFromSessionToken(It.IsAny<Guid>())).Returns(userId);
            buildingRespositoryMock.Setup(x => x.GetConstructionCompanyFromBuildingId(It.IsAny<Guid>())).Throws(new ValueNotFoundException(""));
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);

            Exception exception = null;

            try
            {
                buildingLogic.GetConstructionCompanyFromBuildingId(new Guid());
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            buildingRespositoryMock.VerifyAll();
            Assert.IsInstanceOfType(exception, typeof(NotFoundException));
        }

        [TestMethod]
        public void GetBuildingFromBuildingIdTest()
        {
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            buildingRespositoryMock.Setup(x => x.GetBuildingById(It.IsAny<Guid>())).Returns(_building);
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);

            var result = buildingLogic.GetBuildingById(_building.Id);

            buildingRespositoryMock.VerifyAll();
            Assert.AreEqual(_building, result);
        }

        [TestMethod]
        public void GetBuildingFromInvalidBuildingIdTest()
        {
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            buildingRespositoryMock.Setup(x => x.GetBuildingById(It.IsAny<Guid>())).Throws(new ValueNotFoundException(""));
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);

            Exception exception = null;

            try
            {
                buildingLogic.GetBuildingById(new Guid());
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            buildingRespositoryMock.VerifyAll();
            Assert.IsInstanceOfType(exception, typeof(NotFoundException));
        }

        [TestMethod]
        public void GetManagerBuildingsTest()
        {
            List<Building> buildings = [_building];
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            buildingRespositoryMock.Setup(x => x.GetManagerBuildings(It.IsAny<Guid>())).Returns(buildings);
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);

            var result = buildingLogic.GetManagerBuildings(_building.ManagerId ?? Guid.NewGuid());

            buildingRespositoryMock.VerifyAll();
            Assert.AreEqual(buildings, result);
        }

        [TestMethod]
        public void GetManagerBuildingsFromInvalidManagerIdTest()
        {
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            buildingRespositoryMock.Setup(x => x.GetManagerBuildings(It.IsAny<Guid>())).Throws(new ValueNotFoundException(""));
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);

            Exception exception = null;

            try
            {
                buildingLogic.GetManagerBuildings(new Guid());
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            buildingRespositoryMock.VerifyAll();
            Assert.IsInstanceOfType(exception, typeof(NotFoundException));
        }

        [TestMethod]
        public void UpdateBuildingSuccessfully()
        {
            Building buildingUpdated = new Building
            {
                Id = _building.Id,
                ManagerId = _building.ManagerId,
                Name = "Building",
                Address = "1234 Main St",
                Location = "City",
                ConstructionCompanyId = Guid.NewGuid(),
                CommonExpenses = 1000,
                Apartments = new List<Apartment>
                {
                    new Apartment
                    {
                        Floor = 1,
                        Number = 1,
                        Rooms = 3,
                        Bathrooms = 2,
                        HasTerrace = true,
                        Owner = new Owner
                        {
                            Name = "John",
                            LastName = "Doe",
                            Email = "jhon@gmail.com"
                        }
                    },
                    new Apartment
                    {
                        Floor = 2,
                        Number = 2,
                        Rooms = 4,
                        Bathrooms = 3,
                        HasTerrace = false,
                        Owner = new Owner
                        {
                            Name = "Jane",
                            LastName = "Doe",
                            Email = "jane@gmail.com"
                        }
                    },
                    new Apartment
                    {
                        Floor = 3,
                        Number = 3,
                        Rooms = 2,
                        Bathrooms = 1,
                        HasTerrace = true,
                        Owner = new Owner
                        {
                            Name = "Jade",
                            LastName = "Doe",
                            Email = "jade@gmail.com"
                        }
                    }
                }
            };
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            buildingRespositoryMock.Setup(x => x.UpdateBuilding(It.IsAny<Building>())).Returns(buildingUpdated);
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);

            var result = buildingLogic.UpdateBuilding(buildingUpdated);

            buildingRespositoryMock.VerifyAll();
            Assert.AreEqual(buildingUpdated, result);
        }

        [TestMethod]
        public void UpdateBuildingWithApartmentWithSameFloorAndNumberTest()
        {
            Building buildingUpdated = new Building
            {
                Id = _building.Id,
                ManagerId = _building.ManagerId,
                Name = "Building",
                Address = "1234 Main St",
                Location = "City",
                ConstructionCompanyId = Guid.NewGuid(),
                CommonExpenses = 1000,
                Apartments = new List<Apartment>
                {
                    new Apartment
                    {
                        Floor = 1,
                        Number = 1,
                        Rooms = 3,
                        Bathrooms = 2,
                        HasTerrace = true,
                        Owner = new Owner
                        {
                            Name = "John",
                            LastName = "Doe",
                            Email = "jhon@gmail.com"
                        }
                    },
                    new Apartment
                    {
                        Floor = 2,
                        Number = 2,
                        Rooms = 4,
                        Bathrooms = 3,
                        HasTerrace = false,
                        Owner = new Owner
                        {
                            Name = "Jane",
                            LastName = "Doe",
                            Email = "jane@gmail.com"
                        }
                    },
                    new Apartment
                    {
                        Floor = 1,
                        Number = 1,
                        Rooms = 2,
                        Bathrooms = 1,
                        HasTerrace = true,
                        Owner = new Owner
                        {
                            Name = "Jade",
                            LastName = "Doe",
                            Email = "jade@gmail.com"
                        }
                    }
                }
            };
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);
            Exception exception = null;

            try
            {
                buildingLogic.UpdateBuilding(buildingUpdated);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(DuplicatedValueException));
        }

        [TestMethod]
        public void UpdateBuildingWithApartmentWithSameOwnerEmailTest()
        {
            Building buildingUpdated = new Building
            {
                Id = _building.Id,
                ManagerId = _building.ManagerId,
                Name = "Building",
                Address = "1234 Main St",
                Location = "City",
                ConstructionCompanyId = Guid.NewGuid(),
                CommonExpenses = 1000,
                Apartments = new List<Apartment>
                {
                    new Apartment
                    {
                        Floor = 1,
                        Number = 1,
                        Rooms = 3,
                        Bathrooms = 2,
                        HasTerrace = true,
                        Owner = new Owner
                        {
                            Name = "John",
                            LastName = "Doe",
                            Email = "jhon@gmail.com"
                        }
                    },
                    new Apartment
                    {
                        Floor = 2,
                        Number = 2,
                        Rooms = 4,
                        Bathrooms = 3,
                        HasTerrace = false,
                        Owner = new Owner
                        {
                            Name = "Jane",
                            LastName = "Doe",
                            Email = "jane@gmail.com"
                        }
                    },
                    new Apartment
                    {
                        Floor = 3,
                        Number = 3,
                        Rooms = 2,
                        Bathrooms = 1,
                        HasTerrace = true,
                        Owner = new Owner
                        {
                            Name = "Jade",
                            LastName = "Doe",
                            Email = "jane@gmail.com"
                        }
                    }
                }
            };
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);
            Exception exception = null;

            try
            {
                buildingLogic.UpdateBuilding(buildingUpdated);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(DuplicatedValueException));
        }

        [TestMethod]
        public void DeleteBuildingThatIsNotMine()
        {
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            userLogic.Setup(x => x.GetUserIdFromSessionToken(It.IsAny<Guid>())).Returns(userId);
            constructionCompanyLogicMock.Setup(x => x.IsUserAssociatedToCompany(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns(false);
            buildingRespositoryMock.Setup(x => x.DeleteBuilding(It.IsAny<Guid>())).Throws(new ValueNotFoundException(""));
            buildingRespositoryMock.Setup(x => x.GetConstructionCompanyFromBuildingId(It.IsAny<Guid>())).Returns(companyId);
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);
            Exception exception = null;
            try
            {
                buildingLogic.DeleteBuilding(_building.Id, sessionToken);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(ValueNotFoundException));
        }

        [TestMethod]
        public void UpdateBuildingManagerSuccessfully()
        {
            Building building = new Building
            {
                Id = _building.Id,
                ManagerId = _building.ManagerId,
                Name = "Building",
                Address = "1234 Main St",
                Location = "City",
                ConstructionCompanyId = Guid.NewGuid(),
                CommonExpenses = 1000,
                Apartments = new List<Apartment>
                {
                    new Apartment
                    {
                        Floor = 1,
                        Number = 1,
                        Rooms = 3,
                        Bathrooms = 2,
                        HasTerrace = true,
                        Owner = new Owner
                        {
                            Name = "John",
                            LastName = "Doe",
                            Email = "jhon@gmail.com"
                        }
                    }
                }
            };
            Guid newManagerId = Guid.NewGuid();
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            buildingRespositoryMock.Setup(x => x.ModifyBuildingManager(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns(newManagerId);
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);

            var result = buildingLogic.ModifyBuildingManager(newManagerId, building.Id);

            buildingRespositoryMock.VerifyAll();
            Assert.AreEqual(newManagerId, result);
        }

        [TestMethod]
        public void UpdateBuildingManagerWithInvalidBuildingIdTest()
        {
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            buildingRespositoryMock.Setup(x => x.ModifyBuildingManager(It.IsAny<Guid>(), It.IsAny<Guid>())).Throws(new ValueNotFoundException(""));
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);

            Exception exception = null;

            try
            {
                buildingLogic.ModifyBuildingManager(Guid.NewGuid(), Guid.NewGuid());
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            buildingRespositoryMock.VerifyAll();
            Assert.IsInstanceOfType(exception, typeof(NotFoundException));
        }

        [TestMethod]
        public void GetBuildingDetailsByNameTest()
        {
            BuildingDetails buildingDetails = new BuildingDetails(_building.Id, _building.Name, _building.Address, _building.Location, (decimal)_building.CommonExpenses, (Guid)_building.ManagerId, "Manager name", _building.ConstructionCompanyId, "ConstructionCompany name", _building.Apartments);
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            buildingRespositoryMock.Setup(x => x.GetBuildingDetails(It.IsAny<Guid>())).Returns(buildingDetails);
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);

            var result = buildingLogic.GetBuildingDetails(_building.Id);

            buildingRespositoryMock.VerifyAll();
            Assert.AreEqual(buildingDetails, result);
        }

        [TestMethod]
        public void GetOwnerByEmailTest()
        {
            List<Building> buildings = [_building];
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            buildingRespositoryMock.Setup(x => x.GetOwnerFromEmail(It.IsAny<string>())).Returns(owner);
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);

            var result = buildingLogic.GetOwnerFromEmail(_building.Apartments[0].Owner.Email);

            buildingRespositoryMock.VerifyAll();
            Assert.AreEqual(owner, result);
        }

        [TestMethod]
        public void GetOwnerFromInvalidEmailTest()
        {
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            buildingRespositoryMock.Setup(x => x.GetOwnerFromEmail(It.IsAny<string>())).Throws(new ValueNotFoundException(""));
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);

            Exception exception = null;

            try
            {
                buildingLogic.GetOwnerFromEmail("some@mail.com");
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            buildingRespositoryMock.VerifyAll();
            Assert.IsInstanceOfType(exception, typeof(NotFoundException));
        }

        [TestMethod]
        public void CheckIfBuildingExistsTest()
        {
            var constructionCompanyLogicMock = new Mock<IConstructionCompanyLogic>(MockBehavior.Strict);
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            var userLogic = new Mock<IUserLogic>(MockBehavior.Strict);
            buildingRespositoryMock.Setup(x => x.CheckIfBuildingExists(It.IsAny<Building>())).Returns(true);
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object, constructionCompanyLogicMock.Object, userLogic.Object);

            var result = buildingLogic.CheckIfBuildingExists(_building);

            buildingRespositoryMock.VerifyAll();
            Assert.IsTrue(result);
        }
    }
}