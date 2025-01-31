
using System;

namespace BuildingManagerDomain.Entities
{
    public struct ReportData
    {
        public ReportData(int openRequests, int closeRequests, int inProgressRequests, 
        int averageClosingTime, string maintainerName, Guid buildingId, string categoryName, 
        int? apartmentFloor, int? apartmentNumber, string ownerName, string buildingName)
        {
            OpenRequests = openRequests;
            CloseRequests = closeRequests;
            InProgressRequests = inProgressRequests;
            AverageClosingTime = averageClosingTime;
            MaintainerName = maintainerName;
            BuildingId = buildingId;
            CategoryName = categoryName;
            ApartmentFloor = apartmentFloor;
            ApartmentNumber = apartmentNumber;
            OwnerName = ownerName;
            BuildingName = buildingName;
        }
        public int OpenRequests { get; }
        public int CloseRequests { get; }
        public int InProgressRequests { get; }
        public int AverageClosingTime { get; }
        public string MaintainerName { get; }
        public Guid BuildingId { get; }
        public string CategoryName { get; }
        public int? ApartmentFloor { get; set; }
        public int? ApartmentNumber { get; set; }
        public string OwnerName { get; set; }
        public string BuildingName { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (ReportData)obj;
            return OpenRequests == other.OpenRequests &&
            CloseRequests == other.CloseRequests &&
            InProgressRequests == other.InProgressRequests &&
            AverageClosingTime == other.AverageClosingTime &&
            MaintainerName == other.MaintainerName &&
            BuildingId == other.BuildingId &&
            CategoryName == other.CategoryName &&
            ApartmentFloor == other.ApartmentFloor &&
            ApartmentNumber == other.ApartmentNumber &&
            OwnerName == other.OwnerName &&
            BuildingName == other.BuildingName;
        }
    }
}
