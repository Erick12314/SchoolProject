﻿using System;
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
    public class TipoEvaluacionesController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public TipoEvaluacionesController(IUnityOfWork unityOfwork)
        {
            _UnityOfWork = unityOfwork;
        }

        // GET: TipoEvaluaciones
        public ActionResult Index()
        {
            return View(_UnityOfWork.TipoEvaluaciones.GetAll());
        }

        // GET: TipoEvaluaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEvaluacion tipoEvaluacion = _UnityOfWork.TipoEvaluaciones.Get(id);
            if (tipoEvaluacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoEvaluacion);
        }

        // GET: TipoEvaluaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEvaluaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoEvaluacionId,Descripcion")] TipoEvaluacion tipoEvaluacion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.TipoEvaluaciones.Add(tipoEvaluacion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoEvaluacion);
        }

        // GET: TipoEvaluaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEvaluacion tipoEvaluacion = _UnityOfWork.TipoEvaluaciones.Get(id);
            if (tipoEvaluacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoEvaluacion);
        }

        // POST: TipoEvaluaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoEvaluacionId,Descripcion")] TipoEvaluacion tipoEvaluacion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(tipoEvaluacion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoEvaluacion);
        }

        // GET: TipoEvaluaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEvaluacion tipoEvaluacion = _UnityOfWork.TipoEvaluaciones.Get(id);
            if (tipoEvaluacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoEvaluacion);
        }

        // POST: TipoEvaluaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEvaluacion tipoEvaluacion = _UnityOfWork.TipoEvaluaciones.Get(id);
            _UnityOfWork.TipoEvaluaciones.Delete(tipoEvaluacion);
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
