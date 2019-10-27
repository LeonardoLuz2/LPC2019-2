using ConsumoRestaurante.Domain.Entities.Base;
using System;

namespace ConsumoRestaurante.Domain.Entities
{
    public class Consumo : Entity
    {
        protected Consumo() { }

        public Consumo(DateTime data, decimal valor, Guid restauranteId)
        {
            Data = data;
            Valor = valor;
            RestauranteId = restauranteId;
        }

        public DateTime Data { get; private set; }
        public decimal Valor { get; private set; }
        public virtual Restaurante Restaurante { get; set; }
        public Guid RestauranteId { get; private set; }
    }
}
