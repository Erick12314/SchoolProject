using Colegio.Entities.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities
{
    public class Profesor
    {
        public int ProfesorId { get; set; }
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

        public virtual int DireccionId { get; set; }
        public virtual Direccion Direccion { get; set; }

        public virtual ICollection<Sesion> Sesion { get; set; }

        public virtual ICollection<Curso> Curso { get; set; }

        public Profesor()
        {
            Sesion=new List<Sesion>();
            Curso = new List<Curso>();
        }
    }
}
