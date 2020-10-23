using AutoMapper;
using BookStoreAZ.ActionService;
using BookStoreAZ.Business;
using BookStoreAZ.Web.Models;
using System.Web.Http;

namespace BookStoreAZ.Web.Controllers
{
    public class CategoryController : ApiController
    {
        private IService service { get; set; }

        // static constructor. establishes Automapper object maps

        static CategoryController()
        {
            //Mapper.CreateMap<Category, CategoryModel>()
            //    .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => string.Format("{0:C}", src.UnitPrice)));
            Mapper.CreateMap<CategoryModel, Category>();
        }

        // default constructor

        public CategoryController() : this(new Service())
        {
        }

        // overloaded 'injectable' constructor
        // ** Constructor Dependency Injection (DI).

        public CategoryController(IService service)
        {
            this.service = service;
        }

        [HttpGet]
        public Category Get(int id)
        {
            return service.GetCategoryByBook(id);
        }
    }
}