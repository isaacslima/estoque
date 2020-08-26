using Domain.Entity;
using Infra.Context;
using Infra.Interfaces;
using DapperExtensions;
using System;
using System.Collections.Generic;
using Infra.Mapping;

namespace Infra.BaseRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected BaseContext _context;

        public BaseRepository(BaseContext context)
        {
            _context = context;
            InitializeMapperDapper();
        }

        public static void InitializeMapperDapper()
        {
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[]
            {
                 typeof(ProductMapper).Assembly
             });
        }

        public bool Delete(TEntity entity)
        {
            _context.Connection.Open();
            return _context.Connection.Delete<TEntity>(entity);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            _context.Connection.Open();
            return _context.Connection.GetList<TEntity>();
        }

        public TEntity GetById(int id)
        {
            _context.Connection.Open();
            return _context.Connection.Get<TEntity>(id);

        }

        public bool Insert(TEntity entity)
        {
            try
            {
                _context.Connection.Open();
                var result = _context.Connection.Insert<TEntity>(entity);
                return Convert.ToBoolean(result);
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public bool Update(TEntity entity)
        {
            _context.Connection.Open();
            return _context.Connection.Update<TEntity>(entity);
        }
    }
}
