﻿using Colegio.Entities.IRespositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Colegio.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _Context;

        public Repository(DbContext context)
        {
            _Context = context;
        }

        public void Add(TEntity entity)
        {
            _Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _Context.Set<TEntity>().AddRange(entities);
        }

        public TEntity Get(int? id)
        {
            return _Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _Context.Set<TEntity>().ToList();
        }

        public void Delete(TEntity entity)
        {
            _Context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _Context.Set<TEntity>().RemoveRange(entities);
        }

        public IQueryable<TEntity> GetEntity()
        {
            return _Context.Set<TEntity>();
        }

        public IEnumerable<TEntity> ListDataWithRelationships(IQueryable<TEntity> table)
        {
            return table.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _Context.Set<TEntity>().Where(predicate);
        }

    }
}
