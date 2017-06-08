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
    public class SesionesController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public SesionesController(IUnityOfWork unityOfwork)
        {
            _UnityOfWork = unityOfwork;
        }

        // GET: Sesiones
        public ActionResult Index()
        {
            var sesiones = _UnityOfWork.Sesiones.GetEntity()
                .Include(s => s.Aula)
                .Include(s => s.Curso)
                .Include(s => s.Horario)
                .Include(s => s.Profesor);
            return View(sesiones.ToList());
        }

        // GET: Sesiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sesion sesion = _UnityOfWork.Sesiones.Get(id);
            if (sesion == null)
            {
                return HttpNotFound();
            }
            return View(sesion);
        }

        // GET: Sesiones/Create
        public ActionResult Create()
        {
            ViewBag.AulaId = new SelectList(_UnityOfWork.Aulas.GetEntity(), "AulaId", "Descripcion");
            ViewBag.CursoId = new SelectList(_UnityOfWork.Cursos.GetEntity(), "CursoId", "Descripcion");
            ViewBag.HorarioId = new SelectList(_UnityOfWork.Horarios.GetEntity(), "HorarioId", "Descripcion");
            ViewBag.ProfesorId = new SelectList(_UnityOfWork.Profesores.GetEntity(), "ProfesorId", "Nombre");
            return View();
        }

        // POST: Sesiones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SesionId,Dia,Actividad,HoraInicio,HoraFin,CursoId,ProfesorId,AulaId,HorarioId")] Sesion sesion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Sesiones.Add(sesion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AulaId = new SelectList(_UnityOfWork.Aulas.GetEntity(), "AulaId", "Descripcion", sesion.AulaId);
            ViewBag.CursoId = new SelectList(_UnityOfWork.Cursos.GetEntity(), "CursoId", "Descripcion", sesion.CursoId);
            ViewBag.HorarioId = new SelectList(_UnityOfWork.Horarios.GetEntity(), "HorarioId", "Descripcion", sesion.HorarioId);
            ViewBag.ProfesorId = new SelectList(_UnityOfWork.Profesores.GetEntity(), "ProfesorId", "Nombre", sesion.ProfesorId);
            return View(sesion);
        }

        // GET: Sesiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sesion sesion = _UnityOfWork.Sesiones.Get(id);
            if (sesion == null)
            {
                return HttpNotFound();
            }
            ViewBag.AulaId = new SelectList(_UnityOfWork.Aulas.GetEntity(), "AulaId", "Descripcion", sesion.AulaId);
            ViewBag.CursoId = new SelectList(_UnityOfWork.Cursos.GetEntity(), "CursoId", "Descripcion", sesion.CursoId);
            ViewBag.HorarioId = new SelectList(_UnityOfWork.Horarios.GetEntity(), "HorarioId", "Descripcion", sesion.HorarioId);
            ViewBag.ProfesorId = new SelectList(_UnityOfWork.Profesores.GetEntity(), "ProfesorId", "Nombre", sesion.ProfesorId);
            return View(sesion);
        }

        // POST: Sesiones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SesionId,Dia,Actividad,HoraInicio,HoraFin,CursoId,ProfesorId,AulaId,HorarioId")] Sesion sesion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(sesion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AulaId = new SelectList(_UnityOfWork.Aulas.GetEntity(), "AulaId", "Descripcion", sesion.AulaId);
            ViewBag.CursoId = new SelectList(_UnityOfWork.Cursos.GetEntity(), "CursoId", "Descripcion", sesion.CursoId);
            ViewBag.HorarioId = new SelectList(_UnityOfWork.Horarios.GetEntity(), "HorarioId", "Descripcion", sesion.HorarioId);
            ViewBag.ProfesorId = new SelectList(_UnityOfWork.Profesores.GetEntity(), "ProfesorId", "Nombre", sesion.ProfesorId);
            return View(sesion);
        }

        // GET: Sesiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sesion sesion = _UnityOfWork.Sesiones.Get(id);
            if (sesion == null)
            {
                return HttpNotFound();
            }
            return View(sesion);
        }

        // POST: Sesiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sesion sesion = _UnityOfWork.Sesiones.Get(id);
            _UnityOfWork.Sesiones.Delete(sesion);
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
