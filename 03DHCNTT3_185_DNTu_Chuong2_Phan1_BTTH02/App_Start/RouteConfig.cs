using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Admin",
                url: "QuanTri/{controller}/{action}",
                defaults: new { controller = "QuanLyDauSach", action = "Xem", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                 url: "{Controller}/{action}/{id}",
                defaults: new { controller = "KhoSach", action = "Xem", id = UrlParameter.Optional }
            );
        }
    }
}
