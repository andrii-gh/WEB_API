using Microsoft.AspNetCore.Mvc;

namespace _01.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult Favorite()
        {
            return View();
        }
    }
}
