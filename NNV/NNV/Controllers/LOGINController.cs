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
    public class LOGINController : Controller
    {

       // [HttpPost] stari akcioni metod
       // public ActionResult Login1(LoginModel login)
      //  {
           // if (ModelState.IsValid)
          //  {
               // NNVContext db = new NNVContext();
              //  var user = (from userlist in db.Clanovis
                          //  where userlist.Korisnicko_ime == login.Korisnicko_ime && userlist.Lozinka == login.Lozinka
                          //  select new
                          //  {
                              //  userlist.ID_Clana,
                             //   userlist.Korisnicko_ime
                         //   }).ToList();

                //string admin = "nena";  stara sifra i username za admina koriscena tokom testiranja
                // string lozinka = "333";





                //if (user.FirstOrDefault() != null && login.Korisnicko_ime == "nena" && login.Lozinka == "333")//dodao if za admina
               // {

                   // Session["Korisnicko_ime"] = user.FirstOrDefault().Korisnicko_ime;
                   // Session["ID_Clana"] = user.FirstOrDefault().ID_Clana;
                   // return RedirectToAction("ADMIN", "Home");







                //}






              //  else if (user.FirstOrDefault() != null)
               // {
                 //   Session["Korisnicko_ime"] = user.FirstOrDefault().Korisnicko_ime;
                 //   Session["ID_Clana"] = user.FirstOrDefault().ID_Clana;
                 //   return RedirectToAction("NNV", "Home");
                //}

           // }
           // return View(login);
       // }

        public ActionResult Prva()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Prva(LoginModel login)
        {
            
             if (ModelState.IsValid)


                {
                    NNVContext db = new NNVContext();
                    var user = (from userlist in db.Clanovis
                                where userlist.Korisnicko_ime == login.Korisnicko_ime && userlist.Lozinka == login.Lozinka
                                select new
                                {
                                    userlist.Lozinka,
                                    userlist.Korisnicko_ime
                                }).ToList();

                //string admin = "nena"; staro!
                // string lozinka = "333"; staro!

                 if (user.FirstOrDefault() != null && login.Korisnicko_ime == "deki" && login.Lozinka == "123")//dodao if za admina
                {

                    Session["Korisnicko_ime"] = user.FirstOrDefault().Korisnicko_ime;
                    Session["ID_Clana"] = user.FirstOrDefault().Lozinka;
                    return RedirectToAction("ADMIN", "Home");
                 }

                else if (user.FirstOrDefault() != null)
                {
                    Session["Korisnicko_ime"] = user.FirstOrDefault().Korisnicko_ime;
                    Session["ID_Clana"] = user.FirstOrDefault().Lozinka;
                    return RedirectToAction("NNV", "Home");
                }

                else 
                {

                    ViewBag.Message = string.Format("Погрешно корисничко име или лозинка. Унесите валидне податке!");
                    return View();
                       
                    
                }


                








            }
                return View(login);
            

           
            
            
        }



        public ActionResult WelcomePage()
        {
            return View();
        }






       
            }
        }



    
