using Colegio.Entities.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities
{
    public class Alumno
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

        public virtual int DireccionId { get; set; }
        public virtual Direccion Direccion { get; set; }

        public virtual int NivelId { get; set; }
        public virtual Nivel Nivel { get; set; }

        public virtual int GradoId { get; set; }
        public virtual Grado Grado { get; set; }

        public virtual ICollection<Matricula> Matricula { get; set; }

        public virtual ICollection<Apoderado> Apoderado { get; set; }

        public virtual ICollection<Nota> Nota { get; set; }

        public virtual ICollection<Recibo> Recibo { get; set; }

        public virtual ICollection<Asistencia> Asistencia { get; set; }

        public Alumno()
        {
            Apoderado = new List<Apoderado>();
            Nota = new List<Nota>();
            Recibo = new List<Recibo>();
            Asistencia = new List<Asistencia>();
            Matricula = new List<Matricula>();
        }

    }
}
