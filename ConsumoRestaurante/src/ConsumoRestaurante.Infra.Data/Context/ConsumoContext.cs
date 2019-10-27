using ConsumoRestaurante.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsumoRestaurante.Infra.Data.Context
{
    public class ConsumoContext : DbContext
    {
        public ConsumoContext(DbContextOptions<ConsumoContext> options) : base(options) { }

        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Consumo> Consumos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consumo>()
                .Property(p => p.Valor)
                .HasColumnType("decimal(18,4)");
        }
    }
}
