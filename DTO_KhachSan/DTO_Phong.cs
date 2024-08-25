using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_KhachSan
{
    public class DTO_Phong
    {
        private string MaPhong;
        private string SoPhong;
        private string LoaiPhong;
        private string TinhTrang;
        private float GiaPhong;
        public string Ma_Phong
        {
            get
            {
                return MaPhong;
            }
            set
            {
                MaPhong = value;
            }
        }

        public string So_phong
        {
            get
            {
                return SoPhong;
            }
            set
            {
                SoPhong = value;
            }
        }
        public string Loai_Phong
        {
            get
            {
                return LoaiPhong;
            }
            set
            {
                LoaiPhong = value;
            }
        }
        public string Tinh_Trang
        {
            get
            {
                return TinhTrang;
            }
            set
            {
                TinhTrang = value;
            }
        }
        public float Gia_Phong
        {
            get
            {
                return GiaPhong;
            }
            set
            {
                GiaPhong = value;
            }
        }
        public DTO_Phong()
        { }
        public DTO_Phong(string id, string number, string type, string condi, float price)
        {
            this.Ma_Phong = id;
            this.So_phong = number;
            this.Loai_Phong = type;
            this.Tinh_Trang = condi;
            this.Gia_Phong = price;
        }
    }
}

