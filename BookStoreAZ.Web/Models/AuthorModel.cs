using System;
using System.ComponentModel.DataAnnotations;

namespace BookStoreAZ.MVC.Models
{
    public class AuthorModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(256, ErrorMessage = "Name can be at most 256 chars")]
        public string Name { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(256, ErrorMessage = "Country can be at most 256 chars")]
        public string Country { get; set; }
    }
}