using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using QuanLyBanHoa.Data;
using QuanLyBanHoa.Models;
using System.ComponentModel;

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
                    break;
                case CustomerFormMode.Editing:
                    txtMaKH.ReadOnly = true; // không cho sửa khóa chính
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = true;
                    break;
                default: // None
                    txtMaKH.ReadOnly = true;
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
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
                dgDSKhachHang.DataSource = new BindingList<KhachHang>(KhachHang.GetAll());
                SetupDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            _mode = CustomerFormMode.Adding;
            if (!ValidateInputs())
            {
                SetMode(CustomerFormMode.None);
                return;
            }

            try
            {
                var sdt = TxtSDTBox?.Text ?? string.Empty;
                var kh = new KhachHang
                {
                    TenKH = txtHoTen.Text.Trim(),
                    SoDienThoai = sdt,
                    DiaChi = txtDiaChi.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };
                bool success = KhachHang.Insert(kh);
                if (success)
                {
                    getData();
                    ClearInputs();
                    SetMode(CustomerFormMode.None);
                    MessageBox.Show("Thêm khách hàng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetMode(CustomerFormMode.None);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm khách hàng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetMode(CustomerFormMode.None);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Chọn khách hàng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SetMode(CustomerFormMode.Editing);
            if (_mode != CustomerFormMode.Editing) return;

            if (!ValidateInputs()) return;

            try
            {
                var sdt = TxtSDTBox?.Text ?? string.Empty;
                var kh = new KhachHang
                {
                    MaKH = Convert.ToInt32(txtMaKH.Text),
                    TenKH = txtHoTen.Text.Trim(),
                    SoDienThoai = sdt,
                    DiaChi = txtDiaChi.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };
                bool success = KhachHang.Update(kh);
                if (success)
                {
                    getData();
                    ClearInputs();
                    SetMode(CustomerFormMode.None);
                    MessageBox.Show("Cập nhật khách hàng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật khách hàng thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu khách hàng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                bool success = KhachHang.Delete(maKH);
                if (success)
                {
                    getData();
                    ClearInputs();
                    SetMode(CustomerFormMode.None);
                    MessageBox.Show("Đã xóa khách hàng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa khách hàng thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa khách hàng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            ClearInputs();
            getData();
            Focus();

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
                txtSoluong.Text = Convert.ToString(row.Cells["SoLuongDonHang"].Value ?? "0");
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

        private void SetupDataGridView()
        {
            if (dgDSKhachHang.Columns.Count > 0)
            {
                if (dgDSKhachHang.Columns.Contains("MaKH"))
                    dgDSKhachHang.Columns["MaKH"].HeaderText = "Mã KH";
                if (dgDSKhachHang.Columns.Contains("TenKH"))
                    dgDSKhachHang.Columns["TenKH"].HeaderText = "Tên KH";
                if (dgDSKhachHang.Columns.Contains("DiaChi"))
                    dgDSKhachHang.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                if (dgDSKhachHang.Columns.Contains("SoDienThoai"))
                    dgDSKhachHang.Columns["SoDienThoai"].HeaderText = "SĐT";
                if (dgDSKhachHang.Columns.Contains("Email"))
                    dgDSKhachHang.Columns["Email"].HeaderText = "Email";
                if (dgDSKhachHang.Columns.Contains("SoLuongDonHang"))
                    dgDSKhachHang.Columns["SoLuongDonHang"].HeaderText = "Số Đơn";
            }
        }
    }
}
