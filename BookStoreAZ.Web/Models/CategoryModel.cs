using System;
using System.ComponentModel.DataAnnotations;

namespace BookStoreAZ.MVC.Models
{
    public partial class CategoryModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(256, ErrorMessage = "Name can be at most 256 chars")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Description can be at most 256 chars")]
        public string Description { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}