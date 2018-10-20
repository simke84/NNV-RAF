
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
    public class CLANOVIController : Controller
    {
        private NNVContext db = new NNVContext();

        public ActionResult Index(string option, string search, int? pageNumber, string sort)
        {

            //if the sort parameter is null or empty then we are initializing the value as descending name  
            ViewBag.SortByName = string.IsNullOrEmpty(sort) ? "descending name" : "";
            //if the sort value is gender then we are initializing the value as descending gender  
            ViewBag.SortByGender = sort == "Gender" ? "descending gender" : "Gender";

            //here we are converting the db.Students to AsQueryable so that we can invoke all the extension methods on variable records.  
            var records = db.Clanovis.AsQueryable();

            if (option == "Zapisnik")
            {
                records = records.Where(x => x.Korisnicko_ime.Contains(search) || search == null);
            }
            else if (option == "Ucionica")
            {
                records = records.Where(x => x.Email.Contains(search) || search == null);
            }
            else
            {
                records = records.Where(x => x.Ime_i_prezime.ToString().Contains(search) || search == null);
            }

            switch (sort)
            {

                case "descending name":
                    records = records.OrderByDescending(x => x.Ime_i_prezime);
                    break;

                case "descending gender":
                    records = records.OrderByDescending(x => x.Email);
                    break;

                case "Gender":
                    records = records.OrderBy(x => x.Email);
                    break;

                default:
                    records = records.OrderBy(x => x.Ime_i_prezime);
                    break;

            }
            return View(records.ToPagedList(pageNumber ?? 1, 4));
        }
































        // GET: CLANOVI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clanovi clanovi = db.Clanovis.Find(id);
            if (clanovi == null)
            {
                return HttpNotFound();
            }
            return View(clanovi);
        }

        // GET: CLANOVI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CLANOVI/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Clana,Ime_i_prezime,Email,Status,Korisnicko_ime,Lozinka")] Clanovi clanovi)
        {
            if (ModelState.IsValid)
            {
                db.Clanovis.Add(clanovi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clanovi);
        }

        // GET: CLANOVI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clanovi clanovi = db.Clanovis.Find(id);
            if (clanovi == null)
            {
                return HttpNotFound();
            }
            return View(clanovi);
        }

        // POST: CLANOVI/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Clana,Ime_i_prezime,Email,Status,Korisnicko_ime,Lozinka")] Clanovi clanovi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clanovi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clanovi);
        }

        // GET: CLANOVI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clanovi clanovi = db.Clanovis.Find(id);
            if (clanovi == null)
            {
                return HttpNotFound();
            }
            return View(clanovi);
        }

        // POST: CLANOVI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clanovi clanovi = db.Clanovis.Find(id);
            db.Clanovis.Remove(clanovi);
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

        // public ActionResult Indexx(string option, string search, int? pageNumber, string sort)
        //{

        //if the sort parameter is null or empty then we are initializing the value as descending name  
        // ViewBag.SortByName = string.IsNullOrEmpty(sort) ? "descending name" : "";
        //if the sort value is gender then we are initializing the value as descending gender  
        // ViewBag.SortByGender = sort == "Gender" ? "descending gender" : "Gender";

        //here we are converting the db.Students to AsQueryable so that we can invoke all the extension methods on variable records.  
        // var records = db.Clanovis.AsQueryable();







        //  if (option == "Zapisnik")
        // {
        //    records = records.Where(x => x.Korisnicko_ime.Contains(search) || search == null);
        // }
        //  else if (option == "Ucionica")
        //{
        //      records = records.Where(x => x.Email.Contains(search) || search == null);
        // }
        //else
        //{
        // records = records.Where(x => x.Ime_i_prezime.ToString().Contains(search) || search == null);
        //}

        //  switch (sort)
        //{

        // case "descending name":
        //  records = records.OrderByDescending(x => x.Ime_i_prezime);
        // break;

        // case "descending gender":
        // records = records.OrderByDescending(x => x.Email);
        // break;

        //case "Gender":
        // records = records.OrderBy(x => x.Email);
        //  break;

        //default:
        // records = records.OrderBy(x => x.Ime_i_prezime);
        // break;

        //}
        //return View(records.ToPagedList(pageNumber?? 1, 4));





        // }



        public ActionResult Indexx(string option, string search, int? pageNumber, string sort)
        {

            //if the sort parameter is null or empty then we are initializing the value as descending name  
            ViewBag.SortByName = string.IsNullOrEmpty(sort) ? "descending name" : "";
            //if the sort value is gender then we are initializing the value as descending gender  
            ViewBag.SortByGender = sort == "Gender" ? "descending gender" : "Gender";

            //here we are converting the db.Students to AsQueryable so that we can invoke all the extension methods on variable records.  
            var records = db.Clanovis.AsQueryable();

            if (option == "Zapisnik")
            {
                records = records.Where(x => x.Korisnicko_ime.Contains(search) || search == null);
            }
            else if (option == "Ucionica")
            {
                records = records.Where(x => x.Email.Contains(search) || search == null);
            }
            else
            {
                records = records.Where(x => x.Ime_i_prezime.ToString().Contains(search) || search == null);
            }

            switch (sort)
            {

                case "descending name":
                    records = records.OrderByDescending(x => x.Ime_i_prezime);
                    break;

                case "descending gender":
                    records = records.OrderByDescending(x => x.Email);
                    break;

                case "Gender":
                    records = records.OrderBy(x => x.Email);
                    break;

                default:
                    records = records.OrderBy(x => x.Ime_i_prezime);
                    break;

            }
            return View(records.ToPagedList(pageNumber ?? 1, 4));
        }





    }
}

