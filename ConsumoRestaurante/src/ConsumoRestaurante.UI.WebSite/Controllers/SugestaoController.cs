using System.Linq;
using AutoMapper;
using ConsumoRestaurante.Domain.Interfaces.Repositories;
using ConsumoRestaurante.UI.WebSite.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ConsumoRestaurante.UI.WebSite.Controllers
{
    public class SugestaoController : Controller
    {
        private readonly IConsumoRepository _consumoRepository;
        private readonly IMapper _mapper;

        public SugestaoController(IConsumoRepository consumoRepository, IMapper mapper)
        {
            _consumoRepository = consumoRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var sugestao = _consumoRepository.GetAll()
                .GroupBy(x => x.RestauranteId)
                .Select(sl => new
                {
                    Restaurante = sl.First().Restaurante.Nome,
                    Valor = sl.Sum(s => s.Valor) / sl.Count()
                }).OrderBy(x => x.Valor).FirstOrDefault();

            return View(new SugestaoViewModel
            {
                Restaurante = sugestao.Restaurante,
                Valor = sugestao.Valor
            });
        }
    }
}