using System.Net.Mail;
using Shop.Model.Models;

namespace Shop.Helpers
{
    public static class OrdersHelpers
    {
        public static void SendOrderConfirmation(Order order)
        {
            var msg = new MailMessage();
            msg.To.Add(order.User.Email);
            string orders = "";

            foreach (var detail in order.Details)
            {
                orders += $"{detail.Amount} x {detail.Product.Name}</br>";
            }

            msg.Subject = $"Potwierdzenie zamówienie nr {order.Id}";
            msg.Body = $"<h3>Drogi {order.User.UserName} </h3>" +
                       "<p>Dziękujemy za zakupy w sklepie MikAd! </br>" +
                       "Zakupiłeś następujące przedmioty: </p>" + 
                       orders +
                       $"<p>Forma wysyłki: {order.Consignment.Name}</p>" +
                       $"<p>Koszt wysyłki: {order.Consignment.Cost}</p>" +
                       $"<p>Całkowita opłata za zamówienie: {order.PriceWithConsignment}</p>" +
                       "<p>Wpłaty za zakupy dokonaj na konto:</p>" +
                       "<small>00 1111 2222 3333 4444 5555 6666 </br>" +
                       $"Tytuł przelewu: {order.User.UserName} zamówienie nr {order.Id} </br>" +
                       "Sklep MikAd, ul. Grudziądzka 5, 87-100 Toruń </small></br>" +
                       "<p>Dziękujemy za zakupy, </br>" +
                       "Sklep MikAd</p>";
            msg.IsBodyHtml = true;


            var smtpClient = new SmtpClient();
            smtpClient.Send(msg);
        }
    }
}