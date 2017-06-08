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
    public class DistritoConfiguration : EntityTypeConfiguration<Distrito>
    {
        public DistritoConfiguration()
        {
            //Configuración de la tabla
            ToTable("Distritos");
            HasKey(c => c.DistritoId);
            Property(c => c.DistritoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Descripcion).IsRequired();
            Property(c => c.Descripcion).HasMaxLength(100);
        }
    }
}
