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
    public class ReciboConfiguration : EntityTypeConfiguration<Recibo>
    {
        public ReciboConfiguration()
        {
            //Configuración de la tabla
            ToTable("Recibos");
            HasKey(c => c.ReciboId);
            Property(c => c.ReciboId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Concepto).IsRequired();
            Property(c => c.Concepto).HasMaxLength(200);
            Property(c => c.Monto).IsRequired();
            Property(c => c.FechaEmision).IsRequired();
            Property(c => c.FechaVencimiento).IsRequired();

            //Configuración de las relaciones
            HasRequired(c => c.Alumno)
                .WithMany(c => c.Recibo);
        }
    }
}
