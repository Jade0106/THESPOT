using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace THE_SPOT.Controllers
{
    public class AllProductsController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
