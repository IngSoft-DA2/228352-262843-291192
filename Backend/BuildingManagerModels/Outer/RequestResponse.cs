using System;
using BuildingManagerDomain.Entities;
using BuildingManagerDomain.Enums;

namespace BuildingManagerModels.Outer
{
    public class RequestResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public RequestState State { get; set; }
        public Guid BuildingId { get; set; }
        public Guid ManagerId { get; set; }
        public int ApartmentFloor { get; set; }
        public int ApartmentNumber { get; set; }

        public RequestResponse(Request request)
        {
            Id = request.Id;
            Description = request.Description;
            CategoryId = request.CategoryId;
            BuildingId = request.BuildingId;
            ManagerId = request.ManagerId;
            ApartmentFloor = request.ApartmentFloor;
            ApartmentNumber = request.ApartmentNumber;
            State = request.State;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (RequestResponse)obj;
            return Id == other.Id &&
            Description == other.Description &&
            BuildingId == other.BuildingId &&
            CategoryId == other.CategoryId &&
            ManagerId == other.ManagerId &&
            State == other.State &&
            ApartmentFloor == other.ApartmentFloor &&
            ApartmentNumber == other.ApartmentNumber;
        }
    }
}