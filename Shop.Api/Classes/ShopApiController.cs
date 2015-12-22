using System.Collections.Generic;
using System.Web.Http;
using Shop.Repository.Interfaces;

namespace Shop.Api.Classes
{
    public class ShopApiController<TEntity, TKey> : ApiController where TEntity : class
    {
        protected readonly IRepository<TEntity, TKey> Repository;

        public ShopApiController(IRepository<TEntity, TKey> repository)
        {
            Repository = repository;
        }

        public TEntity Get(TKey id)
        {
            return Repository.Get(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Repository.GetAll();
        } 
    }
}