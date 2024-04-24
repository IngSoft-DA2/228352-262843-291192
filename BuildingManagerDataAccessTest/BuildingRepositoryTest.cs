﻿using BuildingManagerDataAccess.Context;
using BuildingManagerDataAccess.Repositories;
using BuildingManagerDomain.Entities;
using BuildingManagerIDataAccess.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BuildingManagerDataAccessTest
{
    [TestClass]
    public class BuildingRepositoryTest
    {
        [TestMethod]
        public void CreateBuildingTest()
        {
            var context = CreateDbContext("CreateBuildingTest");
            var repository = new BuildingRepository(context);
            var building = new Building
            {
                Id = Guid.NewGuid(),
                ManagerId = Guid.NewGuid(),
                Name = "Building 1",
                Address = "Address 1",
                Location = "Location 1",
                ConstructionCompany = "Company 1",
                CommonExpenses = 1000,
                Apartments = new List<Apartment>
                {
                    new Apartment
                    {
                        Floor = 1,
                        Number = 1,
                        Rooms = 3,
                        Bathrooms = 2,
                        HasTerrace = true,
                        Owner = new Owner
                        {
                            Name = "John",
                            LastName = "Doe",
                            Email = ""
                        }
                    }
                }
            };

            repository.CreateBuilding(building);
            var result = context.Set<Building>().Find(building.Id);

            Assert.AreEqual(building, result);
        }

        private DbContext CreateDbContext(string name)
        {
            var options = new DbContextOptionsBuilder<BuildingManagerContext>()
                .UseInMemoryDatabase(name)
                .Options;
            return new BuildingManagerContext(options);
        }
    }
}