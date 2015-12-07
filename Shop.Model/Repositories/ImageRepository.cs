using System.Linq;
using Shop.Model.Interfaces;
using Shop.Model.Models;

namespace Shop.Model.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private ShopContext _shopContext;

        public ImageRepository()
        {
            _shopContext = new ShopContext();
        }

        public void Dispose()
        {
            _shopContext.Dispose();
        }

        public IQueryable<Image> GetAll()
        {
            return _shopContext.Images;
        }

        public Image GetById(int id)
        {
            return _shopContext.Images.SingleOrDefault(x => x.Id == id);
        }

        public int Add(Image entity)
        {
            _shopContext.Images.Add(entity);
            _shopContext.SaveChanges();

            return entity.Id;
        }

        public void Update(int id, Image entity)
        {
            Image dbImage = GetById(id);
            dbImage.Product = entity.Product;
            dbImage.ProductId = entity.ProductId;
            _shopContext.SaveChanges();
        }

        public void Delete(Image entity)
        {
            _shopContext.Images.Remove(entity);
        }

        public void Delete(int id)
        {
            Image entity = GetById(id);
            _shopContext.Images.Remove(entity);
        }
    }
}