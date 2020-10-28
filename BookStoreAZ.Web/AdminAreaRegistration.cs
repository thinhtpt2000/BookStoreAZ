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
            context.MapRoute("", "Admin", new { controller = "AdminBook", action = "Index" });
            context.MapRoute("", "Admin/ManageBook", new { controller = "AdminBook", action = "Index" });
            context.MapRoute("", "Admin/ManageBook/{id}", new { controller = "AdminBook", action = "AddOrEditBook" });
        }
    }
}