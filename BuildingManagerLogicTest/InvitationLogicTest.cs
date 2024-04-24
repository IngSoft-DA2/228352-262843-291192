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
    public class InvitationLogicTest
    {
        private Invitation _invitation;

        [TestInitialize]
        public void Initialize()
        {
            _invitation = new Invitation()
            {
                Id = new Guid(),
                Name = "John",
                Email = "john@abc.com",
                Deadline = 1745039332
            };
        }

        [TestMethod]
        public void CreateInvitationSuccessfully()
        {
            var invitationRepositoryMock = new Mock<IInvitationRepository>(MockBehavior.Strict);
            invitationRepositoryMock.Setup(x => x.CreateInvitation(It.IsAny<Invitation>())).Returns(_invitation);
            var invitationLogic = new InvitationLogic(invitationRepositoryMock.Object);

            var result = invitationLogic.CreateInvitation(_invitation);

            invitationRepositoryMock.VerifyAll();
            Assert.AreEqual(_invitation, result);
        }

        [TestMethod]
        public void CreateInvitationWithAlreadyInUseEmail()
        {
            var invitationRepositoryMock = new Mock<IInvitationRepository>(MockBehavior.Strict);
            invitationRepositoryMock.Setup(x => x.CreateInvitation(It.IsAny<Invitation>())).Throws(new ValueDuplicatedException(""));
            var invitationLogic = new InvitationLogic(invitationRepositoryMock.Object);
            Exception exception = null;
            try
            {
                invitationLogic.CreateInvitation(_invitation);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            invitationRepositoryMock.VerifyAll();
            Assert.IsInstanceOfType(exception, typeof(DuplicatedValueException));

        }
    }
}