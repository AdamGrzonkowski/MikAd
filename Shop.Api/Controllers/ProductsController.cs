using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Shop.Api.Classes;
using Shop.Model.Models;
using Shop.Repository.Repositories;

namespace Shop.Api.Controllers
{
    public class ProductsController : ShopApiController<Product, int>
    {
        public ProductsController()
        {
            _repository = new ProductRepository(ShopContext.Create());
        }

        public ProductRepository Repository
        {
            get { return _repository as ProductRepository; }
        }

        public IEnumerable<Product> GetAll()
        {
            return Repository.GetAll();
        }

        public Product Get(int id)
        {
            return Repository.Get(id);
        }
    }
}
