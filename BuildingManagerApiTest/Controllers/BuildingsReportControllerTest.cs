using BuildingManagerApi.Controllers;
using BuildingManagerDomain.Entities;
using BuildingManagerDomain.Enums;
using BuildingManagerILogic;
using BuildingManagerLogic;
using BuildingManagerModels.Inner;
using BuildingManagerModels.Outer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BuildingManagerApiTest.Controllers
{
    [TestClass]
    public class BuildingsReportControllerTest
    {
        private List<MaintenanceData> _datas;
        private BuildingsReportResponse _reportResponse;

        [TestInitialize]
        public void Initialize()
        {
            _datas = [new MaintenanceData(3, 2, 1, 7, "", new Guid())];
            _reportResponse = new BuildingsReportResponse(_datas);
        }
        [TestMethod]
        public void GetBuildingsReport_Ok()
        {
            var mockReportLogic = new Mock<IReportLogic>(MockBehavior.Strict);
            mockReportLogic.Setup(x => x.GetReport(It.IsAny<Guid?>(), It.IsAny<string>(), It.IsAny<string>())).Returns(_datas);
            var buildingsReportController = new BuildingsReportController(mockReportLogic.Object);
            OkObjectResult expected = new OkObjectResult(new BuildingsReportResponse(_datas));
            BuildingsReportResponse expectedObject = expected.Value as BuildingsReportResponse;

            OkObjectResult result = buildingsReportController.GetReport(null) as OkObjectResult;
            BuildingsReportResponse resultObject = result.Value as BuildingsReportResponse;

            mockReportLogic.VerifyAll();
            Assert.AreEqual(result.StatusCode, expected.StatusCode);
            Assert.AreEqual(expectedObject, resultObject);
        }

        [TestMethod]
        public void Equals_NullObject_ReturnsFalse()
        {
            BuildingsReportResponse response = new BuildingsReportResponse([new MaintenanceData()]);

            bool result = response.Equals(null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_DifferentTypeObject_ReturnsFalse()
        {
            BuildingsReportResponse response = new BuildingsReportResponse([new MaintenanceData()]);
            object other = new object();

            bool result = response.Equals(other);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_SameObject_ReturnsTrue()
        {
            BuildingsReportResponse response = new BuildingsReportResponse([new MaintenanceData()]);

            bool result = response.Equals(response);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_AtLeastOneFieldDifferent_ReturnsFalse()
        {
            List<MaintenanceData> datas1 = [new MaintenanceData(3, 2, 1, 7, "John", new Guid())];
            List<MaintenanceData> datas2 = [new MaintenanceData(3, 3, 1, 7, "John", new Guid())];

            BuildingsReportResponse response1 = new BuildingsReportResponse(datas1);
            BuildingsReportResponse response2 = new BuildingsReportResponse(datas2);

            bool result = response1.Equals(response2);

            Assert.IsFalse(result);
        }
    }
}