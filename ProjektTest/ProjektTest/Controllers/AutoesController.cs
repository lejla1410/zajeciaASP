using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjektTest.Models;
using ProjektTest.Repository.Interfaces;
using ProjektTest.BusinessLogic.Interfaces;

namespace ProjektTest.Controllers
{
    public class AutoesController : Controller
    {

        private IRepoFirst _carsRepository;
        private IAutoBusinessLogic _autoBusinessLogic;
        public AutoesController(IRepoFirst carsRepository)
        {
            _carsRepository = carsRepository;
        }
        // GET: CarEntities
        public ActionResult Index()
        {
            return View(_carsRepository.GetWhere(x => x.Id > 0));
        }

        // GET: CarEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto carEntity = _carsRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (carEntity == null)
            {
                return HttpNotFound();
            }
            return View(carEntity);
        }

        // GET: CarEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Auto carEntity)
        {
            if (ModelState.IsValid)
            {
                carEntity.ModPerson = _autoBusinessLogic.CheckIfUserIsAuthAndReturnName();
                _carsRepository.Create(carEntity);
                return RedirectToAction("Index");
            }

            return View(carEntity);
        }

        // GET: CarEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto carEntity = _carsRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (carEntity == null)
            {
                return HttpNotFound();
            }
            return View(carEntity);
        }

        // POST: CarEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Auto carEntity)
        {
            if (ModelState.IsValid)
            {
                _carsRepository.Update(carEntity);
                return RedirectToAction("Index");
            }
            return View(carEntity);
        }

        // GET: CarEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto carEntity = _carsRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (carEntity == null)
            {
                return HttpNotFound();
            }
            return View(carEntity);
        }

        // POST: CarEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auto carEntity = _carsRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            _carsRepository.Delete(carEntity);
            return RedirectToAction("Index");
        }


    }
}