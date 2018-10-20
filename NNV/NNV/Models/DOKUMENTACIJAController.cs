using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NNV.Models
{
    public class DOKUMENTACIJAController : Controller
    {
        private NNVContext db = new NNVContext();

        // GET: DOKUMENTACIJA
        public ActionResult Index()
        {
            return View(db.Dokumentacijas.ToList());
        }

        // GET: DOKUMENTACIJA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dokumentacija dokumentacija = db.Dokumentacijas.Find(id);
            if (dokumentacija == null)
            {
                return HttpNotFound();
            }
            return View(dokumentacija);
        }

        // GET: DOKUMENTACIJA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DOKUMENTACIJA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Dokumenta,Naziv_Dokumenta")] Dokumentacija dokumentacija)
        {
            if (ModelState.IsValid)
            {
                db.Dokumentacijas.Add(dokumentacija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dokumentacija);
        }

        // GET: DOKUMENTACIJA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dokumentacija dokumentacija = db.Dokumentacijas.Find(id);
            if (dokumentacija == null)
            {
                return HttpNotFound();
            }
            return View(dokumentacija);
        }

        // POST: DOKUMENTACIJA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Dokumenta,Naziv_Dokumenta")] Dokumentacija dokumentacija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dokumentacija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dokumentacija);
        }

        // GET: DOKUMENTACIJA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dokumentacija dokumentacija = db.Dokumentacijas.Find(id);
            if (dokumentacija == null)
            {
                return HttpNotFound();
            }
            return View(dokumentacija);
        }

        // POST: DOKUMENTACIJA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dokumentacija dokumentacija = db.Dokumentacijas.Find(id);
            db.Dokumentacijas.Remove(dokumentacija);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
