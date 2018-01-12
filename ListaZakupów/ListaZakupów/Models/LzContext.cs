using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ListaZakupów.Models
{
    // dziedziczenie po DbContext z Entity Framework
    public class LzContext : DbContext
    {

        public LzContext() : base("TestDB")
        {

        }
        //  Stworzenie listy pól? sprawdzić i poprawić
        public DbSet<LzDBTest> LzDBTest { get; set; }

    }
}