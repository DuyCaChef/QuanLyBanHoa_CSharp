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
            // Chỉ Admin mới được mở form này
            if (!string.Equals(Session.Vaitro, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Không có quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // MaNV tự tăng - không cho nhập
            txtMaSo.ReadOnly = true;
            txtMaSo.BackColor = System.Drawing.SystemColors.Control;

            LoadNhanVien();
        }

        //1) LOAD: LEFT JOIN NhanVien - Users
        private void LoadNhanVien()
        {
            try
            {
                // Sử dụng User.GetAllWithNhanVien() từ Model
                DataTable dt = User.GetAllWithNhanVien();
                dgvNhanVien.DataSource = dt;
                SetupDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Set header & alignment
        private void SetupDataGridView()
        {
            if (dgvNhanVien.Columns.Count == 0) return;

            void set(string name, string header, DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft)
            {
                if (dgvNhanVien.Columns.Contains(name))
                {
                    dgvNhanVien.Columns[name].HeaderText = header;
                    dgvNhanVien.Columns[name].DefaultCellStyle.Alignment = align;
                }
            }

            set("MaNV", "Mã NV", DataGridViewContentAlignment.MiddleCenter);
            set("TenNV", "Tên nhân viên");
            set("SoDienThoai", "Số điện thoại", DataGridViewContentAlignment.MiddleCenter);
            set("TaiKhoan", "Tài khoản");
            set("MatKhau", "Mật khẩu");
            set("VaiTro", "Vai trò", DataGridViewContentAlignment.MiddleCenter);
        }

        //6) CLEAR INPUTS
        private void ClearInputFields()
        {
            txtMaSo.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            cmbVaiTro.SelectedIndex = -1;
            txtHoTen.Focus();
        }

        //2) THÊM
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(txtHoTen.Text)) { MessageBox.Show("Vui lòng nhập tên nhân viên.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtHoTen.Focus(); return; }
            if (string.IsNullOrWhiteSpace(txtSDT.Text)) { MessageBox.Show("Vui lòng nhập số điện thoại.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtSDT.Focus(); return; }
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text)) { MessageBox.Show("Vui lòng nhập tài khoản.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtTaiKhoan.Focus(); return; }
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text)) { MessageBox.Show("Vui lòng nhập mật khẩu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtMatKhau.Focus(); return; }
            if (cmbVaiTro.SelectedIndex == -1) { MessageBox.Show("Vui lòng chọn vai trò.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning); cmbVaiTro.Focus(); return; }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        try
                        {
                            // Tạo đối tượng NhanVien
                            var nhanVien = new NhanVien
                            {
                                TenNV = txtHoTen.Text.Trim(),
                                SoDienThoai = txtSDT.Text.Trim()
                            };

                            // Insert NhanVien qua Model
                            int newMaNV = NhanVien.Insert(nhanVien, conn, tran);
                            if (newMaNV == 0)
                            {
                                tran.Rollback();
                                MessageBox.Show("Thêm nhân viên không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Tạo đối tượng User
                            var user = new User
                            {
                                TaiKhoan = txtTaiKhoan.Text.Trim(),
                                MatKhau = txtMatKhau.Text,
                                VaiTro = cmbVaiTro.SelectedItem.ToString(),
                                MaNV = newMaNV
                            };

                            // Insert Users qua Model
                            bool userInserted = User.Insert(user, conn, tran);
                            if (!userInserted)
                            {
                                tran.Rollback();
                                MessageBox.Show("Thêm user không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            tran.Commit();
                            MessageBox.Show($"Thêm nhân viên thành công!\nMã NV mới: {newMaNV}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadNhanVien();
                            ClearInputFields();
                        }
                        catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) // unique violation
                        {
                            tran.Rollback();
                            MessageBox.Show("Tài khoản đã tồn tại. Vui lòng chọn tài khoản khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //3) SỬA
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSo.Text) || !int.TryParse(txtMaSo.Text.Trim(), out int maNV))
            { MessageBox.Show("Vui lòng chọn nhân viên để sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtTaiKhoan.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text) || cmbVaiTro.SelectedIndex == -1)
            { MessageBox.Show("Vui lòng nhập đầy đủ thông tin để sửa!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var ask = MessageBox.Show("Bạn có chắc muốn cập nhật thông tin nhân viên này không?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ask != DialogResult.Yes) return;

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        try
                        {
                            // Lấy vai trò hiện tại qua Model
                            string currentRole = User.GetVaiTroByMaNV(maNV, conn, tran);
                            string newRole = cmbVaiTro.SelectedItem.ToString();

                            // Chặn đổi Admin -> NhanVien nếu là admin hiện tại
                            if (string.Equals(currentRole, "Admin", StringComparison.OrdinalIgnoreCase) &&
                                string.Equals(newRole, "NhanVien", StringComparison.OrdinalIgnoreCase))
                            {
                                tran.Rollback();
                                MessageBox.Show("Không được đổi vai trò từ Admin thành Nhân viên!", "Không có quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Update NhanVien qua Model
                            var nhanVien = new NhanVien
                            {
                                MaNV = maNV,
                                TenNV = txtHoTen.Text.Trim(),
                                SoDienThoai = txtSDT.Text.Trim()
                            };
                            NhanVien.Update(nhanVien, conn, tran);

                            // Update Users qua Model
                            var user = new User
                            {
                                TaiKhoan = txtTaiKhoan.Text.Trim(),
                                MatKhau = txtMatKhau.Text,
                                VaiTro = newRole,
                                MaNV = maNV
                            };

                            // Kiểm tra user đã tồn tại chưa
                            bool userExists = User.ExistsByMaNV(maNV, conn, tran);
                            if (userExists)
                            {
                                User.Update(user, conn, tran);
                            }
                            else
                            {
                                User.Insert(user, conn, tran);
                            }

                            tran.Commit();
                            MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadNhanVien();
                            ClearInputFields();
                        }
                        catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
                        {
                            tran.Rollback();
                            MessageBox.Show("Tài khoản đã tồn tại. Vui lòng chọn tài khoản khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            MessageBox.Show("Lỗi khi cập nhật nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //4) XÓA + RESET IDENTITY
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count == 0)
            { MessageBox.Show("Vui lòng chọn nhân viên để xóa.", "Cảnh cáo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var row = dgvNhanVien.SelectedRows[0];
            if (row.Cells["MaNV"].Value == null) { MessageBox.Show("Không tìm thấy Mã Nhân Viên để xóa.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            int maNV = Convert.ToInt32(row.Cells["MaNV"].Value);
            string tenNV = Convert.ToString(row.Cells["TenNV"].Value ?? "");
            string role = Convert.ToString(row.Cells["VaiTro"].Value ?? "");

            // Chặn xóa Admin
            if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
            { MessageBox.Show("Không được xóa tài khoản Admin!", "Không có quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên '{tenNV}' (Mã: {maNV})?\n\nHành động này không thể hoàn tác!",
                                          "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        try
                        {
                            // Xóa NhanVien + Reset Identity qua Model
                            bool success = NhanVien.DeleteAndResetIdentity(maNV, conn, tran);
                    
                            if (success)
                            {
                                tran.Commit();
                                MessageBox.Show("Xóa nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadNhanVien();
                                ClearInputFields();
                            }
                            else
                            {
                                tran.Rollback();
                                MessageBox.Show("Xóa nhân viên không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
       catch (Exception ex)
        {
       tran.Rollback();
    throw;
          }
  }
      }
}
    catch (SqlException ex)
 {
              if (ex.Number == 547)
 {
    MessageBox.Show("Không thể xóa nhân viên này vì đã có dữ liệu liên quan!", "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    //5) LOAD input khi click grid
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
   {
        if (e.RowIndex < 0) return;
            var row = dgvNhanVien.Rows[e.RowIndex];

        txtMaSo.Text = Convert.ToString(row.Cells["MaNV"].Value ?? "");
 txtHoTen.Text = Convert.ToString(row.Cells["TenNV"].Value ?? "");
            txtSDT.Text = Convert.ToString(row.Cells["SoDienThoai"].Value ?? "");
            txtTaiKhoan.Text = Convert.ToString(row.Cells["TaiKhoan"].Value ?? "");
    txtMatKhau.Text = Convert.ToString(row.Cells["MatKhau"].Value ?? "");
            string role = Convert.ToString(row.Cells["VaiTro"].Value ?? "");
        if (!string.IsNullOrEmpty(role) && cmbVaiTro.Items.Contains(role))
          cmbVaiTro.SelectedItem = role;
        else
     cmbVaiTro.SelectedIndex = -1;
      }

        // Tìm kiếm đơn giản theo nhiều trường
 private void C_Click(object sender, EventArgs e)
        {
     string keywordLike = ($"{txtHoTen.Text} {txtSDT.Text} {txtTaiKhoan.Text} {cmbVaiTro.Text}").Trim();
            int idFilter = 0;
    bool hasId = int.TryParse(txtMaSo.Text.Trim(), out idFilter);

      try
  {
       // Sử dụng User.SearchWithNhanVien() từ Model
                DataTable dt = User.SearchWithNhanVien(keywordLike, hasId ? (int?)idFilter : null);
      dgvNhanVien.DataSource = dt;
SetupDataGridView();
            MessageBox.Show($"Tìm thấy {dt.Rows.Count} kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
