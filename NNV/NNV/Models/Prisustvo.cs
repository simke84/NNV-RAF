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
    [Table(name: "Prisustvo")]
    public class Prisustvo
    {
        [Key,Column(Order = 0)]
        public int ID_Clana { get; set; }
        [Key, Column(Order = 1)]
        public int ID_Sednice { get; set; }
        public bool Prisutan { get; set; }
        public bool Opravdano { get; set; }
        public virtual Clanovi Clanovi { get; set; }
        public virtual Sednice Sednice { get; set; }
    }
}