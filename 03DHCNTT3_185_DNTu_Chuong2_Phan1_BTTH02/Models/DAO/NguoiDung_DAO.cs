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

        public static NguoiDung_DTO LayThongTinNguoiDungBoiUsernameVaPassword(string username, string password)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@tendangnhap", username));
            paras.Add(new SqlParameter("@matkhau", password));
            DataTable ketqua = SQLDataAccess.ThucThiSPTraVeKetQua("sp_LayThongTinNguoiDungBoiUsernameVaPassword", paras);
            if (ketqua.Rows.Count > 0)
            {
                NguoiDung_DTO nguoidung = new NguoiDung_DTO();
                if (ketqua.Rows[0]["anhdaidien"] != null)
                {
                    nguoidung.Anhdaidien = ketqua.Rows[0]["anhdaidien"].ToString();
                }
                if (ketqua.Rows[0]["diachi"] != null)
                {
                    nguoidung.Diachi = ketqua.Rows[0]["diachi"].ToString();
                }
                if (ketqua.Rows[0]["email"] != null)
                {
                    nguoidung.Email = ketqua.Rows[0]["email"].ToString();
                }
                if (ketqua.Rows[0]["gioitinh"] != null)
                {
                    nguoidung.Gioitinh = ketqua.Rows[0]["gioitinh"].ToString();
                }
                nguoidung.Hovaten = ketqua.Rows[0]["hovaten"].ToString();
                nguoidung.Khoanguoidung = ketqua.Rows[0]["khoanguoidung"].ToString();
                nguoidung.Maloainguoidung = ketqua.Rows[0]["maloainguoidung"].ToString();
                nguoidung.Matkhau = ketqua.Rows[0]["matkhau"].ToString();
                if (ketqua.Rows[0]["motangan"] != null)
                {
                    nguoidung.Motangan = ketqua.Rows[0]["motangan"].ToString();
                }
                DateTime tam;
                if (DateTime.TryParse(ketqua.Rows[0]["ngaysinh"].ToString(), out tam))
                {
                    nguoidung.Ngaysinh = tam;
                }
                nguoidung.Role = ketqua.Rows[0]["phanquyen"].ToString();
                if (ketqua.Rows[0]["sodienthoai"] != null)
                {
                    nguoidung.Sodienthoai = ketqua.Rows[0]["sodienthoai"].ToString();
                }
                nguoidung.Tendangnhap = ketqua.Rows[0]["tendangnhap"].ToString();
                return nguoidung;
            }
            else
            {
                return null;
            }
            return null;
        }
    }
}