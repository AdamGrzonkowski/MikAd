using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Shop.Api.Classes;
using Shop.Model.Models;
using Shop.Repository.Repositories;

namespace Shop.Api.Controllers
{
    public class CategoriesController : ShopApiController<Category, int>
    {
        public CategoriesController()
        {
            _repository = new CategoryRepository(ShopContext.Create());
        }

        public CategoryRepository Repository { get { return _repository as CategoryRepository; } }

        [Route("api/categories/")]
        public IQueryable<Category> GetAllCategories()
        {
            return Repository.GetAll().AsQueryable();
        }

        [Route("api/categories/{id}")]
        public Category GetCategory(int id)
        {
            return Repository.Get(id);
        }

        [Route("api/categories/rootcategories/")]
        public IQueryable<Category> GetRootCategories()
        {
            return Repository.GetRootCategories().AsQueryable();
        }

        [Route("api/categories/topcategories")]
        public IQueryable<Category> GetAllTopCategories()
        {
            return Repository.GetTopCategories().AsQueryable();
        }

        [Route("api/categories/{id}/topcategories")]
        public IQueryable<Category> GetTopCategories(int id)
        {
            Category category = Repository.Get(id);
            return Repository.GetTopCategories(category).AsQueryable();
        }

        [Route("api/categories/{id}/products")]
        public IQueryable<Product> GetProductsFromCategory(int id)
        {
            return Repository.Get(id).Products.AsQueryable();
        }
    }
}
