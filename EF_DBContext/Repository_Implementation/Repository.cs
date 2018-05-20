using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using EF_DBContext.Repository_Contracts;
using System.Data.Entity;

namespace EF_DBContext.Repository_Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        protected DbSet<TEntity> Entity;

        public Repository(DbContext context)
        {
            Context = context;
            Entity = context.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return Entity.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Entity.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Entity.Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Entity.SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            Entity.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Entity.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Entity.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Entity.RemoveRange(entities);
        }
    }
}
