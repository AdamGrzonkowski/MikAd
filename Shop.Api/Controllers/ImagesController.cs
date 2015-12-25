using Shop.Api.Classes;
using Shop.Model.Models;
using Shop.Repository.Repositories;

namespace Shop.Api.Controllers
{
    public class ImagesController : PublicShopApiController<Image, int>
    {
        public ImagesController()
        {
            Repository = new ImageRepository(ShopContext.Create());
        }
    }
}
