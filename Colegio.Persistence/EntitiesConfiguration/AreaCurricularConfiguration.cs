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
    public class AreaCurricularConfiguration : EntityTypeConfiguration<AreaCurricular>
    {
        public AreaCurricularConfiguration()
        {
            //Configuración de la tabla
            ToTable("AreasCurriculares");
            HasKey(c => c.AreaCurricularId);
            Property(c => c.AreaCurricularId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Descripcion).IsRequired();
            Property(c => c.Descripcion).HasMaxLength(100);
            
            //Configuración de las relaciones
            HasMany(c => c.Aula)
                .WithMany(c => c.AreaCurricular)
                .Map(m =>
                {
                    m.ToTable("AreasCurricularersAulas");
                    m.MapLeftKey("AreaCurricularId");
                    m.MapRightKey("AulaId");
                });


        }
    }
}
