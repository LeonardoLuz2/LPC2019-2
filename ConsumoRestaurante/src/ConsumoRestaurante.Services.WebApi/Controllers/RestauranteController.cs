using AutoMapper;
using ConsumoRestaurante.Application.ViewModels;
using ConsumoRestaurante.Domain.Entities;
using ConsumoRestaurante.Domain.Interfaces;
using ConsumoRestaurante.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ConsumoRestaurante.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ApiController
    {
        private readonly IRestauranteRepository _restauranteRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RestauranteController(IRestauranteRepository restauranteRepository, IUnitOfWork uow, IMapper mapper)
        {
            _restauranteRepository = restauranteRepository;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var restaurantes = _mapper.Map<IEnumerable<RestauranteViewModel>>(_restauranteRepository.GetAll());
            return ResponseOk(restaurantes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var restaurante = _mapper.Map<RestauranteViewModel>(_restauranteRepository.GetById(id));
            return ResponseOk(restaurante);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RestauranteViewModel model)
        {
            if (!ModelState.IsValid) return ResponseModelStateError();

            var restaurante = _mapper.Map<Restaurante>(model);
            _restauranteRepository.Add(restaurante);
            _uow.SaveChanges();

            return ResponseOk(model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] RestauranteViewModel model)
        {
            if (!ModelState.IsValid) return ResponseModelStateError();

            var result = _restauranteRepository.GetById(id);
            if (result == null) return ResponseError("Restaurante inexistente!");

            model.Id = id;
            var restaurante = _mapper.Map(model, result);

            _restauranteRepository.Update(restaurante);
            _uow.SaveChanges();

            return ResponseOk(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _restauranteRepository.GetById(id);
            if (result == null) return ResponseError("Restaurante inexistente!");

            _restauranteRepository.Remove(id);
            _uow.SaveChanges();

            return ResponseOk(result);
        }
    }
}
