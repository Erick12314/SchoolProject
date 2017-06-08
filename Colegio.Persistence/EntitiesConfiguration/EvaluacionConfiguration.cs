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
    public class EvaluacionConfiguration : EntityTypeConfiguration<Evaluacion>
    {
        public EvaluacionConfiguration()
        {
            //Configuración de la tabla
            ToTable("Evaluaciones");
            HasKey(c => c.EvaluacionId);
            Property(c => c.EvaluacionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Titulo).IsRequired();
            Property(c => c.Titulo).HasMaxLength(100);

            //Configuración de las relaciones
            HasRequired(c => c.TipoEvaluacion)
                .WithMany(c => c.Evaluacion);
        }
    }
}
