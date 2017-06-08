using Colegio.Entities.Entitites;
using Colegio.Entities.IRespositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Persistence.Repositories
{
    public class SesionRepository : Repository<Sesion>, ISesionRepository
    {
        public SesionRepository(ColegioDbContext context) : base(context)
        {
        }
    }
}
