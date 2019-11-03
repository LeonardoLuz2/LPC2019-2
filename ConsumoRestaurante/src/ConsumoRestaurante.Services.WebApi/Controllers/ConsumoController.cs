using System;
using System.Collections.Generic;
using AutoMapper;
using ConsumoRestaurante.Application.ViewModels;
using ConsumoRestaurante.Domain.Entities;
using ConsumoRestaurante.Domain.Interfaces;
using ConsumoRestaurante.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ConsumoRestaurante.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumoController : ApiController
    {
        private readonly IConsumoRepository _consumoRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ConsumoController(IConsumoRepository consumoRepository, IUnitOfWork uow, IMapper mapper)
        {
            _consumoRepository = consumoRepository;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var consumos = _mapper.Map<IEnumerable<ConsumoViewModel>>(_consumoRepository.GetAll());
            return ResponseOk(consumos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var consumo = _mapper.Map<ConsumoViewModel>(_consumoRepository.GetById(id));
            return ResponseOk(consumo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ConsumoViewModel model)
        {
            if (!ModelState.IsValid) return ResponseModelStateError();

            var consumo = _mapper.Map<Consumo>(model);
            _consumoRepository.Add(consumo);
            _uow.SaveChanges();

            return ResponseOk(model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ConsumoViewModel model)
        {
            if (!ModelState.IsValid) return ResponseModelStateError();

            var result = _consumoRepository.GetById(id);
            if (result == null) return ResponseError("Consumo inexistente!");

            model.Id = id;
            var consumo = _mapper.Map(model, result);

            _consumoRepository.Update(consumo);
            _uow.SaveChanges();

            return ResponseOk(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _consumoRepository.GetById(id);
            if (result == null) return ResponseError("Consumo inexistente!");

            _consumoRepository.Remove(id);
            _uow.SaveChanges();

            return ResponseOk(result);
        }
    }
}