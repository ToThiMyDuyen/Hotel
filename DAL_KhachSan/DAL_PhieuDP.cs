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
    public class DAL_PhieuDP
    {
        public static DataTable getPhieuDP()
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_GetAllPhieuDP", Conn);
            command.CommandType = CommandType.StoredProcedure;
            Conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dtPhieuDP = new DataTable();
            adapter.Fill(dtPhieuDP);
            Conn.Close();
            return dtPhieuDP;
        }
        public static DataTable TimKiemDatPhong(string maDP)
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_TimKiemDatPhong", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaDP", maDP);
            Conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dtPhieuDP = new DataTable();
            adapter.Fill(dtPhieuDP);
            Conn.Close();
            return dtPhieuDP;
        }
        public static DataTable TimPhongTrong()
        {
            DataTable dt = new DataTable();
            using (SqlConnection Conn = DBConnect.HamKetNoi())
            {
                SqlCommand command = new SqlCommand("sp_TimKiemPhongTrong", Conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            return dt;
        }
        
        public static void themPhieuDP(DTO_PhieuDP phieuDP)
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_InsertPhieuDatPhong", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaDP", SqlDbType.NVarChar).Value = phieuDP.Ma_DP;
            command.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = phieuDP.Ma_Phong;
            command.Parameters.Add("@MaKH", SqlDbType.VarChar).Value = phieuDP.Ma_KH;
            command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = phieuDP.Ma_NV;
            command.Parameters.Add("@NgayThue", SqlDbType.Date).Value = phieuDP.Ngay_Thue;
            command.Parameters.Add("@NgayTra", SqlDbType.Date).Value = phieuDP.Ngay_Tra;
            Conn.Open();
            command.ExecuteNonQuery();
            Conn.Close();
        }

        public static void SuaPhieuDP(DTO_PhieuDP phieuDP)
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_UpdatePhieuDatPhong", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaDP", SqlDbType.NVarChar).Value = phieuDP.Ma_DP;
            command.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = phieuDP.Ma_Phong;
            command.Parameters.Add("@MaKH", SqlDbType.VarChar).Value = phieuDP.Ma_KH;
            command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = phieuDP.Ma_NV;
            command.Parameters.Add("@NgayThue", SqlDbType.Date).Value = phieuDP.Ngay_Thue;
            command.Parameters.Add("@NgayTra", SqlDbType.Date).Value = phieuDP.Ngay_Tra;
            Conn.Open();
            command.ExecuteNonQuery();
            Conn.Close();
        }
    }
}
