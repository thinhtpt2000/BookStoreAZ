using X.PagedList;

namespace BookStoreAZ.MVC.Models
{
    public class BooksModel
    {
        public string Message { get; set; }

        public IPagedList<BookModel> Books { get; set; }
    }
}