using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Colegio.Entities;
using Colegio.Persistence;
using Colegio.Entities.IRespositories;
using Colegio.Entities.DTO;
using AutoMapper;

namespace Colegio.API.Controllers.API
{
    public class AlumnosController : ApiController
    {
        private readonly IUnityOfWork _UnityOfWork;

        public AlumnosController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var Alumnos = _UnityOfWork.Alumnos.GetAll();

            if (Alumnos == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var AlumnosDTO = new List<AlumnoDTO>();

            foreach (var alumno in Alumnos)
                AlumnosDTO.Add(Mapper.Map<Alumno, AlumnoDTO>(alumno));

            return Ok(AlumnosDTO);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var Alumno = _UnityOfWork.Alumnos.Get(id);

            if (Alumno == null)
                return NotFound();

            return Ok(Mapper.Map<Alumno, AlumnoDTO>(Alumno));
        }

        [HttpPut]
        public IHttpActionResult Update(int id, AlumnoDTO AlumnoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var alumnoInPersistence = _UnityOfWork.Alumnos.Get(id);
            if (alumnoInPersistence == null)
                return NotFound();

            Mapper.Map<AlumnoDTO, Alumno>(AlumnoDTO, alumnoInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(AlumnoDTO);
        }

        [HttpPost]
        public IHttpActionResult Create(AlumnoDTO alumnoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var alumno = Mapper.Map<AlumnoDTO, Alumno>(alumnoDTO);

            _UnityOfWork.Alumnos.Add(alumno);
            _UnityOfWork.SaveChanges();

            alumnoDTO.AlumnoId = alumno.AlumnoId;

            return Created(new Uri(Request.RequestUri + "/" + alumno.AlumnoId), alumnoDTO);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var alumnoInDataBase = _UnityOfWork.Alumnos.Get(id);
            if (alumnoInDataBase == null)
                return NotFound();

            _UnityOfWork.Alumnos.Delete(alumnoInDataBase);
            _UnityOfWork.SaveChanges();

            return Ok();
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