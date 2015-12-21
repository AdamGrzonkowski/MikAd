using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Shop.Repository.Interfaces;

namespace Shop.Api.Classes
{
    public class ShopApiController<TEntity, TKey> : ApiController where TEntity : class
    {
        protected readonly IRepository<TEntity, TKey> repository;

        public ShopApiController(IRepository<TEntity, TKey> repository)
        {
            this.repository = repository;
        }

        public TEntity Get(TKey id)
        {
            return repository.Get(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        } 
    }
}