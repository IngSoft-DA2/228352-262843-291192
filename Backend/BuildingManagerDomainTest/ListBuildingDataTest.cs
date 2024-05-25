using BuildingManagerDomain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuildingManagerDomainTest
{
    [TestClass]
    public class ListBuildingDataTest
    {
        [TestMethod]
        public void ListBuildingDataNameTest()
        {
            string name = "test";

            ListBuildingData data = new(name);

            Assert.AreEqual(name, data.Name);
        }

        [TestMethod]
        public void Equals_NullObject_ReturnsFalse()
        {
            ListBuildingData data = new ListBuildingData();

            bool result = data.Equals(null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_DifferentTypeObject_ReturnsFalse()
        {
            ListBuildingData data = new ListBuildingData();
            object other = new object();

            bool result = data.Equals(other);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_SameObject_ReturnsTrue()
        {
            ListBuildingData data = new ListBuildingData();

            bool result = data.Equals(data);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_AtLeastOneFieldDifferent_ReturnsFalse()
        {
            ListBuildingData data1 = new ListBuildingData("test1");
            ListBuildingData data2 = new ListBuildingData("test2");

            bool result = data1.Equals(data2);

            Assert.IsFalse(result);
        }
    }
}
