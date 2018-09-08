using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DAO
{
    public class ChuDe_DAO
    {
        public static List<ChuDe_DTO> LayDanhSachChuDe()
        {
            List<ChuDe_DTO> chudes = new List<ChuDe_DTO>();
            DataTable ketqua = SQLDataAccess.ThucThiSPTraVeKetQua("sp_LayDanhSachChuDe");
            if (ketqua.Rows.Count > 0)
            {
                foreach (DataRow dong in ketqua.Rows)
                {
                    ChuDe_DTO chude = new ChuDe_DTO();
                    chude.Machude = (string)dong["machude"];
                    chude.Tenchude = (string)dong["tenchude"];
                    chudes.Add(chude);
                }
            }
            return chudes;
        }

        public static ChuDe_DTO LayThongTinChiTietChuDeBoiMa(string machude)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@machude", machude));
            DataTable ketqua = SQLDataAccess.ThucThiSPTraVeKetQua("sp_LayDanhSachChuDe");
            if (ketqua.Rows.Count > 0)
            {
                ChuDe_DTO chude = new ChuDe_DTO();
                chude.Machude = (string)ketqua.Rows[0]["machude"];
                chude.Tenchude = (string)ketqua.Rows[0]["tenchude"];
                return chude;
            }
            return null;
        }
    }
}