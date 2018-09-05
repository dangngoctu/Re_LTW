using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DTO;
using System.Data.SqlClient;
using System.Data;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DAO
{
    public class NguoiDung_DAO
    {
        public static string ThemNguoiDungMoi(NguoiDung_DTO nguoidung)
        {
            string tenanhdaidien = "";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@tendangnhap", nguoidung.Tendangnhap));
            paras.Add(new SqlParameter("@matkhau", nguoidung.Matkhau));
            paras.Add(new SqlParameter("@hovaten", nguoidung.Hovaten));
            paras.Add(new SqlParameter("@diachi", nguoidung.Diachi));
            paras.Add(new SqlParameter("@email", nguoidung.Email));
            paras.Add(new SqlParameter("@sodienthoai", nguoidung.Sodienthoai));
            paras.Add(new SqlParameter("@gioitinh", nguoidung.Gioitinh));
            paras.Add(new SqlParameter("@motangan", nguoidung.Motangan));
            paras.Add(new SqlParameter("@maloainguoidung", nguoidung.Maloainguoidung));
            paras.Add(new SqlParameter("@khoanguoidung", nguoidung.Khoanguoidung));
            paras.Add(new SqlParameter("@ngaysinh", nguoidung.Ngaysinh));

            SqlParameter paratenanh = new SqlParameter("@tenanhdaidien", nguoidung.Anhdaidien);
            paratenanh.SqlDbType = SqlDbType.NVarChar;
            paratenanh.Size = 100;
            paratenanh.Direction = ParameterDirection.InputOutput;
            paras.Add(paratenanh);
            SQLDataAccess.ThucThiSPKhongTraVeKetQua("sp_ThemNguoiDungMoi", paras);
            tenanhdaidien = paratenanh.SqlValue.ToString();
            return tenanhdaidien;
        }
    }
}