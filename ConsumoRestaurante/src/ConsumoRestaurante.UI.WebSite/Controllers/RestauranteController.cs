using System;
using Microsoft.AspNetCore.Mvc;
using ConsumoRestaurante.Domain.Entities;
using ConsumoRestaurante.Domain.Interfaces.Repositories;
using ConsumoRestaurante.Domain.Interfaces;
using AutoMapper;
using ConsumoRestaurante.UI.WebSite.ViewModels;
using System.Collections.Generic;

namespace ConsumoRestaurante.UI.WebSite.Controllers
{
    public class RestauranteController : Controller
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

        public IActionResult Index()
        {
            var restaurantes = _mapper.Map<IEnumerable<RestauranteViewModel>>(_restauranteRepository.GetAll());
            return View(restaurantes);
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurante = _mapper.Map<RestauranteViewModel>(_restauranteRepository.GetById(id.Value));
            if (restaurante == null)
            {
                return NotFound();
            }

            return View(restaurante);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestauranteViewModel restauranteViewModel)
        {
            if (ModelState.IsValid)
            {
                var restaurante = _mapper.Map<Restaurante>(restauranteViewModel);
                _restauranteRepository.Add(restaurante);
                _uow.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(restauranteViewModel);
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurante = _mapper.Map<RestauranteViewModel>(_restauranteRepository.GetById(id.Value));
            if (restaurante == null)
            {
                return NotFound();
            }
            return View(restaurante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, RestauranteViewModel restauranteViewModel)
        {
            if (id != restauranteViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var restaurante = _mapper.Map<Restaurante>(restauranteViewModel);
                _restauranteRepository.Update(restaurante);
                _uow.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(restauranteViewModel);
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurante = _mapper.Map<RestauranteViewModel>(_restauranteRepository.GetById(id.Value));
            if (restaurante == null)
            {
                return NotFound();
            }

            return View(restaurante);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _restauranteRepository.Remove(id);
            _uow.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
