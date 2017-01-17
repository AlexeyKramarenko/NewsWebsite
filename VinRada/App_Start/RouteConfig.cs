using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace VinRada.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(null, "", "~/main.aspx");
            routes.MapPageRoute(null, "головна", "~/main.aspx");
            routes.MapPageRoute(null, "контакти", "~/contacts.aspx");
            routes.MapPageRoute(null, "новини", "~/news.aspx");
            routes.MapPageRoute(null, "404", "~/404.aspx");
            routes.MapPageRoute(null, "статтi/{type}", "~/articles.aspx");
            routes.MapPageRoute(null, "login", "~/login.aspx");
            routes.MapPageRoute(null, "адмiн", "~/admin/admin.aspx");
        }
    }
}
