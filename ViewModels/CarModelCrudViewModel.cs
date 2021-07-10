using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CarsCatalog.ViewModels
{
    public class CarModelCrudViewModel
    {
        public CarModelCrudViewModel()
        {
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public IFormFile Photo { get; set; }

        public string Description { get; set; } 
    }
}
