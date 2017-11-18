using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListaZakupów.Models
{
    public class LzDBTest
    {
        public int Id { get; set; }
        public string Produkt { get; set; }
        public int Ilosc { get; set; }
        public double Cena { get; set; }
        public DateTime Czas { get; set; }
        public DateTime? CzasModyfikacji { get; set; }

    }
}