using AutoMapper;
using BookStoreAZ.ActionService;
using BookStoreAZ.Business;
using BookStoreAZ.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreAZ.MVC.Controllers
{
    public class AdminPublisherController : Controller
    {
       private IService Service { get; set; }

        static AdminPublisherController()
        {
            Mapper.CreateMap<Publisher, PublisherModel>();
            Mapper.CreateMap<PublisherModel, Publisher>();
        }

        public AdminPublisherController() : this(new Service())
        {
        }

        public AdminPublisherController(IService service)
        {
            this.Service = service;
        }

        public ActionResult Index()
        {
            var model = new PublisherModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddPublisherAjax(NewBookModel newModel)
        {
            if (ModelState.IsValid)
            {
                var publisher = Mapper.Map<PublisherModel, Publisher>(newModel.Publisher);
                publisher.CreateDate = DateTime.Now;
                int newID = Service.InsertPublisher(publisher);
                return this.Json(new
                {
                    EnableSuccess = true,
                    SuccessTitle = "Success",
                    ID = newID.ToString(),
                    Name = publisher.Name
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