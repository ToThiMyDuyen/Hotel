using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_KhachSan;
using DAL_KhachSan;
using System.Data;
namespace BUS_KhachSan
{
    public class BUS_NhanVien
    {
        public static DataTable getNhanVien()
        {
            return DAL_NhanVien.getNhanVien();
        }
        public static void themNhanVien(DTO_NhanVien nv)
        {
             DAL_NhanVien.themNhanVien(nv);
        }
        public static void xoaNhanVien(string MaNV)
        {
            DAL_NhanVien.xoaNhanVien(MaNV);
        }
        public static void suaNhanVien(DTO_NhanVien nv)
        {
            DAL_NhanVien.suaNhanVien(nv);
        }
        public static DataTable timTheoMa(string Manv)
        {
            return DAL_NhanVien.TimTheoMa(Manv);
        }
        public static DataTable timTheoTen(string TenNV)
        {
            return DAL_NhanVien.TimTheoTen(TenNV);
        }

    }
}
