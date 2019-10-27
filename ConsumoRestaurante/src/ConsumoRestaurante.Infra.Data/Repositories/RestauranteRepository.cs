using ConsumoRestaurante.Domain.Entities;
using ConsumoRestaurante.Domain.Interfaces.Repositories;
using ConsumoRestaurante.Infra.Data.Context;
using ConsumoRestaurante.Infra.Data.Repositories.Base;

namespace ConsumoRestaurante.Infra.Data.Repositories
{
    public class RestauranteRepository : Repository<Restaurante>, IRestauranteRepository
    {
        public RestauranteRepository(ConsumoContext context) : base(context)
        {

        }
    }
}
