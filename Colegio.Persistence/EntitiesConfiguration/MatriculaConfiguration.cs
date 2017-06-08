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
    public class MatriculaConfiguration : EntityTypeConfiguration<Matricula>
    {
        public MatriculaConfiguration()
        {
            //Configuración de la tabla
            ToTable("Matriculas");
            HasKey(c => c.MatriculaId);
            Property(c => c.MatriculaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Year).IsRequired();

            //Configuración de las relaciones
            HasRequired(c => c.Alumno)
                .WithMany(c => c.Matricula);
            HasRequired(c => c.Aula)
                .WithMany(c => c.Matricula)
                .WillCascadeOnDelete(false);
        }
    }
}
