using AutoMapper;
using BookStoreAZ.ActionService;
using BookStoreAZ.Business;
using BookStoreAZ.MVC.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BookStoreAZ.MVC.Controllers
{
    public class AdminCategoryController : Controller
    {
        private IService Service { get; set; }

        static AdminCategoryController()
        {
            Mapper.CreateMap<Category, CategoryModel>();
            Mapper.CreateMap<CategoryModel, Category>();
        }

        public AdminCategoryController() : this(new Service())
        {
        }

        public AdminCategoryController(IService service)
        {
            this.Service = service;
        }

        // GET: BookManagement
        public ActionResult Index()
        {
            var model = new CategoryModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddCategoryAjax(NewBookModel newModel)
        {
            if (ModelState.IsValid)
            {
                var category = Mapper.Map<CategoryModel, Category>(newModel.Category);
                category.CreateDate = DateTime.Now;
                category.Status = true;
                int newID = Service.InsertCategory(category);
                return this.Json(new
                {
                    EnableSuccess = true,
                    SuccessTitle = "Success",
                    ID = newID.ToString(),
                    Name = category.Name
                });
            }
            return this.Json(new
            {
                EnableError = true,
                ErrorMsg = "Fail to add new category"
            });
        }
    }
}