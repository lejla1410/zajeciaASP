﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormEmail.Models
{
    public class ContactForm
    {
        public int Id { get; set; }
        // dzięki temu może pobrac ustawienia dot.Emaila
        [EmailAddress]
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}