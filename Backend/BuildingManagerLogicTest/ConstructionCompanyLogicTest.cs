using BuildingManagerDomain.Entities;
using BuildingManagerIDataAccess;
using BuildingManagerIDataAccess.Exceptions;
using BuildingManagerILogic.Exceptions;
using BuildingManagerLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Diagnostics.CodeAnalysis;

namespace BuildingManagerLogicTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ConstructionCompanyLogicTest
    {
        [TestMethod]
        public void CreateConstructionCompanySuccessfully()
        {
            var userId = Guid.NewGuid();
            var constructionCompany = new ConstructionCompany
            {
                Id = new Guid(),
                Name = "company"
            };
            var constructionCompanyRepositoryMock = new Mock<IConstructionCompanyRepository>(MockBehavior.Strict);
            var userRepositoryMock = new Mock<IUserRepository>(MockBehavior.Strict);
            constructionCompanyRepositoryMock.Setup(x => x.CreateConstructionCompany(It.IsAny<ConstructionCompany>(), It.IsAny<Guid>())).Returns(constructionCompany);
            userRepositoryMock.Setup(x => x.GetUserIdFromSessionToken(It.IsAny<Guid>())).Returns(userId);
            var constructionCompanyLogic = new ConstructionCompanyLogic(constructionCompanyRepositoryMock.Object, userRepositoryMock.Object);

            var result = constructionCompanyLogic.CreateConstructionCompany(constructionCompany, Guid.NewGuid());

            constructionCompanyRepositoryMock.VerifyAll();
            Assert.AreEqual(constructionCompany, result);
        }

        [TestMethod]
        public void CreateConstructionCompanyDuplicatedName()
        {
            var userId = Guid.NewGuid();
            var constructionCompanyRepositoryMock = new Mock<IConstructionCompanyRepository>(MockBehavior.Strict);
            var userRepositoryMock = new Mock<IUserRepository>(MockBehavior.Strict);
            constructionCompanyRepositoryMock.Setup(x => x.CreateConstructionCompany(It.IsAny<ConstructionCompany>(), It.IsAny<Guid>())).Throws(new ValueDuplicatedException(""));
            userRepositoryMock.Setup(x => x.GetUserIdFromSessionToken(It.IsAny<Guid>())).Returns(userId);
            var constructionCompanyLogic = new ConstructionCompanyLogic(constructionCompanyRepositoryMock.Object, userRepositoryMock.Object);

            Exception exception = null;
            try
            {
                constructionCompanyLogic.CreateConstructionCompany(new ConstructionCompany(), Guid.NewGuid());
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            constructionCompanyRepositoryMock.VerifyAll();
            Assert.IsInstanceOfType(exception, typeof(DuplicatedValueException));
        }

        [TestMethod]
        public void CreateConstructionCompanyWithInvalidSessionTokenTest()
        {
            var constructionCompany = new ConstructionCompany
            {
                Id = new Guid(),
                Name = "company"
            };
            var constructionCompanyRepositoryMock = new Mock<IConstructionCompanyRepository>(MockBehavior.Strict);
            var userRepositoryMock = new Mock<IUserRepository>(MockBehavior.Strict);
            userRepositoryMock.Setup(x => x.GetUserIdFromSessionToken(It.IsAny<Guid>())).Throws(new ValueNotFoundException(""));
            var constructionCompanyLogic = new ConstructionCompanyLogic(constructionCompanyRepositoryMock.Object, userRepositoryMock.Object);

            Exception exception = null;
            try
            {
                constructionCompanyLogic.CreateConstructionCompany(new ConstructionCompany(), Guid.NewGuid());
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            constructionCompanyRepositoryMock.VerifyAll();
            Assert.IsInstanceOfType(exception, typeof(NotFoundException));
        }

        [TestMethod]
        public void ModifyConstructionCompanyNameSuccessfully()
        {
            var constructionCompany = new ConstructionCompany
            {
                Id = new Guid(),
                Name = "company"
            };
            string newName = "company2";
            ConstructionCompany modifiedCompany = new()
            {
                Id = constructionCompany.Id,
                Name = newName
            };
            var userId = Guid.NewGuid();
            var userRepositoryMock = new Mock<IUserRepository>(MockBehavior.Strict);
            var constructionCompanyRepositoryMock = new Mock<IConstructionCompanyRepository>(MockBehavior.Strict);
            userRepositoryMock.Setup(x => x.GetUserIdFromSessionToken(It.IsAny<Guid>())).Returns(userId);
            constructionCompanyRepositoryMock.Setup(x => x.ModifyConstructionCompanyName(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<Guid>())).Returns(modifiedCompany);
            var constructionCompanyLogic = new ConstructionCompanyLogic(constructionCompanyRepositoryMock.Object, userRepositoryMock.Object);

            var result = constructionCompanyLogic.ModifyName(constructionCompany.Id, newName, Guid.NewGuid());

            constructionCompanyRepositoryMock.VerifyAll();
            Assert.AreEqual(modifiedCompany, result);
        }

        [TestMethod]
        public void ModifyConstructionCompanyNameWithInvalidId()
        {
            var userId = Guid.NewGuid();
            var userRepositoryMock = new Mock<IUserRepository>(MockBehavior.Strict);
            var constructionCompanyRepositoryMock = new Mock<IConstructionCompanyRepository>(MockBehavior.Strict);
            userRepositoryMock.Setup(x => x.GetUserIdFromSessionToken(It.IsAny<Guid>())).Returns(userId);
            constructionCompanyRepositoryMock.Setup(x => x.ModifyConstructionCompanyName(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<Guid>())).Throws(new ValueNotFoundException(""));
            var constructionCompanyLogic = new ConstructionCompanyLogic(constructionCompanyRepositoryMock.Object, userRepositoryMock.Object);
            Exception exception = null;

            try
            {
                constructionCompanyLogic.ModifyName(Guid.NewGuid(), "new name", Guid.NewGuid());
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            constructionCompanyRepositoryMock.VerifyAll();
            Assert.IsInstanceOfType(exception, typeof(NotFoundException));
        }

        [TestMethod]
        public void ModifyConstructionCompanyNameToAlreadyExistingName()
        {
            var userId = Guid.NewGuid();
            var userRepositoryMock = new Mock<IUserRepository>(MockBehavior.Strict);
            var constructionCompanyRepositoryMock = new Mock<IConstructionCompanyRepository>(MockBehavior.Strict);
            userRepositoryMock.Setup(x => x.GetUserIdFromSessionToken(It.IsAny<Guid>())).Returns(userId);
            constructionCompanyRepositoryMock.Setup(x => x.ModifyConstructionCompanyName(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<Guid>())).Throws(new ValueDuplicatedException(""));
            var constructionCompanyLogic = new ConstructionCompanyLogic(constructionCompanyRepositoryMock.Object, userRepositoryMock.Object);
            Exception exception = null;

            try
            {
                constructionCompanyLogic.ModifyName(Guid.NewGuid(), "existing name", Guid.NewGuid());
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            constructionCompanyRepositoryMock.VerifyAll();
            Assert.IsInstanceOfType(exception, typeof(DuplicatedValueException));
        }

        [TestMethod]
        public void GetConstructionCompanyIdFromUserIdTest()
        {
            Guid userId = Guid.NewGuid();
            Guid companyId = Guid.NewGuid();
            var userRepositoryMock = new Mock<IUserRepository>(MockBehavior.Strict);
            var constructionCompanyRepositoryMock = new Mock<IConstructionCompanyRepository>(MockBehavior.Strict);
            constructionCompanyRepositoryMock.Setup(x => x.GetCompanyIdFromUserId(It.IsAny<Guid>())).Returns(companyId);
            var constructionCompanyLogic = new ConstructionCompanyLogic(constructionCompanyRepositoryMock.Object, userRepositoryMock.Object);

            var result = constructionCompanyLogic.GetCompanyIdFromUserId(userId);

            Assert.AreEqual(companyId, result);
        }

        [TestMethod]
        public void GetConstructionCompanyIdWithInvalidUserId()
        {
            var userRepositoryMock = new Mock<IUserRepository>(MockBehavior.Strict);
            var constructionCompanyRepositoryMock = new Mock<IConstructionCompanyRepository>(MockBehavior.Strict);
            constructionCompanyRepositoryMock.Setup(x => x.GetCompanyIdFromUserId(It.IsAny<Guid>())).Throws(new ValueNotFoundException(""));
            var constructionCompanyLogic = new ConstructionCompanyLogic(constructionCompanyRepositoryMock.Object, userRepositoryMock.Object);
            Exception exception = null;

            try
            {
                constructionCompanyLogic.GetCompanyIdFromUserId(Guid.NewGuid());
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            constructionCompanyRepositoryMock.VerifyAll();
            Assert.IsInstanceOfType(exception, typeof(NotFoundException));
        }
    }
}
