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
    public class NivelConfiguration : EntityTypeConfiguration<Nivel>
    {
        public NivelConfiguration()
        {
            //Configuración de la tabla
            ToTable("Niveles");
            HasKey(c => c.NivelId);
            Property(c => c.NivelId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Descripcion)
                .HasMaxLength(200)
                .IsRequired();

            //Configuración de las relaciones
            HasMany(h => h.Horario)
                .WithRequired(n => n.Nivel);
                       
        }
    }
}