using System.Web.Http;
using Shop.Api.Classes;
using Shop.Model.Models;
using Shop.Repository.Interfaces;

namespace Shop.Api.Controllers
{
    public class OrdersController : AuthorizedApiController<Order, int>
    {
        public OrdersController(IRepository<Order, int> repository) : base(repository)
        {
        }
    }
}
