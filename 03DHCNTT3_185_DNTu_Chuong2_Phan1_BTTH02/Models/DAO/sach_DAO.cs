using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DTO;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DAO
{
    public class sach_DAO
    {
        /*public static List<Sach_DTO> Laydanhsachcaccuonsachtufile()
        {
            string urlFile = System.AppDomain.CurrentDomain.BaseDirectory;
            urlFile = urlFile + "App_Data/Sach.txt";
            System.IO.StreamReader reader = new System.IO.StreamReader(urlFile);
            int socuonsach = int.Parse(reader.ReadLine());
            List<Sach_DTO> sachs = new List<Sach_DTO>();
            for (int i = 0; i <= socuonsach; i++)
            {
                Sach_DTO sach = new Sach_DTO();
                sach.Tensach = reader.ReadLine();
                sach.Anh = reader.ReadLine();
                sach.Tacgia = reader.ReadLine();
                sachs.Add(sach);
            }
            reader.Close();
            return sachs;
        }

        public static List<Sach_DTO> Laydanhsachcacdausach()
        {
            List<Sach_DTO> sachs = new List<Sach_DTO>();
            DataTable ketqua = SQLDataAccess.ThucThiSPTraVeKetQua("sp_LayDanhSachCacDauSach");

            if (ketqua.Rows.Count > 0) {
                foreach (DataRow rows in ketqua.Rows)
                {
                    Sach_DTO sach = new Sach_DTO();
                    sach.Masach = (int)rows["masach"];
                    sach.Tensach = (string)rows["tensach"];
                    sach.Anh = (string)rows["anh"];
                    sach.Ngaydang = (DateTime)rows["ngaydang"];
                    sach.Tacgia = (string)rows["tacgia"];
                    sachs.Add(sach);
                }
            }
            return sachs;
        }
        */
        public static int SoLuongSachTrongHeThong()
        {
            int soluong = 0;
            DataTable ketqua = SQLDataAccess.ThucThiSPTraVeKetQua("sp_SoLuongSachTrongHeThong");
            soluong = (int)ketqua.Rows[0][0];
            return soluong;
        }

        public static List<DauSachFull_DTO> DuyetKhoSachPhanTrang(int sosachtrongtrang, int tranghientai, string cotsapxep)
        {
            List<DauSachFull_DTO> dausachs = new List<DauSachFull_DTO>();
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@sosachtrongtrang", sosachtrongtrang));
            paras.Add(new SqlParameter("@tranghientai", tranghientai));
            paras.Add(new SqlParameter("@cotsapxep", cotsapxep));
            DataTable ketqua = SQLDataAccess.ThucThiSPTraVeKetQua("sp_DuyetKhoSachPhanTrang",paras);
            if (ketqua.Rows.Count > 0)
            {
                foreach(DataRow dong in ketqua.Rows)
                {
                    DauSachFull_DTO dausach = new DauSachFull_DTO();
                    dausach.Bia = dong["bia"].ToString();
                    if(dong["filesach"]!= null)
                    {
                        dausach.Filesach = dong["filesach"].ToString();
                    }
                    
                    dausach.Machude = dong["machude"].ToString();
                    dausach.Madausach = dong["madausach"].ToString();
                    dausach.Manhaxuatban = dong["manhaxuatban"].ToString();
                    dausach.Matacgia = dong["matacgia"].ToString();
                    dausach.Ngaydang = (DateTime)dong["ngaydang"];
                    dausach.Tensach = dong["tensach"].ToString();
                    if (dong["soluong"] != null)
                    {
                        dausach.Soluong = (int)dong["soluong"];
                    }
                    if (dong["tomtat"] != null)
                    {
                        dausach.Tomtat = dong["tomtat"].ToString();
                    }
                    dausach.Luotxem = (int)dong["luotxem"];
                    dausach.Tenchude = dong["tenchude"].ToString();
                    dausach.Tennhaxuatban = dong["tennhaxuatban"].ToString();
                    dausach.Tentacgia = dong["tentacgia"].ToString();
                    dausachs.Add(dausach);
                }
            }
                return dausachs;
        }

        public static List<Sach_DTO> Top10DauSachXemNhieuNhat()
        {
            List<Sach_DTO> dausachs = new List<Sach_DTO>();
            DataTable ketqua = SQLDataAccess.ThucThiSPTraVeKetQua("sp_Top10DauSachXemNhieuNhat");
            if (ketqua.Rows.Count > 0)
            {
                foreach (DataRow dong in ketqua.Rows)
                {
                    Sach_DTO dausach = new Sach_DTO();
                    dausach.Bia = dong["bia"].ToString();
                    dausach.Madausach = dong["madausach"].ToString();
                    dausach.Tensach = dong["tensach"].ToString();
                    dausachs.Add(dausach);
                }
            }
            return dausachs;
        }

        public static List<DauSachFull_DTO> DuyetKhoSachTheoChuDePhanTrang(string machude,int sosachtrongtrang, int tranghientai, string cotsapxep)
        {
            List<DauSachFull_DTO> dausachs = new List<DauSachFull_DTO>();
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@machude", machude));
            paras.Add(new SqlParameter("@sosachtrongtrang", sosachtrongtrang));
            paras.Add(new SqlParameter("@tranghientai", tranghientai));
            paras.Add(new SqlParameter("@cotsapxep", cotsapxep));
            DataTable ketqua = SQLDataAccess.ThucThiSPTraVeKetQua("sp_DuyetKhoSachTheoChuDePhanTrang", paras);
            if (ketqua.Rows.Count > 0)
            {
                foreach (DataRow dong in ketqua.Rows)
                {
                    DauSachFull_DTO dausach = new DauSachFull_DTO();
                    dausach.Bia = dong["bia"].ToString();
                    if (dong["filesach"] != null)
                    {
                        dausach.Filesach = dong["filesach"].ToString();
                    }

                    //dausach.Machude = dong["machude"].ToString();
                    dausach.Madausach = dong["madausach"].ToString();
                    //dausach.Manhaxuatban = dong["manhaxuatban"].ToString();
                    //dausach.Matacgia = dong["matacgia"].ToString();
                    //dausach.Ngaydang = (DateTime)dong["ngaydang"];
                    dausach.Tensach = dong["tensach"].ToString();
                    //if (dong["soluong"] != null)
                    //{
                    //    dausach.Soluong = (int)dong["soluong"];
                    //}
                    //if (dong["tomtat"] != null)
                    //{
                    //    dausach.Tomtat = dong["tomtat"].ToString();
                    //}
                    //dausach.Luotxem = (int)dong["luotxem"];
                    //dausach.Tenchude = dong["tenchude"].ToString();
                    //dausach.Tennhaxuatban = dong["tennhaxuatban"].ToString();
                    dausach.Tentacgia = dong["tentacgia"].ToString();
                    dausachs.Add(dausach);
                }
            }
            return dausachs;
        }

        public static int SoLuongSachCoTrongHeThongCuaMotChuDe(string machude)
        {
            int soluong = 0;
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@machude", machude));
            DataTable ketqua = SQLDataAccess.ThucThiSPTraVeKetQua("sp_SoLuongSachCoTrongHeThongCuaMotChuDe",paras);
            soluong = (int)ketqua.Rows[0][0];
            return soluong;
        }

        public static List<Sach_DTO> Top10DauSachXemNhieuNhatTheoMaChuDe(string machude)
        {
            List<Sach_DTO> dausachs = new List<Sach_DTO>();
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@machude", machude));
            DataTable ketqua = SQLDataAccess.ThucThiSPTraVeKetQua("sp_Top10DauSachXemNhieuNhatTheoMaChuDe", paras);
            if (ketqua.Rows.Count > 0)
            {
                foreach (DataRow dong in ketqua.Rows)
                {
                    Sach_DTO dausach = new Sach_DTO();
                    dausach.Bia = dong["bia"].ToString();
                    dausach.Madausach = dong["madausach"].ToString();
                    dausach.Tensach = dong["tensach"].ToString();
                    dausachs.Add(dausach);
                }
            }
            return dausachs;
        }

        public static List<DauSachFull_DTO> TimKiemSachVaPhanTrang(string khoa, int sosachtrongtrang, int tranghientai, string cotsapxep)
        {
            List<DauSachFull_DTO> dausachs = new List<DauSachFull_DTO>();
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@khoa", khoa));
            paras.Add(new SqlParameter("@sosachtrongtrang", sosachtrongtrang));
            paras.Add(new SqlParameter("@tranghientai", tranghientai));
            paras.Add(new SqlParameter("@cotsapxep", cotsapxep));
            DataTable ketqua = SQLDataAccess.ThucThiSPTraVeKetQua("sp_TimKiemSachVaPhanTrang", paras);
            if (ketqua.Rows.Count > 0)
            {
                foreach (DataRow dong in ketqua.Rows)
                {
                    DauSachFull_DTO dausach = new DauSachFull_DTO();
                    dausach.Bia = dong["bia"].ToString();
                    if (dong["filesach"] != null)
                    {
                        dausach.Filesach = dong["filesach"].ToString();
                    }

                    //dausach.Machude = dong["machude"].ToString();
                    dausach.Madausach = dong["madausach"].ToString();
                    //dausach.Manhaxuatban = dong["manhaxuatban"].ToString();
                    //dausach.Matacgia = dong["matacgia"].ToString();
                    //dausach.Ngaydang = (DateTime)dong["ngaydang"];
                    dausach.Tensach = dong["tensach"].ToString();
                    //if (dong["soluong"] != null)
                    //{
                    //    dausach.Soluong = (int)dong["soluong"];
                    //}
                    //if (dong["tomtat"] != null)
                    //{
                    //    dausach.Tomtat = dong["tomtat"].ToString();
                    //}
                    //dausach.Luotxem = (int)dong["luotxem"];
                    //dausach.Tenchude = dong["tenchude"].ToString();
                    //dausach.Tennhaxuatban = dong["tennhaxuatban"].ToString();
                    dausach.Tentacgia = dong["tentacgia"].ToString();
                    dausachs.Add(dausach);
                }
            }
            return dausachs;
        }

        public static int SoLuongSachTimKiemDuoc(string khoa)
        {
            int soluong = 0;
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@khoa", khoa));
            DataTable ketqua = SQLDataAccess.ThucThiSPTraVeKetQua("sp_SoLuongSachTimKiemDuoc", paras);
            soluong = (int)ketqua.Rows[0][0];
            return soluong;
        }

        public static Sach_DTO LayThongTinChiTietCuaDauSachBoiMa(string madausach)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@madausach", madausach));
            DataTable ketqua = SQLDataAccess.ThucThiSPTraVeKetQua("sp_LayThongTinChiTietCuaDauSachBoiMa", paras);
            if (ketqua.Rows.Count > 0)
            {
                Sach_DTO dausach = new Sach_DTO();
                dausach.Bia = ketqua.Rows[0]["bia"].ToString();
                dausach.Madausach = ketqua.Rows[0]["madausach"].ToString();
                dausach.Tensach = ketqua.Rows[0]["tensach"].ToString();
                return dausach;
            }
            return null;
        }
    }
}