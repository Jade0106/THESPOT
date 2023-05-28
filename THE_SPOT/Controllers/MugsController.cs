using Microsoft.AspNetCore.Mvc;

namespace THE_SPOT.Controllers
{
    public class MugsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
