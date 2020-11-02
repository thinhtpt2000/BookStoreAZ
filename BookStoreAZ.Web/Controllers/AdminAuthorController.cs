using AutoMapper;
using BookStoreAZ.ActionService;
using BookStoreAZ.Business;
using BookStoreAZ.MVC.Models;
using System;
using System.Web.Mvc;

namespace BookStoreAZ.MVC.Controllers
{
    public class AdminAuthorController : Controller
    {
        private IService Service { get; set; }

        static AdminAuthorController()
        {
            Mapper.CreateMap<Author, AuthorModel>();
            Mapper.CreateMap<AuthorModel, Author>();
        }

        public AdminAuthorController() : this(new Service())
        {
        }

        public AdminAuthorController(IService service)
        {
            this.Service = service;
        }

        public ActionResult Index()
        {
            var model = new CategoryModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddAuthorAjax(NewBookModel newModel)
        {
            if (ModelState.IsValid)
            {
                var author = Mapper.Map<AuthorModel, Author>(newModel.Author);
                int newID = Service.InsertAuthor(author);
                return this.Json(new
                {
                    EnableSuccess = true,
                    SuccessTitle = "Success",
                    ID = newID.ToString(),
                    Name = author.Name
                });
            }
            return this.Json(new
            {
                EnableError = true,
                ErrorMsg = "Fail to add new author"
            });
        }
    }
}