using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DTO
{
    public class Sach_DTO
    {
        //Properties
        private int masach;
        private string tensach;
        private string anh;
        private DateTime ngaydang;
        private string tacgia;

        //Contructor
        public Sach_DTO()
        {
            this.Masach = -1;
            this.Tensach = "";
            this.Anh = "noimage.jpg";
            this.Ngaydang = new DateTime(1, 1, 1);
            this.Tacgia = "";
        }

        //accessor
        public int Masach
        {
            get
            {
                return masach;
            }

            set
            {
                masach = value;
            }
        }

        public string Tensach
        {
            get
            {
                return tensach;
            }

            set
            {
                tensach = value;
            }
        }

        public string Anh
        {
            get
            {
                return anh;
            }

            set
            {
                anh = value;
            }
        }

        public DateTime Ngaydang
        {
            get
            {
                return ngaydang;
            }

            set
            {
                ngaydang = value;
            }
        }

        public string Tacgia
        {
            get
            {
                return tacgia;
            }

            set
            {
                tacgia = value;
            }
        }
    }
}