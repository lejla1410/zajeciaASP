using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ListaZakupów.Models;

namespace ListaZakupów.Controllers
{
    public class LzDBTestsController : Controller
    {
        private LzContext db = new LzContext();

        // GET: LzDBTests
        public ActionResult Index()
        {
            return View(db.LzDBTest.ToList());
        }

        // GET: LzDBTests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LzDBTest lzDBTest = db.LzDBTest.Find(id);
            if (lzDBTest == null)
            {
                return HttpNotFound();
            }
            return View(lzDBTest);
        }

        // GET: LzDBTests/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: LzDBTests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Produkt,Ilosc,Cena,Czas")] LzDBTest lzDBTest)
        {
            if (ModelState.IsValid)
            {
                lzDBTest.Czas = DateTime.Now;
                db.LzDBTest.Add(lzDBTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lzDBTest);
        }

        // GET: LzDBTests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LzDBTest lzDBTest = db.LzDBTest.Find(id);
            if (lzDBTest == null)
            {
                return HttpNotFound();
            }
            return View(lzDBTest);
        }

        // POST: LzDBTests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Produkt,Ilosc,Cena,Czas")] LzDBTest lzDBTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lzDBTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lzDBTest);
        }

        // GET: LzDBTests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LzDBTest lzDBTest = db.LzDBTest.Find(id);
            if (lzDBTest == null)
            {
                return HttpNotFound();
            }
            return View(lzDBTest);
        }

        // POST: LzDBTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LzDBTest lzDBTest = db.LzDBTest.Find(id);
            db.LzDBTest.Remove(lzDBTest);
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
