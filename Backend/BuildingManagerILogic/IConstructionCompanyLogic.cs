using System;
using BuildingManagerDomain.Entities;

namespace BuildingManagerILogic
{
    public interface IConstructionCompanyLogic
    {
        public ConstructionCompany CreateConstructionCompany(ConstructionCompany constructionCompany, Guid sessionToken);
        public ConstructionCompany ModifyName(Guid id, string name, Guid sessionToken);
        public Guid GetCompanyIdFromUserId(Guid userId);
        public void AssociateCompanyToUser(Guid userId, Guid companyId);
        public bool IsUserAssociatedToCompany(Guid userId, Guid companyId);
        public ConstructionCompany GetConstructionCompany(Guid companyId);
        public List<BuildingResponse> GetCompanyBuildings(Guid companyId);
    }
}
