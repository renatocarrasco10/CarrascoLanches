using CarrascoLanches.Repositories.Interfaces;
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
            ViewData["Titulo"] = "Todos os Produtos";

            var lanches = _lancheRepository.Lanches;
            int TotalLanches = lanches.Count();
            ViewBag.Total = "Total de Lanches: ";
            ViewBag.TotalLanches = TotalLanches;

            return View(lanches);
        }
    }
}
