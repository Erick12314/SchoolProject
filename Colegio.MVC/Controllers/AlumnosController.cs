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
    public class AlumnosController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;
            
        public AlumnosController(IUnityOfWork unityOfwork)
        {
            _UnityOfWork = unityOfwork;
        }

        // GET: Alumnos
        public ActionResult Index()
        {
            var alumnos = _UnityOfWork.Alumnos.GetEntity().Include(a => a.Direccion).Include(a => a.Grado).Include(a => a.Nivel);
            return View(alumnos.ToList());
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = _UnityOfWork.Alumnos.Get(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            ViewBag.DireccionId = new SelectList(_UnityOfWork.Direcciones.GetEntity(), "DireccionId", "Descripcion");
            ViewBag.GradoId = new SelectList(_UnityOfWork.Grados.GetEntity(), "GradoId", "Descripcion");
            ViewBag.NivelId = new SelectList(_UnityOfWork.Niveles.GetEntity(), "NivelId", "Descripcion");
            return View();
        }

        // POST: Alumnos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlumnoId,Nombre,ApellidoPaterno,ApellidoMaterno,TipoDocumento,NumeroDocumento,Telefono,Sexo,FechaNacimiento,Usuario,Password,DireccionId,NivelId,GradoId")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Alumnos.Add(alumno);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DireccionId = new SelectList(_UnityOfWork.Direcciones.GetEntity(), "DireccionId", "Descripcion", alumno.DireccionId);
            ViewBag.GradoId = new SelectList(_UnityOfWork.Grados.GetEntity(), "GradoId", "Descripcion", alumno.GradoId);
            ViewBag.NivelId = new SelectList(_UnityOfWork.Niveles.GetEntity(), "NivelId", "Descripcion", alumno.NivelId);
            return View(alumno);
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = _UnityOfWork.Alumnos.Get(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            ViewBag.DireccionId = new SelectList(_UnityOfWork.Direcciones.GetEntity(), "DireccionId", "Descripcion", alumno.DireccionId);
            ViewBag.GradoId = new SelectList(_UnityOfWork.Grados.GetEntity(), "GradoId", "Descripcion", alumno.GradoId);
            ViewBag.NivelId = new SelectList(_UnityOfWork.Niveles.GetEntity(), "NivelId", "Descripcion", alumno.NivelId);
            return View(alumno);
        }

        // POST: Alumnos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlumnoId,Nombre,ApellidoPaterno,ApellidoMaterno,TipoDocumento,NumeroDocumento,Telefono,Sexo,FechaNacimiento,Usuario,Password,DireccionId,NivelId,GradoId")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(alumno);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DireccionId = new SelectList(_UnityOfWork.Direcciones.GetEntity(), "DireccionId", "Descripcion", alumno.DireccionId);
            ViewBag.GradoId = new SelectList(_UnityOfWork.Grados.GetEntity(), "GradoId", "Descripcion", alumno.GradoId);
            ViewBag.NivelId = new SelectList(_UnityOfWork.Niveles.GetEntity(), "NivelId", "Descripcion", alumno.NivelId);
            return View(alumno);
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = _UnityOfWork.Alumnos.Get(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alumno alumno = _UnityOfWork.Alumnos.Get(id);
            _UnityOfWork.Alumnos.Delete(alumno);
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
