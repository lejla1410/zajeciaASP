using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GenericRepository.Models;

namespace GenericRepository.Controllers
{
    public class FirstFormsController : Controller
    {
        private GenDB db = new GenDB();

        // GET: FirstForms
        public ActionResult Index()
        {
            return View();
        }

        // GET: FirstForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirstForm firstForm = db.FirstForms.Find(id);
            if (firstForm == null)
            {
                return HttpNotFound();
            }
            return View(firstForm);
        }

        // GET: FirstForms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FirstForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FirstForm firstForm)
        {
            if (ModelState.IsValid)
            {
                db.FirstForms.Add(firstForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(firstForm);
        }

        // GET: FirstForms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirstForm firstForm = db.FirstForms.Find(id);
            if (firstForm == null)
            {
                return HttpNotFound();
            }
            return View(firstForm);
        }

        // POST: FirstForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Produkt,Cena,Ilosc")] FirstForm firstForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(firstForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(firstForm);
        }

        // GET: FirstForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirstForm firstForm = db.FirstForms.Find(id);
            if (firstForm == null)
            {
                return HttpNotFound();
            }
            return View(firstForm);
        }

        // POST: FirstForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FirstForm firstForm = db.FirstForms.Find(id);
            db.FirstForms.Remove(firstForm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
