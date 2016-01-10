using System.Data.Entity;
using Shop.DataEntry;
using Shop.Model.Models;
using Shop.Repository.Interfaces;

namespace Shop.Repository.Repositories
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
      
        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }

        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}
