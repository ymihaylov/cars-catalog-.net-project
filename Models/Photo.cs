using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCatalog.Models
{
    public partial class Photo
    {
        public int Id { get; set; }
        public int CarModelId { get; set; }

        [ForeignKey("CarModelId")]
        public CarModel CarModel { get; set; }

        public string Path { get; set; }
    }
}
