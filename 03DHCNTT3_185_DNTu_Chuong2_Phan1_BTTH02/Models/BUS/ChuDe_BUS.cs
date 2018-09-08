using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DAO;
using _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.BUS
{
    public class ChuDe_BUS
    {
        public static List<ChuDe_DTO> LayDanhSachChuDe()
        {
            return ChuDe_DAO.LayDanhSachChuDe();
        }

        public static ChuDe_DTO LayThongTinChiTietChuDeBoiMa(string machude)
        {
            return ChuDe_DAO.LayThongTinChiTietChuDeBoiMa(machude);
        }
    }
}