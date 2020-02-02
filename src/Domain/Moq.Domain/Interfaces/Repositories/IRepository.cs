using System;
using System.Collections.Generic;

namespace Moq.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity, TType> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        TEntity Get(TType id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
