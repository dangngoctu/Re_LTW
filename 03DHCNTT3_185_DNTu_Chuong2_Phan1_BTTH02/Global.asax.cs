using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DTO;
using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Application["countOnline"] = 0;
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_End()
        {
            Application.Remove("countOnline");
        }
        protected void Session_Start()
        {
            int count = (int)Application["countOnline"];
            count = count + 1;
            Application["countOnline"] = count;
            Session.Add("manguoidung", "");
            Session.Add("manguoidung", "");
            Session.Add("hovaten", "");
            Session.Add("role", "u");
            /*if (Request.Cookies["tendangnhap"] != null && Request.Cookies["matkhau"] != null)
            {
                string username = Request.Cookies["username"].Value;
                string password = Request.Cookies["password"].Value;
                NguoiDung_DTO nguoidung = NguoiDung_BUS.LayThongTinNguoiDung(username, password);
                if (nguoidung != null)
                {
                    Session["name"] = nguoidung.Name;
                    Session["role"] = nguoidung.Role;
                    Session["image"] = nguoidung.Image;
                }
            } else
            {
                Session["name"] = "";
                Session["role"] = "u";
                Session["image"] = "";
            }*/

        }
        protected void Session_End()
        {
            int count = (int)Application["countOnline"];
            count = count - 1;
            Application["countOnline"] = count;

            Session.RemoveAll();
        }
        protected void Application_BeginRequest()
        {

        }
        protected void Application_EndRequest()
        {

        }
    }
}
