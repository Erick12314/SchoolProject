using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities
{
    public class Matricula
    {
        public int MatriculaId { get; set; }
        public DateTime Year { get; set; }
        public string Observaciones { get; set; }

        public virtual int AlumnoId { get; set; }
        public virtual Alumno Alumno { get; set; }

        public virtual int AulaId { get; set; }
        public virtual Aula Aula { get; set; }

    }
}
