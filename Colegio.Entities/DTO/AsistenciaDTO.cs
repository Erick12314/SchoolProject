using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities.DTO
{
    public class AsistenciaDTO
    {
        public int AsistenciaId { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
    }
}
