using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities
{
    public class Asistencia
    {
        public int AsistenciaId { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }

        public virtual int AlumnoId { get; set; }
        public virtual Alumno Alumno { get; set; }
    }
}
