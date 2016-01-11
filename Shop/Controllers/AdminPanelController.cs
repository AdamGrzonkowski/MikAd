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
        /// <summary>
        /// Panel admina
        /// </summary>
        /// <returns>Stronę panelu administratora</returns>
        [Authorize(Roles = "admin")]
        public ActionResult IndexAdminPanel()
        {
            return View();
        }
    }
}