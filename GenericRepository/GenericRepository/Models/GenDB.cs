using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GenericRepository.Models
{
    public class GenDB : DbContext
    {
        public GenDB() : base("FirstForm")
        {

        }

        
    }
}