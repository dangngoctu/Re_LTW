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

        public ActionResult ThucHienDangNhap(string username, string password)
        {
            if (Session["role"] != "u")
            {
                return Redirect("/KhoSach/Xem");
            }
            try
            {
                NguoiDung_DTO nguoidung = NguoiDung_BUS.LayThongTinNguoiDungBoiUsernameVaPassword(username, password);
                if (nguoidung != null)
                {
                    Session["manguoidung"] = nguoidung.Manguoidung;
                    Session["hovaten"] = nguoidung.Hovaten;
                    Session["role"] = nguoidung.Role;
                    Session["anhdaidien"] = nguoidung.Anhdaidien;
                    if (Session["role"].ToString() == "me")
                    {
                        Session["items"] = new List<Item_DTO>();
                    }
                   
                    return Redirect("/KhoSach/Xem");
                }
                else
                {
                    ViewBag.errormessage = "Tên đăng nhập và mật khẩu không đúng, vui lòng nhập lại";
                    return View("~/Views/ThuVien/DangNhap/NhapThongTin.cshtml");
                }
            }
            catch (Exception ex)
            {
                ViewBag.errormessage = "Tên đăng nhập và mật khẩu không đúng, vui lòng nhập lại";
                return View("~/Views/ThuVien/DangNhap/NhapThongTin.cshtml");
            }
        }

        public ActionResult ThucHienDangXuat()
        {
            if (Session["role"] != "u")
            {
                return Redirect("/TrangChu/Xem");
            }
            Session["manguoidung"] = "";
            Session["hovaten"] = "";
            Session["role"] = "u";
            Session["anhdaidien"] = "";

            if (Session["items"] != null)
            {
                Session.Remove("items");
            }

            if (Request.Cookies["tendangnhap"] != null && Request.Cookies["matkhau"] != null)
            {
                Response.Cookies["tendangnhap"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["matkhau"].Expires = DateTime.Now.AddDays(-1);
            }
            return Redirect("/KhoSach/Xem");
        }
    }
}