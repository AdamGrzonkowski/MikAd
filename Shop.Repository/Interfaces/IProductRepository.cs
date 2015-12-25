using System.Collections.Generic;
using Shop.Model.Models;

namespace Shop.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product, int>
    {
        IEnumerable<Product> GetAllProductsFromCategory(Category category);
    }
}
