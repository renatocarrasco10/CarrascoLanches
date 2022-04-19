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

        public IActionResult List()
        {
           
            var lanchesListViewModel = new LancheListViewModel();
            lanchesListViewModel.Lanches = _lancheRepository.Lanches;
            lanchesListViewModel.CategoriaAtual = "Categoria Atual";

            int TotalLanches = lanchesListViewModel.Lanches.Count();
            ViewBag.Total = "Total de Lanches: ";
            ViewBag.TotalLanches = TotalLanches;

            return View(lanchesListViewModel);

            
        }
    }
}
