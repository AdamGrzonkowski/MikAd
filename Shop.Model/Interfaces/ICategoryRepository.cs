using System.Collections.Generic;
using Shop.Model.Models;

namespace Shop.Model.Interfaces
{
    interface ICategoryRepository : IRepository<Category, int>
    {
        Category GetByName(string categoryName);
        IEnumerable<Category> GetAllSubCategories(string categoryName);
        IEnumerable<Category> GetAllSubCategories(Category category);
        IEnumerable<Category> GetAllSubCategories(int categoryId);
        Category GetRootCategory(string categoryName);
        Category GetRootCategory(Category category);
        Category GetRootCategory(int categoryId);
    }
}
