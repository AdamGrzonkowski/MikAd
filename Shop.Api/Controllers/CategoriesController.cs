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

        public IEnumerable<Category> GetAll()
        {
            return Repository.GetAll();
        }

        public Category Get(int id)
        {
            return Repository.Get(id);
        }

        [Route("api/categories/topcategories")]
        public IEnumerable<Category> GetTopCategories()
        {
            // NIE DZIAŁA. Problem z metodą GetTopCategories z repozytorium.
            return Repository.GetTopCategories();
        }

        [Route("api/categories/{id}/topcategories")]
        public IEnumerable<Category> GetTopCategories(int id)
        {
            // NIE DZIAŁA. Problem z metodą GetTopCategories z repozytorium.
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
