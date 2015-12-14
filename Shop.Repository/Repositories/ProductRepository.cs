using System.Linq;
using Shop.Model.Models;
using Shop.Repository.Interfaces;

namespace Shop.Repository.Repositories
{
    class ProductRepository : IProductRepository
    {
        private readonly ShopContext _shopContext;

        public ProductRepository()
        {
            _shopContext = new ShopContext();
        }

        public void Dispose()
        {
            _shopContext.Dispose();
        }

        public IQueryable<Product> GetAll()
        {
            return _shopContext.Products;
        }

        public Product GetById(int id)
        {
            return _shopContext.Products.SingleOrDefault(x => x.Id == id);
        }

        public int Add(Product entity)
        {
            _shopContext.Products.Add(entity);
            _shopContext.SaveChanges();

            return entity.Id;
        }

        public void Update(int id, Product entity)
        {
            Product dbProduct = GetById(id);
            dbProduct.Category = entity.Category;
            dbProduct.CategoryId = entity.CategoryId;
            dbProduct.Amount = entity.Amount;
            dbProduct.Description = entity.Description;
            dbProduct.Price = entity.Price;
            dbProduct.Properties = entity.Properties;
        }

        public void Delete(Product entity)
        {
            _shopContext.Products.Remove(entity);
        }

        public void Delete(int id)
        {
            Product dbProduct = GetById(id);
            _shopContext.Products.Remove(dbProduct);
        }

        public IQueryable<Product> GetAllInStock()
        {
            return _shopContext.Products.Where(x => x.Amount > 0);
        }

        public IQueryable<Product> GetByCategory(int categoryId)
        {
            return _shopContext.Products.Where(x => x.CategoryId == categoryId);
        }

        public IQueryable<Product> GetByCategory(Category category)
        {
            return _shopContext.Products.Where(x => x.Category == category);
        }

        public IQueryable<Product> GetByCategory(string categoryName)
        {
            return _shopContext.Products.Where(x => x.Category.Name == categoryName);
        }

        public IQueryable<Product> GetByProperty(string propertyName, string propertyValue)
        {
            return _shopContext.Products.Where(x => x.Properties[propertyName] == propertyValue);
        }

        public IQueryable<Product> GetByPrice(decimal price)
        {
            return _shopContext.Products.Where(x => x.Price == price);
        }
    }
}