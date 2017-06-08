using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities
{
    public class Distrito
    {
        public int DistritoId { get; set; }
        public string Descripcion { get; set; }

        public virtual List<Direccion> Direccion { get; set; }

        public Distrito()
        {
            Direccion = new List<Direccion>();
        }
    }
}
