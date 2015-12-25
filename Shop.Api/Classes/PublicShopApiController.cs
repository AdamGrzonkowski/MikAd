using System.Collections.Generic;

namespace Shop.Api.Classes
{
    public class PublicShopApiController<TEntity, TKey> : ShopApiController<TEntity, TKey> where TEntity : class 
    {
        public TEntity Get(TKey id)
        {
            return Repository.Get(id);
        }

        IEnumerable<TEntity> GetAll()
        {
            return Repository.GetAll();
        } 
    }
}