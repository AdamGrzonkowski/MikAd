using System.Web.Mvc;

namespace Shop.Controllers
{
    public class OrdersController : Controller
    {
        [Authorize]
        public ActionResult Confirm()
        {
            return View();
        }
    }
}