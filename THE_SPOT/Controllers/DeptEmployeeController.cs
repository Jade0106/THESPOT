using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using THE_SPOT.Data;
using THE_SPOT.Models;

namespace THE_SPOT.Controllers
{
    public class DeptEmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        static int? deleteId;

        public DeptEmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }

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
        public IActionResult CoffeeDeptPR()
        {
            return View();
        }
        public IActionResult TeaDeptPR()
        {
            return View();
        }
        public IActionResult MugsDeptPR()
        {
            return View();
        }
        public IActionResult PRHistoryDepartments()
        {
            IEnumerable<CoffeeDeptPR> objList = _db.CoffeeDeptPR;
            return View(objList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoffeeDeptPR obj)
        {
            if (ModelState.IsValid)
            {
                _db.CoffeeDeptPR.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.CoffeeDeptPR.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST-Update updating the current data we have 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CoffeeDeptPR obj)
        {
            _db.CoffeeDeptPR.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {

            deleteId = id;

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.CoffeeDeptPR.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.CoffeeDeptPR.Find(deleteId);

            try
            {
                _db.CoffeeDeptPR.Remove(obj);
                _db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                if (obj == null)
                {
                    return NotFound();
                }
            }
            return RedirectToAction("Index");
        }

    }
}
