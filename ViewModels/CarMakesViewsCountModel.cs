using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using CarsCatalog.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarsCatalog.ViewModels
{
    public class CarMakesViewsCountModel
    {
        public CarMake carMake { get; set; }
        public int viewsCount { get; set; }
    }
}
