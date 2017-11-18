using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ListaZakupów.Models
{
    public class LzContext : DbContext
    {

        public LzContext() : base("TestDB")
        {

        }
        public DbSet<LzDBTest> LzDBTest { get; set; }

    }
}