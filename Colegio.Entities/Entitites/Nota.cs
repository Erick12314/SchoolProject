using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities
{
    public class Nota
    {
        public int NotaId { get; set; }
        public double Puntaje { get; set; }

        public virtual int AlumnoId { get; set; }
        public virtual Alumno Alumno { get; set; }

        public virtual int CursoId { get; set; }
        public virtual Curso Curso { get; set; }

        public virtual int EvaluacionId { get; set; }
        public virtual Evaluacion Evaluacion { get; set; }


    }
}
