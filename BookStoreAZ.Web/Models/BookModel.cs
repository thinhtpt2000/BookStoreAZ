using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreAZ.MVC.Models
{
    public class BookModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(256, ErrorMessage = "Name must be less than 256 chars")]
        [Display(Name = "Book Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(500, ErrorMessage = "Description must be less than 500 chars")]
        public string Description { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1000, int.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than or equal 0.")]
        public int Quantity { get; set; }

        public int Promotion { get; set; }

        public bool Status { get; set; }

        [Display(Name = "Book Category")]
        public int CategoryID { get; set; }
        [NotMapped]
        public IEnumerable<CategoryModel> Categories { get; set; }

        [Display(Name = "Book Author")]
        public int AuthorID { get; set; }
        [NotMapped]
        public IEnumerable<AuthorModel> Authors { get; set; }

        [Display(Name = "Book Publisher")]
        public int PublisherID { get; set; }
        [NotMapped]
        public IEnumerable<PublisherModel> Publishers { get; set; }
    }
}