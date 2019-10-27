namespace ConsumoRestaurante.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        bool SaveChanges();
    }
}
