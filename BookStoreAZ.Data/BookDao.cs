using AutoMapper;
using BookStoreAZ.Business;
using X.PagedList;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreAZ.Data
{
    public class BookDao : IBookDao
    {
        static BookDao()
        {
            Mapper.CreateMap<CategoryEntity, Category>();
            Mapper.CreateMap<BookEntity, Book>();
            Mapper.CreateMap<Book, BookEntity>();
        }

        public Book GetBook(int bookID)
        {
            using (var context = new Entities())
            {
                var book = context.BookEntities.Where(b => b.ID == bookID).FirstOrDefault();
                return Mapper.Map<BookEntity, Book>(book);
            }
        }

        public IPagedList<Book> GetBooks(int pageNumber = 1, int pageSize = 10)
        {
            using (var context = new Entities())
            {
                var bookEntities = context.BookEntities;
                var pagedBooks = bookEntities.OrderBy(b => b.ID).ToPagedList(pageNumber, pageSize);
                var books = Mapper.Map<IEnumerable<BookEntity>, IEnumerable<Book>>(pagedBooks.ToArray());
                return new StaticPagedList<Book>(books, pagedBooks.GetMetaData());
            }
        }

        public void InsertBook(Book book)
        {
            using (var context = new Entities())
            {
                var bookEntity = Mapper.Map<Book, BookEntity>(book);
                context.BookEntities.Add(bookEntity);
                context.SaveChanges();
                book.ID = bookEntity.ID;
            }
        }

        public void UpdateBook(Book book)
        {
            using (var context = new Entities())
            {
                var bookEntity = context.BookEntities.SingleOrDefault(m => m.ID == book.ID);
                bookEntity.Name = book.Name;
                bookEntity.Description = book.Description;
                bookEntity.Image = book.Image;
                bookEntity.CategoryID = book.CategoryID;
                bookEntity.Category = Mapper.Map<Category, CategoryEntity>(book.Category);
                bookEntity.AuthorID = book.AuthorID;
                bookEntity.Author = Mapper.Map<Author, AuthorEntity>(book.Author);
                bookEntity.PublisherID = book.PublisherID;
                bookEntity.Publisher = Mapper.Map<Publisher, PublisherEntity>(book.Publisher);
                bookEntity.Price = book.Price;
                bookEntity.Quantity = book.Quantity;
                bookEntity.Promotion = book.Promotion;
                bookEntity.Status = book.Status;

                //context.Members.Attach(entity);
                context.SaveChanges();
            }
        }
    }
}