using System;
using System.Collections.Generic;
using BuildingManagerDomain.Entities;

namespace BuildingManagerILogic
{
    public interface IRequestLogic
    {
        Request AssignStaff(Guid id, Guid maintenanceStaffId);
        public Request CreateRequest(Request request);
        public List<Request> GetRequests();
    }
}