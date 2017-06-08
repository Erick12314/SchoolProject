using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities.Entitites
{
    public class Sesion
    {
        public int SesionId { get; set; }
        public Dia Dia { get; set; }
        public string Actividad { get; set; }

        //public Hora Hora { get; set; }
        //public Minuto Minuto { get; set; }

        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }

        public virtual int CursoId { get; set; }
        public virtual Curso Curso { get; set; }

        public virtual int ProfesorId { get; set; }
        public virtual Profesor Profesor { get; set; }

        public virtual int AulaId { get; set; }
        public virtual Aula Aula { get; set; }

        public virtual int HorarioId { get; set; }
        public virtual Horario Horario { get; set; }
    }
}
