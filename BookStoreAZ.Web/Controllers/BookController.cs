using AutoMapper;
using BookStoreAZ.ActionService;
using BookStoreAZ.Business;
using BookStoreAZ.MVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BookStoreAZ.MVC.Controllers
{
    public class BookController : Controller
    {
        private IService Service { get; set; }

        static BookController()
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

        public BookController() : this(new Service())
        {
        }

        public BookController(IService service)
        {
            this.Service = service;
        }

        // GET: BookManagement
        public ActionResult Index(string message = null)
        {
            var model = new BooksModel { Message = message };

            var books = Service.GetBooks();
            model.Books = Mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
            return View(model);
        }

        [HttpGet]
        public ActionResult AddOrEditBook(int id = 0)
        {
            BookModel bookModel;

            var book = Service.GetBook(id);

            if (id > 0 && book != null)
            {
                bookModel = Mapper.Map<Book, BookModel>(book);
                ViewBag.Title = "Edit book";
            }
            else
            {
                bookModel = new BookModel();
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

            return View(bookModel);
        }

        [HttpPost]
        public ActionResult AddOrEditBook(BookModel model)
        {
            if (ModelState.IsValid)
            {
                var book = Mapper.Map<BookModel, Book>(model);
                System.Console.WriteLine(book.CategoryID);
                string message;
                if (book.ID > 0)
                {
                    Service.UpdateBook(book);
                    message = "Member successfully updated";
                }
                else
                {
                    Service.InsertBook(book);
                    message = "Member successfully added";
                }
                return RedirectToAction("Index", new { message = message });
            }
            else
            {
                var categories = Service.GetCategories();
                IEnumerable<CategoryModel> categoryModel = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(categories);
                model.Categories = categoryModel;

                var publishers = Service.GetPublishers();
                IEnumerable<PublisherModel> publisherModel = Mapper.Map<IEnumerable<Publisher>, IEnumerable<PublisherModel>>(publishers);
                model.Publishers = publisherModel;

                var authors = Service.GetAuthors();
                IEnumerable<AuthorModel> authorModel = Mapper.Map<IEnumerable<Author>, IEnumerable<AuthorModel>>(authors);
                model.Authors = authorModel;
            }
            return View(model);
        }
    }
}