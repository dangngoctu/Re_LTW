using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DTO;
using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DAO;
using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.BUS;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Controllers.ThuVien
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap
        public ActionResult NhapThongTin()
        {
            if (Session["role"] != "u")
            {
                return Redirect("/TrangChu/Xem");
            }
            return View("~/Views/ThuVien/DangNhap/NhapThongTin.cshtml");
        }

        
        public ActionResult ThucHienDangXuat()
        {
            Session["name"] = "";
            Session["role"] = "u";
            Session["image"] = "";

            if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
            {
                Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);
            }

            return Redirect("/TrangChu/Xem");

        }
    }
}