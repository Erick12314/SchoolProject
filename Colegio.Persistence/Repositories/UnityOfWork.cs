using Colegio.Entities.IRespositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Persistence.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly ColegioDbContext _Context;

        public IAlumnoRepository Alumnos { get; private set; }
        public IApoderadoRepository Apoderados { get; private set; }
        public IAreaCurricularRepository AreaCurriculares { get; private set; }
        public IAsistenciaRepository Asistencias { get; private set; }
        public IAulaRepository Aulas { get; private set; }
        public ICursoRepository Cursos { get; private set; }
        public IDireccionRepository Direcciones { get; private set; }
        public IDistritoRepository Distritos { get; private set; }
        public IEvaluacionRepository Evaluaciones { get; private set; }
        public IGradoRepository Grados { get; private set; }
        public IHorarioRepository Horarios { get; private set; }
        public IMatriculaRepository Matriculas { get; private set; }
        public INivelRepository Niveles { get; }
        public INotaRepository Notas { get; private set; }
        public IProfesorRepository Profesores { get; private set; }
        public IReciboRepository Recibos { get; private set; }
        public ISesionRepository Sesiones { get; private set; }
        public ITipoEvaluacionRepository TipoEvaluaciones { get; private set; }



        public UnityOfWork()
        {
            
            _Context = new ColegioDbContext();

            Alumnos = new AlumnoRepository(_Context);
            Apoderados = new ApoderadoRepository(_Context);
            AreaCurriculares = new AreaCurricularRepository(_Context);
            Asistencias = new AsistenciaRepository(_Context);
            Aulas = new AulaRepository(_Context);
            Cursos = new CursoRepository(_Context);
            Direcciones = new DireccionRepository(_Context);
            Distritos = new DistritoRepository(_Context);
            Evaluaciones = new EvaluacionRepository(_Context);
            Grados = new GradoRepository(_Context);
            Horarios = new HorarioRepository(_Context);
            Matriculas = new MatriculaRepository(_Context);
            Niveles = new NivelRepository(_Context);
            Notas = new NotaRepository(_Context);
            Profesores = new ProfesorRepository(_Context);
            Recibos = new ReciboRepository(_Context);
            Sesiones = new SesionRepository(_Context);
            TipoEvaluaciones = new TipoEvaluacionRepository(_Context);
            
        }

        public void Dispose()
        {
            _Context.Dispose();
        }

        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }

        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
