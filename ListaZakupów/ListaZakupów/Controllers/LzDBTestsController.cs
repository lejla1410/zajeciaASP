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
        //powstanie nowego elementu do bazy danych z LzContext 
        private LzContext _db = new LzContext();

        // GET: LzDBTests
        public ActionResult Index()
        {
            // stworzenie z bazy danych listę
            return View(_db.LzDBTest.ToList());
        }

        // GET: LzDBTests/Details/5
        public ActionResult Details(int? id)
        {
            // jeśli ID jest nullem to zwróci: Równoważne stanu HTTP 400. BadRequest Wskazuje, 
            //czy żądanie jest niezrozumiałe przez serwer. BadRequest jest wysyłany, gdy błąd nie ma zastosowanie,
            //lub jeśli dokładny błąd jest nieznany lub nie ma swój własny kod błędu.

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // jeśli ID jest ok to baza go wyszukuje
            LzDBTest lzDBTest = _db.LzDBTest.Find(id);

            // jeśli baza nasza nie istnieje 
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

            // Atrybuty 
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public ActionResult Create( LzDBTest lzDBTest)
        {
            if (ModelState.IsValid)
            {
                lzDBTest.Czas = DateTime.Now;
                lzDBTest.CzasModyfikacji = DateTime.Now;
                _db.LzDBTest.Add(lzDBTest);
                _db.SaveChanges();
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
            LzDBTest lzDBTest = _db.LzDBTest.Find(id);
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
        public ActionResult Edit( LzDBTest lzDBTest)
        {
            if (ModelState.IsValid)
            {
                lzDBTest.CzasModyfikacji = DateTime.Now;
                _db.Entry(lzDBTest).State = EntityState.Modified;
                _db.SaveChanges();
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
            LzDBTest lzDBTest = _db.LzDBTest.Find(id);
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
            LzDBTest lzDBTest = _db.LzDBTest.Find(id);
            _db.LzDBTest.Remove(lzDBTest);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
