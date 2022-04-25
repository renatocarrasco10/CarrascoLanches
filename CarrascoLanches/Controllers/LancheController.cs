﻿using CarrascoLanches.Models;
using CarrascoLanches.Repositories.Interfaces;
using CarrascoLanches.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarrascoLanches.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;
            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.Nome);
                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                lanches = _lancheRepository.Lanches
                            .Where(l => l.Categoria.CategoriaNome.Equals(categoria, StringComparison.OrdinalIgnoreCase))
                            .OrderBy(l => l.Nome);

                categoriaAtual = categoria;
            }

            var lanchesListViewModel = new LancheListViewModel();
            lanchesListViewModel.Lanches = lanches;
            lanchesListViewModel.CategoriaAtual = categoriaAtual;

            int TotalLanches = lanchesListViewModel.Lanches.Count();
            ViewBag.Total = "Total de Lanches: ";
            ViewBag.TotalLanches = TotalLanches;

            return View(lanchesListViewModel);


        }

        public IActionResult Details(int lancheId)
        {
            var lanches = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);

            return View(lanches);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = String.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.Nome);
                ViewBag.Total = "Total de Lanches: ";
            }
            else
            {
                lanches = _lancheRepository.Lanches
                    .Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));
                if (lanches.Any())
                    categoriaAtual = "Lanches";
                else
                    categoriaAtual = "Nenhum lanche foi encontrado";
            }
            return View("~/Views/Lanche/List.cshtml", new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            });
        }
    }
}
