using FormularzKontaktowy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FormularzKontaktowy.Models
{
    public class FormContext : DbContext
    {

        public FormContext() : base("FormularzK")
        {

        }
        public DbSet<FkDBList> LzDBTest { get; set; }


    }
}