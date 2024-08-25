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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MYDUYEN\SQLEXPRESS01;Initial Catalog=QuanLyKhachSan;Integrated Security=True");
            string tk = txtDangNhap.Text;
            string mk = txtMK.Text;
            string sql = "select * from TaiKhoan where TenDN = '" + tk + "' and MatKhau = '" + mk + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dta = cmd.ExecuteReader();

            if (dta.Read() == true)
            {
                 MessageBox.Show("Đăng nhập thành công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // mở Form mới
                QuanLyKhachSan frMain = new QuanLyKhachSan();
                frMain.Show();
                this.Hide();
                // this.Close();

            }
            else
            {
                MessageBox.Show("Vui lòng nhập đúng Tên Đăng Nhập và Mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDangNhap.Clear();
                txtMK.Clear();
            }
            con.Close();
        }

      
        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
 }

