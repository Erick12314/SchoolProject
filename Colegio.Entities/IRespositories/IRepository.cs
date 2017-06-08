using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Entities.IRespositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetEntity();
        IEnumerable<TEntity> ListDataWithRelationships(IQueryable<TEntity> table);

        //CREATES
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        //READS
        TEntity Get(int? Id);
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //DELETES
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
