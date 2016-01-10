using System.Linq;
using System.Net.Http;
using Shop.Repository.Repositories;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Shop.DataEntry;
using Shop.Model.Models;

namespace Shop.Api.Classes
{
    public class ShopApiController<TEntity, TKey> : ApiController where TEntity : BaseEntity
    {
        protected Repository<TEntity, TKey> _repository;
        protected ShopContext _context;

        public User LoggedUser
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name);
            }
        }
    }
}