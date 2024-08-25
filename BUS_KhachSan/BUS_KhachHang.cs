using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO_KhachSan;
using DAL_KhachSan;

namespace BUS_KhachSan
{
    public class BUS_KhachHang
    {
        public static DataTable getKhachHang()
        {
            return DAL_KhachHang.getKhachHang();
        }
        public static void themKhachHang(DTO_KhachHang kh)
        {
            DAL_KhachHang.themKhachHang(kh);
        }
        public static void suaKhachHang(DTO_KhachHang kh)
        {
            DAL_KhachHang.suaKhachHang(kh);
        }
        public static void xoaKhachHang(string MaKH)
        {
            DAL_KhachHang.xoaKhachHang(MaKH);
        }
        public static DataTable timKhachHangTheoMa(string maKH)
        {
            return DAL_KhachHang.timKhachHangTheoMa(maKH);
        }
        public static DataTable timKhachHangTheoTen(string tenKH)
        {
            return DAL_KhachHang.timKhachHangTheoTen(tenKH);
        }
    }
}
