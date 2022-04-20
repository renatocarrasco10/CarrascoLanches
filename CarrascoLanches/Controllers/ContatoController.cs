using Microsoft.AspNetCore.Mvc;

namespace CarrascoLanches.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
