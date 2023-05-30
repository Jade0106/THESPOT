using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using THE_SPOT.Data;
using THE_SPOT.Models;

namespace THE_SPOT.Controllers
{
    public class StockControlEmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
