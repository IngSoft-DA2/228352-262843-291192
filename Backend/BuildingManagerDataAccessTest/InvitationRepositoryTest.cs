using BuildingManagerDataAccess.Context;
using BuildingManagerDataAccess.Repositories;
using BuildingManagerDomain.Entities;
using BuildingManagerDomain.Enums;
using BuildingManagerIDataAccess.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BuildingManagerDataAccessTest
{
    [TestClass]
    public class InvitationRepositoryTest
    {
        [TestMethod]
        public void CreateInvitationTest()
        {
            var context = CreateDbContext("CreateInvitationTest");
            var repository = new InvitationRepository(context);
            var invitation = new Invitation
            {
                Id = Guid.NewGuid(),
                Name = "John",
                Email = "test@test.com",
                Deadline = DateTimeOffset.UtcNow.AddYears(3).ToUnixTimeSeconds(),
                Status = InvitationStatus.PENDING
            };

            repository.CreateInvitation(invitation);
            var result = context.Set<Invitation>().Find(invitation.Id);

            Assert.AreEqual(invitation, result);
        }

        [TestMethod]
        public void DeleteInvitationTest()
        {
            var context = CreateDbContext("DeleteInvitationTest");
            var repository = new InvitationRepository(context);
            var invitation = new Invitation
            {
                Id = Guid.NewGuid(),
                Name = "John",
                Email = "test@test.com",
                Deadline = DateTimeOffset.UtcNow.AddYears(3).ToUnixTimeSeconds(),
                Status = InvitationStatus.PENDING
            };
            repository.CreateInvitation(invitation);

            var result = repository.DeleteInvitation(invitation.Id);

            Assert.AreEqual(invitation, result);
        }

        [TestMethod]
        public void ModifyInvitationTest()
        {
            var context = CreateDbContext("ModifyInvitationTest");
            var repository = new InvitationRepository(context);
            var invitation = new Invitation
            {
                Id = Guid.NewGuid(),
                Name = "John",
                Email = "test@test.com",
                Deadline = DateTimeOffset.UtcNow.AddHours(3).ToUnixTimeSeconds(),
                Status = InvitationStatus.PENDING
            };
            repository.CreateInvitation(invitation);

            var result = repository.ModifyInvitation(invitation.Id, DateTimeOffset.UtcNow.AddYears(4).ToUnixTimeSeconds());

            Assert.AreEqual(invitation, result);
        }

        [TestMethod]
        public void CreateInvitationWithDuplicatedEmailTest()
        {
            var context = CreateDbContext("CreateInvitationWithDuplicatedEmailTest");
            var repository = new InvitationRepository(context);
            var invitation = new Invitation
            {
                Id = Guid.NewGuid(),
                Name = "John",
                Email = "test@test.com",
                Deadline = DateTimeOffset.UtcNow.AddYears(3).ToUnixTimeSeconds(),
                Status = InvitationStatus.PENDING
            };
            repository.CreateInvitation(invitation);

            Exception exception = null;
            try
            {
                repository.CreateInvitation(invitation);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsInstanceOfType(exception, typeof(ValueDuplicatedException));
        }

        [TestMethod]
        public void DeleteInvitationWithInvalidIdTest()
        {
            var context = CreateDbContext("DeleteInvitationWithInvalidIdTest");
            var repository = new InvitationRepository(context);

            Exception exception = null;
            try
            {
                repository.DeleteInvitation(new Guid());
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsInstanceOfType(exception, typeof(ValueNotFoundException));
        }

        [TestMethod]
        public void ModifyInvitationWithInvalidIdTest()
        {
            var context = CreateDbContext("ModifyInvitationWithInvalidIdTest");
            var repository = new InvitationRepository(context);

            Exception exception = null;
            try
            {
                repository.ModifyInvitation(new Guid(), DateTimeOffset.UtcNow.AddYears(3).ToUnixTimeSeconds());
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsInstanceOfType(exception, typeof(ValueNotFoundException));
        }

        [TestMethod]
        public void DeleteAcceptedInvitationTest()
        {
            var context = CreateDbContext("DeleteAcceptedInvitationTest");
            var repository = new InvitationRepository(context);
            var invitation = new Invitation
            {
                Id = Guid.NewGuid(),
                Name = "John",
                Email = "test@test.com",
                Deadline = DateTimeOffset.UtcNow.AddHours(3).ToUnixTimeSeconds(),
                Status = InvitationStatus.ACCEPTED
            };
            repository.CreateInvitation(invitation);

            Exception exception = null;
            try
            {
                repository.DeleteInvitation(invitation.Id);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsInstanceOfType(exception, typeof(InvalidOperationException));
        }

        [TestMethod]
        public void ModifyAcceptedInvitationTest()
        {
            var context = CreateDbContext("ModifyAcceptedInvitationTest");
            var repository = new InvitationRepository(context);
            var invitation = new Invitation
            {
                Id = Guid.NewGuid(),
                Name = "John",
                Email = "test@test.com",
                Deadline = DateTimeOffset.UtcNow.AddHours(3).ToUnixTimeSeconds(),
                Status = InvitationStatus.ACCEPTED
            };
            repository.CreateInvitation(invitation);

            Exception exception = null;
            try
            {
                repository.ModifyInvitation(invitation.Id, DateTimeOffset.UtcNow.AddYears(4).ToUnixTimeSeconds());
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsInstanceOfType(exception, typeof(InvalidOperationException));
        }

        [TestMethod]
        public void ModifyInvitationThatExpiresInMoreThanOneDayTest()
        {
            var context = CreateDbContext("ModifyInvitationThatExpiresInMoreThanOneDayTest");
            var repository = new InvitationRepository(context);
            var invitation = new Invitation
            {
                Id = Guid.NewGuid(),
                Name = "John",
                Email = "test@test.com",
                Deadline = DateTimeOffset.UtcNow.AddYears(3).ToUnixTimeSeconds(),
                Status = InvitationStatus.PENDING
            };
            repository.CreateInvitation(invitation);

            Exception exception = null;
            try
            {
                repository.ModifyInvitation(invitation.Id, DateTimeOffset.UtcNow.AddYears(4).ToUnixTimeSeconds());
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsInstanceOfType(exception, typeof(InvalidOperationException));
        }

        [TestMethod]
        public void ModifyInvitationWithInvalidNewDeadlineTest()
        {
            var context = CreateDbContext("ModifyInvitationWithInvalidNewDeadlineTest");
            var repository = new InvitationRepository(context);
            var invitation = new Invitation
            {
                Id = Guid.NewGuid(),
                Name = "John",
                Email = "test@test.com",
                Deadline = DateTimeOffset.UtcNow.AddHours(3).ToUnixTimeSeconds(),
                Status = InvitationStatus.PENDING
            };
            repository.CreateInvitation(invitation);

            Exception exception = null;
            try
            {
                repository.ModifyInvitation(invitation.Id, DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsInstanceOfType(exception, typeof(InvalidOperationException));
        }

        [TestMethod]
        public void RespondDenyInvitationTest()
        {
            var context = CreateDbContext("RespondInvitationTest");
            var repository = new InvitationRepository(context);
            var invitation = new Invitation
            {
                Id = Guid.NewGuid(),
                Email = "peter@abc.com",
                Deadline = DateTimeOffset.UtcNow.AddHours(2).ToUnixTimeSeconds(),
                Status = InvitationStatus.PENDING
            };
            repository.CreateInvitation(invitation);
            var invitationAnswer = new InvitationAnswer
            {
                InvitationId = invitation.Id,
                Email = invitation.Email,
                Status = InvitationStatus.DECLINED
            };
            var expectedInvitation = new Invitation
            {
                Id = invitationAnswer.InvitationId,
                Email = invitationAnswer.Email,
                Status = invitationAnswer.Status,
                Deadline = invitation.Deadline,
            };

            var result = repository.RespondInvitation(invitationAnswer);

            Assert.AreEqual(expectedInvitation, result);
        }

        [TestMethod]
        public void AcceptInvitationTest()
        {
            var context = CreateDbContext("RespondInvitationTest");
            var repository = new InvitationRepository(context);
            var invitation = new Invitation
            {
                Id = Guid.NewGuid(),
                Email = "john@abc.com",
                Deadline = DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds(),
                Status = InvitationStatus.PENDING
            };
            repository.CreateInvitation(invitation);
            var invitationAnswer = new InvitationAnswer
            {
                InvitationId = invitation.Id,
                Email = invitation.Email,
                Status = InvitationStatus.ACCEPTED,
                Password = "123456"
            };
            var expectedInvitation = new Invitation
            {
                Id = invitationAnswer.InvitationId,
                Email = invitationAnswer.Email,
                Status = invitationAnswer.Status,
                Deadline = invitation.Deadline,
            };

            var result = repository.RespondInvitation(invitationAnswer);

            Assert.AreEqual(expectedInvitation, result);
        }

        [TestMethod]
        public void RespondInvitationWithValueNotFoundTest()
        {
            var context = CreateDbContext("RespondInvitationWithValueNotFoundTest");
            var repository = new InvitationRepository(context);
            var invitationAnswer = new InvitationAnswer
            {
                InvitationId = Guid.NewGuid(),
                Email = "nonexisting@hotmail.com",
                Status = InvitationStatus.ACCEPTED,
                Password = "123456"
            };

            Exception exception = null;
            try
            {
                repository.RespondInvitation(invitationAnswer);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsInstanceOfType(exception, typeof(ValueNotFoundException));
        }

        [TestMethod]
        public void RespondInvitationWithExpiredInvitationTest()
        {
            var context = CreateDbContext("RespondInvitationWithExpiredInvitationTest");
            var repository = new InvitationRepository(context);
            var invitation = new Invitation
            {
                Id = Guid.NewGuid(),
                Email = "john@abc.com",
                Deadline = DateTimeOffset.UtcNow.AddHours(-1).ToUnixTimeSeconds(),
                Status = InvitationStatus.PENDING
            };
            repository.CreateInvitation(invitation);

            var invitationAnswer = new InvitationAnswer
            {
                InvitationId = invitation.Id,
                Email = invitation.Email,
                Status = InvitationStatus.ACCEPTED,
                Password = "123456"
            };

            Exception exception = null;
            try
            {
                repository.RespondInvitation(invitationAnswer);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsInstanceOfType(exception, typeof(InvalidOperationException));
        }

        private DbContext CreateDbContext(string name)
        {
            var options = new DbContextOptionsBuilder<BuildingManagerContext>()
                .UseInMemoryDatabase(name)
                .Options;
            return new BuildingManagerContext(options);
        }
    }
}