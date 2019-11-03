using System;

namespace ConsumoRestaurante.Domain.Entities
{
    public class Consumo
    {
        protected Consumo() { }

        public Consumo(Guid id, DateTime data, decimal valor, Guid restauranteId)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Data = data;
            Valor = valor;
            RestauranteId = restauranteId;
        }

        public Guid Id { get; private set; }
        public DateTime Data { get; private set; }
        public decimal Valor { get; private set; }
        public virtual Restaurante Restaurante { get; set; }
        public Guid RestauranteId { get; private set; }
    }
}
