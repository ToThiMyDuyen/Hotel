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
    public class DAL_HoaDon
    {
        public static DataTable getALLHoaDon()
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_GetAllHoaDon", Conn);
            command.CommandType = CommandType.StoredProcedure;
            Conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dtHoaDon = new DataTable();
            adapter.Fill(dtHoaDon);
            Conn.Close();
            return dtHoaDon;
        }
        
        public static void themHoaDon(DTO_HoaDon hd)
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_ThemHD", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaHD", SqlDbType.NVarChar).Value = hd.Ma_HD;
            command.Parameters.Add("@MaDP", SqlDbType.NVarChar).Value = hd.Ma_DP;
            command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = hd.Ma_NV;
            //command.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = hd.Ma_Phong;
            command.Parameters.Add("@MaKH", SqlDbType.VarChar).Value = hd.Ma_KH;
            command.Parameters.Add("@LoaiPhatSinh", SqlDbType.NVarChar).Value = hd.Loai_Phat_Sinh;
            command.Parameters.Add("@ChiPhiPhatSinh", SqlDbType.Float).Value = hd.Chi_Phi_Phat_Sinh;
            command.Parameters.Add("@GiaPhong", SqlDbType.Float).Value= hd.Gia_Phong;
            command.Parameters.Add("@ThanhTien", SqlDbType.Float).Value = hd.Thanh_Tien;
            Conn.Open();
            command.ExecuteNonQuery();
            Conn.Close();
        }
        public static void suaHoaDon(DTO_HoaDon hd)
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_UpdateHoaDon", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaHD", SqlDbType.NVarChar).Value = hd.Ma_HD;
            command.Parameters.Add("@MaDP", SqlDbType.NVarChar).Value = hd.Ma_DP;
            command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = hd.Ma_NV;
           
            command.Parameters.Add("@MaKH", SqlDbType.VarChar).Value = hd.Ma_KH;
            command.Parameters.Add("@LoaiPhatSinh", SqlDbType.NVarChar).Value = hd.Loai_Phat_Sinh;
            command.Parameters.Add("@ChiPhiPhatSinh", SqlDbType.Float).Value = hd.Chi_Phi_Phat_Sinh;
            command.Parameters.Add("@GiaPhong", SqlDbType.Float).Value = hd.Gia_Phong;
            command.Parameters.Add("@ThanhTien", SqlDbType.Float).Value = hd.Thanh_Tien;
            Conn.Open();
            command.ExecuteNonQuery();
            Conn.Close();
        }
    }
}
