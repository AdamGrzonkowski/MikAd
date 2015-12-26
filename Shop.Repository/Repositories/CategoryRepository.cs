using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Category> GetRootCategories()
        {
            return FindMany(x => x.BaseCategory == null);
        }

        public IEnumerable<Category> GetTopCategories()
        {
            return FindMany(x => x.SubCategories == null);
        }

        public IEnumerable<Category> GetTopCategories(Category category)
        {
            List<Category> categories = new List<Category>();

            if (category.SubCategories != null)
            {
                foreach (var subCategory in category.SubCategories)
                {
                    if (subCategory.SubCategories == null)
                    {
                        categories.Add(subCategory);
                    }
                    else
                    {
                        categories = (List<Category>) categories.Concat(GetTopCategories(subCategory));
                    }
                }
            }

            return categories;
        }
    }
}
