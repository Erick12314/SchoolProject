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
    public class NotaConfiguration : EntityTypeConfiguration<Nota>
    {
        public NotaConfiguration()
        {
            //Configuración de la tabla
            ToTable("Notas");
            HasKey(c => c.NotaId);
            Property(c => c.NotaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Puntaje).IsRequired();

            //Configuración de las relaciones
            HasRequired(c => c.Alumno)
                .WithMany(c => c.Nota);
            HasRequired(c => c.Curso)
                .WithMany(c => c.Nota)
                .WillCascadeOnDelete(false);
            HasRequired(c => c.Evaluacion)
                .WithMany(c => c.Nota);
        }
    }
}
