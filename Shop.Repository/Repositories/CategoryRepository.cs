using System.Collections.Generic;
using Shop.Model.Models;
using Shop.Repository.Interfaces;

namespace Shop.Repository.Repositories
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(ShopContext context) : base(context)
        {
        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }

        public IEnumerable<Category> GetAllRootCategories()
        {
            return FindMany(x => x.BaseCategory == null);
        }
    }
}
