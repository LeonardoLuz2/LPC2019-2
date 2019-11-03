using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ConsumoRestaurante.Domain.Entities;
using ConsumoRestaurante.Domain.Interfaces.Repositories;
using ConsumoRestaurante.Domain.Interfaces;
using AutoMapper;
using ConsumoRestaurante.Application.ViewModels;

namespace ConsumoRestaurante.UI.WebSite.Controllers
{
    public class ConsumoController : Controller
    {
        private readonly IConsumoRepository _consumoRepository;
        private readonly IRestauranteRepository _restauranteRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ConsumoController(IConsumoRepository consumoRepository, IUnitOfWork uow, IMapper mapper, IRestauranteRepository restauranteRepository)
        {
            _consumoRepository = consumoRepository;
            _uow = uow;
            _mapper = mapper;
            _restauranteRepository = restauranteRepository;
        }

        public IActionResult Index()
        {
            var consumos = _mapper.Map<IEnumerable<ConsumoViewModel>>(_consumoRepository.GetAll());
            return View(consumos);
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumo = _mapper.Map<ConsumoViewModel>(_consumoRepository.GetById(id.Value));
            if (consumo == null)
            {
                return NotFound();
            }

            return View(consumo);
        }

        public IActionResult Create()
        {
            ViewBag.Restaurantes = _mapper.Map<IEnumerable<RestauranteViewModel>>(_restauranteRepository.GetAll());

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ConsumoViewModel consumoViewModel)
        {
            if (ModelState.IsValid)
            {
                var consumo = _mapper.Map<Consumo>(consumoViewModel);
                _consumoRepository.Add(consumo);
                _uow.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(consumoViewModel);
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumo = _mapper.Map<ConsumoViewModel>(_consumoRepository.GetById(id.Value));
            if (consumo == null)
            {
                return NotFound();
            }

            ViewBag.Restaurantes = _mapper.Map<IEnumerable<RestauranteViewModel>>(_restauranteRepository.GetAll());

            return View(consumo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, ConsumoViewModel consumoViewModel)
        {
            if (id != consumoViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var consumo = _mapper.Map<Consumo>(consumoViewModel);
                _consumoRepository.Update(consumo);
                _uow.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(consumoViewModel);
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumo = _mapper.Map<ConsumoViewModel>(_consumoRepository.GetById(id.Value));
            if (consumo == null)
            {
                return NotFound();
            }

            return View(consumo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _consumoRepository.Remove(id);
            _uow.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
