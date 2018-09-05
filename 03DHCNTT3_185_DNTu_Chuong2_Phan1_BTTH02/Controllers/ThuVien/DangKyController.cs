using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DTO;
using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.BUS;
using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DAO;


namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Controllers.ThuVien
{
    public class DangKyController : Controller
    {
        // GET: DangKy
        public ActionResult NhapThongTin()
        {
            if (Session["role"] != "u")
            {
                return Redirect("/TrangChu/Xem");
            }
            return View("~/Views/ThuVien/DangKy/NhapThongTin.cshtml");
        }
        [ValidateInput(false)]
        public ActionResult ThucHienDangKy()
        {
            if (Session["role"] != "u")
            {
                return Redirect("/TrangChu/Xem");
            }
            NguoiDung_DTO nguoidung = new NguoiDung_DTO();
            try
            {
                nguoidung.Tendangnhap = Request.Form["username"].ToString();
                nguoidung.Matkhau = Request.Form["password"].ToString();
                nguoidung.Hovaten = Request.Form["name"].ToString();
                nguoidung.Ngaysinh = DateTime.Parse(Request.Form["date"].ToString());
                nguoidung.Diachi = Request.Form["address"].ToString();
                nguoidung.Email = Request.Form["mail"].ToString();
                nguoidung.Sodienthoai = Request.Form["phone"].ToString();
                nguoidung.Motangan = Request.Form["sex"].ToString();
                nguoidung.Gioitinh = Request.Form["desc"].ToString();
                nguoidung.Manguoidung = Request.Form["address"].ToString();
                nguoidung.Maloainguoidung = "2";
                nguoidung.Khoanguoidung = "U";
                if (Request.Files["image_avatar"] != null && Request.Files["image_avatar"].ContentLength > 0)
                {
                    nguoidung.Anhdaidien = "Y";
                }
                string tenanhphailuu = NguoiDung_BUS.ThemNguoiDungMoi(nguoidung);
                if (Request.Files["image_avatar"] != null && Request.Files["image_avatar"].ContentLength > 0)
                {
                    Image image = Image.FromStream(Request.Files["image_avatar"].InputStream);
                    Bitmap anhfullsize = XuLyAnh.DoiKichThuocAnh(image, 300, 300);
                    anhfullsize.Save(System.AppDomain.CurrentDomain.BaseDirectory + "/Content/upload/avatar/" + tenanhphailuu);
                    Bitmap anhminisize = XuLyAnh.DoiKichThuocAnh(image, 100, 100);
                    anhminisize.Save(System.AppDomain.CurrentDomain.BaseDirectory + "/Content/upload/avatar/thumbnail/" + tenanhphailuu);
                }
            }
            catch (Exception ex)
            {
                ViewBag.message = ex;
                ViewBag.nguoidung = nguoidung;
                return View("~/Views/ThuVien/DangKy/NhapLaiThongTin.cshtml");
            }
            return Redirect("/DangNhap/NhapThongTin");
        }
    }
}