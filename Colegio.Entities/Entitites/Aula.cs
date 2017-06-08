using Colegio.Entities.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities
{
    public class Aula
    {
        public int AulaId { get; set; }
        public string Descripcion { get; set; }
        public string Seccion { get; set; }

        public virtual int GradoId { get; set; }
        public virtual Grado Grado { get; set; }

        public virtual int NivelId { get; set; }
        public virtual Nivel Nivel { get; set; }

        public virtual ICollection<Sesion> Sesion { get; set; }

        public virtual ICollection<AreaCurricular> AreaCurricular { get; set; }

        public virtual ICollection<Matricula> Matricula { get; set; }

        public Aula()
        {
            AreaCurricular = new List<AreaCurricular>();
            Sesion = new List<Sesion>();
            Matricula = new List<Matricula>();
        }
    }
}
