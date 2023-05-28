using Microsoft.AspNetCore.Mvc;

namespace THE_SPOT.Controllers
{
    public class SalesEmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
