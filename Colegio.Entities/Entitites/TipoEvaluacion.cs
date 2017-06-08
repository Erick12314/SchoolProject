using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities
{
    public class TipoEvaluacion
    {
        public int TipoEvaluacionId { get; set; }
        public string Descripcion { get; set; }

        public virtual List<Evaluacion> Evaluacion { get; set; }

        public TipoEvaluacion()
        {
            Evaluacion = new List<Evaluacion>();
        }
    }
}
