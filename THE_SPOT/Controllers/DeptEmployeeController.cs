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
            IEnumerable<CoffeeDeptPR> objList = _db.CoffeeDeptPR;
            return View(objList);
        }
        public IActionResult CoffeeCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CoffeeCreate(CoffeeDeptPR obj)
        {
            if (ModelState.IsValid)
            {
                _db.CoffeeDeptPR.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult CoffeeUpdate(int? id)
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
        public IActionResult CoffeeUpdate(CoffeeDeptPR obj)
        {
            _db.CoffeeDeptPR.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult CoffeeDelete(int? id)
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
        public IActionResult CoffeeDeletePost(int? id)
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
        public IActionResult TeaDeptPR()
        {
            IEnumerable<TeaDeptPR> objList = _db.TeaDeptPR;
            return View(objList);
        }
        public IActionResult TeaCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TeaCreate(TeaDeptPR obj)
        {
            if (ModelState.IsValid)
            {
                _db.TeaDeptPR.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult TeaUpdate(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.TeaDeptPR.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST-Update updating the current data we have 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TeaUpdate(TeaDeptPR obj)
        {
            _db.TeaDeptPR.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult TeaDelete(int? id)
        {

            deleteId = id;

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.TeaDeptPR.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TeaDeletePost(int? id)
        {
            var obj = _db.TeaDeptPR.Find(deleteId);

            try
            {
                _db.TeaDeptPR.Remove(obj);
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
        public IActionResult MugsDeptPR()
        {
            IEnumerable<MugsDeptPR> objList = _db.MugsDeptPR;
            return View(objList);
        }
        public IActionResult MugsCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MugsCreate(MugsDeptPR obj)
        {
            if (ModelState.IsValid)
            {
                _db.MugsDeptPR.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult MugsUpdate(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.MugsDeptPR.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST-Update updating the current data we have 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MugsUpdate(MugsDeptPR obj)
        {
            _db.MugsDeptPR.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult MugsDelete(int? id)
        {

            deleteId = id;

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.MugsDeptPR.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MugsDeletePost(int? id)
        {
            var obj = _db.MugsDeptPR.Find(deleteId);

            try
            {
                _db.MugsDeptPR.Remove(obj);
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
