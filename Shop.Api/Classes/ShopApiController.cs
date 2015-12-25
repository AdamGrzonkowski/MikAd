using Shop.Repository.Repositories;
using System.Web.Http;

namespace Shop.Api.Classes
{
    public class ShopApiController<TEntity, TKey> : ApiController where TEntity : class
    {
        protected Repository<TEntity, TKey> Repository;
    }
}