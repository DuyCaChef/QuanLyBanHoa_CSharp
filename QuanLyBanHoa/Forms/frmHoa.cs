using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QuanLyBanHoa.Data;
using QuanLyBanHoa.Models;

namespace QuanLyBanHoa.Forms
{
    public partial class frmHoa : Form
    {
        // Static event to notify other forms when flower data changes
        public static event EventHandler HoaDataChanged;

        // Method to raise the event
        protected static void OnHoaDataChanged()
        {
            HoaDataChanged?.Invoke(null, EventArgs.Empty);
        }

        // Biến để lưu trạng thái đang sửa
        private bool isEditing = false;
        private int currentMaHoa = 0;

        public frmHoa()
        {
            InitializeComponent();

            // Đăng ký sự kiện FormClosing
            this.FormClosing += Hoa_FormClosing;
        }

        private void Hoa_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Xác nhận trước khi đóng
            var result = MessageBox.Show(
                "Bạn có muốn đăng xuất và quay lại màn hình đăng nhập?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Clear session
                Session.Clear();
                
                // Tìm và hiển thị lại form đăng nhập
                foreach (Form form in Application.OpenForms)
                {
                    if (form is FrmDangNhap)
                    {
                        form.Show();
                        break;
                    }
                }
            }
            else
            {
                e.Cancel = true; // Hủy đóng form
            }
        }

        private void lbSoLuongTon_Click(object sender, EventArgs e)
        {
        }

        private void frmQuanLiHoa_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin user đang đăng nhập
            this.Text = $"Quản Lý Hoa - {Session.Role}: {Session.UserName}";
            
            LoadSoLuongCoSan();
            LoadDataToDataGridView();
            SetupDataGridView();
            SetButtonState(false);
        }

        private void LoadSoLuongCoSan()
        {
            cboSoLuong.Items.Clear();
            for (int i = 1; i <= 100; i++)
            {
                cboSoLuong.Items.Add(i);
            }
        }

        private void SetupDataGridView()
        {
            if (dgDSHoa.Columns.Count > 0)
            {
                // Đặt tên hiển thị cho các cột
                if (dgDSHoa.Columns.Contains("MaHoa"))
                    dgDSHoa.Columns["MaHoa"].HeaderText = "Mã Hoa";
                
                if (dgDSHoa.Columns.Contains("TenHoa"))
                    dgDSHoa.Columns["TenHoa"].HeaderText = "Tên Hoa";
                
                if (dgDSHoa.Columns.Contains("Gia"))
                {
                    dgDSHoa.Columns["Gia"].HeaderText = "Giá Bán";
                    dgDSHoa.Columns["Gia"].DefaultCellStyle.Format = "N0";
                    dgDSHoa.Columns["Gia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                
                if (dgDSHoa.Columns.Contains("SoLuong"))
                {
                    dgDSHoa.Columns["SoLuong"].HeaderText = "Số Lượng";
                    dgDSHoa.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                
                if (dgDSHoa.Columns.Contains("MoTa"))
                    dgDSHoa.Columns["MoTa"].HeaderText = "Mô Tả";
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
        }

        private void hoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void ClearInputFields()
        {
            txtMaHoa.Clear();
            txtTenHoa.Clear();
            txtGia.Clear();
            txtGhichu.Clear();
            cboSoLuong.SelectedIndex = -1;

            isEditing = false;
            currentMaHoa = 0;
            
            txtMaHoa.ReadOnly = true;
            SetButtonState(false);
        }

        private void SetButtonState(bool editing)
        {
            btnThem.Enabled = !editing;
            btnSua.Enabled = !editing && dgDSHoa.SelectedRows.Count > 0;
            btnXoa.Enabled = !editing && dgDSHoa.SelectedRows.Count > 0;
            btnLuu.Enabled = editing;
        }

        private void dgDSHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        // Event khi chọn dòng trong DataGridView
        private void dgDSHoa_SelectionChanged(object sender, EventArgs e)
        {
            if (dgDSHoa.SelectedRows.Count > 0 && !isEditing)
            {
                DataGridViewRow row = dgDSHoa.SelectedRows[0];
                
                txtMaHoa.Text = row.Cells["MaHoa"].Value?.ToString() ?? "";
                txtTenHoa.Text = row.Cells["TenHoa"].Value?.ToString() ?? "";
                txtGia.Text = row.Cells["Gia"].Value?.ToString() ?? "";
                
                string moTa = row.Cells["MoTa"].Value?.ToString() ?? "";
                txtGhichu.Text = moTa;

                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value ?? 0);
                if (soLuong > 0 && soLuong <= 100)
                {
                    cboSoLuong.SelectedItem = soLuong;
                }

                SetButtonState(false);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtTenHoa.Text))
            {
                MessageBox.Show("Vui lòng nhập tên hoa.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenHoa.Focus();
                return;
            }

            string rawGia = txtGia.Text.Trim();
            if (string.IsNullOrWhiteSpace(rawGia))
            {
                MessageBox.Show("Vui lòng nhập giá bán.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGia.Focus();
                return;
            }

            decimal gia;
            bool parsed = decimal.TryParse(rawGia, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out gia)
                || decimal.TryParse(rawGia, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, new CultureInfo("vi-VN"), out gia)
                || decimal.TryParse(rawGia, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.InvariantCulture, out gia);

            if (!parsed)
            {
                string cleaned = Regex.Replace(rawGia, "[^0-9,.-]", "");
                if (cleaned.Contains(',') && cleaned.Contains('.'))
                {
                    cleaned = cleaned.Replace(".", "");
                    cleaned = cleaned.Replace(',', '.'); // normalize to dot for invariant
                }
                parsed = decimal.TryParse(cleaned, NumberStyles.Number, CultureInfo.InvariantCulture, out gia);
            }

            if (!parsed || gia <= 0)
            {
                MessageBox.Show("Giá không hợp lệ. Vui lòng nhập số lớn hơn 0.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGia.Focus();
                return;
            }

            if (cboSoLuong.SelectedItem == null || !int.TryParse(cboSoLuong.SelectedItem.ToString(), out int soLuong))
            {
                MessageBox.Show("Vui lòng chọn số lượng.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSoLuong.Focus();
                return;
            }

            // Tạo đối tượng Hoa mới và sử dụng phương thức Insert từ class Hoa
            try
            {
                var hoaMoi = new Hoa
                {
                    TenHoa = txtTenHoa.Text.Trim(),
                    Gia = gia,
                    SoLuong = soLuong,
                    MoTa = txtGhichu.Text.Trim()
                };

                bool success = Hoa.Insert(hoaMoi);
                
                if (success)
                {
                    MessageBox.Show("Thêm hoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataToDataGridView();
                    ClearInputFields();
                    OnHoaDataChanged();
                }
                else
                {
                    MessageBox.Show("Thêm hoa không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm hoa: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgDSHoa.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hoa cần sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!isEditing)
            {
                // Chuyển sang chế độ sửa
                isEditing = true;
                currentMaHoa = Convert.ToInt32(txtMaHoa.Text);
                SetButtonState(true);
                txtMaHoa.ReadOnly = true;
                txtTenHoa.Focus();
            }
            else
            {
                // Lưu thay đổi
                SaveEdit();
            }
        }

        private void SaveEdit()
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtTenHoa.Text))
            {
                MessageBox.Show("Vui lòng nhập tên hoa.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenHoa.Focus();
                return;
            }

            string rawGia = txtGia.Text.Trim();
            if (string.IsNullOrWhiteSpace(rawGia))
            {
                MessageBox.Show("Vui lòng nhập giá bán.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGia.Focus();
                return;
            }

            decimal gia;
            bool parsed = decimal.TryParse(rawGia, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out gia)
                || decimal.TryParse(rawGia, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, new CultureInfo("vi-VN"), out gia)
                || decimal.TryParse(rawGia, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.InvariantCulture, out gia);

            if (!parsed)
            {
                string cleaned = Regex.Replace(rawGia, "[^0-9,.-]", "");
                if (cleaned.Contains(',') && cleaned.Contains('.'))
                {
                    cleaned = cleaned.Replace(".", "");
                    cleaned = cleaned.Replace(',', '.'); // normalize to dot for invariant
                }
                parsed = decimal.TryParse(cleaned, NumberStyles.Number, CultureInfo.InvariantCulture, out gia);
            }

            if (!parsed || gia <= 0)
            {
                MessageBox.Show("Giá không hợp lệ. Vui lòng nhập số lớn hơn 0.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGia.Focus();
                return;
            }

            if (cboSoLuong.SelectedItem == null || !int.TryParse(cboSoLuong.SelectedItem.ToString(), out int soLuong))
            {
                MessageBox.Show("Vui lòng chọn số lượng.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSoLuong.Focus();
                return;
            }

            // Tạo đối tượng Hoa và sử dụng phương thức Update từ class Hoa
            try
            {
                var hoaCapNhat = new Hoa
                {
                    MaHoa = currentMaHoa,
                    TenHoa = txtTenHoa.Text.Trim(),
                    Gia = gia,
                    SoLuong = soLuong,
                    MoTa = txtGhichu.Text.Trim()
                };

                bool success = Hoa.Update(hoaCapNhat);
                
                if (success)
                {
                    MessageBox.Show("Cập nhật hoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataToDataGridView();
                    ClearInputFields();
                    OnHoaDataChanged();
                }
                else
                {
                    MessageBox.Show("Cập nhật hoa không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật hoa: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close(); // Gọi sự kiện FormClosing
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                SaveEdit();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để lưu. Vui lòng nhấn 'Sửa' trước.", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadDataToDataGridView()
        {
            try
            {
                // Sử dụng phương thức GetAll từ class Hoa
                List<Hoa> danhSachHoa = Hoa.GetAll();
                
                // Chuyển đổi List<Hoa> sang BindingList để binding với DataGridView
                BindingList<Hoa> bindingList = new BindingList<Hoa>(danhSachHoa);
                dgDSHoa.DataSource = bindingList;
                SetupDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboSoLuong_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgDSHoa.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hoa cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgDSHoa.SelectedRows[0].Cells["MaHoa"].Value == null)
            {
                MessageBox.Show("Không tìm thấy Mã Hoa để xóa.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int maHoaCanXoa = Convert.ToInt32(dgDSHoa.SelectedRows[0].Cells["MaHoa"].Value);
            string tenHoa = dgDSHoa.SelectedRows[0].Cells["TenHoa"].Value?.ToString() ?? "";

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa hoa '{tenHoa}' (Mã: {maHoaCanXoa})?\n\nHành động này không thể hoàn tác!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Sử dụng phương thức Delete từ class Hoa
                    bool success = Hoa.Delete(maHoaCanXoa);

                    if (success)
                    {
                        MessageBox.Show("Xóa hoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataToDataGridView();
                        ClearInputFields();
                        OnHoaDataChanged();
                    }
                    else
                    {
                        MessageBox.Show("Xóa hoa không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1451) // Foreign key constraint fails
                    {
                        MessageBox.Show("Không thể xóa hoa này vì đã có đơn hàng liên quan!", 
                            "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi xóa hoa: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa hoa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTim.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadDataToDataGridView();
                return;
            }

            try
            {
                // Sử dụng phương thức Search từ class Hoa
                List<Hoa> ketQuaTimKiem = Hoa.Search(keyword);
                
                if (ketQuaTimKiem.Count > 0)
                {
                    BindingList<Hoa> bindingList = new BindingList<Hoa>(ketQuaTimKiem);
                    dgDSHoa.DataSource = bindingList;
                    SetupDataGridView();
                    MessageBox.Show($"Tìm thấy {ketQuaTimKiem.Count} kết quả!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataToDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
