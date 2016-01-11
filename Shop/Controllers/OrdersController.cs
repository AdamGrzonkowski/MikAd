using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Shop.DataEntry;
using Shop.Helpers;
using Shop.Model.Models;
using Shop.Model.ViewModels;
using Shop.Repository.Repositories;

namespace Shop.Controllers
{
    public class OrdersController : Controller
    {
        private ShopContext context;

        public OrdersController()
        {
            context = ShopContext.Create();
        }

        [Authorize]
        public ActionResult Confirm()
        {
            var consignmentRepository = new ConsignmentRepository(context);
            var consignments = consignmentRepository.GetAll();
            return View(consignments);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(OrderViewModel _order)
        {
            var user = context.Users.SingleOrDefault(x => x.UserName == User.Identity.Name);
            var orderRepository = new OrderRepository(context);
            var detailRepository = new DetailRepository(context);
            var productRepository = new ProductRepository(context);
            var consignmentRepository = new ConsignmentRepository(context);

            var consignment = consignmentRepository.Get(_order.Consignment);
            var order = new Order
            {
                User = user,
                IP = Request.UserHostAddress,
                Notes = _order.Notes,
                Consignment = consignment
            };
            orderRepository.Add(order);
            Debug.WriteLine("order: " + order.AddedDate + " " + order.ModifiedDate);
            foreach (var orderedProduct in _order.Basket)
            {
                var product = productRepository.Get(orderedProduct.Id);
                var detail = new Detail
                {
                    Order = order,
                    Product = product,
                    Amount = orderedProduct.Amount
                };
                detailRepository.Add(detail);
                detailRepository.Save();
                Debug.WriteLine("detail: " + detail.AddedDate + " " + detail.ModifiedDate);
            }
            orderRepository.Save();
            OrdersHelpers.SendOrderConfirmation(order);
            return Json(order.Id);
        }

        public ActionResult Finish(int id)
        {
            var order = new OrderRepository(ShopContext.Create()).Get(id);
            return View(order);
        }

    }
}