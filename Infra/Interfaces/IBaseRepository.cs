using Domain.Entity;
using System;
using System.Collections.Generic;

namespace Infra.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        bool Insert(TEntity entity);

        bool Delete(TEntity entity);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        bool Update(TEntity entity);
    }
}
