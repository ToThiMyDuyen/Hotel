using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO_KhachSan;
namespace DAL_KhachSan
{
   public class DAL_Phong
   {
        public static DataTable getPhong()
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_GetAllPhong", Conn);
            command.CommandType = CommandType.StoredProcedure;
            Conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dtPhong = new DataTable();
            adapter.Fill(dtPhong);
            Conn.Close();
            return dtPhong;
        }

        public static void themPhong(DTO_Phong phong)
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_InsertPhong", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = phong.Ma_Phong;
            command.Parameters.Add("@SoPhong", SqlDbType.NVarChar).Value = phong.So_phong;
            command.Parameters.Add("@LoaiPhong", SqlDbType.NVarChar).Value = phong.Loai_Phong;
            command.Parameters.Add("@TinhTrangPhong", SqlDbType.NVarChar).Value = phong.Tinh_Trang;
            command.Parameters.Add("@GiaPhong", SqlDbType.Float).Value = phong.Gia_Phong;
            Conn.Open();
            command.ExecuteNonQuery();
            Conn.Close();
        }

        public static void suaPhong(DTO_Phong phong)
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_UpdatePhong", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = phong.Ma_Phong;
            command.Parameters.Add("@SoPhong", SqlDbType.NVarChar).Value = phong.So_phong;
            command.Parameters.Add("@LoaiPhong", SqlDbType.NVarChar).Value = phong.Loai_Phong;
            command.Parameters.Add("@TinhTrangPhong", SqlDbType.NVarChar).Value = phong.Tinh_Trang;
            command.Parameters.Add("@GiaPhong", SqlDbType.Float).Value = phong.Gia_Phong;
            Conn.Open();
            command.ExecuteNonQuery();
            Conn.Close();
        }
      
        public static void xoaPhong(string MaPhong)
        {
            SqlConnection connection = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_DeletePhong", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = MaPhong;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static DataTable timPhongTheoMaPhong(string maPhong)
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_TimMaPhong", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = maPhong;
            Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dtPhong = new DataTable();
            da.Fill(dtPhong);
            Conn.Close();
            return dtPhong;
        }
        public static DataTable timPhongTheoSoPhong(string soPhong)
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_TimSoPhong", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SoPhong", SqlDbType.NVarChar).Value = soPhong;
            Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dtPhong = new DataTable();
            da.Fill(dtPhong);
            Conn.Close();
            return dtPhong;
        }
        public static DataTable getGiaPhongByMaPhong(string maPhong)
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_GetGiaPhongByMaPhong", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaPhong", maPhong);
            Conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dtGiaPhong = new DataTable();
            adapter.Fill(dtGiaPhong);
            Conn.Close();
            return dtGiaPhong;
        }
        public static DataTable getMaPhongByMaDP(string maDP)
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_GetMaPhongByMaDP", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaDP", maDP);
            Conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dtMaPhong = new DataTable();
            adapter.Fill(dtMaPhong);
            Conn.Close();
            return dtMaPhong;
        }
    }
}
