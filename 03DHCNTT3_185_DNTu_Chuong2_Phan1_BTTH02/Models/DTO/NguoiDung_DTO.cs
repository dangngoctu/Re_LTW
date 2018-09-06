using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DTO
{
    public class NguoiDung_DTO
    {
        private string tendangnhap;
        private string matkhau;
        private string hovaten;
        private DateTime ngaysinh;
        private string diachi;
        private string email;
        private string motangan;
        private string sodienthoai;
        private string gioitinh;
        private string anhdaidien;
        private string manguoidung;
        private string maloainguoidung;
        private string khoanguoidung;
        private string role;

        public NguoiDung_DTO()
        {
            tendangnhap = "";
            matkhau = "";
            hovaten = "";
            ngaysinh = new DateTime(1 / 1 / 1);
            diachi = "";
            email = "";
            motangan = "";
            sodienthoai = "";
            gioitinh = "";
            anhdaidien = "";
            manguoidung = "";
            maloainguoidung = "";
            khoanguoidung = "";
            role = "";
        }


        public string Khoanguoidung
        {
            get
            {
                return khoanguoidung;
            }

            set
            {
                khoanguoidung = value;
            }
        }

        public string Maloainguoidung
        {
            get
            {
                return maloainguoidung;
            }

            set
            {
                maloainguoidung = value;
            }
        }

        public string Manguoidung
        {
            get
            {
                return manguoidung;
            }

            set
            {
                manguoidung = value;
            }
        }

        public string Anhdaidien
        {
            get
            {
                return anhdaidien;
            }

            set
            {
                anhdaidien = value;
            }
        }

        public string Gioitinh
        {
            get
            {
                return gioitinh;
            }

            set
            {
                gioitinh = value;
            }
        }

        public string Sodienthoai
        {
            get
            {
                return sodienthoai;
            }

            set
            {
                sodienthoai = value;
            }
        }

        public string Motangan
        {
            get
            {
                return motangan;
            }

            set
            {
                motangan = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Diachi
        {
            get
            {
                return diachi;
            }

            set
            {
                diachi = value;
            }
        }

        public DateTime Ngaysinh
        {
            get
            {
                return ngaysinh;
            }

            set
            {
                ngaysinh = value;
            }
        }

        public string Hovaten
        {
            get
            {
                return hovaten;
            }

            set
            {
                hovaten = value;
            }
        }

        public string Matkhau
        {
            get
            {
                return matkhau;
            }

            set
            {
                matkhau = value;
            }
        }

        public string Tendangnhap
        {
            get
            {
                return tendangnhap;
            }

            set
            {
                tendangnhap = value;
            }
        }

        public string Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
            }
        }
    }
}