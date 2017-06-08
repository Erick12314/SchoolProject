using Colegio.Entities.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities
{
    public class Grado
    {
        public int GradoId { get; set; }
        public string Descripcion{ get; set; }

        public virtual ICollection<Horario> Horario { get; set; }

        public virtual ICollection<Alumno> Alumno { get; set; }

        public Grado()
        {
            Alumno = new List<Alumno>();
            Horario = new List<Horario>();
        }
    }
}
