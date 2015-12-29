using System.Collections.Generic;
using System.Web.Http;
using Shop.Api.Classes;
using Shop.Api.Models;
using Shop.Model.Models;
using Shop.Repository.Repositories;

namespace Shop.Api.Controllers
{
    public class ImagesController : ShopApiController<Image, int>
    {
        public ImagesController()
        {
            _context = ShopContext.Create();
            _repository = new ImageRepository(_context);
        }

        public ImageRepository Repository { get { return _repository as ImageRepository; } }

        public IEnumerable<Image> GetAll()
        {
            return Repository.GetAll();
        }

        public Image Get(int id)
        {
            return Repository.Get(id);
        }

        [HttpPost]
        public Image Post([FromBody] ImageViewModel _image)
        {
            ProductRepository products = new ProductRepository(_context);
            Product product = products.Get(_image.ProductId);
            Image image = new Image {Product = product, Url = _image.Url};
            Repository.Add(image);
            Repository.Save();

            return image;
        }
    }
}
