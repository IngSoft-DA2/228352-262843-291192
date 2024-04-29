
namespace BuildingManagerDomain.Entities
{
    public struct MaintenanceData
    {
        public MaintenanceData(int openRequests, int closeRequests, int inProgressRequests, int averageClosingTime, string maintainerName)
        {
            OpenRequests = openRequests;
            CloseRequests = closeRequests;
            InProgressRequests = inProgressRequests;
            AverageClosingTime = averageClosingTime;
            MaintainerName = maintainerName;
        }
        public int OpenRequests { get; }
        public int CloseRequests { get; }
        public int InProgressRequests { get; }
        public int AverageClosingTime { get; }
        public string MaintainerName { get; }
    }
}