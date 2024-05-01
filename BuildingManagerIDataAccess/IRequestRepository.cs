using System;
using System.Collections.Generic;
using BuildingManagerDomain.Entities;

namespace BuildingManagerIDataAccess
{
    public interface IRequestRepository
    {
        Request AssignStaff(Guid id, Guid maintenanceStaffId);
        Request AttendRequest(Guid id);
        Request CreateRequest (Request request);
        List<Request> GetRequests();
    }
}