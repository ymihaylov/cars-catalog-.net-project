using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCatalog.Models
{
    public partial class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Photo { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public CarMake CarMake { get; set; }

        public int CarMakeId {get; set;}

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Photo> Photos { get; set; }
    }

}
