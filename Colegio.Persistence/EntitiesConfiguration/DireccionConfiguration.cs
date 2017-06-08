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
    public class DireccionConfiguration : EntityTypeConfiguration<Direccion>
    {
        public DireccionConfiguration()
        {
            //Configuración de la tabla
            ToTable("Direcciones");
            HasKey(c => c.DireccionId);
            Property(c => c.DireccionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Descripcion).IsRequired();
            Property(c => c.Descripcion).HasMaxLength(200);

            //Configuración de las relaciones
            HasRequired(c => c.Distrito)
                .WithMany(c => c.Direccion);

            HasMany(c => c.Alumno)
                .WithRequired(c => c.Direccion);

            HasMany(c => c.Profesor)
                .WithRequired(c => c.Direccion);

        }
    }
}
