using System;
using BuildingManagerDomain.Entities;

namespace BuildingManagerILogic
{
    public interface IConstructionCompanyAdminLogic
    {
        public User CreateConstructionCompanyAdmin(User user, Guid sessionToken);
    }
}
