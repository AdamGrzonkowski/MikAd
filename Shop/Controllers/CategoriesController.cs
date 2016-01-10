using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shop.DataEntry;
using Shop.Model.Models;

namespace Shop.Controllers
{
    public class CategoriesController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Categories
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Index()
        {
            /*
            ShopApi api = new ShopApi();
            var categories = api.Categories.GetAll().ToList();
            return View(categories); */
            var categories = db.Categories.Include(c => c.BaseCategory);
            return View(await categories.ToListAsync());
        }

        // GET: Categories/Details/5
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.BaseCategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,BaseCategoryId,JsonProperties,AddedDate,ModifiedDate,IP")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.AddedDate = DateTime.Now;
                category.ModifiedDate = DateTime.Now;
                category.IP = Request.UserHostAddress;
                db.Categories.Add(category);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BaseCategoryId = new SelectList(db.Categories, "Id", "Name", category.BaseCategoryId);
            return View(category);
        }

        // GET: Categories/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.BaseCategoryId = new SelectList(db.Categories, "Id", "Name", category.BaseCategoryId);
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,BaseCategoryId,JsonProperties,AddedDate,ModifiedDate,IP")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                category.ModifiedDate = DateTime.Now;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BaseCategoryId = new SelectList(db.Categories, "Id", "Name", category.BaseCategoryId);
            return View(category);
        }

        // GET: Categories/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Category category = await db.Categories.FindAsync(id);
            db.Categories.Remove(category);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
