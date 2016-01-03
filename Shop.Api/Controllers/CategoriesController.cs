using System.Collections.Generic;
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
        public IEnumerable<Category> GetAllCategories()
        {
            return Repository.GetAll();
        }

        [Route("api/categories/{id}")]
        public Category GetCategory(int id)
        {
            return Repository.Get(id);
        }

        [Route("api/categories/rootcategories/")]
        public IEnumerable<Category> GetRootCategories()
        {
            return Repository.GetRootCategories();
        }

        [Route("api/categories/topcategories")]
        public IEnumerable<Category> GetAllTopCategories()
        {
            return Repository.GetTopCategories();
        }

        [Route("api/categories/{id}/topcategories")]
        public IEnumerable<Category> GetTopCategories(int id)
        {
            Category category = Repository.Get(id);
            return Repository.GetTopCategories(category);
        }

        [Route("api/categories/{id}/products")]
        public IEnumerable<Product> GetProductsFromCategory(int id)
        {
            return Repository.Get(id).Products;
        }
    }
}
