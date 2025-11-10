using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using QuanLyBanHoa.Data;

namespace QuanLyBanHoa.Forms
{
    public partial class frmQuanLiKhachHang : Form
    {
        private enum CustomerFormMode { None, Adding, Editing }
        private CustomerFormMode _mode = CustomerFormMode.None;

        // Helper to safely access the phone TextBox (named "txtSĐT" in designer)
        private TextBox TxtSDTBox
        {
            get
            {
                var arr = this.Controls.Find("txtSĐT", true);
                return (arr != null && arr.Length > 0) ? arr[0] as TextBox : null;
            }
        }

        public frmQuanLiKhachHang()
        {
            InitializeComponent();
            // Remove duplicate manual event subscriptions; Designer already wires Click/SelectionChanged.
            // Keep read-only for txtSoluong
            txtSoluong.ReadOnly = true;
        }

        private void SetMode(CustomerFormMode mode)
        {
            _mode = mode;
            switch (mode)
            {
                case CustomerFormMode.Adding:
                    txtMaKH.ReadOnly = true; // để DB tự tăng
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnLuu.Enabled = true;
                    break;
                case CustomerFormMode.Editing:
                    txtMaKH.ReadOnly = true; // không cho sửa khóa chính
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = true;
                    btnLuu.Enabled = true;
                    break;
                default:
                    txtMaKH.ReadOnly = true;
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnLuu.Enabled = false;
                    break;
            }
        }

        private void ClearInputs()
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            var sdtBox = TxtSDTBox; if (sdtBox != null) sdtBox.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtSoluong.Clear();
        }

        public void getData()
        {
            try
            {
                using var con = Database.GetConnection();
                con.Open();
                string query = @"SELECT k.MaKH, k.TenKH, k.SoDienThoai, k.DiaChi, k.Email,
                                     (SELECT COUNT(*) FROM DonHang d WHERE d.MaKH = k.MaKH) AS SoLuongDon
                                  FROM KhachHang k
                                  ORDER BY k.MaKH DESC";
                using var cmd = new SqlCommand(query, con);
                using var reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dgDSKhachHang.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu khách hàng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            var sdt = TxtSDTBox?.Text ?? string.Empty;
            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Có thể thêm validate email đơn giản
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !txtEmail.Text.Contains('@'))
            {
                var res = MessageBox.Show("Email có vẻ không hợp lệ, tiếp tục?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res != DialogResult.Yes) return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearInputs();
            SetMode(CustomerFormMode.Adding);
            txtHoTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Chọn khách hàng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SetMode(CustomerFormMode.Editing);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaKH.Text) || !int.TryParse(txtMaKH.Text, out int maKH))
                {
                    MessageBox.Show("Chọn khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var confirm = MessageBox.Show($"Xóa khách hàng #{maKH}? Hành động không thể hoàn tác.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;

                using var con = Database.GetConnection();
                con.Open();
                
                // Kiểm tra tồn tại đơn hàng
                using (var checkCmd = new SqlCommand("SELECT COUNT(*) FROM DonHang WHERE MaKH=@MaKH", con))
                {
                    checkCmd.Parameters.AddWithValue("@MaKH", maKH);
                    var count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        var res = MessageBox.Show("Khách hàng có đơn hàng. Vẫn xóa (sẽ xóa cả đơn)?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (res != DialogResult.Yes) return;
                        
                        // SQL Server: Xóa chi tiết đơn trước - dùng subquery thay vì DELETE...JOIN
                        using (var delCt = new SqlCommand("DELETE FROM ChiTietDonHang WHERE MaDH IN (SELECT MaDH FROM DonHang WHERE MaKH=@MaKH)", con))
                        {
                            delCt.Parameters.AddWithValue("@MaKH", maKH);
                            delCt.ExecuteNonQuery();
                        }
                        using (var delDon = new SqlCommand("DELETE FROM DonHang WHERE MaKH=@MaKH", con))
                        {
                            delDon.Parameters.AddWithValue("@MaKH", maKH);
                            delDon.ExecuteNonQuery();
                        }
                    }
                }

                using (var cmd = new SqlCommand("DELETE FROM KhachHang WHERE MaKH=@MaKH", con))
                {
                    cmd.Parameters.AddWithValue("@MaKH", maKH);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đã xóa khách hàng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getData();
                ClearInputs();
                SetMode(CustomerFormMode.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa khách hàng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            try
            {
                using var con = Database.GetConnection();
                con.Open();
                if (_mode == CustomerFormMode.Adding)
                {
                    // SQL Server: SCOPE_IDENTITY() thay vì LAST_INSERT_ID()
                    string insertSql = @"INSERT INTO KhachHang (TenKH, SoDienThoai, DiaChi, Email) VALUES (@TenKH,@SDT,@DiaChi,@Email); SELECT CAST(SCOPE_IDENTITY() AS INT);";
                    using var cmd = new SqlCommand(insertSql, con);
                    cmd.Parameters.AddWithValue("@TenKH", txtHoTen.Text.Trim());
                    cmd.Parameters.AddWithValue("@SDT", (TxtSDTBox?.Text ?? string.Empty).Trim());
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    var idObj = cmd.ExecuteScalar();
                    int newId = idObj != null ? Convert.ToInt32(idObj) : 0;
                    MessageBox.Show($"Đã thêm khách hàng (Mã: {newId}).", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (_mode == CustomerFormMode.Editing && int.TryParse(txtMaKH.Text.Trim(), out int maKH))
                {
                    string updateSql = @"UPDATE KhachHang SET TenKH=@TenKH, SoDienThoai=@SDT, DiaChi=@DiaChi, Email=@Email WHERE MaKH=@MaKH";
                    using var cmd = new SqlCommand(updateSql, con);
                    cmd.Parameters.AddWithValue("@TenKH", txtHoTen.Text.Trim());
                    cmd.Parameters.AddWithValue("@SDT", (TxtSDTBox?.Text ?? string.Empty).Trim());
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaKH", maKH);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã cập nhật khách hàng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Chưa chọn chế độ thêm hoặc sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                getData();
                SetMode(CustomerFormMode.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu khách hàng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgDSKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgDSKhachHang.SelectedRows.Count == 0) return;
                var row = dgDSKhachHang.SelectedRows[0];
                txtMaKH.Text = Convert.ToString(row.Cells["MaKH"].Value ?? "");
                txtHoTen.Text = Convert.ToString(row.Cells["TenKH"].Value ?? "");
                var sdtBox = TxtSDTBox; if (sdtBox != null) sdtBox.Text = Convert.ToString(row.Cells["SoDienThoai"].Value ?? "");
                txtDiaChi.Text = Convert.ToString(row.Cells["DiaChi"].Value ?? "");
                txtEmail.Text = Convert.ToString(row.Cells["Email"].Value ?? "");
                txtSoluong.Text = Convert.ToString(row.Cells["SoLuongDon"].Value ?? "0");
            }
            catch { }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void lbSoluong_Click(object sender, EventArgs e) { }

        private void frmQuanLiKhachHang_Load(object sender, EventArgs e)
        {
            if (dgDSKhachHang != null)
            {
                getData();
            }
            SetMode(CustomerFormMode.None);
        }

        private void lbMaKH_Click(object sender, EventArgs e)
        {

        }
    }
}
