using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
            return Json(order);
        }

        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Index()
        {
            return View(await context.Orders.ToListAsync());
        }

        // GET: Categories/Details/5
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await context.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Categories/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await context.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                context.Entry(order).State = EntityState.Modified;
                order.ModifiedDate = DateTime.Now;
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Categories/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await context.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Categories/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Order order = await context.Orders.FindAsync(id);
            context.Orders.Remove(order);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}