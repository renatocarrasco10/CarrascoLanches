using Microsoft.AspNetCore.Mvc;

namespace CarrascoLanches.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
