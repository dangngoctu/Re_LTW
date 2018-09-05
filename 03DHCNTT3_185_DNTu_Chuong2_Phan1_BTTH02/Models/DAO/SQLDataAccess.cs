using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _03DHCNTT3_185_DNTu_Chuong2_Phan1_BTTH02.Models.DAO
{
    public class SQLDataAccess
    {
        private static string LayConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DangNgocTu"].ConnectionString;
        }

        public static DataTable ThucThiSPTraVeKetQua(string tensp, List<SqlParameter> paras)
        {
            DataTable ketqua = new DataTable();
            string connectionstring = LayConnectionString();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionstring;
            //Mở kết nối sử dụng connection
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = tensp;
            command.CommandType = CommandType.Text;
            if (paras != null)
            {
                foreach (SqlParameter para in paras)
                {
                    command.Parameters.Add(para);
                }
            }
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(ketqua);
            connection.Close();
            return ketqua;
        }
        public static DataTable ThucThiSPTraVeKetQua(string tensp)
        {
            return ThucThiSPTraVeKetQua(tensp, null);
        }
        public static void ThucThiSPKhongTraVeKetQua(string tensp, List<SqlParameter> paras)
        {
            string connectionstring = LayConnectionString();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionstring;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = tensp;
            command.CommandType = CommandType.StoredProcedure;
            if (paras != null)
            {
                foreach (SqlParameter para in paras)
                {
                    command.Parameters.Add(para);
                }
            }
            //chỉ cần kêu thực thi và dong kết nối là xong, vì đâu cần trả về giá trị.
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void ThucThiSPKhongTraVeKetQua(string tensp)
        {
            ThucThiSPKhongTraVeKetQua(tensp, null);
        }
    }
}