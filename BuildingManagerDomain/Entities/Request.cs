using System;
using BuildingManagerDomain.Enums;

namespace BuildingManagerDomain.Entities
{
    public class Request
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public RequestState State { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? MaintainerId { get; set; }
        public Guid BuildingId { get; set; }
        public int ApartmentFloor { get; set; }
    }
}