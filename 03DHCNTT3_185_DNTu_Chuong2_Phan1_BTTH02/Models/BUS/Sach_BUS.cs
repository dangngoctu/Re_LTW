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
        public static List<Sach_DTO> Laydanhsachcaccuonsachtufile()
        {
            return sach_DAO.Laydanhsachcaccuonsachtufile();
        }

        public static List<Sach_DTO> Laydanhsachcacdausach()
        {
            return sach_DAO.Laydanhsachcacdausach();
        }
    }
}   