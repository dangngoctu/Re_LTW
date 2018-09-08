using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DTO;
using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DAO;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.BUS
{
    public class Sach_BUS
    {
        /*public static List<Sach_DTO> Laydanhsachcaccuonsachtufile()
        {
            return sach_DAO.Laydanhsachcaccuonsachtufile();
        }

        public static List<Sach_DTO> Laydanhsachcacdausach()
        {
            return sach_DAO.Laydanhsachcacdausach();
        }
        */
        public static int SoLuongSachTrongHeThong()
        {
            return sach_DAO.SoLuongSachTrongHeThong();
        }

        public static List<DauSachFull_DTO> DuyetKhoSachPhanTrang(int sosachtrongtrang, int tranghientai, string cotsapxep)
        {
            return sach_DAO.DuyetKhoSachPhanTrang(sosachtrongtrang, tranghientai, cotsapxep);
        }

        public static List<Sach_DTO> Top10DauSachXemNhieuNhat()
        {
            return sach_DAO.Top10DauSachXemNhieuNhat();
        }

        public static List<DauSachFull_DTO> DuyetKhoSachTheoChuDePhanTrang(string machude, int sosachtrongtrang, int tranghientai, string cotsapxep)
        {
            return sach_DAO.DuyetKhoSachTheoChuDePhanTrang(machude, sosachtrongtrang, tranghientai, cotsapxep);
        }

        public static int SoLuongSachCoTrongHeThongCuaMotChuDe(string machude)
        {
            return sach_DAO.SoLuongSachCoTrongHeThongCuaMotChuDe(machude);
        }

        public static List<Sach_DTO> Top10DauSachXemNhieuNhatTheoMaChuDe(string machude)
        {
            return sach_DAO.Top10DauSachXemNhieuNhatTheoMaChuDe(machude);
        }

        public static List<DauSachFull_DTO> TimKiemSachVaPhanTrang(string khoa, int sosachtrongtrang, int tranghientai, string cotsapxep)
        {
            return sach_DAO.TimKiemSachVaPhanTrang(khoa, sosachtrongtrang, tranghientai, cotsapxep);
        }

        public static int SoLuongSachTimKiemDuoc(string khoa)
        {
            return sach_DAO.SoLuongSachTimKiemDuoc(khoa);
        }

        public static Sach_DTO LayThongTinChiTietCuaDauSachBoiMa(string madausach)
        {
            return sach_DAO.LayThongTinChiTietCuaDauSachBoiMa(madausach);
        }
    }
}   