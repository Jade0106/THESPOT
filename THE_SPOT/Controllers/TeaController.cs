using THE_SPOT.Data;
using THE_SPOT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace THE_SPOT.Controllers
{
    public class TeaController : Controller
    {
        private readonly ApplicationDbContext db;
        static int? deleteId;
        private readonly IWebHostEnvironment webHostEnvironment;
        public TeaController(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            db = dbContext;
            this.webHostEnvironment = webHostEnvironment;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index1(string searchString)
        {
            ViewBag.CurrentFilter = searchString;

            IEnumerable<Tea> teasFromDb;

            if (!string.IsNullOrEmpty(searchString))
            {
                teasFromDb = db.Teas.Where(t => t.Name.Contains(searchString)).ToList();
            }
            else
            {
                teasFromDb = db.Teas.ToList();
            }

            IEnumerable<TeaViewModel> teas = teasFromDb.Select(t => new TeaViewModel
            {
                TeaId = t.TeaId,
                Name = t.Name,
                Description = t.Description,
                Price = t.Price,
                ImageFile = null, // Set the ImageFile property appropriately based on your application's logic
                Date = t.Date
            });

            return View(teas);
        }





        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tea = new Tea
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Date = model.Date ?? DateTime.Now
                };

                if (model.ImageFile != null)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(fileStream);
                    }

                    tea.Image = await System.IO.File.ReadAllBytesAsync(filePath);
                }

                db.Teas.Add(tea);
                await db.SaveChangesAsync();
                return RedirectToAction("Index1");
            }

            return View(model);
        }






        public IActionResult Delete(int id)
        {
            Tea tea = db.Teas.Find(id);
            if (tea == null)
            {
                return NotFound();
            }

            // Set the TeaId property of the tea object
            tea.TeaId = id;

            return View(tea);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var obj = db.Teas.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            try
            {
                db.Teas.Remove(obj);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Handle the exception if needed
                // For example, you can log the error or show a specific error message
                return RedirectToAction("Error");
            }

            return RedirectToAction("Index1");
        }

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var tea = db.Teas.Find(id);
            if (tea == null)
            {
                return NotFound();
            }

            var teaViewModel = new TeaViewModel
            {
                TeaId = tea.TeaId,
                Name = tea.Name,
                Description = tea.Description,
                Price = tea.Price,
                ImageFile = null, // Set the ImageFile property appropriately based on your application's logic
                Date = tea.Date
            };

            return View(teaViewModel);
        }


        //POST-Update updating the current data we have 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(TeaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tea = db.Teas.Find(model.TeaId);
                if (tea == null)
                {
                    return NotFound();
                }

                tea.Name = model.Name;
                tea.Description = model.Description;
                tea.Price = model.Price;
                tea.Date = model.Date ?? DateTime.Now;

                db.Teas.Update(tea);
                db.SaveChanges();

                return RedirectToAction("Index1");
            }

            return View(model);
        }
        public async Task<IActionResult> GenerateReport()
        {
            // Generate the report logic here
            // This can include retrieving the data, formatting it, and generating a report (e.g., PDF, Excel, etc.)

            // For example, you can use a reporting library like iTextSharp to generate a PDF report
            // Here's a simple example using iTextSharp to generate a PDF report
            // Make sure to install the iTextSharp NuGet package to use the library

            using (MemoryStream memoryStream = new MemoryStream())
            {
                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document();
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);

                pdfDoc.Open();

                // Add content to the PDF document
                pdfDoc.Add(new Paragraph("2023 "));
                pdfDoc.Add(new Paragraph("THE SPOT"));
                pdfDoc.Add(new Paragraph("Tea Report"));
                pdfDoc.Add(new Paragraph(""));
                // Example: Add a table with the tea data
                PdfPTable table = new PdfPTable(5);
                table.AddCell("Name");
                table.AddCell("Description");
                table.AddCell("Price");
                table.AddCell("Image");
                table.AddCell("Date");

                foreach (var tea in db.Teas.ToList())
                {
                    table.AddCell(tea.Name);
                    table.AddCell(tea.Description);
                    table.AddCell(tea.Price.ToString());

                    if (tea.ImageFile != null)
                    {
                        // Save the IFormFile as a temporary file
                        string imagePath = Path.GetTempFileName();
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            await tea.ImageFile.CopyToAsync(stream);
                        }

                        // Create an Image object from the temporary file path
                        Image teaImage = Image.GetInstance(imagePath);
                        PdfPCell imageCell = new PdfPCell(teaImage, true);
                        table.AddCell(imageCell);
                    }
                    else
                    {
                        table.AddCell("");
                    }

                    table.AddCell(tea.Date.ToString());
                }

                pdfDoc.Add(table);

                pdfDoc.Close();

                // Return the PDF file
                return File(memoryStream.ToArray(), "application/pdf", "TeaReport.pdf");
            }
        }
    }
}
