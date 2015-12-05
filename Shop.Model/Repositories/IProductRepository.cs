using System.Linq;
using Shop.Model.Models;

namespace Shop.Model.Repositories
{
    interface IProductRepository : IRepository<Product, int>
    {
        IQueryable<Product> GetAllInStock();
        IQueryable<Product> GetByCategory(int categoryId);
        IQueryable<Product> GetByCategory(Category category);
        IQueryable<Product> GetByCategory(string categoryName);
        IQueryable<Product> GetByProperty(string propertyName, string propertyValue);
        IQueryable<Product> GetByPrice(decimal price);
    }
}
