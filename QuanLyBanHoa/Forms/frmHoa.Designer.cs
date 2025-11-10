namespace QuanLyBanHoa.Forms
{
    partial class frmHoa
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoa));
            groupBox1 = new GroupBox();
            dgDSHoa = new DataGridView();
            btnTim = new Button();
            txtTim = new TextBox();
            label8 = new Label();
            groupBox2 = new GroupBox();
            txtPhanLoai = new TextBox();
            lbPhanLoai = new Label();
            txtGhichu = new TextBox();
            lbGhichu = new Label();
            txtTenHoa = new TextBox();
            txtGia = new TextBox();
            cboSoLuong = new ComboBox();
            txtMaHoa = new TextBox();
            lbSoLuong = new Label();
            lbGia = new Label();
            lbTenHoa = new Label();
            lbMaHoa = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            btnThoat = new Button();
            menuStrip1 = new MenuStrip();
            trangChủToolStripMenuItem = new ToolStripMenuItem();
            tsmQuanLy = new ToolStripMenuItem();
            kháchHàngToolStripMenuItem = new ToolStripMenuItem();
            hoaToolStripMenuItem = new ToolStripMenuItem();
            thốngKêBáoCáoToolStripMenuItem = new ToolStripMenuItem();
            hoaToolStripMenuItem1 = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            headerPanel = new Panel();
            lblHeaderTitle = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgDSHoa).BeginInit();
            groupBox2.SuspendLayout();
            menuStrip1.SuspendLayout();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgDSHoa);
            groupBox1.Controls.Add(btnTim);
            groupBox1.Controls.Add(txtTim);
            groupBox1.Controls.Add(label8);
            groupBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(597, 125);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(953, 553);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh Sách Hoa";
            // 
            // dgDSHoa
            // 
            dgDSHoa.AllowUserToAddRows = false;
            dgDSHoa.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = Color.LightGray;
            dgDSHoa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgDSHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgDSHoa.BackgroundColor = Color.White;
            dgDSHoa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgDSHoa.DefaultCellStyle = dataGridViewCellStyle2;
            dgDSHoa.Location = new Point(23, 84);
            dgDSHoa.Name = "dgDSHoa";
            dgDSHoa.ReadOnly = true;
            dgDSHoa.RowHeadersWidth = 51;
            dgDSHoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgDSHoa.Size = new Size(907, 453);
            dgDSHoa.TabIndex = 11;
            dgDSHoa.CellContentClick += dgDSHoa_CellContentClick;
            dgDSHoa.SelectionChanged += dgDSHoa_SelectionChanged;
            // 
            // btnTim
            // 
            btnTim.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTim.Location = new Point(753, 44);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(177, 31);
            btnTim.TabIndex = 8;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // txtTim
            // 
            txtTim.Font = new Font("Times New Roman", 13.8F);
            txtTim.Location = new Point(168, 41);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(541, 34);
            txtTim.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(23, 44);
            label8.Name = "label8";
            label8.Size = new Size(120, 31);
            label8.TabIndex = 9;
            label8.Text = "Tìm kiếm:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtPhanLoai);
            groupBox2.Controls.Add(lbPhanLoai);
            groupBox2.Controls.Add(txtGhichu);
            groupBox2.Controls.Add(lbGhichu);
            groupBox2.Controls.Add(txtTenHoa);
            groupBox2.Controls.Add(txtGia);
            groupBox2.Controls.Add(cboSoLuong);
            groupBox2.Controls.Add(txtMaHoa);
            groupBox2.Controls.Add(lbSoLuong);
            groupBox2.Controls.Add(lbGia);
            groupBox2.Controls.Add(lbTenHoa);
            groupBox2.Controls.Add(lbMaHoa);
            groupBox2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(24, 125);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(539, 553);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông Tin Hoa";
            // 
            // txtPhanLoai
            // 
            txtPhanLoai.Font = new Font("Times New Roman", 13.8F);
            txtPhanLoai.Location = new Point(146, 218);
            txtPhanLoai.Name = "txtPhanLoai";
            txtPhanLoai.Size = new Size(226, 34);
            txtPhanLoai.TabIndex = 19;
            // 
            // lbPhanLoai
            // 
            lbPhanLoai.AutoSize = true;
            lbPhanLoai.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbPhanLoai.Location = new Point(34, 218);
            lbPhanLoai.Name = "lbPhanLoai";
            lbPhanLoai.Size = new Size(105, 28);
            lbPhanLoai.TabIndex = 18;
            lbPhanLoai.Text = "Phân loại:";
            // 
            // txtGhichu
            // 
            txtGhichu.Font = new Font("Times New Roman", 13.8F);
            txtGhichu.Location = new Point(34, 287);
            txtGhichu.Multiline = true;
            txtGhichu.Name = "txtGhichu";
            txtGhichu.Size = new Size(477, 250);
            txtGhichu.TabIndex = 17;
            // 
            // lbGhichu
            // 
            lbGhichu.AutoSize = true;
            lbGhichu.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbGhichu.Location = new Point(34, 259);
            lbGhichu.Name = "lbGhichu";
            lbGhichu.Size = new Size(89, 28);
            lbGhichu.TabIndex = 16;
            lbGhichu.Text = "Ghi chú:";
            // 
            // txtTenHoa
            // 
            txtTenHoa.Font = new Font("Times New Roman", 13.8F);
            txtTenHoa.Location = new Point(146, 90);
            txtTenHoa.Name = "txtTenHoa";
            txtTenHoa.Size = new Size(365, 34);
            txtTenHoa.TabIndex = 15;
            // 
            // txtGia
            // 
            txtGia.Font = new Font("Times New Roman", 13.8F);
            txtGia.Location = new Point(146, 130);
            txtGia.Name = "txtGia";
            txtGia.Size = new Size(365, 34);
            txtGia.TabIndex = 14;
            // 
            // cboSoLuong
            // 
            cboSoLuong.DropDownHeight = 250;
            cboSoLuong.Font = new Font("Times New Roman", 13.8F);
            cboSoLuong.FormattingEnabled = true;
            cboSoLuong.IntegralHeight = false;
            cboSoLuong.Location = new Point(146, 174);
            cboSoLuong.Name = "cboSoLuong";
            cboSoLuong.Size = new Size(136, 34);
            cboSoLuong.TabIndex = 8;
            cboSoLuong.SelectedIndexChanged += cboSoLuong_SelectedIndexChanged;
            // 
            // txtMaHoa
            // 
            txtMaHoa.Font = new Font("Times New Roman", 13.8F);
            txtMaHoa.Location = new Point(146, 50);
            txtMaHoa.Name = "txtMaHoa";
            txtMaHoa.ReadOnly = true;
            txtMaHoa.Size = new Size(365, 34);
            txtMaHoa.TabIndex = 11;
            // 
            // lbSoLuong
            // 
            lbSoLuong.AutoSize = true;
            lbSoLuong.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbSoLuong.Location = new Point(34, 177);
            lbSoLuong.Name = "lbSoLuong";
            lbSoLuong.Size = new Size(102, 28);
            lbSoLuong.TabIndex = 6;
            lbSoLuong.Text = "Số lượng:";
            // 
            // lbGia
            // 
            lbGia.AutoSize = true;
            lbGia.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbGia.Location = new Point(34, 136);
            lbGia.Name = "lbGia";
            lbGia.Size = new Size(89, 28);
            lbGia.TabIndex = 5;
            lbGia.Text = "Giá bán:";
            // 
            // lbTenHoa
            // 
            lbTenHoa.AutoSize = true;
            lbTenHoa.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbTenHoa.Location = new Point(34, 95);
            lbTenHoa.Name = "lbTenHoa";
            lbTenHoa.Size = new Size(91, 28);
            lbTenHoa.TabIndex = 4;
            lbTenHoa.Text = "Tên hoa:";
            // 
            // lbMaHoa
            // 
            lbMaHoa.AutoSize = true;
            lbMaHoa.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbMaHoa.Location = new Point(34, 54);
            lbMaHoa.Name = "lbMaHoa";
            lbMaHoa.Size = new Size(88, 28);
            lbMaHoa.TabIndex = 3;
            lbMaHoa.Text = "Mã hoa:";
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(46, 204, 113);
            btnThem.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(657, 703);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(127, 46);
            btnThem.TabIndex = 3;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(52, 152, 219);
            btnSua.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(838, 703);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(127, 46);
            btnSua.TabIndex = 4;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(1019, 703);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(127, 46);
            btnXoa.TabIndex = 5;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.Gold;
            btnLuu.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(1200, 703);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(127, 46);
            btnLuu.TabIndex = 6;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = SystemColors.ActiveCaptionText;
            btnThoat.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnThoat.ForeColor = SystemColors.ButtonHighlight;
            btnThoat.Location = new Point(1385, 703);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(127, 46);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.SkyBlue;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { trangChủToolStripMenuItem, tsmQuanLy, đăngXuấtToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1582, 28);
            menuStrip1.TabIndex = 8;
            // 
            // trangChủToolStripMenuItem
            // 
            trangChủToolStripMenuItem.Name = "trangChủToolStripMenuItem";
            trangChủToolStripMenuItem.Size = new Size(89, 24);
            trangChủToolStripMenuItem.Text = "Trang Chủ";
            // 
            // tsmQuanLy
            // 
            tsmQuanLy.DropDownItems.AddRange(new ToolStripItem[] { kháchHàngToolStripMenuItem, hoaToolStripMenuItem, thốngKêBáoCáoToolStripMenuItem, hoaToolStripMenuItem1 });
            tsmQuanLy.Name = "tsmQuanLy";
            tsmQuanLy.Size = new Size(75, 24);
            tsmQuanLy.Text = "Quản Lý";
            tsmQuanLy.Click += toolStripMenuItem1_Click;
            // 
            // kháchHàngToolStripMenuItem
            // 
            kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            kháchHàngToolStripMenuItem.Size = new Size(218, 26);
            kháchHàngToolStripMenuItem.Text = "Khách Hàng";
            // 
            // hoaToolStripMenuItem
            // 
            hoaToolStripMenuItem.Name = "hoaToolStripMenuItem";
            hoaToolStripMenuItem.Size = new Size(218, 26);
            hoaToolStripMenuItem.Text = "Đơn Hàng";
            hoaToolStripMenuItem.Click += hoaToolStripMenuItem_Click;
            // 
            // thốngKêBáoCáoToolStripMenuItem
            // 
            thốngKêBáoCáoToolStripMenuItem.Name = "thốngKêBáoCáoToolStripMenuItem";
            thốngKêBáoCáoToolStripMenuItem.Size = new Size(218, 26);
            thốngKêBáoCáoToolStripMenuItem.Text = "Thống Kê, Báo Cáo";
            // 
            // hoaToolStripMenuItem1
            // 
            hoaToolStripMenuItem1.Name = "hoaToolStripMenuItem1";
            hoaToolStripMenuItem1.Size = new Size(218, 26);
            hoaToolStripMenuItem1.Text = "Hoa";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(93, 24);
            đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.MediumSlateBlue;
            headerPanel.Controls.Add(lblHeaderTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 28);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(24, 12, 24, 12);
            headerPanel.Size = new Size(1582, 60);
            headerPanel.TabIndex = 101;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Dock = DockStyle.Left;
            lblHeaderTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(24, 12);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(151, 32);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Quản lý hoa";
            lblHeaderTitle.Click += lblHeaderTitle_Click;
            // 
            // frmHoa
            // 
            AutoScaleDimensions = new SizeF(13F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1582, 853);
            Controls.Add(headerPanel);
            Controls.Add(btnThoat);
            Controls.Add(btnLuu);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5, 4, 5, 4);
            Name = "frmHoa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Hoa";
            Load += frmQuanLiHoa_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgDSHoa).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label lbGia;
        private Label lbTenHoa;
        private Label lbMaHoa;
        private Button btnTim;
        private TextBox txtTim;
        private Label label8;
        private TextBox txtLoaiHoa;
        private TextBox txtMaHoa;
        private Label lbLoaiHoa;
        private Label lbSoLuong;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLuu;
        private Button btnThoat;
        private DataGridView dgDSHoa;
        private ComboBox cboSoLuong;
        private TextBox txtTenHoa;
        private TextBox txtGia;
        private TextBox txtGhichu;
        private Label lbGhichu;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem trangChủToolStripMenuItem;
        private ToolStripMenuItem tsmQuanLy;
        private ToolStripMenuItem kháchHàngToolStripMenuItem;
        private ToolStripMenuItem hoaToolStripMenuItem;
        private ToolStripMenuItem thốngKêBáoCáoToolStripMenuItem;
        private ToolStripMenuItem hoaToolStripMenuItem1;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private TextBox txtPhanLoai;
        private Label lbPhanLoai;
        private Panel headerPanel;
        private Label lblHeaderTitle;
    }
}
