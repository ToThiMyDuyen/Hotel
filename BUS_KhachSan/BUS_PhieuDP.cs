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
    public class BUS_PhieuDP
    {
        public static DataTable getPhieuDP()
        {
            return DAL_PhieuDP.getPhieuDP();
        }
        public static DataTable TimKiemDatPhong(string maDP)
        {
            return DAL_PhieuDP.TimKiemDatPhong(maDP);
        }
        public static DataTable TimPhongTrong()
        {
            return DAL_PhieuDP.TimPhongTrong();
        }
        public static void themPhieuDP(DTO_PhieuDP phieuDP)
        {
            DAL_PhieuDP.themPhieuDP(phieuDP);
        }
        public static void suaPhieuDP(DTO_PhieuDP phieuDP)
        {
            DAL_PhieuDP.SuaPhieuDP(phieuDP);
        }
    }
}
