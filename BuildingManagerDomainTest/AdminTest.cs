using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BuildingManagerDomain.Entities;

namespace BuildingManagerDomainTest
{
    [TestClass]
    public class AdminTest
    {
        [TestMethod]
        public void AdminIdTest()
        {
            Guid adminId = Guid.NewGuid();
            Admin admin = new Admin { Id = adminId };
            Assert.AreEqual(adminId, admin.Id);
        }

        [TestMethod]
        public void AdminNameTest()
        {
            string name = "John";
            Admin admin = new Admin { Name = name };
            Assert.AreEqual(name, admin.Name);
        }
    }
}