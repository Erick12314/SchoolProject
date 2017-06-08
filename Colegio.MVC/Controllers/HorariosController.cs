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
    public class HorariosController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public HorariosController(IUnityOfWork unityOfwork)
        {
            _UnityOfWork = unityOfwork;
        }

        // GET: Horarios
        public ActionResult Index()
        {
            var horarios = _UnityOfWork.Horarios.GetEntity().Include(h => h.Grado).Include(h => h.Nivel);
            return View(horarios.ToList());
        }

        // GET: Horarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario horario = _UnityOfWork.Horarios.Get(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        // GET: Horarios/Create
        public ActionResult Create()
        {
            ViewBag.GradoId = new SelectList(_UnityOfWork.Grados.GetEntity(), "GradoId", "Descripcion");
            ViewBag.NivelId = new SelectList(_UnityOfWork.Niveles.GetEntity(), "NivelId", "Descripcion");

            return View();
        }

        // POST: Horarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HorarioId,Descripcion,GradoId,NivelId")] Horario horario)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Horarios.Add(horario);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GradoId = new SelectList(_UnityOfWork.Grados.GetEntity(), "GradoId", "Descripcion", horario.GradoId);
            ViewBag.NivelId = new SelectList(_UnityOfWork.Niveles.GetEntity(), "NivelId", "Descripcion", horario.NivelId);

            return View(horario);
        }

        // GET: Horarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario horario = _UnityOfWork.Horarios.Get(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            ViewBag.GradoId = new SelectList(_UnityOfWork.Grados.GetEntity(), "GradoId", "Descripcion", horario.GradoId);
            ViewBag.NivelId = new SelectList(_UnityOfWork.Niveles.GetEntity(), "NivelId", "Descripcion", horario.NivelId);
            return View(horario);
        }

        // POST: Horarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HorarioId,Descripcion,GradoId,NivelId")] Horario horario)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(horario);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GradoId = new SelectList(_UnityOfWork.Grados.GetEntity(), "GradoId", "Descripcion", horario.GradoId);
            ViewBag.NivelId = new SelectList(_UnityOfWork.Niveles.GetEntity(), "NivelId", "Descripcion", horario.NivelId);
            return View(horario);
        }

        // GET: Horarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario horario = _UnityOfWork.Horarios.Get(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Horario horario = _UnityOfWork.Horarios.Get(id);
            _UnityOfWork.Horarios.Delete(horario);
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
