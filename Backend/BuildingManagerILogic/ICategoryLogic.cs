﻿using BuildingManagerDomain.Entities;

namespace BuildingManagerILogic
{
    public interface ICategoryLogic
    {
        public Category CreateCategory(Category category);
        public List<Category> ListCategories();
    }
}
