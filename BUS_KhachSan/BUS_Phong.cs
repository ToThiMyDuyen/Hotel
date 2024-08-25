using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_KhachSan;
using DTO_KhachSan;
namespace BUS_KhachSan
{
    public class BUS_Phong
    {
        public static DataTable getPhong()
        {
            return DAL_Phong.getPhong();
        }

        public static void themPhong(DTO_Phong phong)
        {
            DAL_Phong.themPhong(phong);
        }

        public static void suaPhong(DTO_Phong phong)
        {
            DAL_Phong.suaPhong(phong);
        }

        public static void xoaPhong(string MaPhong)
        {
            DAL_Phong.xoaPhong(MaPhong);
        }
        public static DataTable timPhongTheoMaPhong(string maPhong)
        {
            return DAL_Phong.timPhongTheoMaPhong(maPhong);
        }

        public static DataTable timPhongTheoSoPhong(string soPhong)
        {
            return DAL_Phong.timPhongTheoSoPhong(soPhong);
        }
        public static DataTable getGiaPhongByMaPhong(string maPhong)
        {
            return DAL_Phong.getGiaPhongByMaPhong(maPhong);
        }
        public static DataTable getMaPhongByMaDP(string maDP)
        {
            return DAL_Phong.getMaPhongByMaDP(maDP);
        }
    }
}
