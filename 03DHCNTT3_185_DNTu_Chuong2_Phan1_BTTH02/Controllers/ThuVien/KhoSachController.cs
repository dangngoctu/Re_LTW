using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.BUS;
using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Controllers.ThuVien
{
    public class KhoSachController : Controller
    {
        // GET: KhoSach
        public ActionResult Xem(string sapxep, string trang)
        {
            int soluongsach = Sach_BUS.SoLuongSachTrongHeThong();
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
            
            if(tranghientai < 1)
            {
                tranghientai = 1;
            }else if (tranghientai > sotrang)
            {
                tranghientai = sotrang;
            }
            List<DauSachFull_DTO> dausachs = new List<DauSachFull_DTO>();
            if (sotrang > 0)
            {
                dausachs = Sach_BUS.DuyetKhoSachPhanTrang(sosachtrongtrang, tranghientai, cotsapxep);
            }
            List<Sach_DTO> sachs = Sach_BUS.Top10DauSachXemNhieuNhat();
            ViewBag.soluongsach = soluongsach;
            ViewBag.dausachs = dausachs;
            ViewBag.tranghientai = tranghientai;
            ViewBag.sotrang = sotrang;
            ViewBag.cotsapxep = cotsapxep;
            ViewBag.sachs = sachs;
            return View("~/Views/ThuVien/KhoSach/Xem.cshtml");
        }

        public ActionResult ChuDe(string sapxep, string trang, string ma)
        {
            string machude = "1";
            if (ma != null && ma != "")
            {
                machude = ma;
            }
            int soluongsach = Sach_BUS.SoLuongSachCoTrongHeThongCuaMotChuDe(machude);
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
                dausachs = Sach_BUS.DuyetKhoSachTheoChuDePhanTrang(machude,sosachtrongtrang, tranghientai, cotsapxep);
            }
            List<Sach_DTO> sachs = Sach_BUS.Top10DauSachXemNhieuNhatTheoMaChuDe(machude);
            ChuDe_DTO chude = ChuDe_BUS.LayThongTinChiTietChuDeBoiMa(machude);
            ViewBag.soluongsach = soluongsach;
            ViewBag.dausachs = dausachs;
            ViewBag.tranghientai = tranghientai;
            ViewBag.sotrang = sotrang;
            ViewBag.cotsapxep = cotsapxep;
            ViewBag.sachs = sachs;
            ViewBag.machude = machude;
            ViewBag.chude = chude;
            return View("~/Views/ThuVien/KhoSach/ChuDe.cshtml");
        }
    }
}