using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using PagedList;
using System.Web.Mvc;


namespace NNV.Models
{
    [Table(name: "Clanovi")]
    public class Clanovi
    {
        [Key]
        public int ID_Clana { get; set; }
        [DisplayName("Име и презиме")]
        public string Ime_i_prezime { get; set; }
        [DisplayName("Е-маил")]
        public string Email { get; set; }
        [DisplayName("Активан члан")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "Унесите корисничко име")]

        [Display(Name = "Корисничко име :")]
        [StringLength(30)]

        
        public string Korisnicko_ime { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Lozinka", ErrorMessage = "Лозинка је погрешна")]
        [StringLength(10, ErrorMessage = " Унесите {0} минимум {2} карактера максимално 8", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name ="Лозинка :")]
        [Required(ErrorMessage = "Унесите лозинку")]
        public string Lozinka { get; set; }
        public virtual ICollection<Prisustvo> Prisustvos { get; set; }
    }
}