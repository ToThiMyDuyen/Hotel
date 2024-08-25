using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_KhachSan
{
    public class DTO_NhanVien
    {
        private string MaNV;
        private string TenNV;
        private string SDT;
        private string DiaChi;
        public string NV_ID
        {
            get
            {
                return MaNV;
            }
            set
            {
                MaNV = value;
            }
        }

        public string Name_NV
        {
            get
            {
                return TenNV;
            }
            set
            {
                TenNV = value;
            }
        }
        public string Phone_NV
        {
            get
            {
                return SDT;
            }
            set
            {
                SDT = value;
            }
        }
        public string DiaChi_NV
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
      
        public DTO_NhanVien()
        { }
        public DTO_NhanVien(string id, string Name, string phone, string address)
        {
            this.NV_ID= id;
            this.Name_NV = Name;
            this.Phone_NV = phone;
            this.DiaChi_NV = address;
           
        }

    }
}
