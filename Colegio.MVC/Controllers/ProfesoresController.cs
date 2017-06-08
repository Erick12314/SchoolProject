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
    public class ProfesoresController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public ProfesoresController(IUnityOfWork unityOfwork)
        {
            _UnityOfWork = unityOfwork;
        }

        // GET: Profesores
        public ActionResult Index()
        {
            var profesores = _UnityOfWork.Profesores.GetEntity().Include(p => p.Direccion);
            return View(profesores.ToList());
        }

        // GET: Profesores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesor profesor = _UnityOfWork.Profesores.Get(id);
            if (profesor == null)
            {
                return HttpNotFound();
            }
            return View(profesor);
        }

        // GET: Profesores/Create
        public ActionResult Create()
        {
            ViewBag.DireccionId = new SelectList(_UnityOfWork.Direcciones.GetEntity(), "DireccionId", "Descripcion");
            return View();
        }

        // POST: Profesores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfesorId,Nombre,ApellidoPaterno,ApellidoMaterno,TipoDocumento,NumeroDocumento,Telefono,Sexo,FechaNacimiento,Usuario,Password,DireccionId")] Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Profesores.Add(profesor);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DireccionId = new SelectList(_UnityOfWork.Direcciones.GetEntity(), "DireccionId", "Descripcion", profesor.DireccionId);
            return View(profesor);
        }

        // GET: Profesores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesor profesor = _UnityOfWork.Profesores.Get(id);
            if (profesor == null)
            {
                return HttpNotFound();
            }
            ViewBag.DireccionId = new SelectList(_UnityOfWork.Direcciones.GetEntity(), "DireccionId", "Descripcion", profesor.DireccionId);
            return View(profesor);
        }

        // POST: Profesores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfesorId,Nombre,ApellidoPaterno,ApellidoMaterno,TipoDocumento,NumeroDocumento,Telefono,Sexo,FechaNacimiento,Usuario,Password,DireccionId")] Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(profesor);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DireccionId = new SelectList(_UnityOfWork.Direcciones.GetEntity(), "DireccionId", "Descripcion", profesor.DireccionId);
            return View(profesor);
        }

        // GET: Profesores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesor profesor = _UnityOfWork.Profesores.Get(id);
            if (profesor == null)
            {
                return HttpNotFound();
            }
            return View(profesor);
        }

        // POST: Profesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profesor profesor = _UnityOfWork.Profesores.Get(id);
            _UnityOfWork.Profesores.Delete(profesor);
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
