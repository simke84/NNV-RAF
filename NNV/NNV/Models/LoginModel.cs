using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace NNV.Models
{
    public class LoginModel
    {
        
        [Required(ErrorMessage = "Унесите корисничко име")]

        [Display(Name = "Корисничко име :")]
        [StringLength(30)]
        public string Korisnicko_ime { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Lozinka", ErrorMessage = "Лозинка је погрешна")]
        [Required(ErrorMessage = "Унесите лозинку")]
        [DataType(DataType.Password)]
        [Display(Name = "Лозинка :")]
        [StringLength(10)]
        public string Lozinka { get; set; }

    }


}
