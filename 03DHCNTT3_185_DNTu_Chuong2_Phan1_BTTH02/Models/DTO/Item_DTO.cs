using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DTO
{
    public class Item_DTO
    {
        private string madausach;
        private string tensach;
        private string bia;
        private int soluong;

        public Item_DTO()
        {
            madausach = "";
            tensach = "";
            bia = "";
            soluong = 0;
        }

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

        
    }
}