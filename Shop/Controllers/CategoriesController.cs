using System.Linq;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class CategoriesController : Controller
    {
        public ActionResult Index()
        {
            ShopApi api = new ShopApi();
            var categories = api.Categories.GetAll().ToList();
            return View(categories);
        }
    }
}