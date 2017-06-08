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
    public class ApoderadosController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public ApoderadosController(IUnityOfWork unityOfwork)
        {
            _UnityOfWork = unityOfwork;
        }

        // GET: Apoderados
        public ActionResult Index()
        {
            return View(_UnityOfWork.Apoderados.GetAll());
        }

        // GET: Apoderados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apoderado apoderado = _UnityOfWork.Apoderados.Get(id);
            if (apoderado == null)
            {
                return HttpNotFound();
            }
            return View(apoderado);
        }

        // GET: Apoderados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apoderados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApoderadoId,Nombre,Apellidos,Telefono,Correo")] Apoderado apoderado)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Apoderados.Add(apoderado);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(apoderado);
        }

        // GET: Apoderados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apoderado apoderado = _UnityOfWork.Apoderados.Get(id);
            if (apoderado == null)
            {
                return HttpNotFound();
            }
            return View(apoderado);
        }

        // POST: Apoderados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApoderadoId,Nombre,Apellidos,Telefono,Correo")] Apoderado apoderado)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(apoderado);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(apoderado);
        }

        // GET: Apoderados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apoderado apoderado = _UnityOfWork.Apoderados.Get(id);
            if (apoderado == null)
            {
                return HttpNotFound();
            }
            return View(apoderado);
        }

        // POST: Apoderados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Apoderado apoderado = _UnityOfWork.Apoderados.Get(id);
            _UnityOfWork.Apoderados.Delete(apoderado);
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
