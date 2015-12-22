using Shop.Api.Classes;
using Shop.Model.Models;
using Shop.Repository.Interfaces;

namespace Shop.Api.Controllers
{
    public class CategoriesController : PublicRepositoryApiController<Category, int>
    {
        public CategoriesController(IRepository<Category, int> repository) : base(repository)
        {
        }
    }
}
