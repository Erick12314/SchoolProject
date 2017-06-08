using Colegio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Persistence.EntitiesConfiguration
{
    public class CursoConfiguration : EntityTypeConfiguration<Curso>
    {
        public CursoConfiguration()
        {
            //Configuración de la tabla
            ToTable("Cursos");
            HasKey(c => c.CursoId);
            Property(c => c.CursoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Descripcion).IsRequired();
            Property(c => c.Descripcion).HasMaxLength(200);

            //Configuración de las relaciones

            HasMany(c => c.Profesor)
                .WithMany(c =>c.Curso)
                .Map(m =>
                {
                m.ToTable("ProfesoresCursos");
                m.MapLeftKey("ProfesorId");
                m.MapRightKey("CursoId");
                });
        }
    }
}
