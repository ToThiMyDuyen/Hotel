using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_KhachSan
{
    public class DTO_HoaDon
    {
        private string MaHD;
        private string MaDP;
        private string MaNV;       
        private string MaKH;
        private string LoaiPhatSinh;
        private float ChiPhiPhatSinh;
        private float GiaPhong;
        private float ThanhTien;
        public string Ma_HD
        {
            get { return MaHD; }
            set { MaHD = value; }
        }
        public string Ma_DP
        {
            get { return MaDP; }
            set { MaDP = value; }
        }
        public string Ma_NV
        {
            get { return MaNV; }
            set { MaNV = value; }
        }
        public string Ma_KH
        {
            get { return MaKH; }
            set { MaKH = value; }
        }
        //public string Ma_Phong
        //{
        //    get { return MaPhong; }
        //    set { MaPhong = value; }
        //}
        public string Loai_Phat_Sinh
        {
            get { return LoaiPhatSinh; }
            set { LoaiPhatSinh = value; }
        }
        public float Chi_Phi_Phat_Sinh
        {
            get { return ChiPhiPhatSinh; }
            set { ChiPhiPhatSinh = value; }
        }
        public float Gia_Phong
        {
            get { return GiaPhong; }
            set { GiaPhong = value; }
        }
        public float Thanh_Tien
        {
            get { return ThanhTien; }
            set { ThanhTien = value; }
        }

        public DTO_HoaDon()
        { }
        public DTO_HoaDon(string maHD, string maDP, string maNV, string maPhong, string maKH,string loaiPS, float cpps, float giaPhong, float thanhTien)
        {
            this.Ma_HD = maHD;
            this.Ma_DP = maDP;
            this.Ma_NV = maNV;
            //this.Ma_Phong = maPhong;
            this.Ma_KH = maKH;
            this.Loai_Phat_Sinh = loaiPS;
            this.Chi_Phi_Phat_Sinh = cpps;
            this.Gia_Phong = giaPhong;
            this.Thanh_Tien = thanhTien;
            
        }
    }
}
