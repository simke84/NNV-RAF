using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NNV.Models
{
    public class NNVContext : DbContext
    {
        public NNVContext() : base("NNV.Properties.Settings.Setting1") { }
        public DbSet<Clanovi>Clanovis {get; set; }
        public DbSet<Prisustvo> Prisustvos { get; set; }
        public DbSet<Sednice> Sednices { get; set; }
        public DbSet<Prilozi> Prilozis { get; set; }
        public DbSet<Dokumentacija> Dokumentacijas { get; set; }

    }
}