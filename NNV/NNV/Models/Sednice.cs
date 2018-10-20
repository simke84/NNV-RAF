using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using PagedList;


namespace NNV.Models
{
    [Table(name: "Sednice")]
    public class Sednice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [DisplayName("Рб. седнице")]
        public int ID_Sednice { get; set; }
        [DisplayName("Датум одржавања")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime Datum { get; set; }
        [DisplayName("Редовна седница")]
        public bool Vrsta_redovna { get; set; }
        [DisplayName("Место одржавања")]
        public string Ucionica { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Записник")]
        public string Zapisnik { get; set; }
        [DisplayName("Позив")]
        public string Poziv { get; set; }
        public virtual ICollection<Prisustvo>Prisustvos { get; set; }
        public virtual ICollection<Prilozi> Prilozis{ get; set; }
    }


}