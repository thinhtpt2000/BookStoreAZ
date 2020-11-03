using BookStoreAZ.Business;
using BookStoreAZ.Data;
using X.PagedList;
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

        public IPagedList<Book> GetBooks(int pageNumber = 1, int pageSize = 10)
        {
            return bookDao.GetBooks(pageNumber, pageSize);
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

        public int InsertAuthor(Author author)
        {
            return authorDao.InsertAuthor(author);
        }

        public void InsertBook(Book book)
        {
            bookDao.InsertBook(book);
        }

        public int InsertCategory(Category category)
        {
            return categoryDao.InsertCategory(category);
        }

        public int InsertPublisher(Publisher publisher)
        {
            return publisherDao.InsertPublisher(publisher);
        }

        public void UpdateBook(Book book)
        {
            bookDao.UpdateBook(book);
        }
    }
}