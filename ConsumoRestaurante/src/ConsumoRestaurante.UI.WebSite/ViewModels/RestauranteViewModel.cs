using System;
using System.ComponentModel.DataAnnotations;

namespace ConsumoRestaurante.UI.WebSite.ViewModels
{
    public class RestauranteViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
