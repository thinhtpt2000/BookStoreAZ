using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreAZ.MVC.Models
{
    public class BookModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(256)]
        [Display(Name = "Book Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int? Promotion { get; set; }

        public bool? Status { get; set; }

        [Display(Name = "Book Category")]
        public int CategoryID { get; set; }
        [NotMapped]
        public IEnumerable<CategoryModel> Categories { get; set; }

        public int AuthorID { get; set; }
        public IEnumerable<AuthorModel> Authors { get; set; }


        public int PublisherID { get; set; }
        public IEnumerable<PublisherModel> Publishers { get; set; }
    }
}