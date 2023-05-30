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
    public class MugsDeptPRController : Controller
    {
        private readonly ApplicationDbContext _db;
        static int? deleteId;

        public MugsDeptPRController(ApplicationDbContext db)
        {
            _db = db;
        }
        //public IActionResult Index()
        //{
        //    IEnumerable<MugsDeptPR> objList = _db.MugsDeptPR;
        //    return View(objList);
        //}
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MugsDeptPR obj)
        {
            if (ModelState.IsValid)
            {
                _db.MugsDeptPR.Add(obj);
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
        public IActionResult Update(MugsDeptPR obj)
        {
            _db.MugsDeptPR.Update(obj);
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
            var obj = _db.MugsDeptPR.Find(id);
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
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "description" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            var mugsDeptPRs = from s in _db.MugsDeptPR
                              select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                mugsDeptPRs = mugsDeptPRs.Where(s => s.description.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "qty":
                    mugsDeptPRs = mugsDeptPRs.OrderByDescending(s => s.qty);
                    break;
                case "description":
                    mugsDeptPRs = mugsDeptPRs.OrderBy(s => s.description);
                    break;
                case "itemPrice":
                    mugsDeptPRs = mugsDeptPRs.OrderByDescending(s => s.itemPrice);
                    break;
                case "date":
                    mugsDeptPRs = mugsDeptPRs.OrderByDescending(s => s.date);
                    break;
                case "status":
                    mugsDeptPRs = mugsDeptPRs.OrderByDescending(s => s.PRstatus);
                    break;
                default:
                    mugsDeptPRs = mugsDeptPRs.OrderBy(s => s.description);
                    break;
            }
            return View(await mugsDeptPRs.AsNoTracking().ToListAsync());
        }
    }

}
