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
    public class AlumnoConfiguration : EntityTypeConfiguration<Alumno>
    {
        public AlumnoConfiguration()
        {
            //Configuración de la tabla
            ToTable("Alumnos");
            HasKey(c => c.AlumnoId);
            Property(c => c.AlumnoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Nombre).IsRequired();
            Property(c => c.Nombre).HasMaxLength(200);
            Property(c => c.ApellidoMaterno).IsRequired();
            Property(c => c.ApellidoMaterno).HasMaxLength(200);
            Property(c => c.ApellidoPaterno).IsRequired();
            Property(c => c.ApellidoPaterno).HasMaxLength(200);
            Property(c => c.Telefono).IsRequired();
            Property(c => c.Telefono).HasMaxLength(20);
            Property(c => c.Usuario).IsRequired();
            Property(c => c.Usuario).HasMaxLength(30);
            Property(c => c.Password).IsRequired();
            Property(c => c.Password).HasMaxLength(30);
            Property(c => c.TipoDocumento).IsRequired();
            Property(c => c.NumeroDocumento).IsRequired();

            //Configuración de las relaciones
            HasRequired(c => c.Grado)
                .WithMany(c => c.Alumno);

            HasRequired(c => c.Nivel)
                .WithMany(c => c.Alumno);

            HasMany(c => c.Apoderado)
                .WithMany(c => c.Alumno)
                .Map(m =>
                {
                    m.ToTable("AlumnosApoderados");
                    m.MapLeftKey("AlumnoId");
                    m.MapRightKey("ApoderadoId");
                });
       
        }
    }
}
