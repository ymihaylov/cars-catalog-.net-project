using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarsCatalog.Models;
using CarsCatalog.ViewModels;

using Microsoft.EntityFrameworkCore;
using CarsCatalog.Context;

namespace CarsCatalog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CarsCatalogContext _context;


        public HomeController(CarsCatalogContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
            
        }

        public async Task<IActionResult> IndexAsync()
        {
            var carMakes = _context.CarMake.ToList();
            return View(carMakes);
        }

        public async Task<IActionResult> CarModelsAsync(int id)
        {
            CarMake carMake = _context
                .CarMake
                .Include(carMake => carMake.CarModels)
                .Single(carMake => carMake.Id == id);

            return View(carMake.CarModels);
        }

        public async Task<IActionResult> ShowCarAsync(int id)
        {
            var comments = _context
                .Comments
                .Include(c => c.CarModel)
                .ToList();

            CarModel carModel = _context
                .CarModel
                .Include(carModel => carModel.CarMake)
                .Include(carModel => carModel.Comments.Where(comment => comment.Approved == true && comment.Disapproved == false).OrderByDescending(comment => comment.CreatedDate))
                .Include(carModel => carModel.Photos)
                .Single(carModel => carModel.Id == id);
            carModel.ViewsCount++;
            _context.CarModel.Update(carModel);
            _context.SaveChanges();

            return View(carModel);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchString)
        {
            ViewData["searchString"] = searchString;

            var terms = searchString.Split(" ");
            
            var carModels = _context
                .CarModel
                .Include(carModel => carModel.CarMake)
                .AsEnumerable()
                .Where(carModel => terms.Any(term => carModel.Name.IndexOf(term, comparisonType: StringComparison.OrdinalIgnoreCase) >= 0)
                    || terms.Any(term => carModel.Description.IndexOf(term, comparisonType: StringComparison.OrdinalIgnoreCase) >= 0)
                    || terms.Any(term => carModel.CarMake.Name.IndexOf(term, comparisonType: StringComparison.OrdinalIgnoreCase) >= 0)
                )
                .ToList();

            return View(carModels);
       }

        [HttpPost]
        public IActionResult PostAComment(string comment, int carModelId)
        {
            CarModel carModel = _context.CarModel.Single(carModel => carModel.Id == carModelId);
            Comment commentEntry = new Comment();
            commentEntry.Approved = false;
            commentEntry.Disapproved = false;
            commentEntry.CarModel = carModel;
            commentEntry.Description = comment;

            _context.Comments.Add(commentEntry);
            _context.SaveChanges();

            return new OkResult();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
