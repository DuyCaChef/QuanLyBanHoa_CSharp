using QuanLyBanHoa.Data;
using QuanLyBanHoa.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHoa.Forms
{
    public partial class FrmQuanLiNhanVien : Form
    {
        public FrmQuanLiNhanVien()
        {
            InitializeComponent();
        }

        private void FrmQuanLiNhanVien_Load(object sender, EventArgs e)
        {
            // Kiểm tra quyền Admin
            if (!string.Equals(Session.Vaitro, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Không có quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Set txtMaSo là ReadOnly vì SQL Server tự động tạo MaNV
            txtMaSo.ReadOnly = true;
            txtMaSo.BackColor = System.Drawing.SystemColors.Control;
            
            LoadNhanVien();
        }

        /// <summary>
        /// Load danh sách nhân viên từ database sử dụng class NhanVien
        /// </summary>
        private void LoadNhanVien()
        {
            try
            {
                // Sử dụng phương thức GetAll từ class NhanVien
                List<NhanVien> listNhanVien = NhanVien.GetAll();
                
                // Chuyển đổi List sang BindingList để binding với DataGridView
                BindingList<NhanVien> bindingList = new BindingList<NhanVien>(listNhanVien);
                dgvNhanVien.DataSource = bindingList;
                
                SetupDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Thiết lập hiển thị cho DataGridView
        /// </summary>
        private void SetupDataGridView()
        {
            if (dgvNhanVien.Columns.Count > 0)
            {
                // Đặt tên hiển thị cho các cột
                if (dgvNhanVien.Columns.Contains("MaNV"))
                {
                    dgvNhanVien.Columns["MaNV"].HeaderText = "Mã NV";
                    dgvNhanVien.Columns["MaNV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvNhanVien.Columns.Contains("TenNV"))
                    dgvNhanVien.Columns["TenNV"].HeaderText = "Tên Nhân Viên";

                if (dgvNhanVien.Columns.Contains("SoDienThoai"))
                {
                    dgvNhanVien.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
                    dgvNhanVien.Columns["SoDienThoai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvNhanVien.Columns.Contains("ChucVu"))
                {
                    dgvNhanVien.Columns["ChucVu"].HeaderText = "Chức Vụ";
                    dgvNhanVien.Columns["ChucVu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvNhanVien.Columns.Contains("SoLuongDonHang"))
                {
                    dgvNhanVien.Columns["SoLuongDonHang"].HeaderText = "Số Đơn Hàng";
                    dgvNhanVien.Columns["SoLuongDonHang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvNhanVien.Columns["SoLuongDonHang"].DefaultCellStyle.Format = "N0";
                }
            }
        }

        /// <summary>
        /// Xóa các trường nhập liệu
        /// </summary>
        private void ClearInputFields()
        {
            txtMaSo.Clear();
            txtMaSo.ReadOnly = true; // Không cho nhập MaNV
            txtHoTen.Clear();
            txtSDT.Clear();
            cboChucVu.SelectedIndex = -1;
            txtHoTen.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            if (cboChucVu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chức vụ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChucVu.Focus();
                return;
            }

            try
            {
                // Tạo đối tượng NhanVien mới - KHÔNG cần nhập MaNV (SQL Server tự động tạo)
                var nhanVienMoi = new NhanVien
                {
                    TenNV = txtHoTen.Text.Trim(),
                    SoDienThoai = txtSDT.Text.Trim(),
                    ChucVu = cboChucVu.Text.Trim()
                };

                // Sử dụng phương thức Insert từ class NhanVien - trả về MaNV mới
                int newMaNV = NhanVien.Insert(nhanVienMoi);

                if (newMaNV > 0)
                {
                    MessageBox.Show($"Thêm nhân viên thành công!\nMã nhân viên mới: {newMaNV}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNhanVien();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtMaSo.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên để sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMaSo.Text.Trim(), out int maNV))
            {
                MessageBox.Show("Mã nhân viên không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra không sửa Admin
            NhanVien nv = NhanVien.GetById(maNV);
            if (nv != null && string.Equals(nv.Vaitro, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Không được sửa tài khoản Admin!", "Không có quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || 
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

            try
            {
                // Tạo đối tượng NhanVien để cập nhật
                var nhanVienCapNhat = new NhanVien
                {
                    MaNV = maNV,
                    TenNV = txtHoTen.Text.Trim(),
                    SoDienThoai = txtSDT.Text.Trim(),
                    ChucVu = cboChucVu.Text.Trim()
                };

                // Sử dụng phương thức Update từ class NhanVien
                bool success = NhanVien.Update(nhanVienCapNhat);

                if (success)
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNhanVien();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa.", "Cảnh cáo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvNhanVien.SelectedRows[0].Cells["MaNV"].Value == null)
            {
                MessageBox.Show("Không tìm thấy Mã Nhân Viên để xóa.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int maNV = Convert.ToInt32(dgvNhanVien.SelectedRows[0].Cells["MaNV"].Value);
            string tenNV = dgvNhanVien.SelectedRows[0].Cells["TenNV"].Value?.ToString() ?? "";

            // Kiểm tra không xóa Admin
            NhanVien nv = NhanVien.GetById(maNV);
            if (nv != null && string.Equals(nv.Vaitro, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Không được xóa tài khoản Admin!", "Không có quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên '{tenNV}' (Mã: {maNV})?\n\nHành động này không thể hoàn tác!", 
                                                  "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Sử dụng phương thức Delete từ class NhanVien
                    bool success = NhanVien.Delete(maNV);

                    if (success)
                    {
                        MessageBox.Show("Xóa nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNhanVien();
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    // SQL Server Foreign Key Constraint Error Number: 547
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Không thể xóa nhân viên này vì đã có đơn hàng liên quan!", 
                            "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaSo.Text = row.Cells["MaNV"].Value?.ToString() ?? "";
                txtHoTen.Text = row.Cells["TenNV"].Value?.ToString() ?? "";
                txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString() ?? "";
                cboChucVu.Text = row.Cells["ChucVu"].Value?.ToString() ?? "";
            }
        }

        private void C_Click(object sender, EventArgs e)
        {
            string keyword = txtHoTen.Text.Trim() + " " + txtMaSo.Text.Trim() + " " + txtSDT.Text.Trim() + " " + cboChucVu.Text.Trim();
            keyword = keyword.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadNhanVien();
                return;
            }

            try
            {
                // Sử dụng phương thức Search từ class NhanVien
                List<NhanVien> ketQuaTimKiem = NhanVien.Search(keyword);

                if (ketQuaTimKiem.Count > 0)
                {
                    BindingList<NhanVien> bindingList = new BindingList<NhanVien>(ketQuaTimKiem);
                    dgvNhanVien.DataSource = bindingList;
                    SetupDataGridView();
                    MessageBox.Show($"Tìm thấy {ketQuaTimKiem.Count} kết quả!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào phù hợp!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNhanVien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadNhanVien();
            ClearInputFields();
        }
    }
}
