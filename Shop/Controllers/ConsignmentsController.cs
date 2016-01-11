using System.Web.Mvc;
using Shop.DataEntry;
using Shop.Repository.Repositories;

namespace Shop.Controllers
{
    public class ConsignmentsController : Controller
    {
        // GET: Consignments
        public ActionResult Data()
        {
            var consignmentRepository = new ConsignmentRepository(ShopContext.Create());
            return Json(consignmentRepository.GetAll(), JsonRequestBehavior.AllowGet);
        }
    }
}