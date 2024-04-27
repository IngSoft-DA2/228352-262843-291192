﻿using BuildingManagerDomain.Entities;
using BuildingManagerIDataAccess;
using BuildingManagerIDataAccess.Exceptions;
using BuildingManagerILogic.Exceptions;
using BuildingManagerLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Diagnostics.CodeAnalysis;

namespace BuildingManagerLogicTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]

    public class BuildingLogicTest
    {
        private Building _building;

        [TestInitialize]
        public void Initialize()
        {
            _building = new Building()
            {
                Id = new Guid(),
                ManagerId = new Guid(),
                Name = "Building 1",
                Address = "Address",
                Location = "City",
                ConstructionCompany = "Company",
                CommonExpenses = 1000
            };
        }

        [TestMethod]
        public void CreateBuildingSuccessfully()
        {
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            buildingRespositoryMock.Setup(x => x.CreateBuilding(It.IsAny<Building>())).Returns(_building);
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object);

            var result = buildingLogic.CreateBuilding(_building);

            buildingRespositoryMock.VerifyAll();
            Assert.AreEqual(_building, result);

        }

        [TestMethod]
        public void CreateBuildingWithAlreadyInUseName()
        {
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            buildingRespositoryMock.Setup(x => x.CreateBuilding(It.IsAny<Building>())).Throws(new ValueDuplicatedException(""));
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object);
            Exception exception = null;
            try
            {
                buildingLogic.CreateBuilding(_building);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(DuplicatedValueException));
        }

        [TestMethod]
        public void CreateBuildingWithApartmentWithSameFloorAndNumberTest() {             
            var buildingRespositoryMock = new Mock<IBuildingRepository>(MockBehavior.Strict);
            buildingRespositoryMock.Setup(x => x.CreateBuilding(It.IsAny<Building>())).Throws(new ValueDuplicatedException(""));
            var buildingLogic = new BuildingLogic(buildingRespositoryMock.Object);
            Exception exception = null;
            try
            {
                buildingLogic.CreateBuilding(_building);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(DuplicatedValueException));
        }
    }
}
