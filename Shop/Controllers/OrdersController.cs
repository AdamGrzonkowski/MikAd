using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Shop.DataEntry;
using Shop.Model.Models;
using Shop.Model.ViewModels;
using Shop.Repository.Repositories;

namespace Shop.Controllers
{
    public class OrdersController : Controller
    {
        [Authorize]
        public ActionResult Confirm()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(OrderViewModel _order)
        {
            var context = ShopContext.Create();
            var user = context.Users.SingleOrDefault(x => x.UserName == User.Identity.Name);
            var orderRepository = new OrderRepository(context);
            var detailRepository = new DetailRepository(context);
            var productRepository = new ProductRepository(context);
            var order = new Order
            {
                User = user,
                IP = Request.UserHostAddress,
                Notes = _order.Notes,
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
            return Json("Utworzono zamówienie");
        }
    }
}