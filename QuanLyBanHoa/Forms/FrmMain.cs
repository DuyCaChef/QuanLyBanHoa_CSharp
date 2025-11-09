using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBanHoa.Forms
{
    public partial class FrmMain : Form
    {
        private Form currentChildForm;

        public FrmMain()
        {
            InitializeComponent();

            // Force ToolStrip rendering and a Unicode-capable font to avoid '?' on Vietnamese characters
            try
            {
                ToolStripManager.RenderMode = ToolStripManagerRenderMode.Professional;
                menuStrip1.RenderMode = ToolStripRenderMode.Professional;
                // Prefer Segoe UI; fallback to Arial Unicode MS if necessary
                Font menuFont;
                try
                {
                    menuFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                }
                catch
                {
                    menuFont = new Font("Arial Unicode MS", 11F, FontStyle.Regular, GraphicsUnit.Point);
                }
                menuStrip1.Font = menuFont;
                menuStrip1.Invalidate();
            }
            catch
            {
                // ignore if fails on some environments
            }

            // Load form Hoa m?c ??nh khi kh?i t?o
            OpenChildForm(new FrmHoa());
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Hi?n th? thông tin ng??i dùng n?u c?n
            if (Session.IsLoggedIn)
            {
                Text = $"Qu?n Lý Bán Hoa - {Session.UserName} ({Session.Role})";
            }
        }

        /// <summary>
        /// M? form con trong panel chính
        /// </summary>
        private void OpenChildForm(Form childForm)
        {
            // ?óng form con hi?n t?i n?u có
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // Menu item click handlers
        private void mnuHoa_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmHoa());
        }

        private void mnuDonHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDonHang());
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLiKhachHang());
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmQuanLiNhanVien());
        }

        private void mnuThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormThongKeBaoCao());
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "B?n có ch?c ch?n mu?n ??ng xu?t không?",
                "Xác nh?n",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Clear session
                    Session.Logout();

                    // ?óng form hi?n t?i
                    this.Hide();

                    // M? l?i form ??ng nh?p
                    FrmDangNhap frmDangNhap = new FrmDangNhap();
                    frmDangNhap.ShowDialog();

                    // Sau khi form ??ng nh?p ?óng, thoát h?n ?ng d?ng
                    this.Close();
                }
                catch (Exception ex)
                {
                    this.Show();
                    MessageBox.Show($"L?i khi ??ng xu?t:\n{ex.Message}", 
                        "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "B?n có ch?c ch?n mu?n thoát ?ng d?ng không?",
                "Xác nh?n",
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
