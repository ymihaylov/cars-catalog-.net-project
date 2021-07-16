using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CarsCatalog.Context;
using CarsCatalog.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarsCatalog.Controllers
{
    public class CommentsController : Controller
    {
        private readonly CarsCatalogContext _context;


        public CommentsController(CarsCatalogContext context)
        {
            _context = context;

        }

        public IActionResult CommentsWaitingApproval()
        {

            //var comments = _context
            //    .Comments
            //    .Select(comment => new { comment.CarModel, comment.CarModel.CarMake })
            //    //.Where(comment => comment.Approved == false)
            //    .Include(_ => _.CarModel)
            //    .ToList();

            var list = new List<Comment>();

            list.AddRange(_context.Set<Comment>()
                .Include(c => c.CarModel)
                .ToList());


            var comments = _context
                .Comments
                .Include(comment => comment.CarModel);

            ViewBag.Comments = comments;
            return View();
        }
    }
}