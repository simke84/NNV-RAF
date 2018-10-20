using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NNV.Models;

namespace NNV.Controllers
{
    public class PRISUSTVOController : Controller
    {
        private NNVContext db = new NNVContext();

        // GET: PRISUSTVO
        public ActionResult Index()
        {
            var prisustvos = db.Prisustvos.Include(p => p.Clanovi).Include(p => p.Sednice);
            return View(prisustvos.ToList());
        }

        // GET: PRISUSTVO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prisustvo prisustvo = db.Prisustvos.Find(id);
            if (prisustvo == null)
            {
                return HttpNotFound();
            }
            return View(prisustvo);
        }

        // GET: PRISUSTVO/Create
        public ActionResult Create()
        {
            ViewBag.ID_Clana = new SelectList(db.Clanovis, "ID_Clana", "Ime_i_prezime");
            ViewBag.ID_Sednice = new SelectList(db.Sednices, "ID_Sednice", "Ucionica");
            return View();
        }

        // POST: PRISUSTVO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Clana,ID_Sednice,Prisutan,Opravdano")] Prisustvo prisustvo)
        {
            if (ModelState.IsValid)
            {
                db.Prisustvos.Add(prisustvo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Clana = new SelectList(db.Clanovis, "ID_Clana", "Ime_i_prezime", prisustvo.ID_Clana);
            ViewBag.ID_Sednice = new SelectList(db.Sednices, "ID_Sednice", "Ucionica", prisustvo.ID_Sednice);
            return View(prisustvo);
        }

        // GET: PRISUSTVO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prisustvo prisustvo = db.Prisustvos.Find(id);
            if (prisustvo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Clana = new SelectList(db.Clanovis, "ID_Clana", "Ime_i_prezime", prisustvo.ID_Clana);
            ViewBag.ID_Sednice = new SelectList(db.Sednices, "ID_Sednice", "Ucionica", prisustvo.ID_Sednice);
            return View(prisustvo);
        }

        // POST: PRISUSTVO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Clana,ID_Sednice,Prisutan,Opravdano")] Prisustvo prisustvo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prisustvo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Clana = new SelectList(db.Clanovis, "ID_Clana", "Ime_i_prezime", prisustvo.ID_Clana);
            ViewBag.ID_Sednice = new SelectList(db.Sednices, "ID_Sednice", "Ucionica", prisustvo.ID_Sednice);
            return View(prisustvo);
        }

        // GET: PRISUSTVO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prisustvo prisustvo = db.Prisustvos.Find(id);
            if (prisustvo == null)
            {
                return HttpNotFound();
            }
            return View(prisustvo);
        }

        // POST: PRISUSTVO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prisustvo prisustvo = db.Prisustvos.Find(id);
            db.Prisustvos.Remove(prisustvo);
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
