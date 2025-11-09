using System;
using System.Drawing;
using System.Windows.Forms;
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

            // Mở form Hoa mặc định
            OpenChildForm(new FrmHoa());
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (Session.IsLoggedIn)
            {
                Text = $"Quản Lý Bán Hoa - {Session.UserName} ({Session.Role})";
            }
            lblTitle.Text = "Quản Lý Bán Hoa"; // header title
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
        private void mnuHoa_Click(object sender, EventArgs e) => OpenChildForm(new FrmHoa());
        private void mnuDonHang_Click(object sender, EventArgs e) => OpenChildForm(new FormDonHang());
        private void mnuKhachHang_Click(object sender, EventArgs e) => OpenChildForm(new frmQuanLiKhachHang());
        private void mnuNhanVien_Click(object sender, EventArgs e) => OpenChildForm(new FrmQuanLiNhanVien());
        private void mnuThongKe_Click(object sender, EventArgs e) => OpenChildForm(new FormThongKeBaoCao());

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
                    Session.Logout();
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
