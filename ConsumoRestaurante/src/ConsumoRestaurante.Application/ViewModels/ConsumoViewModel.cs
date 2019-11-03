using System;
using System.ComponentModel.DataAnnotations;

namespace ConsumoRestaurante.Application.ViewModels
{
    public class ConsumoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Data")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        public decimal Valor { get; set; }

        public RestauranteViewModel Restaurante { get; set; }

        public Guid RestauranteId { get; set; }
    }
}
