using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_KhachSan;
using DTO_KhachSan;
using System.Data;
namespace BUS_KhachSan
{
    public class BUS_HoaDon
    {
        public static DataTable getHoaDon()
        {
            return DAL_HoaDon.getALLHoaDon();
        }
        public static void themHD(DTO_HoaDon HD)
        {
            DAL_HoaDon.themHoaDon(HD);
        }
        public static void suaHD(DTO_HoaDon HD)
        {
            DAL_HoaDon.suaHoaDon(HD);
        }
    }
    
}
