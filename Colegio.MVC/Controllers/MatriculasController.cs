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
    public class MatriculasController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public MatriculasController(IUnityOfWork unityOfwork)
        {
            _UnityOfWork = unityOfwork;
        }

        // GET: Matriculas
        public ActionResult Index()
        {
            var matriculas = _UnityOfWork.Matriculas.GetEntity().Include(m => m.Alumno).Include(m => m.Aula);
            return View(matriculas.ToList());
        }

        // GET: Matriculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = _UnityOfWork.Matriculas.Get(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // GET: Matriculas/Create
        public ActionResult Create()
        {
            ViewBag.AlumnoId = new SelectList(_UnityOfWork.Alumnos.GetEntity(), "AlumnoId", "Nombre");
            ViewBag.AulaId = new SelectList(_UnityOfWork.Aulas.GetEntity(), "AulaId", "Descripcion");
            return View();
        }

        // POST: Matriculas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatriculaId,Year,Observaciones,AlumnoId,AulaId")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Matriculas.Add(matricula);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlumnoId = new SelectList(_UnityOfWork.Alumnos.GetEntity(), "AlumnoId", "Nombre", matricula.AlumnoId);
            ViewBag.AulaId = new SelectList(_UnityOfWork.Aulas.GetEntity(), "AulaId", "Descripcion", matricula.AulaId);
            return View(matricula);
        }

        // GET: Matriculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = _UnityOfWork.Matriculas.Get(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlumnoId = new SelectList(_UnityOfWork.Alumnos.GetEntity(), "AlumnoId", "Nombre", matricula.AlumnoId);
            ViewBag.AulaId = new SelectList(_UnityOfWork.Aulas.GetEntity(), "AulaId", "Descripcion", matricula.AulaId);
            return View(matricula);
        }

        // POST: Matriculas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatriculaId,Year,Observaciones,AlumnoId,AulaId")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(matricula);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlumnoId = new SelectList(_UnityOfWork.Alumnos.GetEntity(), "AlumnoId", "Nombre", matricula.AlumnoId);
            ViewBag.AulaId = new SelectList(_UnityOfWork.Aulas.GetEntity(), "AulaId", "Descripcion", matricula.AulaId);
            return View(matricula);
        }

        // GET: Matriculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = _UnityOfWork.Matriculas.Get(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matricula matricula = _UnityOfWork.Matriculas.Get(id);
            _UnityOfWork.Matriculas.Delete(matricula);
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
