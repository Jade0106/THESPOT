using Microsoft.AspNetCore.Mvc;

namespace THE_SPOT.Controllers
{
    public class TeaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
