using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Colegio.Entities.Entitites;
using Colegio.Persistence;
using Colegio.Entities.IRespositories;

namespace Colegio.MVC.Controllers
{
    public class NivelesController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public NivelesController(IUnityOfWork unityOfwork)
        {
            _UnityOfWork = unityOfwork;
        }

        // GET: Niveles
        public ActionResult Index()
        {
            return View(_UnityOfWork.Niveles.GetAll());
        }

        // GET: Niveles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nivel nivel = _UnityOfWork.Niveles.Get(id);
            if (nivel == null)
            {
                return HttpNotFound();
            }
            return View(nivel);
        }

        // GET: Niveles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Niveles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NivelId,Descripcion")] Nivel nivel)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Niveles.Add(nivel);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nivel);
        }

        // GET: Niveles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nivel nivel = _UnityOfWork.Niveles.Get(id);
            if (nivel == null)
            {
                return HttpNotFound();
            }
            return View(nivel);
        }

        // POST: Niveles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NivelId,Descripcion")] Nivel nivel)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(nivel);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nivel);
        }

        // GET: Niveles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nivel nivel = _UnityOfWork.Niveles.Get(id);
            if (nivel == null)
            {
                return HttpNotFound();
            }
            return View(nivel);
        }

        // POST: Niveles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nivel nivel = _UnityOfWork.Niveles.Get(id);
            _UnityOfWork.Niveles.Delete(nivel);
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
