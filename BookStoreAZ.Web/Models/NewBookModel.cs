using System.Collections.Generic;

namespace BookStoreAZ.MVC.Models
{
    public class NewBookModel
    {
        public BookModel Book { get; set; }
        public IEnumerable<AuthorModel> Authors { get; set; }
        public IEnumerable<PublisherModel> Publishers { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}