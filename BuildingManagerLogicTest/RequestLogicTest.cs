using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BuildingManagerDomain.Entities;
using BuildingManagerIDataAccess;
using BuildingManagerLogic;
using BuildingManagerILogic.Exceptions;
using BuildingManagerIDataAccess.Exceptions;

namespace BuildingManagerLogicTest
{
    [TestClass]
    public class RequestLogicTest
    {
        private Request _request;

        [TestInitialize]
        public void Initialize()
        {
            _request = new Request()
            {
                Id = new Guid(),
                Description = "description",
                CategoryId = new Guid("11111111-1111-1111-1111-111111111111"),
                BuildingId = new Guid("11111111-1111-1111-1111-111111111111"),
                ApartmentFloor = 1,
                ApartmentNumber = 1,
            };
        }

        [TestMethod]
        public void CreateRequestSuccessfully()
        {
            var requestRepositoryMock = new Mock<IRequestRepository>(MockBehavior.Strict);
            requestRepositoryMock.Setup(x => x.CreateRequest(It.IsAny<Request>())).Returns(_request);
            var requestLogic = new RequestLogic(requestRepositoryMock.Object);

            var result = requestLogic.CreateRequest(_request);

            requestRepositoryMock.VerifyAll();
            Assert.AreEqual(_request, result);
        }

        [TestMethod]
        public void CreateRequestWithInvalidCategoryIdOrApartmentIdTest()
        {
            var requestRepositoryMock = new Mock<IRequestRepository>(MockBehavior.Strict);
            requestRepositoryMock.Setup(x => x.CreateRequest(It.IsAny<Request>())).Throws(new ValueNotFoundException(""));
            var requestLogic = new RequestLogic(requestRepositoryMock.Object);
            Exception exception = null;

            try
            {
                requestLogic.CreateRequest(_request);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            requestRepositoryMock.VerifyAll();
            Assert.IsInstanceOfType(exception, typeof(NotFoundException));
        }

        [TestMethod]
        public void GetRequestsSuccessfullyTest()
        {
            List<Request> requests = new List<Request> { _request };
            var requestRepositoryMock = new Mock<IRequestRepository>(MockBehavior.Strict);
            requestRepositoryMock.Setup(x => x.GetRequests()).Returns(requests);
            var requestLogic = new RequestLogic(requestRepositoryMock.Object);

            var result = requestLogic.GetRequests();

            requestRepositoryMock.VerifyAll();
            Assert.AreEqual(requests, result);
        }

        [TestMethod]
        public void AssignStaffSuccessfullyTest()
        {
            var requestRepositoryMock = new Mock<IRequestRepository>(MockBehavior.Strict);
            requestRepositoryMock.Setup(x => x.AssignStaff(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns(_request);
            var requestLogic = new RequestLogic(requestRepositoryMock.Object);

            var result = requestLogic.AssignStaff(_request.Id, new Guid());

            requestRepositoryMock.VerifyAll();
            Assert.AreEqual(_request, result);
        }

        [TestMethod]
        public void AssignStaffWithInvalidRequestIdTest()
        {
            var requestRepositoryMock = new Mock<IRequestRepository>(MockBehavior.Strict);
            requestRepositoryMock.Setup(x => x.AssignStaff(It.IsAny<Guid>(), It.IsAny<Guid>())).Throws(new ValueNotFoundException(""));
            var requestLogic = new RequestLogic(requestRepositoryMock.Object);
            Exception exception = null;

            try
            {
                requestLogic.AssignStaff(_request.Id, new Guid());
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            requestRepositoryMock.VerifyAll();
            Assert.IsInstanceOfType(exception, typeof(NotFoundException));
        }
    }
}