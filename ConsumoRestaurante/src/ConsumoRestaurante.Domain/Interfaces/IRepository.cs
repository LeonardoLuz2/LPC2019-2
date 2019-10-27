using System;
using System.Collections.Generic;

namespace ConsumoRestaurante.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(Guid id);
        void Add(TEntity obj);
        void Remove(Guid id);
        void Update(TEntity obj);
    }
}
