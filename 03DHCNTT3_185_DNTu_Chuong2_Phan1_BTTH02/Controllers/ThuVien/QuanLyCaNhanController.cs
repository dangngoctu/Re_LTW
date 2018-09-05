using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Controllers.ThuVien
{
    public class QuanLyCaNhanController : Controller
    {
        // GET: QuanLyCaNhan
        public ActionResult Xem()
        {
            if (Session["role"] != "a" && Session["role"] != "u")
            {
                return Redirect("/TrangChu/Xem");
            }
            return View("~/Views/ThuVien/QuanLyCaNhan/Xem.cshtml");
        }
    }
}