using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities.DTO
{
    public class AlumnoDTO
    {
        public int AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public long NumeroDocumento { get; set; }
        public string Telefono { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}
