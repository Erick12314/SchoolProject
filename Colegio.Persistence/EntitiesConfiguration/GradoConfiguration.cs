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
    public class GradoConfiguration : EntityTypeConfiguration<Grado>
    {
        public GradoConfiguration()
        {
            //Configuración de la tabla
            ToTable("Grados");
            HasKey(c => c.GradoId);
            Property(c => c.GradoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Descripcion).IsRequired();
            Property(c => c.Descripcion).HasMaxLength(10);

            //Configuración de las relaciones
            HasMany(g => g.Horario)
                .WithRequired(h => h.Grado);

        }
    }
}
