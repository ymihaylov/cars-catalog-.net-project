using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using CarsCatalog.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarsCatalog.ViewModels
{
    public class PhotosViewModel
    {
        public PhotosViewModel()
        {
        }

        public IFormFile Photo1 { get; set; }
        public string PhotoPath1 { get; set; }

        public IFormFile Photo2 { get; set; }
        public string PhotoPath2 { get; set; }

        public IFormFile Photo3 { get; set; }
        public string PhotoPath3 { get; set; }

        public IFormFile Photo4 { get; set; }
        public string PhotoPath4 { get; set; }

        public IFormFile Photo5 { get; set; }
        public string PhotoPath5 { get; set; }
    }
}
