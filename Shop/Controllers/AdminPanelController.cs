using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class AdminPanelController : Controller
    {
        // GET: AdminPanel
        [Authorize(Roles = "admin")]
        public ActionResult IndexAdminPanel()
        {
            return View();
        }
    }
}