using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FormEmail.Models
{

    //  w tym miejscu tworzymy baze danych
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("ContactForm")
        {

        }

        public DbSet<ContactForm> ContactForm { get; set; }
    }
}