using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Controllers.ThuVien
{
    public class LienHeController : Controller
    {
        // GET: LienHe
        public ActionResult Xem()
        {
            return View("~/Views/ThuVien/LienHe/Xem.cshtml");
        }
    }
}