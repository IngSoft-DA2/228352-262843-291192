using System;
using System.Collections.Generic;
using BuildingManagerDomain.Entities;
using BuildingManagerILogic;

namespace BuildingManagerLogic
{
    public class MaintenanceReport : IMaintenanceReport
    {
        public List<MaintenanceData> GetReport(Guid buildingId)
        {
            throw new System.NotImplementedException();
        }
    }
}