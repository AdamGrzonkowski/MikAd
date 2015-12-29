using System.Collections.Generic;
using Shop.Api.Classes;
using Shop.Model.Models;
using Shop.Repository.Repositories;

namespace Shop.Api.Controllers
{
    public class ImagesController : ShopApiController<Image, int>
    {
        public ImagesController()
        {
            _repository = new ImageRepository(ShopContext.Create());
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
    }
}
