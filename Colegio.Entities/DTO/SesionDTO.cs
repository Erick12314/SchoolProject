using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities.DTO
{
    public class SesionDTO
    {
        public int SesionId { get; set; }
        public Dia Dia { get; set; }
        public string Actividad { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
    }
}
