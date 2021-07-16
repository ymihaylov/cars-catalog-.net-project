using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCatalog.Models
{
    public class Comment
    {
        public Comment()
        {
            this.CreatedDate = DateTime.UtcNow;
        }

        public int Id { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("CarModelId")]
        public CarModel CarModel { get; set; }

        public bool Approved { get; set; }

        public bool Disapproved { get; set; }

        public string Status { get; set; } = "waiting_approval";

        public int CarModelId { get; set; }
    }
}
