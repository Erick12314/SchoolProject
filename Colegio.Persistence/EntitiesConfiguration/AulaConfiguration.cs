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
    public class AulaConfiguration : EntityTypeConfiguration<Aula>
    {
        public AulaConfiguration()
        {
            //Configuración de la tabla
            ToTable("Aulas");
            HasKey(c => c.AulaId);
            Property(c => c.AulaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Descripcion).IsRequired();
            Property(c => c.Descripcion).HasMaxLength(50);
            Property(c => c.Seccion).IsRequired();
            Property(c => c.Seccion).HasMaxLength(1);

        }
    }
}
