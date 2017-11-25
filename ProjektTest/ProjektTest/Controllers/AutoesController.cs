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
using ProjektTest.ViewModels;

namespace ProjektTest.Controllers
{
    public class AutoesController : Controller
    {

        private IRepoFirst _repoFirst;
        private IAutoBusinessLogic _autoBusinessLogic;
        public AutoesController(IRepoFirst repoFirst, IAutoBusinessLogic autoBusinessLogic)
        {
            _repoFirst = repoFirst;
            _autoBusinessLogic = autoBusinessLogic;
        }
        // GET: CarEntities
        public ActionResult Index()
        {
            var autoVM = new VMAuto { AutoList = new List<Auto>() };
            autoVM.ShowIfAuth = _autoBusinessLogic.CheckIfUserIsAutorize();
            if (autoVM.ShowIfAuth)
            {
                autoVM = _repoFirst.GetWhere(x => x.Id > 0);
            }
            else
            {
                autoVM = _repoFirst.GetWhere(x => x.Id > 0 && x.IsActive);
            }

            return View(autoVM);
        }

        // GET: CarEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto carEntity = _repoFirst.GetWhere(x => x.Id == id.Value).FirstOrDefault();
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
                _repoFirst.Create(carEntity);
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
            Auto carEntity = _repoFirst.GetWhere(x => x.Id == id.Value).FirstOrDefault();
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
                _repoFirst.Update(carEntity);
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
            Auto carEntity = _repoFirst.GetWhere(x => x.Id == id.Value).FirstOrDefault();
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
            Auto carEntity = _repoFirst.GetWhere(x => x.Id == id).FirstOrDefault();
            _repoFirst.Delete(carEntity);
            return RedirectToAction("Index");
        }


    }
}