using BookStoreAZ.Business;
using BookStoreAZ.Data;
using System.Collections.Generic;

namespace BookStoreAZ.ActionService
{
    public class Service : IService
    {
        private static readonly IDaoFactory factory = new DaoFactory();

        private static readonly ICategoryDao categoryDao = factory.CategoryDao;
        private static readonly IBookDao bookDao = factory.BookDao;
        private static readonly IAuthorDao authorDao = factory.AuthorDao;
        private static readonly IPublisherDao publisherDao = factory.PublisherDao;

        public IEnumerable<Author> GetAuthors()
        {
            return authorDao.GetAuthors();
        }

        public Business.Book GetBook(int bookID)
        {
            return bookDao.GetBook(bookID);
        }

        public IEnumerable<Book> GetBooks()
        {
            return bookDao.GetBooks();
        }

        public IEnumerable<Category> GetCategories()
        {
            return categoryDao.GetCategories();
        }

        public Category GetCategoryByBook(int bookID)
        {
            return categoryDao.GetCategoryByBook(bookID);
        }

        public IEnumerable<Publisher> GetPublishers()
        {
            return publisherDao.GetPublishers();
        }

        public void InsertBook(Book book)
        {
            bookDao.InsertBook(book);
        }

        public void UpdateBook(Book book)
        {
            bookDao.UpdateBook(book);
        }
    }
}