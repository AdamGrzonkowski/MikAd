using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Microsoft.AspNet.Identity;
using Shop.DataEntry;
using Shop.Model.Models;
using Review = Shop.Model.Models.Review;

namespace Shop.Controllers
{
    public class ReviewsController : Controller
    {
        private ShopContext db = new ShopContext();
        private ProductsController product = new ProductsController();

        public async Task<ActionResult> CreateReview(Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                review.AddedDate = DateTime.Now;
                review.ModifiedDate = DateTime.Now;
                review.IP = Request.UserHostAddress;
                review.AuthorId = User.Identity.GetUserId();
                review.ProductId = Convert.ToInt32(Request.UrlReferrer.PathAndQuery.Split('/').Last());
                db.Reviews.Add(review);
                db.SaveChanges();
            }
           
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }
    }
}