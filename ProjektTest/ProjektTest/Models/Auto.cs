using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjektTest.Models
{
    public class Auto 
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public int NrRejestracyjny { get; set; }
    }
}