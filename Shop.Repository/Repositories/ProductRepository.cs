using System.Collections.Generic;
using Shop.Model.Models;
using Shop.Repository.Interfaces;

namespace Shop.Repository.Repositories
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(ShopContext context) : base(context)
        {
        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }

        public IEnumerable<Product> GetAllProductsFromCategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetAllProductsFromCategory(int categoryId)
        {
            throw new System.NotImplementedException();
        }
    }
}
