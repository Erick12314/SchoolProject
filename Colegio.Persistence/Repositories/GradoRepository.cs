using Colegio.Entities;
using Colegio.Entities.IRespositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Colegio.Persistence.Repositories
{
    public class GradoRepository : Repository<Grado>, IGradoRepository
    {
        public GradoRepository(DbContext context) : base(context)
        {
        }
    }
}
