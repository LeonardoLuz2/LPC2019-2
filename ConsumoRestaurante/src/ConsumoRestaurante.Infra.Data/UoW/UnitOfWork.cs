using ConsumoRestaurante.Domain.Interfaces;
using ConsumoRestaurante.Infra.Data.Context;

namespace ConsumoRestaurante.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConsumoContext _context;

        public UnitOfWork(ConsumoContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
