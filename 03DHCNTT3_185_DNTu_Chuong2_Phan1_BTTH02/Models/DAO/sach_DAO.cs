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
        public static List<Sach_DTO> Laydanhsachcaccuonsachtufile()
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
    }
}