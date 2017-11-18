using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormularzKontaktowy.Models
{
    public class FkDBList
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

    }
}