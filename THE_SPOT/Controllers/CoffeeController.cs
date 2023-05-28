using Microsoft.AspNetCore.Mvc;

namespace THE_SPOT.Controllers
{
    public class CoffeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
