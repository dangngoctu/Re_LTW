﻿using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.BUS;
using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Controllers.ThuVien
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        public ActionResult ThucHienTimKiem(string khoa, string sapxep, string trang)
        {
            int soluongsach = Sach_BUS.SoLuongSachTimKiemDuoc(khoa);
            int sosachtrongtrang = 30;
            int tranghientai = 1;
            string cotsapxep = "ngaydang";
            if (sapxep != null && sapxep != "")
            {
                cotsapxep = (string)sapxep;
            }
            if (trang != null && trang != "")
            {
                tranghientai = int.Parse(trang);
            }

            int sotrang = (int)Math.Ceiling((float)soluongsach / (float)sosachtrongtrang);

            if (tranghientai < 1)
            {
                tranghientai = 1;
            }
            else if (tranghientai > sotrang)
            {
                tranghientai = sotrang;
            }
            List<DauSachFull_DTO> dausachs = new List<DauSachFull_DTO>();
            if (sotrang > 0)
            {
                dausachs = Sach_BUS.TimKiemSachVaPhanTrang(khoa,sosachtrongtrang, tranghientai, cotsapxep);
            }
            ViewBag.soluongsach = soluongsach;
            ViewBag.dausachs = dausachs;
            ViewBag.tranghientai = tranghientai;
            ViewBag.sotrang = sotrang;
            ViewBag.cotsapxep = cotsapxep;
            ViewBag.khoa = khoa;
            return View("~/Views/ThuVien/KhoSach/ThucHienTimKiem.cshtml");
        }
    }
}