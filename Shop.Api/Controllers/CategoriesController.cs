using Shop.Api.Classes;
using Shop.Model.Models;
using Shop.Repository.Repositories;

namespace Shop.Api.Controllers
{
    public class CategoriesController : PublicShopApiController<Category, int>
    {
        public CategoriesController()
        {
            Repository = new CategoryRepository(ShopContext.Create());
        }
    }
}
