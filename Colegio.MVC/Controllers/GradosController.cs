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
    public class GradosController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public GradosController(IUnityOfWork unityOfwork)
        {
            _UnityOfWork = unityOfwork;
        }

        // GET: Grados
        public ActionResult Index()
        {
            return View(_UnityOfWork.Grados.GetAll());
        }

        // GET: Grados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grado grado = _UnityOfWork.Grados.Get(id);
            if (grado == null)
            {
                return HttpNotFound();
            }
            return View(grado);
        }

        // GET: Grados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GradoId,Descripcion")] Grado grado)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Grados.Add(grado);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grado);
        }

        // GET: Grados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grado grado = _UnityOfWork.Grados.Get(id);
            if (grado == null)
            {
                return HttpNotFound();
            }
            return View(grado);
        }

        // POST: Grados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GradoId,Descripcion")] Grado grado)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(grado);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grado);
        }

        // GET: Grados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grado grado = _UnityOfWork.Grados.Get(id);
            if (grado == null)
            {
                return HttpNotFound();
            }
            return View(grado);
        }

        // POST: Grados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grado grado = _UnityOfWork.Grados.Get(id);
            _UnityOfWork.Grados.Delete(grado);
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
