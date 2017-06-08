using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Colegio.Entities;
using Colegio.Persistence;
using Colegio.Entities.IRespositories;

namespace Colegio.MVC.Controllers
{
    public class AreaCurricularesController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public AreaCurricularesController(IUnityOfWork unityOfwork)
        {
            _UnityOfWork = unityOfwork;
        }

        // GET: AreaCurriculares
        public ActionResult Index()
        {
            return View(_UnityOfWork.AreaCurriculares.GetAll());
        }

        // GET: AreaCurriculares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaCurricular areaCurricular = _UnityOfWork.AreaCurriculares.Get(id);
            if (areaCurricular == null)
            {
                return HttpNotFound();
            }
            return View(areaCurricular);
        }

        // GET: AreaCurriculares/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AreaCurriculares/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AreaCurricularId,Descripcion")] AreaCurricular areaCurricular)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.AreaCurriculares.Add(areaCurricular);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(areaCurricular);
        }

        // GET: AreaCurriculares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaCurricular areaCurricular = _UnityOfWork.AreaCurriculares.Get(id);
            if (areaCurricular == null)
            {
                return HttpNotFound();
            }
            return View(areaCurricular);
        }

        // POST: AreaCurriculares/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AreaCurricularId,Descripcion")] AreaCurricular areaCurricular)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(areaCurricular);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(areaCurricular);
        }

        // GET: AreaCurriculares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaCurricular areaCurricular = _UnityOfWork.AreaCurriculares.Get(id);
            if (areaCurricular == null)
            {
                return HttpNotFound();
            }
            return View(areaCurricular);
        }

        // POST: AreaCurriculares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AreaCurricular areaCurricular = _UnityOfWork.AreaCurriculares.Get(id);
            _UnityOfWork.AreaCurriculares.Delete(areaCurricular);
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
