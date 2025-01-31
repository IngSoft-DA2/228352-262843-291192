
using System;

namespace BuildingManagerDomain.Entities
{
    public struct BuildingsReportData
    {
        public BuildingsReportData(int openRequests, int closeRequests, int inProgressRequests, Guid buildingId, string buildingName)
        {
            OpenRequests = openRequests;
            CloseRequests = closeRequests;
            InProgressRequests = inProgressRequests;
            BuildingId = buildingId;
            BuildingName = buildingName;
        }
        public int OpenRequests { get; }
        public int CloseRequests { get; }
        public int InProgressRequests { get; }
        public Guid BuildingId { get; }
        public string BuildingName { get; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (BuildingsReportData)obj;
            return OpenRequests == other.OpenRequests &&
            CloseRequests == other.CloseRequests &&
            InProgressRequests == other.InProgressRequests &&
            BuildingId == other.BuildingId &&
            BuildingName == other.BuildingName;
        }
    }
}
