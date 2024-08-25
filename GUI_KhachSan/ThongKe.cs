using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace GUI_KhachSan
{
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=MYDUYEN\SQLEXPRESS01;Initial Catalog=QuanLyKhachSan;Integrated Security=True");
            SqlDataAdapter ad = new SqlDataAdapter("SELECT PhieuDatPhong.MaPhong, SUM(HoaDon.ThanhTien) AS 'TongTien' FROM HoaDon INNER JOIN PhieuDatPhong ON HoaDon.MaDP = PhieuDatPhong.MaDP GROUP BY PhieuDatPhong.MaPhong", conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            chart1.DataSource = dt;
            //Lấy trục tung, trục hoành cho biểu đồ
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "MaPhong";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "TongTien";
            chart1.Series["Mã phòng"].XValueMember = "MaPhong";
            chart1.Series["Mã phòng"].YValueMembers = "TongTien";

        }
    }
}
