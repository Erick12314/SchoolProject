using Colegio.Entities.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string Descripcion { get; set; }

        public virtual int AreaCurricularId { get; set; }
        public virtual AreaCurricular AreaCurricular { get; set; }

        public virtual ICollection<Sesion> Sesion { get; set; }

        public virtual ICollection<Nota> Nota { get; set; }

        public virtual ICollection<Profesor> Profesor { get; set; }

        public Curso()
        {
            Sesion = new List<Sesion>();
            Nota = new List<Nota>();
            Profesor = new List<Profesor>();
        }
    }
}
