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
    //public class PagedListConverter : ITypeConverter<IEnumerable<Book>, PagedList<BookModel>>
    //{
    //    public PagedList<BookModel> Convert(ResolutionContext context)
    //    {
    //        var source = (IEnumerable<Book>)context.SourceValue;
    //        var dest = source.Select(b => Mapper.Map<Book, BookModel>(b)).ToList();
    //        return new PagedList<BookModel>(dest, models.PageIndex, models.PageSize);
    //    }
    //}

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