using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildingManagerDomain.Entities;
using System.Diagnostics.CodeAnalysis;
using BuildingManagerDomain.Enums;

namespace BuildingManagerDomainTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ConstructionCompanyAdminTest
    {
        [TestMethod]
        public void ConstructionCompanyAdminIdTest()
        {
            Guid constructionCompanyAdminId = Guid.NewGuid();
            ConstructionCompanyAdmin constructionCompanyAdmin = new ConstructionCompanyAdmin { Id = constructionCompanyAdminId };
            Assert.AreEqual(constructionCompanyAdminId, constructionCompanyAdmin.Id);
        }

        [TestMethod]
        public void ConstructionCompanyAdminNameTest()
        {
            string constructionCompanyAdminName = "John";
            ConstructionCompanyAdmin constructionCompanyAdmin = new ConstructionCompanyAdmin { Name = constructionCompanyAdminName };
            Assert.AreEqual(constructionCompanyAdminName, constructionCompanyAdmin.Name);
        }

        [TestMethod]
        public void ConstructionCompanyAdminRoleTest()
        {
            RoleType role = RoleType.CONSTRUCTIONCOMPANYADMIN;
            ConstructionCompanyAdmin constructionCompanyAdmin = new() { };
            Assert.AreEqual(role, constructionCompanyAdmin.Role);
        }

        [TestMethod]
        public void ConstructionCompanyAdminEmailTest()
        {
            string email = "abc@example.com";
            ConstructionCompanyAdmin constructionCompanyAdmin = new() { Email = email };
            Assert.AreEqual(email, constructionCompanyAdmin.Email);
        }

        [TestMethod]
        public void ConstructionCompanyAdminPasswordTest()
        {
            string password = "pass123";
            ConstructionCompanyAdmin constructionCompanyAdmin = new() { Password = password };
            Assert.AreEqual(password, constructionCompanyAdmin.Password);
        }

         [TestMethod]
        public void ConstructionCompanyAdminLastnameTest()
        {
            string lastname = "";
            ConstructionCompanyAdmin constructionCompanyAdmin = new() { };
            Assert.AreEqual(lastname, constructionCompanyAdmin.Lastname);
        }

        [TestMethod]
        public void ConstructionCompanyAdminSessionTokenTest()
        {
            Guid sessionToken = new();
            ConstructionCompanyAdmin constructionCompanyAdmin = new() { SessionToken = sessionToken };
            Assert.AreEqual(sessionToken, constructionCompanyAdmin.SessionToken);
        }
    }
}