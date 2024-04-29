﻿using BuildingManagerDataAccess.Context;
using BuildingManagerDataAccess.Repositories;
using BuildingManagerDomain.Entities;
using BuildingManagerDomain.Enums;
using BuildingManagerIDataAccess.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BuildingManagerDataAccessTest
{
    [TestClass]
    public class BuildingRepositoryTest
    {
        [TestMethod]
        public void CreateBuildingTest()
        {
            var context = CreateDbContext("CreateBuildingTest");
            var repository = new BuildingRepository(context);
            var building = new Building
            {
                Id = Guid.NewGuid(),
                ManagerId = Guid.NewGuid(),
                Name = "Building 1",
                Address = "Address 1",
                Location = "Location 1",
                ConstructionCompany = "Company 1",
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
                            Email = "validmail@outlook.com"
                        }
                    }
                }
            };

            repository.CreateBuilding(building);
            var result = context.Set<Building>().Find(building.Id);

            Assert.AreEqual(building, result);
        }

        private DbContext CreateDbContext(string name)
        {
            var options = new DbContextOptionsBuilder<BuildingManagerContext>()
                .UseInMemoryDatabase(name)
                .Options;
            return new BuildingManagerContext(options);
        }

        [TestMethod]
        public void CreateBuildingWithAlreadyInUseNameTest()
        {
            var context = CreateDbContext("CreateBuildingWithAlreadyInUseNameTest");
            var repository = new BuildingRepository(context);
            var building = new Building
            {
                Id = Guid.NewGuid(),
                ManagerId = Guid.NewGuid(),
                Name = "Building 1",
                Address = "Address 1",
                Location = "Location 1",
                ConstructionCompany = "Company 1",
                CommonExpenses = 1000
            };

            context.Set<Building>().Add(building);
            context.SaveChanges();

            Assert.ThrowsException<ValueDuplicatedException>(() => repository.CreateBuilding(building));
        }

        [TestMethod]
        public void CreateBuildingWithSameOwnerEmailTest()
        {
            var context = CreateDbContext("CreateBuildingWithSameOwnerEmailTest");
            var repository = new BuildingRepository(context);
            var building = new Building
            {
                Id = Guid.NewGuid(),
                ManagerId = Guid.NewGuid(),
                Name = "Building 1",
                Address = "Address 1",
                Location = "Location 1",
                ConstructionCompany = "Company 1",
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
            context.Set<Building>().Add(building);
            context.SaveChanges();

            var building2 = new Building
            {
                Id = Guid.NewGuid(),
                ManagerId = Guid.NewGuid(),
                Name = "Building 2",
                Address = "Address 2",
                Location = "Location 2",
                ConstructionCompany = "Company 1",
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
                            LastName = "Oed",
                            Email = "jhon@gmail.com"
                        }
                    }
                }
            };

            Assert.ThrowsException<ValueDuplicatedException>(() => repository.CreateBuilding(building2));
        }

        [TestMethod]
        public void CreateBuildingWithSameLocationAndAddressTest()
        {
            var context = CreateDbContext("CreateBuildingWithSameLocationAndAddressTest");
            var repository = new BuildingRepository(context);
            var building = new Building
            {
                Id = Guid.NewGuid(),
                ManagerId = Guid.NewGuid(),
                Name = "Building 1",
                Address = "Address 1",
                Location = "Location 1",
                ConstructionCompany = "Company 1",
                CommonExpenses = 1000
            };
            context.Set<Building>().Add(building);
            context.SaveChanges();

            var building2 = new Building
            {
                Id = Guid.NewGuid(),
                ManagerId = Guid.NewGuid(),
                Name = "Building 2",
                Address = "Address 1",
                Location = "Location 1",
                ConstructionCompany = "Company 1",
                CommonExpenses = 1000
            };

            Assert.ThrowsException<ValueDuplicatedException>(() => repository.CreateBuilding(building2));
        }

        [TestMethod]
        public void DeleteBuildingTest()
        {
            var context = CreateDbContext("DeleteBuildingTest");
            var repository = new BuildingRepository(context);
            var building = new Building
            {
                Id = Guid.NewGuid(),
                ManagerId = Guid.NewGuid(),
                Name = "Building 1",
                Address = "Address 1",
                Location = "Location 1",
                ConstructionCompany = "Company 1",
                CommonExpenses = 1000
            };
            context.Set<Building>().Add(building);
            context.SaveChanges();

            repository.DeleteBuilding(building.Id);
            var result = context.Set<Building>().Find(building.Id);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteBuildingThatDoesNotExistTest()
        {
            var context = CreateDbContext("DeleteBuildingThatDoesNotExistTest");
            var repository = new BuildingRepository(context);

            Assert.ThrowsException<ValueNotFoundException>(() => repository.DeleteBuilding(Guid.NewGuid()));
        }

        [TestMethod]
        public void GetManagerIdBySessionTokenTest() {             
            var context = CreateDbContext("GetManagerIdBySessionToken");
            var repository = new BuildingRepository(context);
            Guid sessionToken = Guid.NewGuid();
            Guid managerId = Guid.NewGuid();
            UserRepository userRepository = new UserRepository(context);
            Manager manager = new Manager
            {
                Id = managerId,
                Name = "John",
                Lastname = "",
                Email = "test@test.com",
                Password = "Somepass",
                Role = RoleType.MANAGER,
                SessionToken = sessionToken
            };
            userRepository.CreateUser(manager);

            Guid result = repository.GetManagerIdBySessionToken(sessionToken);
        
            Assert.AreEqual(managerId, result);
        }

        [TestMethod]
        public void GetManagerIdBySessionTokenThatDoesNotExistTest()
        {
            var context = CreateDbContext("GetManagerIdBySessionTokenThatDoesNotExist");
            var repository = new BuildingRepository(context);
            Guid sessionToken = Guid.NewGuid();

            Assert.ThrowsException<ValueNotFoundException>(() => repository.GetManagerIdBySessionToken(sessionToken));
        }

        [TestMethod]
        public void UpdateBuildingTest()
        {
            var context = CreateDbContext("UpdateBuildingTest");
            var repository = new BuildingRepository(context);
            Guid buildingId = Guid.NewGuid();
            Guid managerId = Guid.NewGuid();
            var originalBuilding = new Building
            {
                Id = buildingId,
                ManagerId = managerId,
                Name = "Building 1",
                Address = "Address 1",
                Location = "Location 1",
                ConstructionCompany = "Company 1",
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
                        BuildingId = buildingId
                    },
                    new Apartment
                    {
                        Floor = 2,
                        Number = 2,
                        Rooms = 4,
                        Bathrooms = 3,
                        HasTerrace = false,
                        BuildingId = buildingId
                    },
                    new Apartment
                    {
                        Floor = 3,
                        Number = 3,
                        Rooms = 2,
                        Bathrooms = 1,
                        HasTerrace = true,
                        BuildingId = buildingId
                    }
                }
            };
            context.Set<Building>().Add(originalBuilding);

            var buildingUpdated = new Building
            {
                Id = buildingId,
                ManagerId = managerId,
                Name = "Building 2",
                Address = "Address 2",
                Location = "Location 2",
                ConstructionCompany = "Company 2",
                CommonExpenses = 2000,
                Apartments = new List<Apartment>
                {
                    new Apartment
                    {
                        Floor = 1,
                        Number = 3,
                        Rooms = 1,
                        Bathrooms = 1,
                        HasTerrace = false,
                        BuildingId = buildingId
                    },
                    new Apartment
                    {
                        Floor = 1,
                        Number = 2,
                        Rooms = 3,
                        Bathrooms = 2,
                        HasTerrace = true,
                        BuildingId = buildingId
                    }
                }
            };

            repository.UpdateBuilding(buildingUpdated);
            var result = context.Set<Building>().Find(originalBuilding.Id);

            Assert.AreEqual(originalBuilding, result);
        }
    }
}
