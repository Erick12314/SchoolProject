using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities.DTO
{
    public class MatriculaDTO
    {
        public int MatriculaId { get; set; }
        public DateTime Year { get; set; }
        public string Observaciones { get; set; }
    }
}
