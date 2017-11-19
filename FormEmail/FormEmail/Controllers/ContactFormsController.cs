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
using FormEmail.Repository;

namespace FormEmail.Controllers
{
    public class ContactFormsController : Controller
    {

        private EmailService _emailService;
        private ContactFormRepository _contactRepository;

        public ContactFormsController()
        {
            _emailService = new EmailService();
            _contactRepository = new ContactFormRepository();

        }
       

        // GET: ContactForms
        public ActionResult Index()
        {
            return View(_contactRepository.GetWhere(x=> x.Id>0));
        }

        // GET: ContactForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //lambda
            ContactForm contactForm = _contactRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
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
                _contactRepository.Create(contactForm); 
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
            // Value dodaliśmy bo jest int? (nullable)
            ContactForm contactForm = _contactRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (contactForm == null)
            {
                return HttpNotFound();
            }
            return View(contactForm);
        }

        // POST: ContactForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        // tutaj potwierdzamy usunęcie wiersza
        public ActionResult DeleteConfirmed(int id)
        {
            ContactForm contactForm = _contactRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            _contactRepository.Delete(contactForm);
            return RedirectToAction("Index");
        }

       
    }
}
