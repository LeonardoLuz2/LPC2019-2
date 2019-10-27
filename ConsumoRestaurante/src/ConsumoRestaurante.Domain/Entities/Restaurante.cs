using ConsumoRestaurante.Domain.Entities.Base;
using System;

namespace ConsumoRestaurante.Domain.Entities
{
    public class Restaurante : Entity
    {
        protected Restaurante() { }

        public Restaurante(Guid id, string nome, string endereco, int numero, string cidade, string estado)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
        }

        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public int Numero { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
    }
}
