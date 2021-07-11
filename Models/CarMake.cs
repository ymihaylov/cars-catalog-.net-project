using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarsCatalog.Models
{
    public partial class CarMake
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }

        public ICollection<CarModel> CarModels { get; set; }
    }
}
