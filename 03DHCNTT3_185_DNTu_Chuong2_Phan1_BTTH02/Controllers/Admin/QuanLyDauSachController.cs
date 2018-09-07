using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DTO;
using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.BUS;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Controllers.Admin
{
    public class QuanLyDauSachController : Controller
    {
        // GET: QuanLyDauSach
        public ActionResult Xem()
        {
            if (Session["role"] != "a")
            {
                return Redirect("/TrangChu/Xem");
            }
          //  List<Sach_DTO> sachs = Sach_BUS.Laydanhsachcacdausach();
          //  ViewBag.sachs = sachs;
            return View("~/Views/Admin/QuanLyDauSach/Xem.cshtml");
        }
    }
}