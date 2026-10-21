using Microsoft.AspNetCore.Mvc;

namespace _01.Controllers
{
    public class PlanetController : Controller
    {
        public IActionResult BestPlaces()
        {
            return View();
        }
    }
}