using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Controllers.Admin
{
    public class ThemMoiTacGiaController : Controller
    {
        // GET: ThemMoiTacGia
        public ActionResult Xem()
        {
            if (Session["role"] != "a")
            {
                return Redirect("/TrangChu/Xem");
            }
            return View("~/Views/Admin/ThemMoiTacGia/Xem.cshtml");
        }
    }
}