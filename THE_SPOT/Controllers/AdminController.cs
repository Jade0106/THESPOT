using Microsoft.AspNetCore.Mvc;

namespace THE_SPOT.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
