using JsonImporter;

namespace JsonImporterTest
{
    [TestClass]
    public class JsonBuildingTest
    {
        [TestMethod]
        public void BuildingNameTest()
        {
            string name = "some building name";
            JsonBuilding building = new JsonBuilding { Name = name };
            Assert.AreEqual(name, building.Name);
        }

        [TestMethod]
        public void BuildingAddressTest()
        {
            string address = "some address";
            JsonBuilding building = new JsonBuilding { Address = address };
            Assert.AreEqual(address, building.Address);
        }

        [TestMethod]
        public void BuildingManagerTest()
        {
            string manager = "some manager";
            JsonBuilding building = new JsonBuilding { Manager = manager };
            Assert.AreEqual(manager, building.Manager);
        }
    }
}