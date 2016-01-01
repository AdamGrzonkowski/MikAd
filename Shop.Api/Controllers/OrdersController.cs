using System.Web.Http;
using Shop.Api.Classes;
using Shop.Api.Models;
using Shop.Model.Models;
using Shop.Repository.Repositories;

namespace Shop.Api.Controllers
{
    public class OrdersController : ShopApiController<Order, int>
    {
        public OrdersController()
        {
            _context = ShopContext.Create();
            _repository = new OrderRepository(_context);
        }

        [HttpPost]
        public void Post([FromBody] OrderViewModel newOrder)
        {
            
        }
    }
}
