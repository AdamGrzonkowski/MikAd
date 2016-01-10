using System.Web.Http;
using Shop.Api.Classes;
using Shop.Api.Models;
using Shop.DataEntry;
using Shop.Model.Models;
using Shop.Repository.Repositories;

namespace Shop.Api.Controllers
{
    [Authorize]
    public class OrdersController : ShopApiController<Order, int>
    {
        public OrdersController()
        {
            _context = ShopContext.Create();
            _repository = new OrderRepository(_context);
        }

        public OrderRepository Repository { get {return _repository as OrderRepository;} } 

        [HttpPost]
        public void Post([FromBody] OrderViewModel newOrder)
        {
            
        }
    }
}
