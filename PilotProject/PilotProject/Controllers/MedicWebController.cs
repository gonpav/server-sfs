using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PilotProject.Controllers
{
    public class MedicWebController : Controller
    {
        private SFFContext db = new SFFContext();

        //
        // GET: /MedicWeb/

        public ActionResult Index()
        {
            return View(db.Medics.ToList());
        }

        //
        // GET: /MedicWeb/Details/5

        public ActionResult Details(int id = 0)
        {
            Medic medic = db.Medics.Find(id);
            if (medic == null)
            {
                return HttpNotFound();
            }
            return View(medic);
        }

        //
        // GET: /MedicWeb/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MedicWeb/Create

        [HttpPost]
        public ActionResult Create(Medic medic)
        {
            if (ModelState.IsValid)
            {
                db.Medics.Add(medic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medic);
        }

        //
        // GET: /MedicWeb/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Medic medic = db.Medics.Find(id);
            if (medic == null)
            {
                return HttpNotFound();
            }
            return View(medic);
        }

        //
        // POST: /MedicWeb/Edit/5

        [HttpPost]
        public ActionResult Edit(Medic medic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medic).State = EntityState.Modified;
                db.SaveChanges();
                SignalR.MessageHub.SendMedicUpdate(medic);
                return RedirectToAction("Index");
            }
            return View(medic);
        }

        //
        // GET: /MedicWeb/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Medic medic = db.Medics.Find(id);
            if (medic == null)
            {
                return HttpNotFound();
            }
            return View(medic);
        }

        //
        // POST: /MedicWeb/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Medic medic = db.Medics.Find(id);
            db.Medics.Remove(medic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}