using Colegio.Entities;
using Colegio.Entities.Entitites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Persistence.EntitiesConfiguration
{
    public class SesionConfiguration : EntityTypeConfiguration<Sesion>
    {
        public SesionConfiguration()
        {
            //Configuración de la tabla
            ToTable("Sesiones");
            HasKey(c => c.SesionId);
            Property(c => c.SesionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Dia).IsRequired();
            Property(c => c.Actividad).HasMaxLength(300);
            Property(c => c.HoraInicio).IsRequired();
            Property(c => c.HoraFin).IsRequired();

            //Configuración de las relaciones
            HasRequired(c => c.Curso)
                .WithMany(c => c.Sesion)
                .WillCascadeOnDelete(false);
            HasRequired(c => c.Profesor)
                .WithMany(c => c.Sesion);
            HasRequired(c => c.Aula)
                .WithMany(c => c.Sesion);
            HasRequired(c => c.Horario)
                .WithMany(c => c.Sesion)
                .WillCascadeOnDelete(false);
        }
    }
}
