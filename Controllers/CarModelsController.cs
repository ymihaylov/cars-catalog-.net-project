using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarsCatalog.Context;
using CarsCatalog.Models;
using CarsCatalog.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CarsCatalog.Controllers
{
    public class CarModels : Controller
    {
        private readonly CarsCatalogContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CarModels(CarsCatalogContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: CarModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarModel.Include(carModel => carModel).ToListAsync());
        }

        // GET: CarModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModel = await _context.CarModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carModel == null)
            {
                return NotFound();
            }

            return View(carModel);
        }

        // GET: CarModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Photo,Description")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carModel);
        }

        // GET: CarModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModel = await _context.CarModel.FindAsync(id);
            if (carModel == null)
            {
                return NotFound();
            }

            CarModelCrudViewModel carModelCrudViewModel = new CarModelCrudViewModel()
            {
                Id = carModel.Id,
                Name = carModel.Name,
                Description = carModel.Description

            };
            return View(carModelCrudViewModel);
        }

        // POST: CarModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Photo,Description")] CarModelCrudViewModel carViewModel)
        {


            //if (id != carModel.Id)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(carViewModel);
                CarModel carModel = _context
                    .CarModel
                    .Single(carModel => carModel.Id == id);

                carModel.Name = carViewModel.Name;
                carModel.Description = carViewModel.Description;
                carModel.Photo = uniqueFileName;

                _context.Update(carModel);
                await _context.SaveChangesAsync();

                //    try
                //    {
                //        _context.Update(carModel);
                //        await _context.SaveChangesAsync();
                //    }
                //    catch (DbUpdateConcurrencyException)
                //    {
                //        if (!CarModelExists(carModel.Id))
                //        {
                //            return NotFound();
                //        }
                //        else
                //        {
                //            throw;
                //        }
                //    }
                //    return RedirectToAction(nameof(Index));
            }
            return View(carViewModel);
        }

        private string UploadedFile(CarModelCrudViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "img/uploads");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        // GET: CarModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModel = await _context.CarModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carModel == null)
            {
                return NotFound();
            }

            return View(carModel);
        }

        // POST: CarModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carModel = await _context.CarModel.FindAsync(id);
            _context.CarModel.Remove(carModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarModelExists(int id)
        {
            return _context.CarModel.Any(e => e.Id == id);
        }
    }
}
