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
    public class RecibosController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public RecibosController(IUnityOfWork unityOfwork)
        {
            _UnityOfWork = unityOfwork;
        }

        // GET: Recibos
        public ActionResult Index()
        {
            var recibos = _UnityOfWork.Recibos.GetEntity().Include(r => r.Alumno);
            return View(recibos.ToList());
        }

        // GET: Recibos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recibo recibo = _UnityOfWork.Recibos.Get(id);
            if (recibo == null)
            {
                return HttpNotFound();
            }
            return View(recibo);
        }

        // GET: Recibos/Create
        public ActionResult Create()
        {
            ViewBag.AlumnoId = new SelectList(_UnityOfWork.Alumnos.GetEntity(), "AlumnoId", "Nombre");
            return View();
        }

        // POST: Recibos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReciboId,Concepto,Monto,FechaEmision,FechaVencimiento,AlumnoId")] Recibo recibo)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Recibos.Add(recibo);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlumnoId = new SelectList(_UnityOfWork.Alumnos.GetEntity(), "AlumnoId", "Nombre", recibo.AlumnoId);
            return View(recibo);
        }

        // GET: Recibos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recibo recibo = _UnityOfWork.Recibos.Get(id);
            if (recibo == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlumnoId = new SelectList(_UnityOfWork.Alumnos.GetEntity(), "AlumnoId", "Nombre", recibo.AlumnoId);
            return View(recibo);
        }

        // POST: Recibos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReciboId,Concepto,Monto,FechaEmision,FechaVencimiento,AlumnoId")] Recibo recibo)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(recibo);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlumnoId = new SelectList(_UnityOfWork.Alumnos.GetEntity(), "AlumnoId", "Nombre", recibo.AlumnoId);
            return View(recibo);
        }

        // GET: Recibos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recibo recibo = _UnityOfWork.Recibos.Get(id);
            if (recibo == null)
            {
                return HttpNotFound();
            }
            return View(recibo);
        }

        // POST: Recibos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recibo recibo = _UnityOfWork.Recibos.Get(id);
            _UnityOfWork.Recibos.Delete(recibo);
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
