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
    public class TipoEvaluacionConfiguration : EntityTypeConfiguration<TipoEvaluacion>
    {
        public TipoEvaluacionConfiguration()
        {
            //Configuración de la tabla
            ToTable("TiposEvaluaciones");
            HasKey(c => c.TipoEvaluacionId);
            Property(c => c.TipoEvaluacionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Descripcion).IsRequired();
            Property(c => c.Descripcion).HasMaxLength(200);
        }
    }
}
