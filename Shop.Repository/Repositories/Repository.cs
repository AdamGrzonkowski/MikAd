using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Shop.Model.Models;
using Shop.Repository.Interfaces;

namespace Shop.Repository.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : BaseEntity
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Get(TKey id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public IEnumerable<TEntity> FindMany(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public void Add(TEntity entity)
        {
            entity.AddedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            Context.Set<TEntity>().Add(entity);
        }


        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.AddedDate = DateTime.Now;
                entity.ModifiedDate = DateTime.Now;
            }
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public void Save()
        {
            Context.SaveChanges();
        }


        public void Dispose()
        {
            Save();
            Context.Dispose();
        }
    }
}
