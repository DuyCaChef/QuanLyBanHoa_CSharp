using MySql.Data.MySqlClient;
using QuanLyBanHoa.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHoa.Forms; // local forms

namespace QuanLyBanHoa.Forms
{
    public partial class FrmQuanLiNhanVien : Form
    {
        public FrmQuanLiNhanVien()
        {
            InitializeComponent();
        }

        //Kết nối với class database để lấy dữ liệu từ database
        private void LoadNhanVien()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"
                    SELECT
                        nv.MaNV,
                        nv.TenNV,
                        nv.SoDienThoai,
                        nv.ChucVu,
                        COUNT(ct.MaDh) AS SoLuongDonHang
                    FROM NhanVien nv
                    LEFT JOIN ChiTietDonHang ct ON nv.MaNV = ct.MaNV
                    GROUP BY nv.MaNV, nv.TenNV, nv.SoDienThoai, nv.ChucVu;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvNhanVien.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmQuanLiNhanVien_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtMaSo.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(cboChucVu.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = Database.GetConnection())
            {
                conn.Open();

                //check mã nhân viên đã tồn tại chưa, không được trùng
                string checkQuerry = "SELECT COUNT(*) FROM nhanvien WHERE MaNV = @MaNV";
                MySqlCommand checkCmd = new MySqlCommand(checkQuerry, conn);
                checkCmd.Parameters.AddWithValue("@MaNV", txtMaSo.Text);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng sử dụng mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                string querry = "INSERT INTO nhanvien ( TenNV, MaNV, SoDienThoai, ChucVu) VALUES (@TenNV, @MaNV, @SoDienThoai, @ChucVu)";
                MySqlCommand cmd = new MySqlCommand(querry, conn);
                cmd.Parameters.AddWithValue("@TenNV", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@MaNV", txtMaSo.Text);
                cmd.Parameters.AddWithValue("@SoDienThoai", txtSDT.Text);
                cmd.Parameters.AddWithValue("@ChucVu", cboChucVu.Text);
                cmd.ExecuteNonQuery();
            }
            LoadNhanVien();
            MessageBox.Show("Thêm nhân viên thành công!");

            txtHoTen.Clear();
            txtMaSo.Clear();
            txtSDT.Clear();
            cboChucVu.SelectedIndex = -1;
            txtHoTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa.");
                return;
            }

            // Lấy mã nhân viên từ dòng được chọn
            string MaNV = dgvNhanVien.SelectedRows[0].Cells["MaNV"].Value.ToString();
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên mã {MaNV} không?", "Xác nhận xóa", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string querry = "DELETE FROM nhanvien WHERE MaNV = @MaNV";
                    MySqlCommand cmd = new MySqlCommand(querry, conn);
                    cmd.Parameters.AddWithValue("@MaNV", MaNV);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa nhân viên thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhan viên để xoá!");
                    }
                }
                LoadNhanVien();

            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtHoTen.Text = row.Cells["TenNV"].Value.ToString();
                txtMaSo.Text = row.Cells["MaNV"].Value.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
                cboChucVu.Text = row.Cells["ChucVu"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSo.Text) ||
            string.IsNullOrWhiteSpace(txtHoTen.Text) ||
            string.IsNullOrWhiteSpace(txtSDT.Text) ||
            cboChucVu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin để sửa!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn cập nhật thông tin nhân viên này không?",
                                                  "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE nhanvien 
                         SET TenNV = @TenNV, 
                             SoDienThoai = @SoDienThoai, 
                             ChucVu = @ChucVu 
                         WHERE MaNV = @MaNV";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenNV", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@SoDienThoai", txtSDT.Text);
                cmd.Parameters.AddWithValue("@ChucVu", cboChucVu.Text);
                cmd.Parameters.AddWithValue("@MaNV", txtMaSo.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            LoadNhanVien();
            txtHoTen.Clear();
            txtMaSo.Clear();
            txtSDT.Clear();
            cboChucVu.SelectedIndex = -1;
            txtHoTen.Focus();
        }

        private void C_Click(object sender, EventArgs e)
        {
            string tenNV = txtHoTen.Text.Trim();
            string maNV = txtMaSo.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string chucVu = cboChucVu.Text.Trim();

            using (var conn = Database.GetConnection())
            {
                conn.Open();

                // Truy vấn có đếm số đơn hàng
                string query = @"
            SELECT 
                nv.MaNV,
                nv.TenNV,
                nv.SoDienThoai,
                nv.ChucVu,
                COUNT(ct.MaDh) AS SoLuongDonHang
            FROM nhanvien nv
            LEFT JOIN chitietdonhang ct ON nv.MaNV = ct.MaNV
            WHERE 1=1";

                if (!string.IsNullOrEmpty(maNV))
                    query += " AND nv.MaNV LIKE @MaNV";
                if (!string.IsNullOrEmpty(tenNV))
                    query += " AND nv.TenNV LIKE @TenNV";
                if (!string.IsNullOrEmpty(sdt))
                    query += " AND nv.SoDienThoai LIKE @SDT";
                if (!string.IsNullOrEmpty(chucVu))
                    query += " AND nv.ChucVu LIKE @ChucVu";

                query += " GROUP BY nv.MaNV, nv.TenNV, nv.SoDienThoai, nv.ChucVu";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                // Thêm tham số động
                if (!string.IsNullOrEmpty(maNV))
                    cmd.Parameters.AddWithValue("@MaNV", "%" + maNV + "%");
                if (!string.IsNullOrEmpty(tenNV))
                    cmd.Parameters.AddWithValue("@TenNV", "%" + tenNV + "%");
                if (!string.IsNullOrEmpty(sdt))
                    cmd.Parameters.AddWithValue("@SDT", "%" + sdt + "%");
                if (!string.IsNullOrEmpty(chucVu))
                    cmd.Parameters.AddWithValue("@ChucVu", "%" + chucVu + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvNhanVien.DataSource = dt;
            }

            if (dgvNhanVien.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy nhân viên nào phù hợp!");
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadNhanVien();
            txtHoTen.Clear();
            txtMaSo.Clear();
            txtSDT.Clear();
            cboChucVu.SelectedIndex = -1;
            txtHoTen.Focus();
        }

        //mở form trang chủ
        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChuyenForm<FrmHoa>("Hoa");
        }

        private void đơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChuyenForm<FormDonHang>("Đơn Hàng");
        }

        private void kháchHàngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ChuyenForm<frmQuanLiKhachHang>("Khách Hàng");
        }

        private void thốngKêBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChuyenForm<FormThongKeBaoCao>("Thống Kê Báo Cáo");
        }

        // Phương thức chung để chuyển form với xử lý lỗi tốt hơn
        private void ChuyenForm<T>(string tenForm) where T : Form, new()
        {
            try
            {
                // Ẩn form hiện tại trước
                this.Hide();

                // Tạo form mới trong try-catch riêng
                T newForm = null;
                try
                {
                    newForm = new T();
                }
                catch (Exception ex)
                {
                    // Nếu lỗi khi khởi tạo form, hiện lại form hiện tại
                    this.Show();
                    MessageBox.Show(
                        $"Lỗi khi khởi tạo form {tenForm}:\n\n" +
                        $"Lỗi: {ex.Message}\n\n" +
                        $"Chi tiết:\n{ex.InnerException?.Message ?? ex.StackTrace}",
                        "Lỗi khởi tạo form",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // Đăng ký sự kiện đóng form để hiện lại form hiện tại
                newForm.FormClosed += (s, args) =>
                {
                    if (!this.IsDisposed)
                        this.Show();
                };

                // Hiển thị form mới
                try
                {
                    newForm.Show();
                }
                catch (Exception ex)
                {
                    // Nếu lỗi khi hiển thị form, dispose form mới và hiện lại form hiện tại
                    newForm?.Dispose();
                    this.Show();
                    MessageBox.Show(
                        $"Lỗi khi hiển thị form {tenForm}:\n\n" +
                        $"Lỗi: {ex.Message}\n\n" +
                        $"Chi tiết:\n{ex.InnerException?.Message ?? ex.StackTrace}",
                        "Lỗi hiển thị form",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Bắt mọi lỗi khác và đảm bảo form hiện tại được hiển thị lại
                if (!this.Visible && !this.IsDisposed)
                    this.Show();
                    
                MessageBox.Show(
                    $"Lỗi không xác định khi mở form {tenForm}:\n\n" +
                    $"Lỗi: {ex.Message}\n\n" +
                    $"Chi tiết:\n{ex.InnerException?.Message ?? ex.StackTrace}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Bạn có chắc chắn muốn đăng xuất không?",
            "Xác nhận",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
    );

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Ẩn form hiện tại (form chính)
                    this.Hide();

                    // Mở lại form đăng nhập
                    FrmDangNhap frmDangNhap = new FrmDangNhap();
                    frmDangNhap.ShowDialog(); // dùng ShowDialog để đợi đăng nhập xong

                    // Sau khi form đăng nhập đóng, thoát hẳn ứng dụng
                    this.Close();
                }
                catch (Exception ex)
                {
                    this.Show();
                    MessageBox.Show($"Lỗi khi đăng xuất:\n{ex.Message}\n\nChi tiết:\n{ex.StackTrace}", 
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
    }

}
