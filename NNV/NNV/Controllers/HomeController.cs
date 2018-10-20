using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NNV.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using NNV.Controllers;
using NNV.Properties;
using NNV;



namespace NNV.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public ActionResult Login1(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                NNVContext db = new NNVContext();
                var user = (from userlist in db.Clanovis
                            where userlist.Korisnicko_ime == login.Korisnicko_ime && userlist.Lozinka == login.Lozinka
                            select new
                            {
                                userlist.ID_Clana,
                                userlist.Korisnicko_ime
                            }).ToList();

                //string admin = "nena";
                // string lozinka = "333";

                if (user.FirstOrDefault() != null && login.Korisnicko_ime == "nena" && login.Lozinka == "333")//dodao if za admina
                {

                    Session["Korisnicko_ime"] = user.FirstOrDefault().Korisnicko_ime;
                    Session["ID_Clana"] = user.FirstOrDefault().ID_Clana;
                    return RedirectToAction("ADMIN", "Home");







                }






                else if (user.FirstOrDefault() != null)
                {
                    Session["Korisnicko_ime"] = user.FirstOrDefault().Korisnicko_ime;
                    Session["ID_Clana"] = user.FirstOrDefault().ID_Clana;
                    return RedirectToAction("NNV", "Home");
                }

            }
            return View(login);
        }


        //[HttpPost]
        //public ActionResult Login1(LoginModel login)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        NNVContext db = new NNVContext();
        //        var user = (from userlist in db.Clanovis
        //                    where userlist.Korisnicko_ime == login.Korisnicko_ime && userlist.Lozinka == login.Lozinka
        //                    select new
        //                    {
        //                        userlist.ID_Clana,
        //                        userlist.Korisnicko_ime
        //                    }).ToList();

        //        //string admin = "nena";
        //        // string lozinka = "333";

        //        if (user.FirstOrDefault() != null && login.Korisnicko_ime == "nena" && login.Lozinka == "333")//dodao if za admina
        //        {

        //            Session["Korisnicko_ime"] = user.FirstOrDefault().Korisnicko_ime;
        //            Session["ID_Clana"] = user.FirstOrDefault().ID_Clana;
        //            return RedirectToAction("ADMIN", "Home");







        //        }






        //        else if (user.FirstOrDefault() != null)
        //        {
        //            Session["Korisnicko_ime"] = user.FirstOrDefault().Korisnicko_ime;
        //            Session["ID_Clana"] = user.FirstOrDefault().ID_Clana;
        //            return RedirectToAction("NNV", "Home");
        //        }

        //    }
        //    return View(login);
        //}

        public ActionResult WelcomePage()
        {
            return View();
        }




        public ActionResult NNV()
        {

            return View();
        }




        public ActionResult ADMIN()
        {

            return View();
        }

    }



}