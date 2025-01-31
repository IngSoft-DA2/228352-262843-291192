﻿using BuildingManagerApi.Controllers;
using BuildingManagerDomain.Entities;
using BuildingManagerDomain.Enums;
using BuildingManagerILogic;
using BuildingManagerModels.Outer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Diagnostics.CodeAnalysis;

namespace BuildingManagerApiTest.Controllers
{
    [TestClass]
    public class CategoriesReportControllerTest
    {
        private List<ReportData> _data;
        private CategoriesReportResponse _reportResponse;

        [TestInitialize]
        public void Initialize()
        {
            _data = [new ReportData(3, 2, 1, 7, "John", new Guid(), "Electricista", null, null, null, null)];
            _reportResponse = new CategoriesReportResponse(_data);
        }

        [TestMethod]
        public void GetCategoriesReport_Ok()
        {
            var mockReportLogic = new Mock<IReportLogic>(MockBehavior.Strict);
            mockReportLogic.Setup(x => x.GetReport(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<ReportType>())).Returns(_data);
            var categoriesReportController = new CategoriesReportController(mockReportLogic.Object);
            OkObjectResult expected = new OkObjectResult(new CategoriesReportResponse(_data));
            CategoriesReportResponse expectedObject = expected.Value as CategoriesReportResponse;

            OkObjectResult result = categoriesReportController.GetReport(new Guid(), "Electricista") as OkObjectResult;
            CategoriesReportResponse resultObject = result.Value as CategoriesReportResponse;

            mockReportLogic.VerifyAll();
            Assert.AreEqual(result.StatusCode, expected.StatusCode);
            Assert.AreEqual(expectedObject, resultObject);
        }

        [TestMethod]
        public void Equals_NullObject_ReturnsFalse()
        {
            CategoriesReportResponse response = new CategoriesReportResponse([new ReportData()]);

            bool result = response.Equals(null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_DifferentTypeObject_ReturnsFalse()
        {
            CategoriesReportResponse response = new CategoriesReportResponse([new ReportData()]);
            object other = new object();

            bool result = response.Equals(other);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_SameObject_ReturnsTrue()
        {
            CategoriesReportResponse response = new CategoriesReportResponse([new ReportData()]);

            bool result = response.Equals(response);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_AtLeastOneFieldDifferent_ReturnsFalse()
        {
            List<ReportData> data1 = [new ReportData(3, 2, 1, 7, "John", new Guid(), "Electricista", null, null, null, null)];
            List<ReportData> data2 = [new ReportData(3, 2, 1, 7, "John", new Guid(), "Plomero", null, null, null, null)];
            CategoriesReportResponse response1 = new CategoriesReportResponse(data1);
            CategoriesReportResponse response2 = new CategoriesReportResponse(data2);

            bool result = response1.Equals(response2);

            Assert.IsFalse(result);
        }
    }
}
