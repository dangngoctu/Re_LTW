﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Controllers.Admin
{
    public class QuanLyMuonSachController : Controller
    {
        // GET: QuanLyMuonSach
        public ActionResult Xem()
        {
            if (Session["role"] != "a")
            {
                return Redirect("/TrangChu/Xem");
            }
            return View("~/Views/Admin/QuanLyMuonSach/Xem.cshtml");
        }
    }
}