using THE_SPOT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using THE_SPOT.Data;

namespace THE_SPOT.Controllers
{
    public class CoffeeDeptPRController : Controller
    {
        private readonly ApplicationDbContext _db;
        static int? deleteId;

        public CoffeeDeptPRController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
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
        public async Task<IActionResult> Index1(string searchString)
        {

            ViewData["CurrentFilter"] = searchString;

            var coffeeDeptPR = from s in _db.CoffeeDeptPR
                               select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                coffeeDeptPR = coffeeDeptPR.Where(s => s.description.Contains(searchString)
                                       || s.description.Contains(searchString));
            }

            return View(await coffeeDeptPR.AsNoTracking().ToListAsync());
        }
    }

}
