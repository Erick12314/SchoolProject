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
    public class DireccionesController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public DireccionesController(IUnityOfWork unityOfwork)
        {
            _UnityOfWork = unityOfwork;
        }

        // GET: Direcciones
        public ActionResult Index()
        {
            var direcciones = _UnityOfWork.Direcciones.GetEntity().Include(d => d.Distrito);
            return View(direcciones.ToList());
        }

        // GET: Direcciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = _UnityOfWork.Direcciones.Get(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // GET: Direcciones/Create
        public ActionResult Create()
        {
            ViewBag.DistritoId = new SelectList(_UnityOfWork.Distritos.GetEntity(), "DistritoId", "Descripcion");
            return View();
        }

        // POST: Direcciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DireccionId,Descripcion,DistritoId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Direcciones.Add(direccion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistritoId = new SelectList(_UnityOfWork.Distritos.GetEntity(), "DistritoId", "Descripcion", direccion.DistritoId);
            return View(direccion);
        }

        // GET: Direcciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = _UnityOfWork.Direcciones.Get(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistritoId = new SelectList(_UnityOfWork.Distritos.GetEntity(), "DistritoId", "Descripcion", direccion.DistritoId);
            return View(direccion);
        }

        // POST: Direcciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DireccionId,Descripcion,DistritoId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(direccion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistritoId = new SelectList(_UnityOfWork.Distritos.GetEntity(), "DistritoId", "Descripcion", direccion.DistritoId);
            return View(direccion);
        }

        // GET: Direcciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = _UnityOfWork.Direcciones.Get(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Direcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Direccion direccion = _UnityOfWork.Direcciones.Get(id);
            _UnityOfWork.Direcciones.Delete(direccion);
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
