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
    public class AulasController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public AulasController(IUnityOfWork unityOfwork)
        {
            _UnityOfWork = unityOfwork;
        }

        // GET: Aulas
        public ActionResult Index()
        {
            var aulas = _UnityOfWork.Aulas.GetEntity().Include(a => a.Grado).Include(a => a.Nivel);
            return View(aulas.ToList());
        }

        // GET: Aulas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aula aula = _UnityOfWork.Aulas.Get(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            return View(aula);
        }

        // GET: Aulas/Create
        public ActionResult Create()
        {
            ViewBag.GradoId = new SelectList(_UnityOfWork.Grados.GetEntity(), "GradoId", "Descripcion");
            ViewBag.NivelId = new SelectList(_UnityOfWork.Niveles.GetEntity(), "NivelId", "Descripcion");
            return View();
        }

        // POST: Aulas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AulaId,Descripcion,Seccion,GradoId,NivelId")] Aula aula)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Aulas.Add(aula);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GradoId = new SelectList(_UnityOfWork.Grados.GetEntity(), "GradoId", "Descripcion", aula.GradoId);
            ViewBag.NivelId = new SelectList(_UnityOfWork.Niveles.GetEntity(), "NivelId", "Descripcion", aula.NivelId);
            return View(aula);
        }

        // GET: Aulas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aula aula = _UnityOfWork.Aulas.Get(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            ViewBag.GradoId = new SelectList(_UnityOfWork.Grados.GetEntity(), "GradoId", "Descripcion", aula.GradoId);
            ViewBag.NivelId = new SelectList(_UnityOfWork.Niveles.GetEntity(), "NivelId", "Descripcion", aula.NivelId);
            return View(aula);
        }

        // POST: Aulas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AulaId,Descripcion,Seccion,GradoId,NivelId")] Aula aula)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(aula);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GradoId = new SelectList(_UnityOfWork.Grados.GetEntity(), "GradoId", "Descripcion", aula.GradoId);
            ViewBag.NivelId = new SelectList(_UnityOfWork.Niveles.GetEntity(), "NivelId", "Descripcion", aula.NivelId);
            return View(aula);
        }

        // GET: Aulas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aula aula = _UnityOfWork.Aulas.Get(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            return View(aula);
        }

        // POST: Aulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aula aula = _UnityOfWork.Aulas.Get(id);
            _UnityOfWork.Aulas.Delete(aula);
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
