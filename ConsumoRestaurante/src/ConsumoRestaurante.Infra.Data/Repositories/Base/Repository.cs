using ConsumoRestaurante.Domain.Interfaces;
using ConsumoRestaurante.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ConsumoRestaurante.Infra.Data.Repositories.Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ConsumoContext _context;
        private readonly DbSet<TEntity> _db;

        public Repository(ConsumoContext context)
        {
            _context = context;
            _db = context.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            _db.Add(obj);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _db;
        }
       
        public virtual TEntity GetById(Guid id)
        {
            return _db.Find(id);
        }

        public void Remove(Guid id)
        {
            _db.Remove(GetById(id));
        }

        public void Update(TEntity obj)
        {
            _db.Update(obj);
        }
    }
}
