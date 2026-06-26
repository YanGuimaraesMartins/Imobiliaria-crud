using Microsoft.AspNetCore.Mvc;

namespace Imobiliaria.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
