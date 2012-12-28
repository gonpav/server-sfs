using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PilotProject.Models;

namespace PilotProject.DAL
{
    public class UnitOfWork : IDisposable
    {
        private SFSContext context = new SFSContext();
        private GenericRepository<Medic> medicRepository;
        private GenericRepository<MedicType> medicTypeRepository;

        public GenericRepository<Medic> MedicRepository
        {
            get
            {
                if (this.medicRepository == null)
                {
                    this.medicRepository = new GenericRepository<Medic>(context);
                }
                return this.medicRepository;
            }
        }

        public GenericRepository<MedicType> MedicTypeRepository
        {
            get
            {
                if (this.medicTypeRepository == null)
                {
                    this.medicTypeRepository = new GenericRepository<MedicType>(context);
                }
                return this.medicTypeRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}