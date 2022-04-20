using CarrascoLanches.Models;
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
                if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches
                                .Where(l => l.Categoria.CategoriaNome.Equals("Normal", StringComparison.OrdinalIgnoreCase))
                                .OrderBy(l => l.Nome);
                }
                else 
                {
                    lanches = _lancheRepository.Lanches
                                .Where(l => l.Categoria.CategoriaNome.Equals("Natural", StringComparison.OrdinalIgnoreCase))
                                .OrderBy(l => l.Nome);
                    
                }
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
    }
}
