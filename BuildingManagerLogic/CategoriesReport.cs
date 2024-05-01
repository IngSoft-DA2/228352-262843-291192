﻿using BuildingManagerDomain.Entities;
using BuildingManagerIDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildingManagerLogic
{
    public class CategoriesReport : Report
    {
        public CategoriesReport(IRequestRepository repository) : base(repository) { }

        internal override void SortRequests(Guid? identifier, string filter)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                Requests = Requests.Where(r => r.Category.Name == filter).ToList();
            }
            foreach (var request in Requests.Where(r => r.BuildingId == identifier))
            {
                if (SortedRequests.ContainsKey(request.CategoryId.ToString()))
                {
                    SortedRequests[request.CategoryId.ToString()].Add(request);
                }
                else
                {
                    List<Request> newList = new List<Request>
                    {
                        request
                    };
                    SortedRequests[request.CategoryId.ToString()] = newList;
                }
            }
        }
    }
}
