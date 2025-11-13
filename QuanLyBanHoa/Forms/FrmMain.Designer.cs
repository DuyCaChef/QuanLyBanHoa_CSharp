using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBanHoa.Forms
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            headerPanel = new Panel();
            lblTitle = new Label();
            toolStripNav = new ToolStrip();
            tsHoa = new ToolStripButton();
            tsDonHang = new ToolStripButton();
            tsKhachHang = new ToolStripButton();
            tsNhanVien = new ToolStripButton();
            tsThongKe = new ToolStripButton();
            tsHeThong = new ToolStripDropDownButton();
            tsDangXuat = new ToolStripMenuItem();
            tsThoat = new ToolStripMenuItem();
            panelContent = new Panel();
            headerPanel.SuspendLayout();
            toolStripNav.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(52, 152, 219);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(24, 12, 24, 12);
            headerPanel.Size = new Size(1200, 60);
            headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Left;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(24, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(234, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản Lý Bán Hoa";
            // 
            // toolStripNav
            // 
            toolStripNav.AutoSize = false;
            toolStripNav.BackColor = Color.FromArgb(41, 128, 185);
            toolStripNav.GripStyle = ToolStripGripStyle.Hidden;
            toolStripNav.ImageScalingSize = new Size(20, 20);
            toolStripNav.Items.AddRange(new ToolStripItem[] { tsHoa, tsDonHang, tsKhachHang, tsNhanVien, tsThongKe, tsHeThong });
            toolStripNav.Location = new Point(0, 60);
            toolStripNav.Name = "toolStripNav";
            toolStripNav.Padding = new Padding(10, 6, 10, 4);
            toolStripNav.Size = new Size(1200, 46);
            toolStripNav.TabIndex = 1;
            toolStripNav.Text = "toolStripNav";
            // 
            // tsHoa
            // 
            tsHoa.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsHoa.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            tsHoa.ForeColor = Color.White;
            tsHoa.Margin = new Padding(2, 0, 2, 0);
            tsHoa.Name = "tsHoa";
            tsHoa.Padding = new Padding(8, 0, 8, 0);
            tsHoa.Size = new Size(67, 36);
            tsHoa.Text = "Hoa";
            tsHoa.Click += mnuHoa_Click;
            // 
            // tsDonHang
            // 
            tsDonHang.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsDonHang.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            tsDonHang.ForeColor = Color.White;
            tsDonHang.Margin = new Padding(2, 0, 2, 0);
            tsDonHang.Name = "tsDonHang";
            tsDonHang.Padding = new Padding(8, 0, 8, 0);
            tsDonHang.Size = new Size(118, 36);
            tsDonHang.Text = "Đơn Hàng";
            tsDonHang.Click += mnuDonHang_Click;
            // 
            // tsKhachHang
            // 
            tsKhachHang.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsKhachHang.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            tsKhachHang.ForeColor = Color.White;
            tsKhachHang.Margin = new Padding(2, 0, 2, 0);
            tsKhachHang.Name = "tsKhachHang";
            tsKhachHang.Padding = new Padding(8, 0, 8, 0);
            tsKhachHang.Size = new Size(136, 36);
            tsKhachHang.Text = "Khách Hàng";
            tsKhachHang.Click += mnuKhachHang_Click;
            // 
            // tsNhanVien
            // 
            tsNhanVien.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsNhanVien.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            tsNhanVien.ForeColor = Color.White;
            tsNhanVien.Margin = new Padding(2, 0, 2, 0);
            tsNhanVien.Name = "tsNhanVien";
            tsNhanVien.Padding = new Padding(8, 0, 8, 0);
            tsNhanVien.Size = new Size(121, 36);
            tsNhanVien.Text = "Nhân Viên";
            tsNhanVien.Click += mnuNhanVien_Click;
            // 
            // tsThongKe
            // 
            tsThongKe.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsThongKe.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            tsThongKe.ForeColor = Color.White;
            tsThongKe.Margin = new Padding(2, 0, 2, 0);
            tsThongKe.Name = "tsThongKe";
            tsThongKe.Padding = new Padding(8, 0, 8, 0);
            tsThongKe.Size = new Size(114, 36);
            tsThongKe.Text = "Thống Kê";
            tsThongKe.Click += mnuThongKe_Click;
            // 
            // tsHeThong
            // 
            tsHeThong.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsHeThong.DropDownItems.AddRange(new ToolStripItem[] { tsDangXuat, tsThoat });
            tsHeThong.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            tsHeThong.ForeColor = Color.White;
            tsHeThong.Margin = new Padding(2, 0, 2, 0);
            tsHeThong.Name = "tsHeThong";
            tsHeThong.Padding = new Padding(8, 0, 8, 0);
            tsHeThong.Size = new Size(126, 36);
            tsHeThong.Text = "Hệ Thống";
            // 
            // tsDangXuat
            // 
            tsDangXuat.Font = new Font("Segoe UI", 10F);
            tsDangXuat.Name = "tsDangXuat";
            tsDangXuat.Size = new Size(177, 28);
            tsDangXuat.Text = "Đăng Xuất";
            tsDangXuat.Click += mnuDangXuat_Click;
            // 
            // tsThoat
            // 
            tsThoat.Font = new Font("Segoe UI", 10F);
            tsThoat.Name = "tsThoat";
            tsThoat.Size = new Size(177, 28);
            tsThoat.Text = "Thoát";
            tsThoat.Click += mnuThoat_Click;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 106);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1200, 574);
            panelContent.TabIndex = 2;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1200, 680);
            Controls.Add(panelContent);
            Controls.Add(toolStripNav);
            Controls.Add(headerPanel);
            Font = new Font("Segoe UI", 10F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Bán Hoa";
            WindowState = FormWindowState.Maximized;
            Load += FrmMain_Load;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            toolStripNav.ResumeLayout(false);
            toolStripNav.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel headerPanel;
        private Label lblTitle;
        private ToolStrip toolStripNav;
        private ToolStripButton tsHoa;
        private ToolStripButton tsDonHang;
        private ToolStripButton tsKhachHang;
        private ToolStripButton tsNhanVien;
        private ToolStripButton tsThongKe;
        private ToolStripDropDownButton tsHeThong;
        private ToolStripMenuItem tsDangXuat;
        private ToolStripMenuItem tsThoat;
        private Panel panelContent;
    }
}
