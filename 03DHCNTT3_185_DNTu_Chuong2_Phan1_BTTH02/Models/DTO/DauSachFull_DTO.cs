using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DTO
{
    public class DauSachFull_DTO:Sach_DTO
    {
        protected string tennhaxuatban;
        protected string tentacgia;
        protected string tenchude;

        public string Tennhaxuatban
        {
            get
            {
                return tennhaxuatban;
            }

            set
            {
                tennhaxuatban = value;
            }
        }

        public string Tentacgia
        {
            get
            {
                return tentacgia;
            }

            set
            {
                tentacgia = value;
            }
        }

        public string Tenchude
        {
            get
            {
                return tenchude;
            }

            set
            {
                tenchude = value;
            }
        }

        public DauSachFull_DTO():base()
        {
            this.Tenchude = "";
            this.Tennhaxuatban = "";
            this.Tentacgia = "";
        }
    }
}