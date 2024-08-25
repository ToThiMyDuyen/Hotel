using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_KhachSan;
using BUS_KhachSan;
namespace GUI_KhachSan
{
    public partial class QuanLyKhachSan : Form
    {

        public QuanLyKhachSan()
        {
            InitializeComponent();
        }

        private void QuanLyKhachSan_Load(object sender, EventArgs e)
        {
            dtgNV.DataSource = BUS_NhanVien.getNhanVien();
            dGVKH.DataSource = BUS_KhachHang.getKhachHang();
            dGVPhong.DataSource = BUS_Phong.getPhong();
            LoadData();
            LoadMaDP();
            dGVHD.DataSource = BUS_HoaDon.getHoaDon();
            ShowCBMaDPHD();
           
        }
        //THÊM NHÂN VIÊN
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != "" && txtTenNV.Text != "" && txtSDT.Text != "" && txtDiaChi.Text != "")

            {
                try
                {
                    DTO_NhanVien nv = new DTO_NhanVien(txtMaNV.Text, txtTenNV.Text, txtSDT.Text, txtDiaChi.Text);
                    BUS_NhanVien.themNhanVien(nv);
                    MessageBox.Show("Bạn đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtgNV.DataSource = BUS_NhanVien.getNhanVien();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {

                MessageBox.Show("Xin hãy nhập đầy đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        //XÓA NHÂN VIÊN
        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa nhân viên không?", "Xóa nhân viên", MessageBoxButtons.OKCancel, MessageBoxIcon.Question).ToString() == "OK")
            {
                try
                {
                    DTO_NhanVien nv = new DTO_NhanVien(txtMaNV.Text, txtTenNV.Text, txtSDT.Text, txtDiaChi.Text);
                    BUS_NhanVien.xoaNhanVien(txtMaNV.Text);
                    MessageBox.Show("Bạn đã xóa thành công!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtgNV.DataSource = BUS_NhanVien.getNhanVien();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //SỬA NHÂN VIÊN
        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != "" && txtTenNV.Text != "" && txtSDT.Text != "" && txtDiaChi.Text != "")
            {
                try
                {
                    DTO_NhanVien nv = new DTO_NhanVien(txtMaNV.Text, txtTenNV.Text, txtSDT.Text, txtDiaChi.Text);
                    BUS_NhanVien.suaNhanVien(nv);
                    MessageBox.Show("Bạn đã sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtgNV.DataSource = BUS_NhanVien.getNhanVien();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Xin hãy nhập đầy đủ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Hiển thị dữ liệu lên dataGridView 
        private void dtgNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaNV.Text = dtgNV.Rows[index].Cells[0].Value.ToString();
                txtTenNV.Text = dtgNV.Rows[index].Cells[1].Value.ToString();
                txtSDT.Text = dtgNV.Rows[index].Cells[2].Value.ToString();
                txtDiaChi.Text = dtgNV.Rows[index].Cells[3].Value.ToString();
            }
        }
        //Tìm kiếm nhân viên
        private void btTim_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable result = null; //Khởi tạo biến result để lưu kết quả tìm kiếm

                if (rdMaNV.Checked) //Nếu chọn tìm kiếm theo mã nhân viên
                {
                    result = BUS_NhanVien.timTheoMa(txtTim.Text);
                }
                else if (rdTenNV.Checked)
                {
                    result = BUS_NhanVien.timTheoTen(txtTim.Text);
                }
                //kiểm tra trước xem kết quả tìm kiếm (result) có null hay không, sau đó kiểm tra số lượng hàng sử dụng RowCount.
                //Nếu không có kết quả hoặc kết quả rỗng, chúng ta hiển thị thông báo "Không tìm thấy" 
                if (result != null && result.Rows.Count > 0)
                {
                    dtgNV.DataSource = result;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Hiển thị lại danh sách nhan vien
                    dtgNV.DataSource = BUS_NhanVien.getNhanVien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm nhân viên: " + ex.Message);
            }          
        }
        //---------TAB KHACH HANG-----------
        private void btnThemKH_Click(object sender, EventArgs e) //THÊM KHÁCH HÀNG
        {
            if (txtMaKH.Text != "" && txtTenKH.Text != "" && txtCCCD.Text != "" && txtDiaChiKH.Text != "" && txtSdtKH.Text != "")
            {
                try
                {
                    //Tạo một đối tượng DTO_KhachHang mới để nhập dữ liệu
                    DTO_KhachHang kh = new DTO_KhachHang(txtMaKH.Text, txtTenKH.Text, txtCCCD.Text, txtDiaChiKH.Text, txtSdtKH.Text);
                    //Gọi phương thức themKhachHang từ đối tượng BUS_KhachHang để thêm khách hàng mới vào CSDL
                    BUS_KhachHang.themKhachHang(kh);
                    MessageBox.Show("Bạn đã thêm thành công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Cập nhật dữ liệu trên DataGridView (dGVKH)
                    dGVKH.DataSource = BUS_KhachHang.getKhachHang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Xin hãy nhập đầy đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        //SỬA KHÁCH HÀNG
        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text != "" && txtTenKH.Text != "" && txtCCCD.Text != "" && txtDiaChiKH.Text != "" && txtSdtKH.Text != "")
            {
                try
                {
                    DTO_KhachHang kh = new DTO_KhachHang(txtMaKH.Text, txtTenKH.Text, txtCCCD.Text, txtDiaChiKH.Text, txtSdtKH.Text);
                    BUS_KhachHang.suaKhachHang(kh);
                    MessageBox.Show("Bạn đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dGVKH.DataSource = BUS_KhachHang.getKhachHang();// refresh datagridview
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Xin hãy nhập thông tin cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        //XÓA KH
        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa khách hàng không ?", "Xóa khách hàng",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question).ToString() == "OK")
            {
                try
                {
                    DTO_KhachHang kh = new DTO_KhachHang(txtMaKH.Text, txtTenKH.Text, txtCCCD.Text, txtDiaChi.Text, txtSdtKH.Text);                  
                    BUS_KhachHang.xoaKhachHang(txtMaKH.Text);
                    MessageBox.Show("Bạn đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dGVKH.DataSource = BUS_KhachHang.getKhachHang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        // hiển thị dữ liệu lên thông tin khách hàng khi click vào datagridViewKH
        private void dGVKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex; //Lấy chỉ số dòng của ô được click
            if (index >= 0)
            {
                //Lấy giá trị của từng ô trong dòng được click và hiển thị lên các ô 
                txtMaKH.Text = dGVKH.Rows[index].Cells[0].Value.ToString();
                txtTenKH.Text = dGVKH.Rows[index].Cells[1].Value.ToString();
                txtCCCD.Text = dGVKH.Rows[index].Cells[2].Value.ToString();
                txtDiaChiKH.Text = dGVKH.Rows[index].Cells[3].Value.ToString();
                txtSdtKH.Text = dGVKH.Rows[index].Cells[4].Value.ToString();
            }
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Form1 fr1 = new Form1();
            fr1.Show();
            this.Hide();
        }
        //TÌM KIẾM KHÁCH HÀNG
        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable result = null; //Khởi tạo biến result để lưu kết quả tìm kiếm

                if (rdMaKH.Checked)//Nếu chọn tìm kiếm theo Mã khách hàng
                {
                    result = BUS_KhachHang.timKhachHangTheoMa(txtTimKiemKH.Text);
                }
                else if (rdTenKH.Checked)
                {
                    result = BUS_KhachHang.timKhachHangTheoTen(txtTimKiemKH.Text);
                }
                //kiểm tra trước xem kết quả tìm kiếm (result) có null hay không, sau đó kiểm tra số lượng hàng sử dụng RowCount.
                //Nếu không có kết quả hoặc kết quả rỗng, chúng ta hiển thị thông báo "Không tìm thấy" 
                if (result != null && result.Rows.Count > 0)
                {
                    dGVKH.DataSource = result; //Hiển thị kết quả tìm kiếm lên DataGridView
                }
                else
                {
                    MessageBox.Show("Không tìm thấy.", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    // Hiển thị lại danh sách khách hàng nếu không tìm thấy
                    dGVKH.DataSource = BUS_KhachHang.getKhachHang();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm khách hàng: " + ex.Message);
            }

        }
        //-----------TAB PHÒNG---------
        //// hiển thị dữ liệu lên thông tin phòng khi click vào datagridViewPhong
        private void dGVPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaP.Text = dGVPhong.Rows[index].Cells[0].Value.ToString();
                txtSoPhong.Text = dGVPhong.Rows[index].Cells[1].Value.ToString();
                cobLoaiP.Text = dGVPhong.Rows[index].Cells[2].Value.ToString();
                cobTinhTrangP.Text = dGVPhong.Rows[index].Cells[3].Value.ToString();
                txtGiaP.Text = dGVPhong.Rows[index].Cells[4].Value.ToString();
               
            }
        }
        //Thêm phòng
        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            if (txtMaP.Text != "" && txtSoPhong.Text != "")
            {
                try
                {
                    DTO_Phong phong = new DTO_Phong(txtMaP.Text, txtSoPhong.Text, cobLoaiP.SelectedItem.ToString(), cobTinhTrangP.SelectedItem.ToString(), float.Parse(txtGiaP.Text));
                    BUS_Phong.themPhong(phong);
                    MessageBox.Show("Bạn đã thêm phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dGVPhong.DataSource = BUS_Phong.getPhong();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {

                MessageBox.Show("Xin hãy nhập đầy đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Sửa phòng
        private void btnSuaPhong_Click(object sender, EventArgs e)
        {
            if (txtMaP.Text != "" && txtSoPhong.Text != "" && cobLoaiP.SelectedItem != null && cobTinhTrangP.SelectedItem != null && txtGiaP.Text != "")
            {
                try
                {
                    DTO_Phong phong = new DTO_Phong(txtMaP.Text, txtSoPhong.Text, cobLoaiP.SelectedItem.ToString(), cobTinhTrangP.SelectedItem.ToString(), float.Parse(txtGiaP.Text));
                    BUS_Phong.suaPhong(phong);
                    MessageBox.Show("Bạn đã sửa phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dGVPhong.DataSource = BUS_Phong.getPhong();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Xin hãy nhập thông tin cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Xóa phòng
        private void btnXoaPhong_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có muốn xóa phòng không ?", "Xóa phòng",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question).ToString() == "OK")
            {
                try
                {
                    BUS_Phong.xoaPhong(txtMaP.Text);
                    MessageBox.Show("Bạn đã xóa phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dGVPhong.DataSource = BUS_Phong.getPhong();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        //Tìm phòng
        private void btTimPhong_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable result = null; //Khởi tạo biến result để lưu kết quả tìm kiếm

                if (rdMaPhong.Checked) //Nếu chọn tìm kiếm theo Mã phòng
                {
                    result = BUS_Phong.timPhongTheoMaPhong(txtTimPhong.Text);
                }
                else if (rdSoPhong.Checked) //Nếu chọn tìm kiếm theo Số phòng
                {
                    result = BUS_Phong.timPhongTheoSoPhong(txtTimPhong.Text);
                }
                //kiểm tra trước xem kết quả tìm kiếm (result) có null hay không, sau đó kiểm tra số lượng hàng sử dụng RowCount.
                //Nếu không có kết quả hoặc kết quả rỗng, chúng ta hiển thị thông báo "Không tìm thấy" 
                if (result != null && result.Rows.Count > 0)
                {
                    dGVPhong.DataSource = result; //Hiển thị kết quả tìm kiếm lên DataGridView
                }
                else
                {
                    MessageBox.Show("Không tìm thấy. Vui lòng nhập đúng mã hoặc số phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Hiển thị lại danh sách phòng khi không tìm thấy 
                    dGVPhong.DataSource = BUS_Phong.getPhong();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm phòng: " + ex.Message);
            }
        }
        //------------Tab ĐẶT PHÒNG----------
        private void LoadData()
        {
            //Load dữ liệu vào ComboBox mã khách hàng từ bảng KhachHang
            cobMaKHP.DataSource = BUS_KhachHang.getKhachHang(); //Lấy dữ liệu khách hàng từ BUS_KhachHang và gán vào ComboBox cobMaKHP
            cobMaKHP.DisplayMember = "MaKH"; //Chỉ định MaKH làm giá trị hiển thị trên ComboBox
            cobMaKHP.ValueMember = "MaKH"; //Chỉ định MaKH làm giá trị thực sự được chọn trên ComboBox

            //Load dữ liệu vào TextBox tên khách hàng từ bảng KhachHang
            txtTenKHP.DataBindings.Clear(); //Xóa các kết nối dữ liệu hiện có cho TextBox 
            txtTenKHP.DataBindings.Add("Text", cobMaKHP.DataSource, "TenKH"); //Kết nối TextBox(txtTenKHP) với TenKH của dữ liệu trong cobMaKHP

            //Load dữ liệu vào ComboBox mã phòng từ bảng Phong
            cobMaPhongP.DataSource = BUS_Phong.getPhong();
            cobMaPhongP.DisplayMember = "MaPhong";
            cobMaPhongP.ValueMember = "MaPhong";
            //Ô Số phòng
            txtSoPhongP.DataBindings.Clear();
            txtSoPhongP.DataBindings.Add("Text", cobMaPhongP.DataSource, "SoPhong");
            //Ô Tình trạng Phòng
            txtTinhTrangP.DataBindings.Clear();
            txtTinhTrangP.DataBindings.Add("Text", cobMaPhongP.DataSource, "TinhTrangPhong");
            //Load dữ liệu vào ComboBox mã nhân viên từ bảng NhanVien
            cobMaNVDP.DataSource = BUS_NhanVien.getNhanVien();
            cobMaNVDP.DisplayMember = "MaNV";
            cobMaNVDP.ValueMember = "MaNV";
            //Load dữ liệu vào DataGridView danh sách đặt phòng từ bảng PhieuDatPhong
            dGVDP.DataSource = BUS_PhieuDP.getPhieuDP();
        }

        private void dGVDP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                DataGridViewRow selectedRow = dGVDP.Rows[index]; //Lấy dòng được click
                txtMaDP.Text = selectedRow.Cells["MaDP"].Value.ToString();
                txtTenKHP.Text = selectedRow.Cells["TenKH1"].Value.ToString();
                cobMaPhongP.SelectedValue = selectedRow.Cells["MaPhong1"].Value.ToString();
                dTPNgayThue.Value = (DateTime)selectedRow.Cells["NgayThue"].Value;
                dTPNgayTra.Value = (DateTime)selectedRow.Cells["NgayTra"].Value;
            }
        }
        //TÌM KIẾM ĐẶT PHÒNG
        private void btnTKDP_Click(object sender, EventArgs e)
        {
            string maDP = cobTkDP.SelectedItem?.ToString(); //Lấy mã đặt phòng từ ComboBox
            if (!string.IsNullOrEmpty(maDP))
            {
                //Gọi phương thức TimKiemDatPhong từ đối tượng BUS_PhieuDP
                DataTable dt = BUS_PhieuDP.TimKiemDatPhong(maDP);
                if (dt.Rows.Count > 0) //Kiểm tra xem có kết quả tìm kiếm không
                {
                    //Hiển thị kết quả tìm kiếm lên DataGridView 
                    dGVDP.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin cho mã đặt phòng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mã đặt phòng để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Lấy mã đặt phòng hiển thị trong comboBox tìm kiếm
        private void LoadMaDP()
        {
            //Xóa các mục cũ trong ComboBox trước khi thêm mới
            cobTkDP.Items.Clear();
            //Thêm lại mã phiếu đặt phòng vào ComboBox
            foreach (DataGridViewRow row in dGVDP.Rows) //Duyệt qua từng dòng trong DataGridView dGVDP
            {
                if (!row.IsNewRow) //Kiểm tra xem dòng hiện tại có phải là dòng mới không
                {
                    string maPhieuDP = row.Cells["MaDP"].Value.ToString(); //Lấy mã phiếu đặt phòng từ cột "MaDP" của dòng hiện tại
                    cobTkDP.Items.Add(maPhieuDP);
                }
            }
        }

        private void btnThemDatPhong_Click(object sender, EventArgs e)
        {
            if (txtMaDP.Text != "" && cobMaKHP.SelectedIndex != -1 && cobMaPhongP.SelectedIndex != -1 && cobMaNVDP.SelectedIndex != -1)
            {
                try
                {
                    string maPhong = cobMaPhongP.SelectedValue.ToString();
                    //Kiểm tra xem mã phòng đã tồn tại trong dGVDP chưa
                    foreach (DataGridViewRow row in dGVDP.Rows) //duyệt qua mỗi hàng trong DataGridView dGVDP
                    {
                        if (!row.IsNewRow) //kiểm tra xem hàng hiện tại có phải là hàng mới không
                        {
                            if (row.Cells["MaPhong1"].Value.ToString() == maPhong)
                            {
                                MessageBox.Show("Phòng đã được đặt. Vui lòng chọn phòng khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return; // Kết thúc phương thức nếu mã phòng đã tồn tại
                            }
                        }
                    }
                    //Sau đó thêm phòng nếu mã phòng không tồn tại trong dGVDP
                    //Kiểm tra tình trạng của phòng được chọn
                    string tinhTrangPhong = txtTinhTrangP.Text;
                    if (tinhTrangPhong.Equals("Trống"))
                    {
                        //Tạo đối tượng DTO_PhieuDP từ dữ liệu nhập vào
                        DTO_PhieuDP phieuDP = new DTO_PhieuDP();
                        phieuDP.Ma_DP = txtMaDP.Text;
                        phieuDP.Ma_KH = cobMaKHP.SelectedValue.ToString();
                        phieuDP.Ma_Phong = cobMaPhongP.SelectedValue.ToString();
                        phieuDP.Ma_NV = cobMaNVDP.SelectedValue.ToString();
                        phieuDP.Ngay_Thue = dTPNgayThue.Value;
                        phieuDP.Ngay_Tra = dTPNgayTra.Value;
                        //Gọi phương thức thêm phiếu đặt phòng từ BUS_PhieuDP
                        BUS_PhieuDP.themPhieuDP(phieuDP);
                        //Hiển thị thông báo và cập nhật lại DataGridView danh sách đặt phòng
                        MessageBox.Show("Bạn đã thêm phiếu đặt phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dGVDP.DataSource = BUS_PhieuDP.getPhieuDP();
                    }
                    else
                    {
                        MessageBox.Show("Phòng đã được đặt hoặc đang sửa chữa. Vui lòng chọn phòng khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Xin hãy nhập đầy đủ thông tin!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //SỬA ĐẶT PHÒNG
        private void btSưaDP_Click(object sender, EventArgs e)
        {
            if (txtMaDP.Text != "" && cobMaKHP.SelectedIndex != -1 && cobMaPhongP.SelectedIndex != -1 && cobMaNVDP.SelectedIndex != -1)
            {
                try
                {
                   string maPhong = cobMaPhongP.SelectedValue.ToString();
                        //Kiểm tra xem mã phòng đã tồn tại trong dGVDP chưa
                        foreach (DataGridViewRow row in dGVDP.Rows) //duyệt qua mỗi hàng trong DataGridView dGVDP
                        {
                            if (!row.IsNewRow) //kiểm tra xem hàng hiện tại có phải là hàng mới không
                            {
                                if (row.Cells["MaPhong1"].Value.ToString() == maPhong)
                                {
                                    MessageBox.Show("Phòng đã được đặt. Vui lòng chọn phòng khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return; // Kết thúc phương thức nếu mã phòng đã tồn tại
                                }
                            }
                        }
                        //Kiểm tra tình trạng của phòng được chọn
                        string tinhTrangPhong = txtTinhTrangP.Text;
                if (tinhTrangPhong.Equals("Trống"))
                {
                    //Tạo đối tượng DTO_PhieuDP từ dữ liệu nhập vào
                    DTO_PhieuDP phieuDP = new DTO_PhieuDP();
                    phieuDP.Ma_DP = txtMaDP.Text;
                    phieuDP.Ma_KH = cobMaKHP.SelectedValue.ToString();
                    phieuDP.Ma_Phong = cobMaPhongP.SelectedValue.ToString();
                    phieuDP.Ma_NV = cobMaNVDP.SelectedValue.ToString();
                    phieuDP.Ngay_Thue = dTPNgayThue.Value;
                    phieuDP.Ngay_Tra = dTPNgayTra.Value;
                    //Gọi phương thức sửa phiếu đặt phòng từ BUS_PhieuDP
                    BUS_PhieuDP.suaPhieuDP(phieuDP);
                    //Hiển thị thông báo và cập nhật lại DataGridView danh sách đặt phòng
                    MessageBox.Show("Bạn đã sửa phiếu đặt phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dGVDP.DataSource = BUS_PhieuDP.getPhieuDP();
                }
                else
                {
                    MessageBox.Show("Phòng đã được đặt hoặc đang sửa chữa. Vui lòng chọn phòng khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Xin hãy nhập thông tin cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //----------Tab hoa đơn-------------
        private void ShowCBMaDPHD()
        {
            cobMaPDPHD.DataSource = BUS_PhieuDP.getPhieuDP();
            cobMaPDPHD.DisplayMember = "MaDP";
            cobMaPDPHD.ValueMember = "MaDP";
            //Gán dữ liệu Mã nhân viên, Mã khách hàng, Mã phòng từ tab Đặt phòng vào tab Hóa đơn
            txtMaNVHD.DataBindings.Clear();
            txtMaNVHD.DataBindings.Add("Text", cobMaPDPHD.DataSource, "MaNV");
            txtMaKHHD.DataBindings.Clear();
            txtMaKHHD.DataBindings.Add("Text", cobMaPDPHD.DataSource, "MaKH");
            txtMaPHD.DataBindings.Clear();
            txtMaPHD.DataBindings.Add("Text", cobMaPDPHD.DataSource, "MaPhong");
            // Gắn sự kiện SelectedIndexChanged cho combobox Mã phiếu đặt phòng
            cobMaPDPHD.SelectedIndexChanged += cobMaPDPHD_SelectedIndexChanged;
        }

        private void dGVHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                DataGridViewRow selectedRow = dGVHD.Rows[index]; //Lấy dòng được click
                txtMaHD.Text = selectedRow.Cells["MaHD"].Value.ToString();
                cobMaPDPHD.SelectedValue = selectedRow.Cells["MaDPHD"].Value.ToString();
                txtMaNVHD.Text = selectedRow.Cells["MaNVHD"].Value.ToString();
                txtMaKHHD.Text = selectedRow.Cells["MaKHHD"].Value.ToString();
                txtLoaiPS.Text = selectedRow.Cells["LoaiPS1"].Value.ToString();
                txtCPPS.Text = selectedRow.Cells["chiPhiPS"].Value.ToString();
                txtGiaPhongHD.Text = selectedRow.Cells["GiaPhong1"].Value.ToString();
                // Tính toán Thành tiền
                float chiPhiPhatSinh = float.Parse(txtCPPS.Text);
                float giaPhong = float.Parse(txtGiaPhongHD.Text);
                float thanhTien = chiPhiPhatSinh + giaPhong;
                txtThanhTien.Text = thanhTien.ToString();
                txtThanhTien.Text = selectedRow.Cells["thanhTien"].Value.ToString();
            }
        }
        //THÊM HÓA ĐƠN
        private void btThemHD_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text != "" && cobMaPDPHD.SelectedIndex != -1 && txtMaKHHD.Text != "" && txtMaPHD.Text != "")
            {
                try
                {
                    DTO_HoaDon HD = new DTO_HoaDon();
                    HD.Ma_HD = txtMaHD.Text;
                    HD.Ma_DP = cobMaPDPHD.SelectedValue?.ToString();
                    HD.Ma_NV = txtMaNVHD.Text;
                    HD.Ma_KH = txtMaKHHD.Text;
                    HD.Loai_Phat_Sinh = txtLoaiPS.Text;
                    HD.Chi_Phi_Phat_Sinh = float.Parse(txtCPPS.Text);
                    HD.Gia_Phong = float.Parse(txtGiaPhongHD.Text);
                    HD.Thanh_Tien = HD.Chi_Phi_Phat_Sinh + HD.Gia_Phong;

                    BUS_HoaDon.themHD(HD);
                    //Hiển thị thông báo và cập nhật lại DataGridView danh sách đặt phòng
                    MessageBox.Show("Bạn đã thêm hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dGVHD.DataSource = BUS_HoaDon.getHoaDon();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Xin hãy nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void cobMaPDPHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maDP = cobMaPDPHD.SelectedValue.ToString();
            //Gọi hàm từ BUS_Phong để lấy mã phòng dựa trên mã phiếu đặt phòng
            DataTable dtMaPhong = BUS_Phong.getMaPhongByMaDP(maDP);
            //Kiểm tra xem DataTable có dữ liệu không
            if (dtMaPhong.Rows.Count > 0)
            {
                //Lấy mã phòng từ DataTable
                string maPhong = dtMaPhong.Rows[0]["MaPhong"].ToString();
                //Gọi hàm từ BUS_Phong để lấy giá phòng dựa trên mã phòng
                DataTable dtGiaPhong = BUS_Phong.getGiaPhongByMaPhong(maPhong);
                //Kiểm tra xem DataTable có dữ liệu không
                if (dtGiaPhong.Rows.Count > 0)
                {
                    //Lấy giá phòng từ DataTable
                    float giaPhong = Convert.ToSingle(dtGiaPhong.Rows[0]["GiaPhong"]);
                    //Hiển thị giá phòng lên TextBox txtGiaPhongHD
                    txtGiaPhongHD.Text = giaPhong.ToString();
                }
            }
            
        }
        private void btInHD_Click(object sender, EventArgs e)
        {
            inHoaDon hd = new inHoaDon();
            hd.Show();
        }
        //SỬA HÓA ĐƠN
        private void btSuaHD_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text != "" && cobMaPDPHD.SelectedIndex != -1 && txtMaKHHD.Text != "" && txtMaPHD.Text != "")
            {
                try
                {
                    DTO_HoaDon HD = new DTO_HoaDon();
                    HD.Ma_HD = txtMaHD.Text;
                    HD.Ma_DP = cobMaPDPHD.SelectedValue?.ToString();
                    HD.Ma_NV = txtMaNVHD.Text;
                   
                    HD.Ma_KH = txtMaKHHD.Text;
                    HD.Loai_Phat_Sinh = txtLoaiPS.Text;
                    HD.Chi_Phi_Phat_Sinh = float.Parse(txtCPPS.Text);
                    HD.Gia_Phong = float.Parse(txtGiaPhongHD.Text);
                    HD.Thanh_Tien = HD.Chi_Phi_Phat_Sinh + HD.Gia_Phong;

                    BUS_HoaDon.suaHD(HD);
                    MessageBox.Show("Bạn đã sửa hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dGVHD.DataSource = BUS_HoaDon.getHoaDon();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Xin hãy nhập thông tin cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKe tk = new ThongKe();
            tk.ShowDialog();
        }

     
        private void chart1_Click(object sender, EventArgs e)
        {

        }

     
    }
}

