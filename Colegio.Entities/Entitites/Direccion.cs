using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities
{
    public class Direccion
    {
        public int DireccionId { get; set; }
        public string Descripcion { get; set; }

        public virtual int DistritoId { get; set; }
        public virtual Distrito Distrito { get; set; }

        public virtual ICollection<Alumno> Alumno { get; set; }

        public virtual ICollection<Profesor> Profesor { get; set; }

        public Direccion()
        {
            Alumno = new List<Alumno>();
            Profesor = new List<Profesor>();
        }

    }
}
