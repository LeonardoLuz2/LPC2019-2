using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsumoRestaurante.Application.ViewModels
{
    public class RestauranteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Numero é obrigatório")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório")]
        public string Estado { get; set; }
        public IEnumerable<ConsumoViewModel> Consumos { get; set; }
    }
}
