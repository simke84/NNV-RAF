
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NNV.Models;
using PagedList;

namespace NNV.Controllers
{
    public class SEDNICEController : Controller
    {
        private NNVContext db = new NNVContext();

        // GET: SEDNICE
        public ActionResult Index(string option, string search, int? pageNumber, string sort)
        {

            //if the sort parameter is null or empty then we are initializing the value as descending name  
            ViewBag.SortByName = string.IsNullOrEmpty(sort) ? "descending name" : "";
            //if the sort value is gender then we are initializing the value as descending gender  
            ViewBag.SortByGender = sort == "Gender" ? "descending gender" : "Gender";

            //here we are converting the db.Students to AsQueryable so that we can invoke all the extension methods on variable records.  
            var records = db.Sednices.AsQueryable();

            if (option == "Zapisnik")
            {
                records = records.Where(x => x.Zapisnik.Contains(search) || search == null);
            }
            else if (option == "Ucionica")
            {
                records = records.Where(x => x.Ucionica.Contains(search) || search == null);
            }
            else
            {
                records = records.Where(x => x.Datum.ToString().Contains(search) || search == null);
            }

            switch (sort)
            {

                case "descending name":
                    records = records.OrderByDescending(x => x.Datum);
                    break;

                case "descending gender":
                    records = records.OrderByDescending(x => x.Ucionica);
                    break;

                case "Gender":
                    records = records.OrderBy(x => x.Ucionica);
                    break;

                default:
                    records = records.OrderBy(x => x.Datum);
                    break;

            }
            return View(records.ToPagedList(pageNumber ?? 1, 4));
        }

        // GET: SEDNICE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sednice sednice = db.Sednices.Find(id);
            if (sednice == null)
            {
                return HttpNotFound();
            }
            return View(sednice);
        }

        // GET: SEDNICE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SEDNICE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Sednice,Datum,Vrsta_redovna,Ucionica,Zapisnik,Poziv")] Sednice sednice)
        {
            if (ModelState.IsValid)
            
            {
                db.Sednices.Add(sednice);
                db.SaveChanges();
                return RedirectToAction("Indexx");


                
            }
        

            return View(sednice);
        }

        // GET: SEDNICE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sednice sednice = db.Sednices.Find(id);
            if (sednice == null)
            {
                return HttpNotFound();
            }
            return View(sednice);
        }

        // POST: SEDNICE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Sednice,Datum,Vrsta_redovna,Ucionica,Zapisnik,Poziv")] Sednice sednice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sednice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Indexx");
            }
            return View(sednice);
        }

        // GET: SEDNICE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sednice sednice = db.Sednices.Find(id);
            if (sednice == null)
            {
                return HttpNotFound();
            }
            return View(sednice);
        }

        // POST: SEDNICE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sednice sednice = db.Sednices.Find(id);
            db.Sednices.Remove(sednice);
            db.SaveChanges();
            return RedirectToAction("Indexx");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Lejaut3()
        {
            return View();
        }


        public ActionResult Indexx(string option, string search, int? pageNumber, string sort)//novi akcioni metod za admin stranu
        {

            //if the sort parameter is null or empty then we are initializing the value as descending name  
            ViewBag.SortByName = string.IsNullOrEmpty(sort) ? "descending name" : "";
            //if the sort value is gender then we are initializing the value as descending gender  
            ViewBag.SortByGender = sort == "Gender" ? "descending gender" : "Gender";

            //here we are converting the db.Students to AsQueryable so that we can invoke all the extension methods on variable records.  
            var records = db.Sednices.AsQueryable();

            if (option == "Zapisnik")
            {
                records = records.Where(x => x.Zapisnik.Contains(search) || search == null);
            }
            else if (option == "Ucionica")
            {
                records = records.Where(x => x.Ucionica.Contains(search) || search == null);
            }
            else
            {
                records = records.Where(x => x.Datum.ToString().Contains(search) || search == null);
            }

            switch (sort)
            {

                case "descending name":
                    records = records.OrderByDescending(x => x.Datum);
                    break;

                case "descending gender":
                    records = records.OrderByDescending(x => x.Ucionica);
                    break;

                case "Gender":
                    records = records.OrderBy(x => x.Ucionica);
                    break;

                default:
                    records = records.OrderBy(x => x.Datum);
                    break;

            }
            return View(records.ToPagedList(pageNumber ?? 1, 4));
        }





    }
}
