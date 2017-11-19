using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenericRepository.Models
{
    public class FirstForm
    {
        public int Id { get; set; }
        public string Produkt { get; set; }
        public double Cena { get; set; }
        public int Ilosc  { get; set; }
    }

    //Dbset<>
}