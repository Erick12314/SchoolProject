using Colegio.Entities.Entitites;
using Colegio.Entities.IRespositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Colegio.Persistence.Repositories
{
    public class NivelRepository : Repository<Nivel>, INivelRepository
    {
        public NivelRepository(DbContext context) : base(context)
        {
        }
    }
}
