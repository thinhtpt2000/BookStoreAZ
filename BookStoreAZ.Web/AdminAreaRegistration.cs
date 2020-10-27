using System.Web.Mvc;

namespace BookStoreAZ.MVC
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute("", "Admin", new { controller = "BookManagement", action = "Index" });
            context.MapRoute("", "Admin/ManageBook", new { controller = "BookManagement", action = "Index" });
            context.MapRoute("", "Admin/ManageBook/{id}", new { controller = "BookManagement", action = "Book" });
        }
    }
}