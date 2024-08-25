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
    public class DAL_KhachHang
    {
        public static DataTable getKhachHang()
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_GetAllKhachHang", Conn);
            command.CommandType = CommandType.StoredProcedure;
            Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dtKhachHang = new DataTable();
            da.Fill(dtKhachHang);
            Conn.Close();
            return dtKhachHang;
        }
        public static void themKhachHang(DTO_KhachHang kh)
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_InsertKhachHang", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaKH", SqlDbType.VarChar).Value = kh.Ma_KH;
            command.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = kh.Ten_KH;
            command.Parameters.Add("@CCCD", SqlDbType.NVarChar).Value = kh.CCCD_KH;
            command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = kh.DiaChi_KH;
            command.Parameters.Add("@Sdt", SqlDbType.NVarChar).Value = kh.SDT_KH;
            Conn.Open();
            command.ExecuteNonQuery();
            Conn.Close();

        }
        public static void suaKhachHang(DTO_KhachHang kh)
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_UpdateKhachHang", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaKH", SqlDbType.VarChar).Value = kh.Ma_KH;
            command.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = kh.Ten_KH;
            command.Parameters.Add("@CCCD", SqlDbType.NVarChar).Value = kh.CCCD_KH;
            command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = kh.DiaChi_KH;
            command.Parameters.Add("@Sdt", SqlDbType.NVarChar).Value = kh.SDT_KH;
            Conn.Open();
            command.ExecuteNonQuery();
            Conn.Close();
        }
        public static void xoaKhachHang(string MaKH)
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_DeleteKhachHang", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaKH", SqlDbType.VarChar).Value = MaKH;

            Conn.Open();
            command.ExecuteNonQuery();
            Conn.Close();
        }

        public static DataTable timKhachHangTheoMa(string maKH)
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_TimMaKH", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaKH", SqlDbType.VarChar).Value = maKH;
            Conn.Open();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dtKhachHang = new DataTable();
            da.Fill(dtKhachHang);
            Conn.Close();
            return dtKhachHang;

        }
        public static DataTable timKhachHangTheoTen(string tenKH)
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_TimTenKH", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = tenKH;
            Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dtKhachHang = new DataTable();
            da.Fill(dtKhachHang);
            Conn.Close();
            return dtKhachHang;
        }

    }
}
