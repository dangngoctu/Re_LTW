using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DTO
{
    public class ChuDe_DTO
    {
        private string machude;
        private string tenchude;

        public ChuDe_DTO()
        {
            this.machude = "";
            this.tenchude = "";
        }

        public string Machude
        {
            get
            {
                return machude;
            }

            set
            {
                machude = value;
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
    }
}