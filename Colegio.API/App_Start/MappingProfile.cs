using AutoMapper;
using Colegio.Entities;
using Colegio.Entities.DTO;
using Colegio.Entities.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Colegio.API.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Alumno, AlumnoDTO>();
            CreateMap<AlumnoDTO, Alumno>();

            CreateMap<Apoderado, ApoderadoDTO>();
            CreateMap<ApoderadoDTO, Apoderado>();

            CreateMap<Asistencia, AsistenciaDTO>();
            CreateMap<AsistenciaDTO, Asistencia>();

            CreateMap<AreaCurricular, AreaCurricularDTO>();
            CreateMap<AreaCurricularDTO, AreaCurricular>();

            CreateMap<Aula, AulaDTO>();
            CreateMap<AulaDTO, Aula>();

            CreateMap<Curso, CursoDTO>();
            CreateMap<CursoDTO, Curso>();

            CreateMap<Direccion, DireccionDTO>();
            CreateMap<DireccionDTO, Direccion>();

            CreateMap<Distrito, DistritoDTO>();
            CreateMap<DistritoDTO, Distrito>();

            CreateMap<Evaluacion, EvaluacionDTO>();
            CreateMap<EvaluacionDTO, Evaluacion>();

            CreateMap<Grado, GradoDTO>();
            CreateMap<GradoDTO, Grado>();

            CreateMap<Horario, HorarioDTO>();
            CreateMap<HorarioDTO, Horario>();

            CreateMap<Matricula, MatriculaDTO>();
            CreateMap<MatriculaDTO, Matricula>();

            CreateMap<Nivel, NivelDTO>();
            CreateMap<NivelDTO, Nivel>();

            CreateMap<Nota, NotaDTO>();
            CreateMap<NotaDTO, Nota>();

            CreateMap<Profesor, ProfesorDTO>();
            CreateMap<ProfesorDTO, Profesor>();

            CreateMap<Recibo, ReciboDTO>();
            CreateMap<ReciboDTO, Recibo>();

            CreateMap<Sesion, SesionDTO>();
            CreateMap<SesionDTO, Sesion>();

            CreateMap<TipoEvaluacion, TipoEvaluacionDTO>();
            CreateMap<TipoEvaluacionDTO, TipoEvaluacion>();
        }
    }
}