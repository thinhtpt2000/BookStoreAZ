namespace BookStoreAZ.MVC.Models
{
    public class NewBookModel
    {
        public BookModel Book { get; set; }
        public AuthorModel Author { get; set; }
        public PublisherModel Publisher { get; set; }
        public CategoryModel Category { get; set; }
    }
}