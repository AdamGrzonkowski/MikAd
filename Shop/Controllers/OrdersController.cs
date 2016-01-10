using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class OrdersController : Controller
    {
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Authorize]
        public ActionResult Confirm(List<ProductViewModel> basket)
        {
            return Content("udało się");
        }
    }
}