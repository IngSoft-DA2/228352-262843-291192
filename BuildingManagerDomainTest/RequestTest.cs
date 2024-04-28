using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildingManagerDomain.Entities;
using System.Diagnostics.CodeAnalysis;
using BuildingManagerDomain.Enums;
using BuildingManagerModels.Inner;
using BuildingManagerModels.CustomExceptions;

namespace BuildingManagerDomainTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class RequestTest
    {
        [TestMethod]
        public void RequestIdTest()
        {
            Guid requestId = Guid.NewGuid();
            Request request = new() { Id = requestId };
            Assert.AreEqual(requestId, request.Id);
        }

        [TestMethod]
        public void RequestDescriptionTest()
        {
            string description = "some description";
            Request request = new() { Description = description };
            Assert.AreEqual(description, request.Description);
        }

        [TestMethod]
        public void RequestStateTest()
        {
            RequestState state = RequestState.OPEN;
            Request request = new() { State = state };
            Assert.AreEqual(state, request.State);
        }

        [TestMethod]
        public void RequestCategoryTest()
        {
            Guid categoryId = new();
            Request request = new() { CategoryId = categoryId };
            Assert.AreEqual(categoryId, request.CategoryId);
        }

        [TestMethod]
        public void RequestMaintainerIdTest()
        {
            Guid maintainerId = new();
            Request request = new() { MaintainerId = maintainerId };
            Assert.AreEqual(maintainerId, request.MaintainerId);
        }

        [TestMethod]
        public void RequestBuildingIdTest()
        {
            Guid buildingId = new();
            Request request = new() { BuildingId = buildingId };
            Assert.AreEqual(buildingId, request.BuildingId);
        }

        [TestMethod]
        public void RequestApartmentFloorTest()
        {
            int apartmentFloor = new();
            Request request = new() { ApartmentFloor = apartmentFloor };
            Assert.AreEqual(apartmentFloor, request.ApartmentFloor);
        }

        [TestMethod]
        public void RequestApartmentNumberTest()
        {
            int apartmentNumber = new();
            Request request = new() { ApartmentNumber = apartmentNumber };
            Assert.AreEqual(apartmentNumber, request.ApartmentNumber);
        }

        [TestMethod]
        public void RequestWithoutDescription()
        {
            Exception exception = null;
            try
            {
                var requestWithoutDescription = new CreateRequestRequest()
                {
                    CategoryId = new Guid(),
                };
                requestWithoutDescription.Validate();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsInstanceOfType(exception, typeof(InvalidArgumentException));
        }

        [TestMethod]
        public void RequestWithoutCategoryIdTest()
        {
            Exception exception = null;
            try
            {
                var requestWithoutCategoryId = new CreateRequestRequest()
                {
                    Description = "some description",
                };
                requestWithoutCategoryId.Validate();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsInstanceOfType(exception, typeof(InvalidArgumentException));
        }
    }
}