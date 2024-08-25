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
using Microsoft.Reporting.WinForms;
using BUS_KhachSan;

namespace GUI_KhachSan
{
    public partial class inHoaDon : Form
    {
        string strCon = @"Data Source=MYDUYEN\SQLEXPRESS01;Initial Catalog=QuanLyKhachSan;Integrated Security=True";
        SqlConnection sqlCon = null;
        public inHoaDon()
        {
            InitializeComponent();
           
        }
       
        private void inHoaDon_Load(object sender, EventArgs e)
        {
            //Hiển thị MaHD trong comboBox
            cobMaHD.DataSource = BUS_HoaDon.getHoaDon();
            cobMaHD.DisplayMember = "MaHD";
            cobMaHD.ValueMember = "MaHD";
            //Kết nối CSDL
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            // Từ CSDL đưa lên dataset
            string sql = "select * from HoaDon";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlCon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "HoaDon");
            // Từ dataset đưa lên report datasource
            this.rpHoaDon.LocalReport.ReportEmbeddedResource = "GUI_KhachSan.InHoaDon.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = ds.Tables["HoaDon"];
            //Tư report datasource đưa lên reportviewer
            this.rpHoaDon.LocalReport.DataSources.Add(rds);
            this.rpHoaDon.RefreshReport();
        }

        private void btnXemHD_Click(object sender, EventArgs e)
        { 
            // Lấy mã hóa đơn được chọn từ comboBox
            string maHD = cobMaHD.SelectedValue.ToString();
            // Truy vấn CSDL để lấy thông tin hóa đơn dựa trên mã hóa đơn
            string query = "SELECT * FROM HoaDon WHERE MaHD = @MaHD";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlCon);
            adapter.SelectCommand.Parameters.AddWithValue("@MaHD", maHD);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "HoaDon");
            // Cập nhật dữ liệu của report
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = ds.Tables["HoaDon"];
            this.rpHoaDon.LocalReport.DataSources.Clear();
            this.rpHoaDon.LocalReport.DataSources.Add(rds);
            this.rpHoaDon.RefreshReport();
        }
    }
}
