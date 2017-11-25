using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjektTest.Models
{
    public class BazaDB : DbContext
    {

        public BazaDB() : base("Baza Aut Klientów")
        {

        }
        public DbSet<Auto> LzDBTest { get; set; }
    }
}