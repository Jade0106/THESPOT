using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using THE_SPOT.Data;
using THE_SPOT.Models;

namespace THE_SPOT.Controllers
{
    public class DeptEmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewProducts()
        {
            return View();
        }
        public IActionResult PRDepartments()
        {
            return View();
        }
        public IActionResult PRHistoryDepartments()
        {
            return View();
        }
       
    }
}
