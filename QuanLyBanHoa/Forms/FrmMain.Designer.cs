using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBanHoa.Forms
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new MenuStrip();
            this.mnuHoa = new ToolStripMenuItem();
            this.mnuDonHang = new ToolStripMenuItem();
            this.mnuKhachHang = new ToolStripMenuItem();
            this.mnuNhanVien = new ToolStripMenuItem();
            this.mnuThongKe = new ToolStripMenuItem();
            this.mnuHeThong = new ToolStripMenuItem();
            this.mnuDangXuat = new ToolStripMenuItem();
            this.mnuThoat = new ToolStripMenuItem();
            this.panelContent = new Panel();
            this.statusStrip1 = new StatusStrip();
            this.toolStripStatusLabel1 = new ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new Size(24, 24);
            this.menuStrip1.Items.AddRange(new ToolStripItem[] {
            this.mnuHoa,
            this.mnuDonHang,
            this.mnuKhachHang,
            this.mnuNhanVien,
            this.mnuThongKe,
            this.mnuHeThong});
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(1200, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuHoa
            // 
            this.mnuHoa.Font = new Font("Segoe UI", 11F);
            this.mnuHoa.Name = "mnuHoa";
            this.mnuHoa.Size = new Size(59, 29);
            this.mnuHoa.Text = "Hoa";
            this.mnuHoa.Click += new System.EventHandler(this.mnuHoa_Click);
            // 
            // mnuDonHang
            // 
            this.mnuDonHang.Font = new Font("Segoe UI", 11F);
            this.mnuDonHang.Name = "mnuDonHang";
            this.mnuDonHang.Size = new Size(115, 29);
            this.mnuDonHang.Text = "??n Hàng";
            this.mnuDonHang.Click += new System.EventHandler(this.mnuDonHang_Click);
            // 
            // mnuKhachHang
            // 
            this.mnuKhachHang.Font = new Font("Segoe UI", 11F);
            this.mnuKhachHang.Name = "mnuKhachHang";
            this.mnuKhachHang.Size = new Size(133, 29);
            this.mnuKhachHang.Text = "Khách Hàng";
            this.mnuKhachHang.Click += new System.EventHandler(this.mnuKhachHang_Click);
            // 
            // mnuNhanVien
            // 
            this.mnuNhanVien.Font = new Font("Segoe UI", 11F);
            this.mnuNhanVien.Name = "mnuNhanVien";
            this.mnuNhanVien.Size = new Size(117, 29);
            this.mnuNhanVien.Text = "Nhân Viên";
            this.mnuNhanVien.Click += new System.EventHandler(this.mnuNhanVien_Click);
            // 
            // mnuThongKe
            // 
            this.mnuThongKe.Font = new Font("Segoe UI", 11F);
            this.mnuThongKe.Name = "mnuThongKe";
            this.mnuThongKe.Size = new Size(108, 29);
            this.mnuThongKe.Text = "Th?ng Kê";
            this.mnuThongKe.Click += new System.EventHandler(this.mnuThongKe_Click);
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] {
            this.mnuDangXuat,
            this.mnuThoat});
            this.mnuHeThong.Font = new Font("Segoe UI", 11F);
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new Size(114, 29);
            this.mnuHeThong.Text = "H? Th?ng";
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new Size(196, 30);
            this.mnuDangXuat.Text = "??ng Xu?t";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new Size(196, 30);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // panelContent
            // 
            this.panelContent.Dock = DockStyle.Fill;
            this.panelContent.Location = new Point(0, 33);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new Size(1200, 617);
            this.panelContent.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new Size(24, 24);
            this.statusStrip1.Items.AddRange(new ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new Point(0, 650);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new Size(1200, 30);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new Size(223, 25);
            this.toolStripStatusLabel1.Text = "H? Th?ng Qu?n Lý Bán Hoa";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new SizeF(10F, 25F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 680);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Qu?n Lý Bán Hoa";
            this.WindowState = FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuHoa;
        private ToolStripMenuItem mnuDonHang;
        private ToolStripMenuItem mnuKhachHang;
        private ToolStripMenuItem mnuNhanVien;
        private ToolStripMenuItem mnuThongKe;
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripMenuItem mnuThoat;
        private Panel panelContent;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}
