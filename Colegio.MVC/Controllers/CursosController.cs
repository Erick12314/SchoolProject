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
    public class CursosController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public CursosController(IUnityOfWork unityOfwork)
        {
            _UnityOfWork = unityOfwork;
        }

        // GET: Cursos
        public ActionResult Index()
        {
            var cursos = _UnityOfWork.Cursos.GetEntity().Include(c => c.AreaCurricular);
            return View(cursos.ToList());
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = _UnityOfWork.Cursos.Get(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // GET: Cursos/Create
        public ActionResult Create()
        {
            ViewBag.AreaCurricularId = new SelectList(_UnityOfWork.AreaCurriculares.GetEntity(), "AreaCurricularId", "Descripcion");
            return View();
        }

        // POST: Cursos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CursoId,Descripcion,AreaCurricularId")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Cursos.Add(curso);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaCurricularId = new SelectList(_UnityOfWork.AreaCurriculares.GetEntity(), "AreaCurricularId", "Descripcion", curso.AreaCurricularId);
            return View(curso);
        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = _UnityOfWork.Cursos.Get(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaCurricularId = new SelectList(_UnityOfWork.AreaCurriculares.GetEntity(), "AreaCurricularId", "Descripcion", curso.AreaCurricularId);
            return View(curso);
        }

        // POST: Cursos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CursoId,Descripcion,AreaCurricularId")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(curso);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaCurricularId = new SelectList(_UnityOfWork.AreaCurriculares.GetEntity(), "AreaCurricularId", "Descripcion", curso.AreaCurricularId);
            return View(curso);
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = _UnityOfWork.Cursos.Get(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = _UnityOfWork.Cursos.Get(id);
            _UnityOfWork.Cursos.Delete(curso);
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
