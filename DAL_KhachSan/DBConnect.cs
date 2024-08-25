using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DAL_KhachSan
{
    public class DBConnect
    {
        public static SqlConnection HamKetNoi()
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=MYDUYEN\SQLEXPRESS01;Initial Catalog=QuanLyKhachSan;Integrated Security=True");
            return _conn;
        }
            
        
    }
}
