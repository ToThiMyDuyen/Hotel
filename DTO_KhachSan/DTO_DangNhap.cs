using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_KhachSan
{
    public class DTO_DangNhap
    {
        private string tenDN;
        private string matKhau;
        public string TenDN 
        { 
            get
            {
                return tenDN;
            }
            set
            {
                tenDN = value;
            }
        }
        public string MatKhau
        {
            get
            {
                return matKhau;
            }
            set
            {
                matKhau = value;
            }
        }
        public DTO_DangNhap()
        { }
        public DTO_DangNhap(string NameLogin, string pass)
        {
            this.tenDN = NameLogin;
            this.matKhau = pass;
        }
    }
}
