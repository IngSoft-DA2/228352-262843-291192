using BuildingManagerDomain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuildingManagerDomainTest
{
    [TestClass]
    public class BuildingsReportDataTest
    {
        [TestMethod]
        public void BuildingsReportDataOpenRequestsTest()
        {
            int openRequests = 5;
            int closeRequests = 2;
            int inProgressRequests = 1;
            Guid buildingId = Guid.NewGuid();

            BuildingsReportData data = new(openRequests, closeRequests, inProgressRequests, buildingId);

            Assert.AreEqual(openRequests, data.OpenRequests);
        }

        [TestMethod]
        public void BuildingsReportDataCloseRequestsTest()
        {
            int openRequests = 5;
            int closeRequests = 2;
            int inProgressRequests = 1;
            Guid buildingId = Guid.NewGuid();

            BuildingsReportData data = new(openRequests, closeRequests, inProgressRequests, buildingId);

            Assert.AreEqual(closeRequests, data.CloseRequests);
        }

        [TestMethod]
        public void BuildingsReportDataInProgressRequestsTest()
        {
            int openRequests = 5;
            int closeRequests = 2;
            int inProgressRequests = 1;
            Guid buildingId = Guid.NewGuid();

            BuildingsReportData data = new(openRequests, closeRequests, inProgressRequests, buildingId);

            Assert.AreEqual(inProgressRequests, data.InProgressRequests);
        }

        [TestMethod]
        public void BuildingsReportDataBuildingIdTest()
        {
            int openRequests = 5;
            int closeRequests = 2;
            int inProgressRequests = 1;
            Guid buildingId = Guid.NewGuid();

            BuildingsReportData data = new(openRequests, closeRequests, inProgressRequests, buildingId);

            Assert.AreEqual(buildingId, data.BuildingId);
        }

        [TestMethod]
        public void Equals_NullObject_ReturnsFalse()
        {
            BuildingsReportData data = new BuildingsReportData();

            bool result = data.Equals(null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_DifferentTypeObject_ReturnsFalse()
        {
            BuildingsReportData data = new BuildingsReportData();
            object other = new object();

            bool result = data.Equals(other);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_SameObject_ReturnsTrue()
        {
            BuildingsReportData data = new BuildingsReportData();

            bool result = data.Equals(data);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_AtLeastOneFieldDifferent_ReturnsFalse()
        {
            BuildingsReportData data1 = new BuildingsReportData(1, 1, 1, new Guid());
            BuildingsReportData data2 = new BuildingsReportData(2, 1, 1, new Guid());

            bool result = data1.Equals(data2);

            Assert.IsFalse(result);
        }
    }
}