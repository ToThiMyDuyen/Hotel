using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_KhachSan
{
    public class DTO_PhieuDP
    {
        private string MaDP;
        private string MaKH;
        private string TenKH;
        private string MaPhong;
        private string MaNV;
        private DateTime NgayThue;
        private DateTime NgayTra;

        public string Ma_DP
        {
            get { return MaDP; }
            set { MaDP = value; }
        }

        public string Ma_KH
        {
            get { return MaKH; }
            set { MaKH = value; }
        }
        public string Ten_KH
        {
            get { return TenKH; }
            set { TenKH = value; }
        }
        public string Ma_Phong
        {
            get { return MaPhong; }
            set { MaPhong = value; }
        }

        public string Ma_NV
        {
            get { return MaNV; }
            set { MaNV = value; }
        }

        public DateTime Ngay_Thue
        {
            get { return NgayThue; }
            set { NgayThue = value; }
        }

        public DateTime Ngay_Tra
        {
            get { return NgayTra; }
            set { NgayTra = value; }
        }

        // Constructors
        public DTO_PhieuDP() { }

        public DTO_PhieuDP(string maDP, string maKH, string tenKH, string maPhong, string maNV, DateTime ngayThue, DateTime ngayTra)
        {
            this.Ma_DP = maDP;
            this.Ma_KH = maKH;
            this.Ten_KH = tenKH;
            this.Ma_Phong = maPhong;
            this.Ma_NV = maNV;
            this.Ngay_Thue = ngayThue;
            this.Ngay_Tra = ngayTra;
        }



    }
}