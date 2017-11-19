using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FormEmail.Models;
using FormEmail.Service;

namespace FormEmail.Controllers
{
    public class ContactFormsController : Controller
    {

        private EmailService _emailService;
        public ContactFormsController()
        {
            _emailService = new EmailService();
        }
        private ApplicationContext db = new ApplicationContext();

        // GET: ContactForms
        public ActionResult Index()
        {
            return View(db.ContactForm.ToList());
        }

        // GET: ContactForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactForm contactForm = db.ContactForm.Find(id);
            if (contactForm == null)
            {
                return HttpNotFound();
            }
            return View(contactForm);
        }

        // GET: ContactForms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                db.ContactForm.Add(contactForm);
                db.SaveChanges();
                var message= _emailService.SendMessage(contactForm);
                _emailService.SendEmail(message);

                return RedirectToAction("Index");
            }

            return View(contactForm);
        }

    

        // GET: ContactForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactForm contactForm = db.ContactForm.Find(id);
            if (contactForm == null)
            {
                return HttpNotFound();
            }
            return View(contactForm);
        }

        // POST: ContactForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactForm contactForm = db.ContactForm.Find(id);
            db.ContactForm.Remove(contactForm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
