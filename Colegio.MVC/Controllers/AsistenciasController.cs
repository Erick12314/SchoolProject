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
    public class AsistenciasController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public AsistenciasController(IUnityOfWork unityOfwork)
        {
            _UnityOfWork = unityOfwork;
        }

        // GET: Asistencias
        public ActionResult Index()
        {
            var asistencias = _UnityOfWork.Asistencias.GetEntity().Include(a => a.Alumno);
            return View(asistencias.ToList());
        }

        // GET: Asistencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = _UnityOfWork.Asistencias.Get(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // GET: Asistencias/Create
        public ActionResult Create()
        {
            ViewBag.AlumnoId = new SelectList(_UnityOfWork.Alumnos.GetEntity(), "AlumnoId", "Nombre");
            return View();
        }

        // POST: Asistencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AsistenciaId,Fecha,Estado,AlumnoId")] Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Asistencias.Add(asistencia);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlumnoId = new SelectList(_UnityOfWork.Alumnos.GetEntity(), "AlumnoId", "Nombre", asistencia.AlumnoId);
            return View(asistencia);
        }

        // GET: Asistencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = _UnityOfWork.Asistencias.Get(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlumnoId = new SelectList(_UnityOfWork.Alumnos.GetEntity(), "AlumnoId", "Nombre", asistencia.AlumnoId);
            return View(asistencia);
        }

        // POST: Asistencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AsistenciaId,Fecha,Estado,AlumnoId")] Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(asistencia);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlumnoId = new SelectList(_UnityOfWork.Alumnos.GetEntity(), "AlumnoId", "Nombre", asistencia.AlumnoId);
            return View(asistencia);
        }

        // GET: Asistencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = _UnityOfWork.Asistencias.Get(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // POST: Asistencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asistencia asistencia = _UnityOfWork.Asistencias.Get(id);
            _UnityOfWork.Asistencias.Delete(asistencia);
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
