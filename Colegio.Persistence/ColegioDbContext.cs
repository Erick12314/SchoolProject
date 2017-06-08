using Colegio.Entities;
using Colegio.Entities.Entitites;
using Colegio.Persistence.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Persistence
{
    public class ColegioDbContext : DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Apoderado> Apoderados { get; set; }
        public DbSet<AreaCurricular> AreaCurricular { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Nivel> Niveles { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Recibo> Recibos { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<TipoEvaluacion> TipoEvaluacion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlumnoConfiguration());
            modelBuilder.Configurations.Add(new ApoderadoConfiguration());
            modelBuilder.Configurations.Add(new AreaCurricularConfiguration());
            modelBuilder.Configurations.Add(new AsistenciaConfiguration());
            modelBuilder.Configurations.Add(new AulaConfiguration());
            modelBuilder.Configurations.Add(new CursoConfiguration());
            modelBuilder.Configurations.Add(new DireccionConfiguration());
            modelBuilder.Configurations.Add(new DistritoConfiguration());
            modelBuilder.Configurations.Add(new EvaluacionConfiguration());
            modelBuilder.Configurations.Add(new GradoConfiguration());
            modelBuilder.Configurations.Add(new HorarioConfiguration());
            modelBuilder.Configurations.Add(new MatriculaConfiguration());
            modelBuilder.Configurations.Add(new NivelConfiguration());
            modelBuilder.Configurations.Add(new NotaConfiguration());
            modelBuilder.Configurations.Add(new ProfesorConfiguration());
            modelBuilder.Configurations.Add(new ReciboConfiguration());
            modelBuilder.Configurations.Add(new SesionConfiguration());
            modelBuilder.Configurations.Add(new TipoEvaluacionConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public ColegioDbContext():base("ColegioDB")
        {

        }

    }
}
