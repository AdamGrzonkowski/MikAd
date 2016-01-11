using PagedList;
using Shop.DataEntry;
using Shop.Model.Models;
using Shop.Model.ViewModels;
using Shop.Repository.Repositories;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList.Mvc;

namespace Shop.Controllers
{
    public class ProductsController : Controller
    {
        private ShopContext db = new ShopContext();
        protected Repository<Product, int> _repository;

        public ProductsController()
        {
            _repository = new ProductRepository(ShopContext.Create());
        }

        public ProductRepository Repository
        {
            get { return _repository as ProductRepository; }
        }

        // GET: Products
        public async Task<ActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CategoryNameSortParm = String.IsNullOrEmpty(sortOrder) ? "cat_name_desc" : "";
            ViewBag.QuantitySortParm = String.IsNullOrEmpty(sortOrder) ? "quantity_desc" : "";
            ViewBag.PriceSortParm = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var products = db.Products.Include(p => p.Category);
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString)
                                       || s.Category.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(s => s.Name);
                    break;
                case "cat_name_desc":
                    products = products.OrderByDescending(s => s.Category.Name);
                    break;
                case "quantity_desc":
                    products = products.OrderByDescending(s => s.Amount);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(s => s.Price);
                    break;
                default:
                    products = products.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 9;         
            int pageNumber = (page ?? 1);

            return View(products.ToPagedList(pageNumber,pageSize));
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await AddPhoto(product);
                product.IP = Request.UserHostAddress;

                _repository.Add(product);
                _repository.Save();

                return RedirectToAction("IndexAdmin");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.PhotoUpload != null)
                {
                    await AddPhoto(product);
                }              
                db.Entry(product).State = EntityState.Modified;
                product.ModifiedDate = DateTime.Now;

                db.SaveChanges();

                return RedirectToAction("IndexAdmin");

            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await db.Products.FindAsync(id);
            var photoPath = "";
            photoPath = Request.MapPath(product.Photo);
            if (System.IO.File.Exists(photoPath))
            {
                System.IO.File.Delete(photoPath);
            }
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction("IndexAdmin");
        }

        // ADMIN Methods

        // GET: Products - returns view to product admin page
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> IndexAdmin(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CategoryNameSortParm = String.IsNullOrEmpty(sortOrder) ? "cat_name_desc" : "";
            ViewBag.QuantitySortParm = String.IsNullOrEmpty(sortOrder) ? "quantity_desc" : "";
            ViewBag.PriceSortParm = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var products = db.Products.Include(p => p.Category);
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString)
                                       || s.Category.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(s => s.Name);
                    break;
                case "cat_name_desc":
                    products = products.OrderByDescending(s => s.Category.Name);
                    break;
                case "quantity_desc":
                    products = products.OrderByDescending(s => s.Amount);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(s => s.Price);
                    break;
                default:
                    products = products.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 50;
            int pageNumber = (page ?? 1);
            return View(products.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Data(int id)
        {
            Product product = db.Products.SingleOrDefault(x => x.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return Json(new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Amount = 0,
                Price = product.Price,
                Stock = product.Amount
            } , JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult _RecentProductsPartial()
        {
            var recentProducts = db.Products.OrderByDescending(x => x.AddedDate).Take(8);
            
            return PartialView(recentProducts);
        }


        public PartialViewResult _MainPageProductsPartial()
        {
            var recentProducts = db.Products.OrderByDescending(x => x.ModifiedDate).Take(3);

            return PartialView(recentProducts);
        }

        public PartialViewResult _FeaturedProductsPartial()
        {
            var featuredProducts = db.Products.Where(x => x.Featured).OrderByDescending(x => x.ModifiedDate).Take(4);

            return PartialView(featuredProducts);
        }

        public PartialViewResult _ReviewsPartial()
        {
            var reviews = new Review();

            return PartialView(reviews);
        }

        public PartialViewResult _CategoriesPartial()
        {
            var categories = db.Categories;
            return PartialView(categories);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Helpers

        private async Task<string> AddPhoto(Product productWithoutPhoto)
        {
            var validTypes = new[] { "image/jpeg", "image/pjpeg", "image/png", "image/gif" };
            if (!validTypes.Contains(productWithoutPhoto.PhotoUpload.ContentType))
            {
                ModelState.AddModelError("PhotoUpload", "Please upload either a JPG, GIF, or PNG image.");
            }
            if (productWithoutPhoto.PhotoUpload.ContentLength > 0)
            {
                    // A file was uploaded
                    string uploadPath = "~/Images/Products/";
                    var fileName = Path.GetFileName(productWithoutPhoto.PhotoUpload.FileName);
                    var path = Path.Combine(Server.MapPath(uploadPath), fileName);
                    if (!System.IO.Directory.Exists(uploadPath))
                    {
                        ModelState.AddModelError("PhotoUpload", "The directory of products images doesn't seem to exits. Contact administrator.");
                    }
                    productWithoutPhoto.PhotoUpload.SaveAs(path);
                    productWithoutPhoto.Photo = uploadPath + fileName;  
            }

            return productWithoutPhoto.Photo;
        }


        #endregion

        public async Task<ActionResult> DetailsAdmin(int? id)
        {
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Product product = await db.Products.FindAsync(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
        }
    }
}
