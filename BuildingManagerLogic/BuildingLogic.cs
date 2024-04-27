﻿using BuildingManagerDomain.Entities;
using BuildingManagerIDataAccess;
using BuildingManagerIDataAccess.Exceptions;
using BuildingManagerILogic;
using BuildingManagerILogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagerLogic
{
    public class BuildingLogic : IBuildingLogic
    {
        private IBuildingRepository _buildingRepository;

        public BuildingLogic(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public Building CreateBuilding(Building building)
        {
            try
            {
                if (HasDuplicatedApartment(building.Apartments))
                {
                    throw new ValueDuplicatedException("Apartment floor and number");
                }

                if (HasDistinctOwnersWithSameEmail(building.Apartments))
                {
                    throw new ValueDuplicatedException("Owner email");
                }

                return _buildingRepository.CreateBuilding(building);
            }catch(ValueDuplicatedException e)
            {
                throw new DuplicatedValueException(e, e.Message);
            }
        }

        private bool HasDuplicatedApartment(List<Apartment> apartments)
        {
            for (int i = 0; i < apartments.Count; i++)
            {
                for (int j = i + 1; j < apartments.Count; j++)
                {
                    if (apartments[i].Floor == apartments[j].Floor && apartments[i].Number == apartments[j].Number)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool HasDistinctOwnersWithSameEmail(List<Apartment> apartments)
        {
            for (int i = 0; i < apartments.Count; i++)
            {
                for (int j = i + 1; j < apartments.Count; j++)
                {
                    if (apartments[i].Owner.Email == apartments[j].Owner.Email)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
