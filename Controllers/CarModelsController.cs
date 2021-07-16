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
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarModel.Include(carModel => carModel.CarMake).ToListAsync());
        }

        // GET: CarModels/Create
        [Authorize]
        public IActionResult Create()
        {
            CarModelCrudViewModel carModelCrudViewModel = new CarModelCrudViewModel()
            {
                CarMakeId = new SelectList(_context.CarMake, "Id", "Name"),
            };

            return View(carModelCrudViewModel);
        }

        // POST: CarModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Name,Photo,Description,SelectedCarMakeId")] CarModelCrudViewModel carViewModel)
        {
            if (ModelState.IsValid)
            {
                CarModel carModel = new()
                {
                    Name = carViewModel.Name,
                    Description = carViewModel.Description,
                    CarMakeId = carViewModel.SelectedCarMakeId
                };

                string uniqueFileName = UploadedFile(carViewModel);

                if (carViewModel.Photo != null)
                {
                    carModel.Photo = uniqueFileName;
                }

                _context.Add(carModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carViewModel);
        }

        // GET: CarModels/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarModel carModel = _context
                .CarModel
                .Include(carModel => carModel.CarMake)
                .Include(carModel => carModel.Comments)
                .Single(carModel => carModel.Id == id);

            if (carModel == null)
            {
                return NotFound();
            }

            CarModelCrudViewModel carModelCrudViewModel = new CarModelCrudViewModel()
            {
                Id = carModel.Id,
                Name = carModel.Name,
                Description = carModel.Description,
                PhotoPath = carModel.Photo,
                CarMakeId = new SelectList(_context.CarMake, "Id", "Name", carModel.CarMakeId),
                SelectedCarMakeId = carModel.CarMakeId,
                CommentsWaitingApproval = carModel
                    .Comments
                    .Where(comment => comment.Approved == false && comment.Disapproved == false)
                    .OrderByDescending(comment => comment.CreatedDate)
                    .ToList()
            };

            return View(carModelCrudViewModel);
        }

        // POST: CarModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Photo,Description,SelectedCarMakeId")] CarModelCrudViewModel carViewModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(carViewModel);
                CarModel carModel = _context
                    .CarModel
                    .Include(carModel => carModel.CarMake)
                    .Single(carModel => carModel.Id == id);

                carModel.Name = carViewModel.Name;
                carModel.Description = carViewModel.Description;
                carModel.CarMakeId = carViewModel.SelectedCarMakeId;

                if (carViewModel.Photo != null)
                {
                    carModel.Photo = uniqueFileName;
                }
                
                _context.Update(carModel);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
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

            return "/img/uploads/" + uniqueFileName;
        }

        // GET: CarModels/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModel = _context.CarModel.Include(carModel => carModel.CarMake).Single(carModel => carModel.Id == id);
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

        [HttpPost]
        public IActionResult ChangeCommentStatus(int commentId, string actionString)
        {
            var comment = _context.Comments.Single(comment => comment.Id == commentId);

            if (actionString == "approve")
            {
                comment.Approved = true;
            }

            if (actionString == "disaprove")
            {
                comment.Approved = false;
                comment.Disapproved = true; 
            }

            _context.Update(comment);
            _context.SaveChanges();

            return new OkResult();
        }
    }
}

