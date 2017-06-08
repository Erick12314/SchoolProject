using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities.Entitites
{
    public class Nivel
    {
        public int NivelId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Alumno> Alumno { get; set; }

        public virtual ICollection<Horario> Horario { get; set; }

        public Nivel()
        {
            Horario = new List<Horario>();
            Alumno = new List<Alumno>();
    }
    }
}
