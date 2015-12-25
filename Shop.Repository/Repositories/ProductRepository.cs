using System.Collections.Generic;
using System.Linq;
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
            List<Product> products = new List<Product>();

            if (category.Products != null)
            {
                products = (List<Product>) products.Concat(category.Products);
            }

            if (category.SubCategories != null)
            {
                foreach (var subCategory in category.SubCategories)
                {
                    products = (List<Product>) products.Concat(GetAllProductsFromCategory(subCategory));
                }
            }

            return products;
        }
    }
}
