using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PilotProject.Models;

namespace PilotProject.Controllers
{   
    public class MedicsController : Controller
    {
		private readonly IMedicTypeRepository medictypeRepository;
		private readonly IMedicRepository medicRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public MedicsController() : this(new MedicTypeRepository(), new MedicRepository())
        {
        }

        public MedicsController(IMedicTypeRepository medictypeRepository, IMedicRepository medicRepository)
        {
			this.medictypeRepository = medictypeRepository;
			this.medicRepository = medicRepository;
        }

        //
        // GET: /Medics/

        public ViewResult Index()
        {
            return View(medicRepository.AllIncluding(medic => medic.flowsheets));
        }

        //
        // GET: /Medics/Details/5

        public ViewResult Details(int id)
        {
            return View(medicRepository.Find(id));
        }

        //
        // GET: /Medics/Create

        public ActionResult Create()
        {
			ViewBag.PossiblemedicTypes = medictypeRepository.All;
            return View();
        } 

        //
        // POST: /Medics/Create

        [HttpPost]
        public ActionResult Create(Medic medic)
        {
            if (ModelState.IsValid) {
                medicRepository.InsertOrUpdate(medic);
                medicRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossiblemedicTypes = medictypeRepository.All;
				return View();
			}
        }
        
        //
        // GET: /Medics/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossiblemedicTypes = medictypeRepository.All;
             return View(medicRepository.Find(id));
        }

        //
        // POST: /Medics/Edit/5

        [HttpPost]
        public ActionResult Edit(Medic medic)
        {
            if (ModelState.IsValid) {
                medicRepository.InsertOrUpdate(medic);
                medicRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossiblemedicTypes = medictypeRepository.All;
				return View();
			}
        }

        //
        // GET: /Medics/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(medicRepository.Find(id));
        }

        //
        // POST: /Medics/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            medicRepository.Delete(id);
            medicRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                medictypeRepository.Dispose();
                medicRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

