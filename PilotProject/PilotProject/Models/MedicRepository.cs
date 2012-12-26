using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PilotProject.Models
{ 
    public class MedicRepository : IMedicRepository
    {
        SFFContext context = new SFFContext();

        public IQueryable<Medic> All
        {
            get { return context.Medics; }
        }

        public IQueryable<Medic> AllIncluding(params Expression<Func<Medic, object>>[] includeProperties)
        {
            IQueryable<Medic> query = context.Medics;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Medic Find(int id)
        {
            return context.Medics.Find(id);
        }

        public void InsertOrUpdate(Medic medic)
        {
            if (medic.medicID == default(int)) {
                // New entity
                context.Medics.Add(medic);
            } else {
                // Existing entity
                context.Entry(medic).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var medic = context.Medics.Find(id);
            context.Medics.Remove(medic);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface IMedicRepository : IDisposable
    {
        IQueryable<Medic> All { get; }
        IQueryable<Medic> AllIncluding(params Expression<Func<Medic, object>>[] includeProperties);
        Medic Find(int id);
        void InsertOrUpdate(Medic medic);
        void Delete(int id);
        void Save();
    }
}