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
    public class EvaluacionesController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public EvaluacionesController(IUnityOfWork unityOfwork)
        {
            _UnityOfWork = unityOfwork;
        }

        // GET: Evaluaciones
        public ActionResult Index()
        {
            var evaluaciones = _UnityOfWork.Evaluaciones.GetEntity().Include(e => e.TipoEvaluacion);
            return View(evaluaciones.ToList());
        }

        // GET: Evaluaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = _UnityOfWork.Evaluaciones.Get(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // GET: Evaluaciones/Create
        public ActionResult Create()
        {
            ViewBag.TipoEvaluacionId = new SelectList(_UnityOfWork.TipoEvaluaciones.GetEntity(), "TipoEvaluacionId", "Descripcion");
            return View();
        }

        // POST: Evaluaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EvaluacionId,Titulo,TipoEvaluacionId")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Evaluaciones.Add(evaluacion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoEvaluacionId = new SelectList(_UnityOfWork.TipoEvaluaciones.GetEntity(), "TipoEvaluacionId", "Descripcion", evaluacion.TipoEvaluacionId);
            return View(evaluacion);
        }

        // GET: Evaluaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = _UnityOfWork.Evaluaciones.Get(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoEvaluacionId = new SelectList(_UnityOfWork.TipoEvaluaciones.GetEntity(), "TipoEvaluacionId", "Descripcion", evaluacion.TipoEvaluacionId);
            return View(evaluacion);
        }

        // POST: Evaluaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EvaluacionId,Titulo,TipoEvaluacionId")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(evaluacion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoEvaluacionId = new SelectList(_UnityOfWork.TipoEvaluaciones.GetEntity(), "TipoEvaluacionId", "Descripcion", evaluacion.TipoEvaluacionId);
            return View(evaluacion);
        }

        // GET: Evaluaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = _UnityOfWork.Evaluaciones.Get(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // POST: Evaluaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluacion evaluacion = _UnityOfWork.Evaluaciones.Get(id);
            _UnityOfWork.Evaluaciones.Delete(evaluacion);
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
