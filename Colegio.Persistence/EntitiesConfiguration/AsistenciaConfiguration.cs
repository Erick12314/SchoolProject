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
    public class AsistenciaConfiguration : EntityTypeConfiguration<Asistencia>
    {
        public AsistenciaConfiguration()
        {
            //Configuración de la tabla
            ToTable("Asistencias");
            HasKey(c => c.AsistenciaId);
            Property(c => c.AsistenciaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Configuración de las relaciones
            HasRequired(c => c.Alumno)
                .WithMany(c => c.Asistencia);            
        }
    }
}
