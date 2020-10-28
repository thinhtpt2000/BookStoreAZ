using BookStoreAZ.Business;
using X.PagedList;

namespace BookStoreAZ.Data
{
    public interface IBookDao
    {
        IPagedList<Book> GetBooks(int pageNumber = 1, int pageSize = 10);

        Book GetBook(int bookID);

        void InsertBook(Book book);

        void UpdateBook(Book book);
    }
}