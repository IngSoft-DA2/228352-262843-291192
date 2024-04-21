using System;
using BuildingManagerDomain.Entities;

namespace BuildingManagerModels.Outer
{
    public class CreateInvitationResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public long Deadline { get; set; }

        public CreateInvitationResponse(Invitation invitation)
        {
            Id = invitation.Id;
            Email = invitation.Email;
            Name = invitation.Name;
            Deadline = invitation.Deadline;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (CreateInvitationResponse)obj;
            return Id == other.Id && Email == other.Email && Name == other.Name && Deadline == other.Deadline;
        }

    }
}