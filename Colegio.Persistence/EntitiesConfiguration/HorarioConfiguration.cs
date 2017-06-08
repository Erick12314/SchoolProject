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
    public class HorarioConfiguration : EntityTypeConfiguration<Horario>
    {
        public HorarioConfiguration()
        {
            //Configuración de la tabla
            ToTable("Horarios");
            HasKey(c => c.HorarioId);
            Property(c => c.HorarioId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Descripcion).IsRequired();
            Property(c => c.Descripcion).HasMaxLength(300);

            //Configuración de las relaciones
            HasRequired(c => c.Grado)
                .WithMany(c => c.Horario)
                .WillCascadeOnDelete(false);
            HasRequired(c => c.Nivel)
                .WithMany(c => c.Horario);
            HasMany(c => c.Sesion)
                .WithRequired(c => c.Horario);

        }
    }
}
