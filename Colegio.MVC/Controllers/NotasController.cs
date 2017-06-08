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
    public class NotasController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public NotasController(IUnityOfWork unityOfwork)
        {
            _UnityOfWork = unityOfwork;
        }

        // GET: Notas
        public ActionResult Index()
        {
            var notas = _UnityOfWork.Notas.GetEntity().Include(n => n.Alumno).Include(n => n.Curso).Include(n => n.Evaluacion);
            return View(notas.ToList());
        }

        // GET: Notas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nota nota = _UnityOfWork.Notas.Get(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            return View(nota);
        }

        // GET: Notas/Create
        public ActionResult Create()
        {
            ViewBag.AlumnoId = new SelectList(_UnityOfWork.Alumnos.GetEntity(), "AlumnoId", "Nombre");
            ViewBag.CursoId = new SelectList(_UnityOfWork.Cursos.GetEntity(), "CursoId", "Descripcion");
            ViewBag.EvaluacionId = new SelectList(_UnityOfWork.Evaluaciones.GetEntity(), "EvaluacionId", "Titulo");
            return View();
        }

        // POST: Notas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NotaId,Puntaje,AlumnoId,CursoId,EvaluacionId")] Nota nota)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Notas.Add(nota);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlumnoId = new SelectList(_UnityOfWork.Alumnos.GetEntity(), "AlumnoId", "Nombre", nota.AlumnoId);
            ViewBag.CursoId = new SelectList(_UnityOfWork.Cursos.GetEntity(), "CursoId", "Descripcion", nota.CursoId);
            ViewBag.EvaluacionId = new SelectList(_UnityOfWork.Evaluaciones.GetEntity(), "EvaluacionId", "Titulo", nota.EvaluacionId);
            return View(nota);
        }

        // GET: Notas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nota nota = _UnityOfWork.Notas.Get(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlumnoId = new SelectList(_UnityOfWork.Alumnos.GetEntity(), "AlumnoId", "Nombre", nota.AlumnoId);
            ViewBag.CursoId = new SelectList(_UnityOfWork.Cursos.GetEntity(), "CursoId", "Descripcion", nota.CursoId);
            ViewBag.EvaluacionId = new SelectList(_UnityOfWork.Evaluaciones.GetEntity(), "EvaluacionId", "Titulo", nota.EvaluacionId);
            return View(nota);
        }

        // POST: Notas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NotaId,Puntaje,AlumnoId,CursoId,EvaluacionId")] Nota nota)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(nota);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlumnoId = new SelectList(_UnityOfWork.Alumnos.GetEntity(), "AlumnoId", "Nombre", nota.AlumnoId);
            ViewBag.CursoId = new SelectList(_UnityOfWork.Cursos.GetEntity(), "CursoId", "Descripcion", nota.CursoId);
            ViewBag.EvaluacionId = new SelectList(_UnityOfWork.Evaluaciones.GetEntity(), "EvaluacionId", "Titulo", nota.EvaluacionId);
            return View(nota);
        }

        // GET: Notas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nota nota = _UnityOfWork.Notas.Get(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            return View(nota);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nota nota = _UnityOfWork.Notas.Get(id);
            _UnityOfWork.Notas.Delete(nota);
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
