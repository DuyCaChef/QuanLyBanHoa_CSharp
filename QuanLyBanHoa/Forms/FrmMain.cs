using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBanHoa.Models;
using QuanLyBanHoa.UI;

namespace QuanLyBanHoa.Forms
{
    public partial class FrmMain : Form
    {
        private Form currentChildForm;

        public FrmMain()
        {
            InitializeComponent();

            // Style ToolStrip for consistency and Unicode
            toolStripNav.RenderMode = ToolStripRenderMode.Professional;
            toolStripNav.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripNav.Renderer = new FlatToolStripRenderer();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            // Mở form Hoa mặc định
            OpenChildForm(new frmHoa());
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Update title từ Session
            if (Session.IsLoggedIn)
            {
                Text = $"Quản Lý Bán Hoa - {Session.TaiKhoan} ({Session.Vaitro})";
            }
            lblTitle.Text = "Quản Lý Bán Hoa"; // header title

            // Phân quyền hiển thị menu
            try
            {
                //Ẩn tất cả trước
                tsHoa.Visible = false;
                tsKhachHang.Visible = false;
                tsDonHang.Visible = false;
                tsNhanVien.Visible = false;
                tsThongKe.Visible = false;

                if (string.Equals(Session.Vaitro, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    // Admin thấy tất cả
                    tsHoa.Visible = true;
                    tsKhachHang.Visible = true;
                    tsDonHang.Visible = true;
                    tsNhanVien.Visible = true;
                    tsThongKe.Visible = true;
                }
                else
                {
                    // Mặc định cho Nhân viên
                    // Hỗ trợ hai giá trị: "NhanVien" hoặc "Nhân viên"
                    if (string.Equals(Session.Vaitro, "NhanVien", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(Session.Vaitro, "Nhân viên", StringComparison.OrdinalIgnoreCase) ||
                        string.IsNullOrEmpty(Session.Vaitro))
                    {
                        tsHoa.Visible = true;
                        tsKhachHang.Visible = true;
                        tsDonHang.Visible = true;
                        tsNhanVien.Visible = false;
                        tsThongKe.Visible = false;
                    }
                }
            }
            catch { }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContent.Controls.Clear();
            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // Điều hướng
        private void mnuHoa_Click(object sender, EventArgs e) => OpenChildForm(new frmHoa());
        private void mnuDonHang_Click(object sender, EventArgs e) => OpenChildForm(new FormDonHang());
        private void mnuKhachHang_Click(object sender, EventArgs e) => OpenChildForm(new frmQuanLiKhachHang());
        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            // Chặn nếu không phải Admin
            if (!string.Equals(Session.Vaitro, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Không có quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenChildForm(new FrmQuanLiNhanVien());
        }
        private void mnuThongKe_Click(object sender, EventArgs e)
        {
            if (!string.Equals(Session.Vaitro, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Không có quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenChildForm(new FormThongKeBaoCao());
        }

        // Nếu có menu KhuyenMai trên designer, chặn tương tự
        private void mnuKhuyenMai_Click(object sender, EventArgs e)
        {
            if (!string.Equals(Session.Vaitro, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Không có quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu có form khuyen mai
            try
            {
                var f = new Form();
                f.Text = "Khuyến mãi";
                f.Show();
            }
            catch { }
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
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
                    Session.Clear();
                    this.Hide();
                    FrmDangNhap frmDangNhap = new FrmDangNhap();
                    frmDangNhap.ShowDialog();
                    this.Close();
                }
                catch (Exception ex)
                {
                    this.Show();
                    MessageBox.Show($"Lỗi khi đăng xuất:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát ứng dụng không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
