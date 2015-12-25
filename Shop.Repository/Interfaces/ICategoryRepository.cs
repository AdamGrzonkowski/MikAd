using System.Collections.Generic;
using Shop.Model.Models;

namespace Shop.Repository.Interfaces
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        IEnumerable<Category> GetAllRootCategories();
    }
}
