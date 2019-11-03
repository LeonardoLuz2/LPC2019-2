using System;
using System.Collections.Generic;

namespace ConsumoRestaurante.Domain.Entities
{
    public class Restaurante
    {
        protected Restaurante() { }

        public Restaurante(Guid id, string nome, string endereco, int numero, string cidade, string estado, Guid consumoId)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Nome = nome;
            Endereco = endereco;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
            ConsumoId = consumoId;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public int Numero { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public virtual IEnumerable<Consumo> Consumos { get; private set; }
        public Guid ConsumoId { get; private set; }
    }
}
