using BookStoreAZ.Business;
using System.Collections.Generic;

namespace BookStoreAZ.Data
{
    public interface IBookDao
    {
        IEnumerable<Book> GetBooks();

        Book GetBook(int bookID);

        void InsertBook(Book book);

        void UpdateBook(Book book);
    }
}