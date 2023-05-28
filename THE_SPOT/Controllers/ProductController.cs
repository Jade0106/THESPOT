//using THE_SPOT.Controllers;
//using THE_SPOT.Data;
//using THE_SPOT.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Collections;
//using System.Collections.Generic;

//namespace THE_SPOT.Controllers
//{
//    public class ProductController : Controller
//    {
//        private readonly ApplicationDbContext _db;
//        static int? deleteId;
//        public ProductController(ApplicationDbContext db)
//        {
//            _db = db;
//        }
//        public IActionResult Index()
//        {
//            IEnumerable<Product> objList = _db.Product;
//            return View(objList);
//        }
//        public IActionResult Create()
//        {
//            return View();
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Create(Product obj)
//        {
//            try
//            {
//                if (ModelState.IsValid)//Checks to see if all the required fields have been met.
//                {
//                    _db.Product.Add(obj);
//                    _db.SaveChanges();
//                    return RedirectToAction("Index");
//                }
//            }
//            catch (DbUpdateException ex)
//            {
//                ViewBag.Message = string.Format("Product added successfuly!");

//            }
//            return View(obj);
//        }
//        public IActionResult Update(int? id)
//        {
//            if (id == null || id == 0)
//            {
//                return NotFound();
//            }

//            var obj = _db.Product.Find(id);
//            if (obj == null)
//            {
//                return NotFound();
//            }

//            return View(obj);
//        }

//        //POST-Update updating the current data we have 
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Update(Product obj)
//        {
//            _db.Product.Update(obj);
//            _db.SaveChanges();
//            return RedirectToAction("Index");

//        }
//        public IActionResult Delete(int? id)
//        {

//            deleteId = id;

//            if (id == null || id == 0)
//            {
//                return NotFound();
//            }
//            var obj = _db.Product.Find(id);
//            if (obj == null)
//            {
//                return NotFound();
//            }
//            return View(obj);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult DeletePost(int? id)
//        {
//            var obj = _db.Product.Find(deleteId);

//            try
//            {

//                _db.Product.Remove(obj);
//                _db.SaveChanges();

//            }
//            catch (DbUpdateException ex)
//            {
//                if (obj == null)
//                {
//                    return NotFound();
//                }

//            }

//            return RedirectToAction("Index");
//        }
//    }
//}
