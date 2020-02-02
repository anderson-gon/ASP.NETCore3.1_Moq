using Microsoft.EntityFrameworkCore;
using Moq.Domain.Interfaces.Repositories;
using Moq.Infra.Data;
using System;
using System.Collections.Generic;

namespace Moq.Infra.Repository
{
    public class Repository<TEntity, TType> : IRepository<TEntity, TType> where TEntity : class
    {
        protected readonly DataContext _context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DataContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual TEntity Get(TType id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
