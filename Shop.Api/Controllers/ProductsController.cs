using System.Collections.Generic;
using System.Web.Http.Cors;
using Shop.Api.Classes;
using Shop.DataEntry;
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

        [EnableCors(origins: "http://localhost:59583", headers: "*", methods: "*")]
        public IEnumerable<Product> GetAll()
        {
            return Repository.GetAll();
        }

        [EnableCors(origins: "http://localhost:59583", headers: "*", methods: "*")]
        public Product Get(int id)
        {
            return Repository.Get(id);
        }
    }
}
