using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NNV.Models
{
    [Table(name: "Prilozi")]
    public class Prilozi
    {
        [Key]
      
        public int Redni_broj { get; set; }
        [DisplayName("Број документа")]
        public int ID_Dokumenta { get; set; }
        [DisplayName("Број седнице")]
        public int ID_Sednice { get; set; }
        [DisplayName("Путања")]
        public string Putanja { get; set; }
        [DisplayName("Послато")]
        public bool Poslato{ get; set; }
        [DisplayName("Датум слања")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime Datum_slanja { get; set; }
       
        public virtual Dokumentacija Dokumentacijas{ get; set; }
        public virtual Sednice Sednices { get; set; }


    }
   
}