using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PilotProject.Models;

namespace PilotProject.Controllers
{   
    public class MedicTypesController : Controller
    {
		private readonly IMedicTypeRepository medictypeRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public MedicTypesController() : this(new MedicTypeRepository())
        {
        }

        public MedicTypesController(IMedicTypeRepository medictypeRepository)
        {
			this.medictypeRepository = medictypeRepository;
        }

        //
        // GET: /MedicTypes/

        public ViewResult Index()
        {
            return View(medictypeRepository.AllIncluding(medictype => medictype.medics));
        }

        //
        // GET: /MedicTypes/Details/5

        public ViewResult Details(int id)
        {
            return View(medictypeRepository.Find(id));
        }

        //
        // GET: /MedicTypes/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /MedicTypes/Create

        [HttpPost]
        public ActionResult Create(MedicType medictype)
        {
            if (ModelState.IsValid) {
                medictypeRepository.InsertOrUpdate(medictype);
                medictypeRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /MedicTypes/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(medictypeRepository.Find(id));
        }

        //
        // POST: /MedicTypes/Edit/5

        [HttpPost]
        public ActionResult Edit(MedicType medictype)
        {
            if (ModelState.IsValid) {
                medictypeRepository.InsertOrUpdate(medictype);
                medictypeRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /MedicTypes/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(medictypeRepository.Find(id));
        }

        //
        // POST: /MedicTypes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            medictypeRepository.Delete(id);
            medictypeRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                medictypeRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

