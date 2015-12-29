using System.Collections.Generic;
using Shop.Repository.Repositories;
using System.Web.Http;
using Shop.Model.Models;

namespace Shop.Api.Classes
{
    public class ShopApiController<TEntity, TKey> : ApiController where TEntity : class
    {
        protected Repository<TEntity, TKey> _repository;
        protected ShopContext _context;
    }
}