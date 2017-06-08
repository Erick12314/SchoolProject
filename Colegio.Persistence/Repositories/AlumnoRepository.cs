using Colegio.Entities;
using Colegio.Entities.IRespositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Persistence.Repositories
{
    public class AlumnoRepository : Repository<Alumno>, IAlumnoRepository
    {
        public AlumnoRepository(ColegioDbContext context) : base(context)
        {
        }
    }
}
