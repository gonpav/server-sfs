using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PilotProject.DAL;
using PilotProject.Models;

namespace PilotProject.Services
{
    public class MedicsService
    {
        private UnitOfWork context = new UnitOfWork();
        public IEnumerable<Medic> GetAll()
        {
            return context.MedicRepository.Get();
        }

        public Medic GetById(int id)
        {
            return context.MedicRepository.GetById(id);
        }
    }
}