using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Data;
using System.Data.Entity;
using PilotProject.Models;

namespace PilotProject.DAL
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal SFSContext context;

        public GenericRepository(SFSContext context)
        {
            this.context = context;
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetById(object id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = context.Set<TEntity>().Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                context.Set<TEntity>().Attach(entityToDelete);
            }
            context.Set<TEntity>().Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            context.Set<TEntity>().Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
    public interface IGenericRepository : IDisposable
    {
        IQueryable<MedicType> All { get; }
        IQueryable<MedicType> AllIncluding(params Expression<Func<MedicType, object>>[] includeProperties);
        MedicType Find(int id);
        void InsertOrUpdate(MedicType medictype);
        void Delete(int id);
        void Save();
    }
}