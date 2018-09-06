using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DTO
{
    public class Sach_DTO
    {
        //Properties
        protected string madausach;
        protected string tensach;
        protected string manhaxuatban;
        protected string bia;
        protected string tomtat;
        protected string filesach;
        protected int soluong;
        protected int luotxem;
        protected DateTime ngaydang;
        protected string machude;
        protected string matacgia;


        //Contructor
        public Sach_DTO()
        {
            this.madausach = "";
            this.tensach = "";
            this.filesach = "";
            this.manhaxuatban = "";
            this.bia = "noimage.jpg";
            this.tomtat = "";
            this.soluong = -1;
            this.Ngaydang = new DateTime(1, 1, 1);
            this.luotxem = -1;
            this.machude = "";
            this.matacgia = "";
        }

        //accessor
        public string Madausach
        {
            get
            {
                return madausach;
            }

            set
            {
                madausach = value;
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

        public string Manhaxuatban
        {
            get
            {
                return manhaxuatban;
            }

            set
            {
                manhaxuatban = value;
            }
        }

        public string Bia
        {
            get
            {
                return bia;
            }

            set
            {
                bia = value;
            }
        }

        public string Tomtat
        {
            get
            {
                return tomtat;
            }

            set
            {
                tomtat = value;
            }
        }

        public string Filesach
        {
            get
            {
                return filesach;
            }

            set
            {
                filesach = value;
            }
        }

        public int Soluong
        {
            get
            {
                return soluong;
            }

            set
            {
                soluong = value;
            }
        }

        public int Luotxem
        {
            get
            {
                return luotxem;
            }

            set
            {
                luotxem = value;
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

        public string Matacgia
        {
            get
            {
                return matacgia;
            }

            set
            {
                matacgia = value;
            }
        }

    }
}