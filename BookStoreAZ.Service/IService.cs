using BookStoreAZ.Business;
using X.PagedList;
using System.Collections.Generic;

namespace BookStoreAZ.ActionService
{
    public interface IService
    {
        IEnumerable<Category> GetCategories();

        Category GetCategoryByBook(int bookID);

        int InsertCategory(Category category);

        IPagedList<Book> GetBooks(int pageNumber = 1, int pageSize = 10);

        Book GetBook(int bookID);

        void UpdateBook(Book book);

        void InsertBook(Book book);

        IEnumerable<Publisher> GetPublishers();
        int InsertPublisher(Publisher publisher);

        IEnumerable<Author> GetAuthors();

        int InsertAuthor(Author author);
    }
}