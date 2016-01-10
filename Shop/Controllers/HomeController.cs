using System.Net.Mail;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            
            
            return View();
        }

        public ActionResult SubmitContactForm(string msgTitle, string msgEmailAddress, string msgBody)
        {
            var msg = new MailMessage();
            msg.To.Add("Sklep_MVC@wp.pl");

            msg.Subject = msgTitle;
            msg.Body = "Wiadomość od: <a href='mailto:" + msgEmailAddress + "'>" + msgEmailAddress + "</a> <h4> Treść: </h4>" + msgBody;
            msg.IsBodyHtml = true;

            var smtpClient = new SmtpClient();
            smtpClient.Send(msg);

            return RedirectToAction("Contact");
        }

    }
}