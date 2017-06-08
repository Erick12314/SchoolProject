using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities
{
    public class AreaCurricular
    {
        public int AreaCurricularId { get; set; }
        public String Descripcion { get; set; }

        public virtual ICollection<Aula> Aula { get; set; }

        public virtual ICollection<Curso> Curso { get; set; }

        public AreaCurricular()
        {
            Curso = new List<Curso>();
            Aula = new List<Aula>();
        }
    }
}
