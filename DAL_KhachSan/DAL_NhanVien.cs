using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO_KhachSan;
namespace DAL_KhachSan
{
    public class DAL_NhanVien 
    {
        public static  DataTable getNhanVien()
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_GetAllNhanVien", Conn);
            command.CommandType = CommandType.StoredProcedure;
            Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dtNhanVien = new DataTable();
            da.Fill(dtNhanVien);
            Conn.Close();             
            return dtNhanVien;
        }
        public static void themNhanVien(DTO_NhanVien nv)
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_InsertNhanVien", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = nv.NV_ID;
            command.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = nv.Name_NV;
            command.Parameters.Add("@SĐT", SqlDbType.VarChar).Value = nv.Phone_NV;
            command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nv.DiaChi_NV;
            Conn.Open();
            command.ExecuteNonQuery();
            Conn.Close();   
            
        }
        public static void xoaNhanVien(string MaNV)
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_DeleteNhanVien", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = MaNV;

            Conn.Open();
            command.ExecuteNonQuery();
            Conn.Close();
        }
        public static void suaNhanVien(DTO_NhanVien nv)
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_UpdateNhanVien", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = nv.NV_ID;
            command.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = nv.Name_NV;
            command.Parameters.Add("@SĐT", SqlDbType.VarChar).Value = nv.Phone_NV;
            command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nv.DiaChi_NV;
            Conn.Open();
            command.ExecuteNonQuery();
            Conn.Close();
        }
        public static DataTable TimTheoMa(string maNV)
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_TimMaNV", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = maNV;
            Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            
            DataTable dtNhanVien = new DataTable();
            da.Fill(dtNhanVien);
            Conn.Close();
            return dtNhanVien;

        }
        public static DataTable TimTheoTen(string tenNV)
        {
            SqlConnection Conn = DBConnect.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_TimTenNV", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = tenNV;
            Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);

            DataTable dtNhanVien = new DataTable();
            da.Fill(dtNhanVien);
            Conn.Close();
            return dtNhanVien;

        }


    }
}
