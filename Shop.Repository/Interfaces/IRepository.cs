using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Shop.Model.Models;

namespace Shop.Repository.Interfaces
{
    public interface IRepository<TEntity, TKey> : IDisposable where TEntity : BaseEntity
    {
        TEntity Get(TKey id);
        IEnumerable<TEntity> GetAll();

        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> FindMany(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Save();
    }
}
