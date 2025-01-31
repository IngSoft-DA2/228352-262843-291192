using BuildingManagerDataAccess.Context;
using BuildingManagerDataAccess.Repositories;
using BuildingManagerDomain.Entities;
using BuildingManagerIDataAccess.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BuildingManagerDataAccessTest
{
    [TestClass]
    public class ConstructionCompanyRepositoryTest
    {
        [TestMethod]
        public void CreateConstructionCompanyTest()
        {
            var context = CreateDbContext("CreateConstructionCompanyTest");
            var repository = new ConstructionCompanyRepository(context);
            var constructionCompany = new ConstructionCompany
            {
                Id = Guid.NewGuid(),
                Name = "company 1"
            };
            var sessionToken = Guid.NewGuid();

            repository.CreateConstructionCompany(constructionCompany, sessionToken);
            var companyResult = context.Set<ConstructionCompany>().Find(constructionCompany.Id);
            var companyAdminAssociationResult = context.Set<CompanyAdminAssociation>().Find(sessionToken, constructionCompany.Id);

            Assert.AreEqual(constructionCompany, companyResult);
            Assert.AreEqual(constructionCompany.Id, companyAdminAssociationResult.ConstructionCompanyId);
            Assert.AreEqual(sessionToken, companyAdminAssociationResult.ConstructionCompanyAdminId);
        }

        [TestMethod]
        public void GetConstructionCompanyTest()
        {
            var context = CreateDbContext("GetConstructionCompanyTest");
            var repository = new ConstructionCompanyRepository(context);
            var constructionCompany = new ConstructionCompany
            {
                Id = Guid.NewGuid(),
                Name = "company 1"
            };
            var userId = Guid.NewGuid();
            repository.CreateConstructionCompany(constructionCompany, userId);

            var result = repository.GetConstructionCompany(constructionCompany.Id);

            Assert.AreEqual(constructionCompany, result);
        }

        [TestMethod]
        public void CreateConstructionCompanyWithDuplicatedNameTest()
        {
            var context = CreateDbContext("CreateConstructionCompanyWithDuplicatedNameTest");
            var repository = new ConstructionCompanyRepository(context);
            var userId = Guid.NewGuid();
            var constructionCompany = new ConstructionCompany
            {
                Id = Guid.NewGuid(),
                Name = "company 1"
            };
            repository.CreateConstructionCompany(constructionCompany, userId);

            Exception exception = null;
            try
            {
                repository.CreateConstructionCompany(constructionCompany, userId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsInstanceOfType(exception, typeof(ValueDuplicatedException));
        }

        [TestMethod]
        public void CreateConstructionCompanyWithDuplicatedUserTest()
        {
            var context = CreateDbContext("CreateConstructionCompanyWithDuplicatedUserTest");
            var repository = new ConstructionCompanyRepository(context);
            var userId = Guid.NewGuid();
            var constructionCompany1 = new ConstructionCompany
            {
                Id = Guid.NewGuid(),
                Name = "company 1"
            };
            repository.CreateConstructionCompany(constructionCompany1, userId);
            var constructionCompany2 = new ConstructionCompany
            {
                Id = Guid.NewGuid(),
                Name = "company 2"
            };

            Exception exception = null;
            try
            {
                repository.CreateConstructionCompany(constructionCompany2, userId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsInstanceOfType(exception, typeof(ValueDuplicatedException));
        }

        [TestMethod]
        public void ModifyConstructionCompanyNameTest()
        {
            var context = CreateDbContext("ModifyConstructionCompanyNameTest");
            var repository = new ConstructionCompanyRepository(context);
            var userId = Guid.NewGuid();
            var constructionCompany = new ConstructionCompany
            {
                Id = Guid.NewGuid(),
                Name = "company 1"
            };
            repository.CreateConstructionCompany(constructionCompany, userId);

            var result = repository.ModifyConstructionCompanyName(constructionCompany.Id, "company 2", userId);

            Assert.AreEqual(constructionCompany, result);
        }

        [TestMethod]
        public void ModifyConstructionCompanyWithDuplicatedNameTest()
        {
            var context = CreateDbContext("ModifyConstructionCompanyWithDuplicatedNameTest");
            var repository = new ConstructionCompanyRepository(context);
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();
            var constructionCompany1 = new ConstructionCompany
            {
                Id = Guid.NewGuid(),
                Name = "company 1"
            };
            var constructionCompany2 = new ConstructionCompany
            {
                Id = Guid.NewGuid(),
                Name = "company 2"
            };
            repository.CreateConstructionCompany(constructionCompany1, userId1);
            repository.CreateConstructionCompany(constructionCompany2, userId2);

            Exception exception = null;
            try
            {
                repository.ModifyConstructionCompanyName(constructionCompany1.Id, "company 2", userId1);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsInstanceOfType(exception, typeof(ValueDuplicatedException));
        }

        [TestMethod]
        public void ModifyConstructionCompanyWithInvalidIdTest()
        {
            var context = CreateDbContext("ModifyConstructionCompanyWithInvalidIdTest");
            var repository = new ConstructionCompanyRepository(context);

            Exception exception = null;
            try
            {
                repository.ModifyConstructionCompanyName(Guid.NewGuid(), "company 2", Guid.NewGuid());
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsInstanceOfType(exception, typeof(ValueNotFoundException));
        }

        [TestMethod]
        public void ModifyConstructionCompanyWithInvalidUserIdAssociationTest()
        {
            var context = CreateDbContext("ModifyConstructionCompanyWithInvalidUserIdAssociationTest");
            var repository = new ConstructionCompanyRepository(context);
            var constructionCompany = new ConstructionCompany
            {
                Id = Guid.NewGuid(),
                Name = "company 1"
            };
            var userId1 = Guid.NewGuid();
            repository.CreateConstructionCompany(constructionCompany, userId1);
            var userId2 = Guid.NewGuid();

            Exception exception = null;
            try
            {
                repository.ModifyConstructionCompanyName(constructionCompany.Id, "company 2", userId2);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsInstanceOfType(exception, typeof(ValueNotFoundException));
        }

        [TestMethod]
        public void GetConstructionCompanyIdFromUserIdTest()
        {
            var context = CreateDbContext("GetConstructionCompanyIdFromUserIdTest");
            var repository = new ConstructionCompanyRepository(context);
            var userRepository = new UserRepository(context);
            var constructionCompany = new ConstructionCompany
            {
                Id = Guid.NewGuid(),
                Name = "company 1"
            };
            ConstructionCompanyAdmin user = new()
            {
                Name = "name",
                Id = Guid.NewGuid(),
                Email = "email",
                Password = "password"
            };
            userRepository.CreateUser(user);
            repository.CreateConstructionCompany(constructionCompany, user.Id);

            var result = repository.GetCompanyIdFromUserId(user.Id);

            Assert.AreEqual(constructionCompany.Id, result);
        }

        [TestMethod]
        public void GetConstructionCompanyIdFromUserIdWithInvalidUserIdAssociationTest()
        {
            var context = CreateDbContext("GetConstructionCompanyIdFromUserIdWithInvalidUserIdAssociationTest");
            var repository = new ConstructionCompanyRepository(context);
            var userId = Guid.NewGuid();

            Exception exception = null;
            try
            {
                repository.GetCompanyIdFromUserId(userId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsInstanceOfType(exception, typeof(ValueNotFoundException));
        }

        [TestMethod]
        public void AssociateCompanyToAdminTest()
        {
            var context = CreateDbContext("AssociateCompanyToAdminTest");
            var repository = new ConstructionCompanyRepository(context);
            var repositoryUser = new UserRepository(context);
            var userId = Guid.NewGuid();
            var constructionCompany = new ConstructionCompany
            {
                Id = Guid.NewGuid(),
                Name = "company 1"
            };
            repositoryUser.CreateUser(new ConstructionCompanyAdmin { Name = "user1", Id = userId, Email = "email", Password = "password" });
            repository.CreateConstructionCompany(constructionCompany, userId);
            var userId2 = Guid.NewGuid();
            repositoryUser.CreateUser(new ConstructionCompanyAdmin { Name = "user2", Id = userId2, Email = "email2", Password = "password2" });

            repository.AssociateCompanyToUser(userId2, constructionCompany.Id);
            var companyAdminAssociationResult = context.Set<CompanyAdminAssociation>().Find(userId2, constructionCompany.Id);

            Assert.AreEqual(constructionCompany.Id, companyAdminAssociationResult.ConstructionCompanyId);
            Assert.AreEqual(constructionCompany.Id, companyAdminAssociationResult.ConstructionCompanyId);
            Assert.AreEqual(userId2, companyAdminAssociationResult.ConstructionCompanyAdminId);
        }

        [TestMethod]
        public void AssociateCompanyToAdminWithDuplicatedUserTest()
        {
            var context = CreateDbContext("AssociateCompanyToAdminWithDuplicatedUserTest");
            var repository = new ConstructionCompanyRepository(context);
            var userId = Guid.NewGuid();
            var constructionCompany1 = new ConstructionCompany
            {
                Id = Guid.NewGuid(),
                Name = "company 1"
            };
            repository.CreateConstructionCompany(constructionCompany1, userId);

            Exception exception = null;
            try
            {
                repository.AssociateCompanyToUser(userId, constructionCompany1.Id);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsInstanceOfType(exception, typeof(ValueDuplicatedException));
        }

        [TestMethod]
        public void AssociateCompanyToAdminWithInvalidCompanyIdTest()
        {
            var context = CreateDbContext("AssociateCompanyToAdminWithInvalidCompanyIdTest");
            var repository = new ConstructionCompanyRepository(context);
            var userId = Guid.NewGuid();

            Exception exception = null;
            try
            {
                repository.AssociateCompanyToUser(userId, Guid.NewGuid());
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsInstanceOfType(exception, typeof(ValueNotFoundException));
        }

        [TestMethod]
        public void AssociateCompanyToAdminWithInvalidUserIdTest()
        {
            var context = CreateDbContext("AssociateCompanyToAdminWithInvalidUserIdTest");
            var repository = new ConstructionCompanyRepository(context);
            var userId = Guid.NewGuid();
            var constructionCompany1 = new ConstructionCompany
            {
                Id = Guid.NewGuid(),
                Name = "company 1"
            };
            repository.CreateConstructionCompany(constructionCompany1, userId);

            Exception exception = null;
            try
            {
                repository.AssociateCompanyToUser(Guid.NewGuid(), constructionCompany1.Id);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsInstanceOfType(exception, typeof(ValueNotFoundException));
        }

        [TestMethod]
        public void IsUserAssociatedToCompanyTest()
        {
            var context = CreateDbContext("IsUserAssociatedToCompanyTest");
            var repository = new ConstructionCompanyRepository(context);
            var userRepository = new UserRepository(context);
            var constructionCompany = new ConstructionCompany
            {
                Id = Guid.NewGuid(),
                Name = "company 1"
            };
            ConstructionCompanyAdmin user = new()
            {
                Name = "name",
                Id = Guid.NewGuid(),
                Email = "email",
                Password = "password"
            };
            userRepository.CreateUser(user);
            repository.CreateConstructionCompany(constructionCompany, user.Id);

            var result = repository.IsUserAssociatedToCompany(user.Id, constructionCompany.Id);

            Assert.IsTrue(result);
        }

        private DbContext CreateDbContext(string name)
        {
            var options = new DbContextOptionsBuilder<BuildingManagerContext>()
                .UseInMemoryDatabase(name)
                .Options;
            return new BuildingManagerContext(options);
        }

        [TestMethod]
        public void GetCompanyBuildingsTest()
        {
            var context = CreateDbContext("GetCompanyBuildingsTest");
            var repository = new ConstructionCompanyRepository(context);
            var constructionCompany = new ConstructionCompany
            {
                Id = Guid.NewGuid(),
                Name = "company 1"
            };
            var building = new Building
            {
                Id = Guid.NewGuid(),
                Name = "building 1",
                Address = "address 1",
                Location = "location 1",
                ConstructionCompanyId = constructionCompany.Id
            };
            var building2 = new Building
            {
                Id = Guid.NewGuid(),
                Name = "building 2",
                Address = "address 2",
                Location = "location 2",
                ConstructionCompanyId = constructionCompany.Id
            };
            context.Set<ConstructionCompany>().Add(constructionCompany);
            context.Set<Building>().Add(building);
            context.Set<Building>().Add(building2);
            context.SaveChanges();

            var result = repository.GetCompanyBuildings(constructionCompany.Id);

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(building.Id, result[0].Id);
            Assert.AreEqual(building.Name, result[0].Name);
            Assert.AreEqual(building.Address, result[0].Address);
            Assert.AreEqual(building2.Id, result[1].Id);
            Assert.AreEqual(building2.Name, result[1].Name);
            Assert.AreEqual(building2.Address, result[1].Address);
        }
    }
}
