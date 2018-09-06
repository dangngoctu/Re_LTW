using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DTO;
using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DAO;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.BUS
{
    public class NguoiDung_BUS
    {
        public static string ThemNguoiDungMoi(NguoiDung_DTO nguoidung)
        {
            nguoidung.Matkhau = MaHoaThongTin_BUS.MaHoaSHA1(nguoidung.Matkhau).ToLower();
            return NguoiDung_DAO.ThemNguoiDungMoi(nguoidung);
        }

        public static NguoiDung_DTO LayThongTinNguoiDungBoiUsernameVaPassword(string username, string password)
        {
            password = MaHoaThongTin_BUS.MaHoaSHA1(password).ToLower();
            return NguoiDung_DAO.LayThongTinNguoiDungBoiUsernameVaPassword(username, password);
        }
    }
}