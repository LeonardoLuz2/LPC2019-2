using ConsumoRestaurante.Domain.Entities;
using ConsumoRestaurante.Domain.Interfaces.Repositories;
using ConsumoRestaurante.Infra.Data.Context;
using ConsumoRestaurante.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsumoRestaurante.Infra.Data.Repositories
{
    public class RestauranteRepository : Repository<Restaurante>, IRestauranteRepository
    {
        public RestauranteRepository(ConsumoContext context) : base(context)
        {

        }

        public override IEnumerable<Restaurante> GetAll()
        {
            return _context.Set<Restaurante>().Include(x => x.Consumos);
        }

        public override Restaurante GetById(Guid id)
        {
            return _context.Set<Restaurante>().Include(x => x.Consumos).SingleOrDefault(x => x.Id == id);
        }
    }
}
