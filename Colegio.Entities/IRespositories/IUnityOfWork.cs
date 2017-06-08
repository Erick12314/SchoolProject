using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities.IRespositories
{
    public interface IUnityOfWork : IDisposable
    {
        IAlumnoRepository Alumnos { get; }
        IApoderadoRepository Apoderados { get; }
        IAreaCurricularRepository AreaCurriculares { get; }
        IAsistenciaRepository Asistencias { get; }
        IAulaRepository Aulas { get; }
        ICursoRepository Cursos { get; }
        IDireccionRepository Direcciones { get; }
        IDistritoRepository Distritos { get; }
        IEvaluacionRepository Evaluaciones { get; }
        IGradoRepository Grados { get; }
        IHorarioRepository Horarios { get; }
        IMatriculaRepository Matriculas { get; }
        INotaRepository Notas { get; }
        INivelRepository Niveles { get; }
        IProfesorRepository Profesores { get; }
        IReciboRepository Recibos { get; }
        ISesionRepository Sesiones { get; }
        ITipoEvaluacionRepository TipoEvaluaciones { get; }

        int SaveChanges();

        void StateModified(object entity);
    }
}
