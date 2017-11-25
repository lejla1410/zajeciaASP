using ProjektTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektTest.ViewModels
{
    public class VMAuto
    {
        public Auto Type { get; set; }
        public List<Auto> AutoList{ get; set; }
        public bool ShowIfAuth { get; set; }
    }
}