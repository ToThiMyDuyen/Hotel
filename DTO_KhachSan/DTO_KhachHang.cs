using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_KhachSan
{
    public class DTO_KhachHang
    {
        private string MaKH;
        private string TenKH;
        private string CCCD;
        private string DiaChi;
        private string Sdt;
        public string Ma_KH
        {
            get
            {
                return MaKH;
            }
            set
            {
                MaKH = value;
            }
        }

        public string Ten_KH
        {
            get
            {
                return TenKH;
            }
            set
            {
                TenKH = value;
            }
        }
        public string CCCD_KH
        {
            get
            {
                return CCCD;
            }
            set
            {
                CCCD = value;
            }
        }
        public string DiaChi_KH
        {
            get
            {
                return DiaChi;
            }
            set
            {
                DiaChi = value;
            }
        }
        public string SDT_KH
        {
            get
            {
                return Sdt;
            }
            set
            {
                Sdt = value;
            }
        }
        public DTO_KhachHang()
        { }
        public DTO_KhachHang(string id, string Name, string cccd, string address, string phone)
        {
            this.Ma_KH = id;
            this.Ten_KH = Name;
            this.CCCD_KH = cccd;
            this.DiaChi_KH = address;
            this.SDT_KH = phone;
        }
    }
}
