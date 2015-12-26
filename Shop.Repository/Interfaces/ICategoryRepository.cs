using System.Collections.Generic;
using Shop.Model.Models;

namespace Shop.Repository.Interfaces
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        IEnumerable<Category> GetRootCategories();
        IEnumerable<Category> GetTopCategories();
        IEnumerable<Category> GetTopCategories(Category category);
    }
}
