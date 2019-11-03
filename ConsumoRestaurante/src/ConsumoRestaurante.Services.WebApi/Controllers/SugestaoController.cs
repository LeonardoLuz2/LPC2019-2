using System.Linq;
using AutoMapper;
using ConsumoRestaurante.Application.ViewModels;
using ConsumoRestaurante.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ConsumoRestaurante.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SugestaoController : ApiController
    {
        private readonly IConsumoRepository _consumoRepository;
        private readonly IMapper _mapper;

        public SugestaoController(IConsumoRepository consumoRepository, IMapper mapper)
        {
            _consumoRepository = consumoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sugestao = _consumoRepository.GetAll()
                .GroupBy(x => x.RestauranteId)
                .Select(sl => new
                {
                    Restaurante = sl.First().Restaurante.Nome,
                    Valor = sl.Sum(s => s.Valor) / sl.Count()
                }).OrderBy(x => x.Valor).FirstOrDefault();

            if (sugestao == null) return ResponseError("Não existem consumos cadastrados");

            return ResponseOk(new SugestaoViewModel
            {
                Restaurante = sugestao.Restaurante,
                Valor = sugestao.Valor
            });
        }
    }
}