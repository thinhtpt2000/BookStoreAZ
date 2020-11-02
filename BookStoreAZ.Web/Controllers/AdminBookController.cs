using AutoMapper;
using BookStoreAZ.ActionService;
using BookStoreAZ.Business;
using BookStoreAZ.MVC.Models;
using X.PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookStoreAZ.MVC.Controllers
{
    public class AdminBookController : Controller
    {
        private IService Service { get; set; }

        static AdminBookController()
        {
            Mapper.CreateMap<Book, BookModel>();
            Mapper.CreateMap<BookModel, Book>();
            Mapper.CreateMap<Publisher, PublisherModel>();
            Mapper.CreateMap<PublisherModel, Publisher>();
            Mapper.CreateMap<Author, AuthorModel>();
            Mapper.CreateMap<AuthorModel, Author>();
            Mapper.CreateMap<Category, CategoryModel>();
            Mapper.CreateMap<CategoryModel, Category>();
        }

        public AdminBookController() : this(new Service())
        {
        }

        public AdminBookController(IService service)
        {
            this.Service = service;
        }

        // GET: BookManagement
        public ActionResult Index(int page = 1, string message = null)
        {
            var model = new BooksModel { Message = message };
            var pagedBooks = Service.GetBooks(page);
            var books = Mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(pagedBooks.ToArray());
            model.Books = new StaticPagedList<BookModel>(books, pagedBooks.GetMetaData());
            return View(model);
        }

        [HttpGet]
        public ActionResult AddOrEditBook(int id = 0)
        {
            NewBookModel model = new NewBookModel();
            BookModel bookModel = new BookModel();

            var book = Service.GetBook(id);

            if (id > 0 && book != null)
            {
                bookModel = Mapper.Map<Book, BookModel>(book);
                ViewBag.Title = "Edit book";
            }
            else
            {
                bookModel.Status = true;
                ViewBag.Title = "Add Book";
            }

            var categories = Service.GetCategories();
            IEnumerable<CategoryModel> categoryModel = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(categories);
            bookModel.Categories = categoryModel;

            var publishers = Service.GetPublishers();
            IEnumerable<PublisherModel> publisherModel = Mapper.Map<IEnumerable<Publisher>, IEnumerable<PublisherModel>>(publishers);
            bookModel.Publishers = publisherModel;

            var authors = Service.GetAuthors();
            IEnumerable<AuthorModel> authorModel = Mapper.Map<IEnumerable<Author>, IEnumerable<AuthorModel>>(authors);
            bookModel.Authors = authorModel;

            model.Book = bookModel;

            return View(model);
        }

        [HttpPost]
        public ActionResult AddOrEditBook(NewBookModel newModel)
        {
            if (ModelState.IsValid)
            {
                var book = Mapper.Map<BookModel, Book>(newModel.Book);
                string message;
                if (book.ID > 0)
                {
                    Service.UpdateBook(book);
                    message = "Book successfully updated";
                }
                else
                {
                    Service.InsertBook(book);
                    message = "Book successfully added";
                }
                return RedirectToAction("Index", new { message = message });
            }
            else
            {
                var categories = Service.GetCategories();
                IEnumerable<CategoryModel> categoryModel = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(categories);
                newModel.Book.Categories = categoryModel;

                var publishers = Service.GetPublishers();
                IEnumerable<PublisherModel> publisherModel = Mapper.Map<IEnumerable<Publisher>, IEnumerable<PublisherModel>>(publishers);
                newModel.Book.Publishers = publisherModel;

                var authors = Service.GetAuthors();
                IEnumerable<AuthorModel> authorModel = Mapper.Map<IEnumerable<Author>, IEnumerable<AuthorModel>>(authors);
                newModel.Book.Authors = authorModel;
            }
            return View(newModel);
        }
    }
}