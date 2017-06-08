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
    public class ApoderadoConfiguration : EntityTypeConfiguration<Apoderado>
    {
        public ApoderadoConfiguration()
        {
            //Configuración de la tabla
            ToTable("Apoderados");
            HasKey(c => c.ApoderadoId);
            Property(c => c.ApoderadoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Nombre).IsRequired();
            Property(c => c.Nombre).HasMaxLength(200);
            Property(c => c.Apellidos).IsRequired();
            Property(c => c.Apellidos).HasMaxLength(500);
            Property(c => c.Correo).IsRequired();
            Property(c => c.Correo).HasMaxLength(100);
            Property(c => c.Telefono).IsRequired();
            Property(c => c.Telefono).HasMaxLength(20);
            
        }
    }
}
