using AutoMapper;
using BookStoreAZ.ActionService;
using BookStoreAZ.MVC.Models;
using System.Web.Http;

namespace BookStoreAZ.MVC.Controllers
{
    public class CategoryController : ApiController
    {
        private IService Service { get; set; }

        // static constructor. establishes Automapper object maps

        static CategoryController()
        {
            //Mapper.CreateMap<Category, CategoryModel>()
            //    .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => string.Format("{0:C}", src.UnitPrice)));
            Mapper.CreateMap<CategoryModel, Business.Category>();
        }

        // default constructor

        public CategoryController() : this(new Service())
        {
        }

        // overloaded 'injectable' constructor
        // ** Constructor Dependency Injection (DI).

        public CategoryController(IService service)
        {
            this.Service = service;
        }

        [HttpGet]
        public Business.Category Get(int id)
        {
            return Service.GetCategoryByBook(id);
        }
    }
}