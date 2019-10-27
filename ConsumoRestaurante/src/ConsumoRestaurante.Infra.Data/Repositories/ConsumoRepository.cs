using System;
using System.Collections.Generic;
using System.Linq;
using ConsumoRestaurante.Domain.Entities;
using ConsumoRestaurante.Domain.Interfaces.Repositories;
using ConsumoRestaurante.Infra.Data.Context;
using ConsumoRestaurante.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace ConsumoRestaurante.Infra.Data.Repositories
{
    public class ConsumoRepository : Repository<Consumo>, IConsumoRepository
    {
        public ConsumoRepository(ConsumoContext context) : base(context)
        {
        }

        public override IEnumerable<Consumo> GetAll()
        {
            return _context.Set<Consumo>().Include(x => x.Restaurante);
        }

        public override Consumo GetById(Guid id)
        {
            return _context.Set<Consumo>().Include(x => x.Restaurante).SingleOrDefault(x => x.Id == id);
        }
    }
}
