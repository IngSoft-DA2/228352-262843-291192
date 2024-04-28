using BuildingManagerApi.Controllers;
using BuildingManagerDomain.Entities;
using BuildingManagerDomain.Enums;
using BuildingManagerILogic;
using BuildingManagerModels.Inner;
using BuildingManagerModels.Outer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BuildingManagerApiTest.Controllers
{
    [TestClass]
    public class RequestControllerTest
    {
        private Request _request;
        private CreateRequestRequest _createRequestRequest;
        private RequestResponse _requestResponse;

        [TestInitialize]
        public void Initialize()
        {
            _request = new Request
            {
                Id = new Guid("11111111-1111-1111-1111-111111111111"),
                Description = "description",
                ApartmentId = new Guid("11111111-1111-1111-1111-111111111111"),
                CategoryId = new Guid("11111111-1111-1111-1111-111111111111"),
            };
            _createRequestRequest = new CreateRequestRequest
            {
                Description = _request.Description,
                ApartmentId = _request.ApartmentId,
                CategoryId = _request.CategoryId,
            };
            _requestResponse = new RequestResponse(_request);

        }
        [TestMethod]
        public void CreateRequest_Ok()
        {
            var mockRequestLogic = new Mock<IRequestLogic>(MockBehavior.Strict);
            mockRequestLogic.Setup(x => x.CreateRequest(It.IsAny<Request>())).Returns(_request);
            var requestController = new RequestController(mockRequestLogic.Object);

            var result = requestController.CreateRequest(_createRequestRequest);
            var createdAtActionResult = result as CreatedAtActionResult;
            var content = createdAtActionResult.Value as RequestResponse;

            mockRequestLogic.VerifyAll();
            Assert.AreEqual(_requestResponse, content);
            Assert.AreEqual(content.State, RequestState.OPEN);
        }

        [TestMethod]
        public void Equals_NullObject_ReturnsFalse()
        {
            RequestResponse response = new RequestResponse(new Request());

            bool result = response.Equals(null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_DifferentTypeObject_ReturnsFalse()
        {
            RequestResponse response = new RequestResponse(new Request());
            object other = new object();

            bool result = response.Equals(other);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_SameObject_ReturnsTrue()
        {
            RequestResponse response = new RequestResponse(new Request());

            bool result = response.Equals(response);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_AtLeastOneFieldDifferent_ReturnsFalse()
        {
            Request request1 = new Request
            {
                Id = new Guid("11111111-1111-1111-1111-111111111111"),
                Description = "description",
                ApartmentId = new Guid("11111111-1111-1111-1111-111111111111"),
                CategoryId = new Guid("11111111-1111-1111-1111-111111111111"),
                State = RequestState.OPEN
            };

            Request request2 = new Request
            {
                Id = new Guid("11111111-1111-1111-1111-111111111111"),
                Description = "different description",
                ApartmentId = new Guid("11111111-1111-1111-1111-111111111111"),
                CategoryId = new Guid("11111111-1111-1111-1111-111111111111"),
                State = RequestState.OPEN
            };

            RequestResponse response1 = new RequestResponse(request1);
            RequestResponse response2 = new RequestResponse(request2);

            bool result = response1.Equals(response2);

            Assert.IsFalse(result);
        }
    }
}