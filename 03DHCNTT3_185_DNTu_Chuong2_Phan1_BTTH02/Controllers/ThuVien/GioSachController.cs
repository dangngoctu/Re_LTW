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
    public class GioSachController : Controller
    {
        // GET: GioSach
        public ActionResult ThemSach(string madausach, string urlnext)
        {
            if (Session["role"].ToString() == "u")
            {
                return Redirect("/DangNhap/NhapThongTin");
            }
            if (Session["role"].ToString() == "ma" || Session["role"].ToString() == "a")
            {
                return Redirect(urlnext);
            }
            Sach_DTO dausach = Sach_BUS.LayThongTinChiTietCuaDauSachBoiMa(madausach);
            if (dausach != null)
            {
                bool cotontai = false;
                foreach (Item_DTO item in (List<Item_DTO>)Session["items"])
                {
                    if (item.Madausach == dausach.Madausach)
                    {
                        item.Soluong = item.Soluong + 1;
                        cotontai = true;
                    }
                }
                if (cotontai == false)
                {
                    Item_DTO item = new Item_DTO();
                    item.Madausach = dausach.Madausach;
                    item.Tensach = dausach.Tensach;
                    item.Bia = dausach.Bia;
                    item.Soluong = 1;
                    ((List<Item_DTO>)Session["items"]).Add(item);
                }
            }
            return Redirect(urlnext);
        }

        public ActionResult XemChiTiet()
        {
            if (Session["role"].ToString() != "me")
            {
                return Redirect("/KhoSach/Xem");
            }
            return View("~/Views/ThuVien/KhoSach/ChiTietSach.cshtml");
        }

        public ActionResult XoaDauSachMuon(string madausach)
        {
            if (Session["role"].ToString() != "me")
            {
                return Redirect("/KhoSach/DuyetKhoSach");
            }
            List<Item_DTO> items = (List<Item_DTO>)Session["items"];
            foreach (Item_DTO item in items)
            {
                if (item.Madausach == madausach)
                {
                    items.Remove(item);
                    break;
                }
            }
            return Redirect("/GioSach/XemChiTiet");
        }

        public ActionResult SuaThongTin(string madausach)
        {
            if (Session["role"].ToString() != "me")
            {
                return Redirect("/KhoSach/DuyetKhoSach");
            }
            List<Item_DTO> items = (List<Item_DTO>)Session["items"];
            foreach (Item_DTO item in items)
            {
                if (item.Madausach == madausach)
                {
                    ViewBag.item = item;
                    break;
                }
            }
            return View("~/Views/ThuVien/KhoSach/SuaThongTin.cshtml");
        }

        public ActionResult ThucHienCapNhat(string madausach, int soluong)
        {
            if (Session["role"].ToString() != "me")
            {
                return Redirect("/KhoSach/DuyetKhoSach");
            }
            List<Item_DTO> items = (List<Item_DTO>)Session["items"];
            foreach (Item_DTO item in items)
            {
                if (item.Madausach == madausach)
                {
                    item.Soluong = soluong;
                    ViewBag.item = item;
                    break;
                }
            }
            return View("~/Views/ThuVien/KhoSach/ChiTietSach.cshtml");
        }
    }
}