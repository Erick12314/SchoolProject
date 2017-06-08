using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities
{
    public class Apoderado
    {
        public int ApoderadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public virtual ICollection<Alumno> Alumno { get; set; }

        public Apoderado()
        {
            Alumno = new List<Alumno>();
        }
    }
}
