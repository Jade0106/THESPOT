﻿using THE_SPOT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using THE_SPOT.Data;

namespace THE_SPOT.Controllers
{
    public class TeaDeptPRController : Controller
    {
        private readonly ApplicationDbContext _db;
        static int? deleteId;

        public TeaDeptPRController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<TeaDeptPR> objList = _db.TeaDeptPR;
            return View(objList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TeaDeptPR obj)
        {
            if (ModelState.IsValid)
            {
                _db.TeaDeptPR.Add(obj);
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
        public IActionResult Update(TeaDeptPR obj)
        {
            _db.TeaDeptPR.Update(obj);
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
            var obj = _db.TeaDeptPR.Find(id);
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
        public async Task<IActionResult> Index1(string searchString)
        {

            ViewData["CurrentFilter"] = searchString;

            var teaDeptPR = from s in _db.TeaDeptPR
                               select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                teaDeptPR = teaDeptPR.Where(s => s.description.Contains(searchString)
                                       || s.description.Contains(searchString));
            }

            return View(await teaDeptPR.AsNoTracking().ToListAsync());
        }
    }

}
