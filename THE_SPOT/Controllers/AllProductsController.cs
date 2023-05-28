using Microsoft.AspNetCore.Mvc;

namespace THE_SPOT.Controllers
{
    public class AllProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
