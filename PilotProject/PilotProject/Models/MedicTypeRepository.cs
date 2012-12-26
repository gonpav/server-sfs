using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PilotProject.Models
{ 
    public class MedicTypeRepository : IMedicTypeRepository
    {
        SFFContext context = new SFFContext();

        public IQueryable<MedicType> All
        {
            get { return context.MedicTypes; }
        }

        public IQueryable<MedicType> AllIncluding(params Expression<Func<MedicType, object>>[] includeProperties)
        {
            IQueryable<MedicType> query = context.MedicTypes;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public MedicType Find(int id)
        {
            return context.MedicTypes.Find(id);
        }

        public void InsertOrUpdate(MedicType medictype)
        {
            if (medictype.medicTypeID == default(int)) {
                // New entity
                context.MedicTypes.Add(medictype);
            } else {
                // Existing entity
                context.Entry(medictype).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var medictype = context.MedicTypes.Find(id);
            context.MedicTypes.Remove(medictype);
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

    public interface IMedicTypeRepository : IDisposable
    {
        IQueryable<MedicType> All { get; }
        IQueryable<MedicType> AllIncluding(params Expression<Func<MedicType, object>>[] includeProperties);
        MedicType Find(int id);
        void InsertOrUpdate(MedicType medictype);
        void Delete(int id);
        void Save();
    }
}