using BookStoreAZ.Business;
using System.Collections.Generic;

namespace BookStoreAZ.ActionService
{
    public interface IService
    {
        IEnumerable<Category> GetCategories();

        Category GetCategoryByBook(int bookID);

        IEnumerable<Book> GetBooks();
        Book GetBook(int bookID);
        void UpdateBook(Book book);
        void InsertBook(Book book);

        IEnumerable<Publisher> GetPublishers();

        IEnumerable<Author> GetAuthors();
    }
}