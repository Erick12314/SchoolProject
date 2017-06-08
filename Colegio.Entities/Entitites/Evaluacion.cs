using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities
{
    public class Evaluacion
    {
        public int EvaluacionId { get; set; }
        public string Titulo { get; set; }

        public virtual int TipoEvaluacionId { get; set; }
        public virtual TipoEvaluacion TipoEvaluacion { get; set; }

        public virtual List<Nota> Nota { get; set; }

        public Evaluacion()
        {
            Nota = new List<Nota>();
        }
    
    }
}
