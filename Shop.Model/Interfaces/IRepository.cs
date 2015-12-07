using System;
using System.Linq;

namespace Shop.Model.Interfaces
{
    interface IRepository<TEntity, TKey> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(TKey id);
        TKey Add(TEntity entity);
        void Update(TKey id, TEntity entity);
        void Delete(TEntity entity);
        void Delete(TKey id);
    }
}
