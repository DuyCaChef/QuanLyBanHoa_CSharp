namespace Doan_QLKhachhang
{
    partial class frmQuanLiKhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLiKhachHang));
            btnThem = new Button();
            btnThoat = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnLuu = new Button();
            groupBox1 = new GroupBox();
            txtSoluong = new TextBox();
            lbSoluong = new Label();
            lbEmail = new Label();
            txtEmail = new TextBox();
            txtDiaChi = new TextBox();
            txtSĐT = new TextBox();
            txtHoTen = new TextBox();
            txtMaKH = new TextBox();
            lbDiaChi = new Label();
            lbSĐT = new Label();
            lbHoTen = new Label();
            lbMaKH = new Label();
            groupBox2 = new GroupBox();
            dgDSKhachHang = new DataGridView();
            lbTen = new Label();
            menuStrip1 = new MenuStrip();
            trangChủToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            kháchHàngToolStripMenuItem = new ToolStripMenuItem();
            đơnHàngToolStripMenuItem = new ToolStripMenuItem();
            thốngKêBáoCáoToolStripMenuItem = new ToolStripMenuItem();
            hoaToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgDSKhachHang).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.ButtonFace;
            btnThem.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = Color.Orange;
            btnThem.Location = new Point(329, 739);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(160, 47);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = SystemColors.ActiveCaptionText;
            btnThoat.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThoat.ForeColor = SystemColors.Control;
            btnThoat.Location = new Point(1097, 739);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(160, 47);
            btnThoat.TabIndex = 1;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = SystemColors.ButtonFace;
            btnXoa.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(713, 739);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(160, 47);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            btnSua.BackColor = SystemColors.ButtonFace;
            btnSua.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.ForeColor = Color.Magenta;
            btnSua.Location = new Point(521, 739);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(160, 47);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = SystemColors.ButtonFace;
            btnLuu.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLuu.ForeColor = Color.Blue;
            btnLuu.Location = new Point(905, 739);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(160, 47);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtSoluong);
            groupBox1.Controls.Add(lbSoluong);
            groupBox1.Controls.Add(lbEmail);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtDiaChi);
            groupBox1.Controls.Add(txtSĐT);
            groupBox1.Controls.Add(txtHoTen);
            groupBox1.Controls.Add(txtMaKH);
            groupBox1.Controls.Add(lbDiaChi);
            groupBox1.Controls.Add(lbSĐT);
            groupBox1.Controls.Add(lbHoTen);
            groupBox1.Controls.Add(lbMaKH);
            groupBox1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(254, 131);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1074, 315);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin Khách Hàng";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // txtSoluong
            // 
            txtSoluong.Location = new Point(267, 259);
            txtSoluong.Name = "txtSoluong";
            txtSoluong.Size = new Size(145, 34);
            txtSoluong.TabIndex = 9;
            // 
            // lbSoluong
            // 
            lbSoluong.AutoSize = true;
            lbSoluong.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbSoluong.Location = new Point(40, 267);
            lbSoluong.Name = "lbSoluong";
            lbSoluong.Size = new Size(195, 26);
            lbSoluong.TabIndex = 8;
            lbSoluong.Text = "Số lượng đơn hàng:";
            lbSoluong.Click += lbSoluong_Click;
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbEmail.Location = new Point(40, 222);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(71, 26);
            lbEmail.TabIndex = 7;
            lbEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(267, 214);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(354, 34);
            txtEmail.TabIndex = 6;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(267, 168);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(455, 34);
            txtDiaChi.TabIndex = 6;
            // 
            // txtSĐT
            // 
            txtSĐT.Location = new Point(267, 119);
            txtSĐT.Name = "txtSĐT";
            txtSĐT.Size = new Size(231, 34);
            txtSĐT.TabIndex = 6;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(267, 79);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(354, 34);
            txtHoTen.TabIndex = 6;
            // 
            // txtMaKH
            // 
            txtMaKH.Location = new Point(267, 33);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(145, 34);
            txtMaKH.TabIndex = 6;
            // 
            // lbDiaChi
            // 
            lbDiaChi.AutoSize = true;
            lbDiaChi.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbDiaChi.Location = new Point(40, 176);
            lbDiaChi.Name = "lbDiaChi";
            lbDiaChi.Size = new Size(85, 26);
            lbDiaChi.TabIndex = 3;
            lbDiaChi.Text = "Địa chỉ:";
            // 
            // lbSĐT
            // 
            lbSĐT.AutoSize = true;
            lbSĐT.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbSĐT.Location = new Point(40, 127);
            lbSĐT.Name = "lbSĐT";
            lbSĐT.Size = new Size(141, 26);
            lbSĐT.TabIndex = 2;
            lbSĐT.Text = "Số điện thoại:";
            // 
            // lbHoTen
            // 
            lbHoTen.AutoSize = true;
            lbHoTen.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbHoTen.Location = new Point(40, 82);
            lbHoTen.Name = "lbHoTen";
            lbHoTen.Size = new Size(107, 26);
            lbHoTen.TabIndex = 1;
            lbHoTen.Text = "Họ và tên:";
            // 
            // lbMaKH
            // 
            lbMaKH.AutoSize = true;
            lbMaKH.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbMaKH.Location = new Point(40, 41);
            lbMaKH.Name = "lbMaKH";
            lbMaKH.Size = new Size(160, 26);
            lbMaKH.TabIndex = 0;
            lbMaKH.Text = "Mã khách hàng:";
            lbMaKH.Click += label1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgDSKhachHang);
            groupBox2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(254, 452);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1074, 263);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh Sách Khách Hàng";
            // 
            // dgDSKhachHang
            // 
            dgDSKhachHang.AllowUserToAddRows = false;
            dgDSKhachHang.AllowUserToDeleteRows = false;
            dgDSKhachHang.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.LightGray;
            dgDSKhachHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgDSKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgDSKhachHang.BackgroundColor = SystemColors.ButtonHighlight;
            dgDSKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgDSKhachHang.GridColor = SystemColors.HighlightText;
            dgDSKhachHang.Location = new Point(15, 33);
            dgDSKhachHang.Name = "dgDSKhachHang";
            dgDSKhachHang.ReadOnly = true;
            dgDSKhachHang.RowHeadersWidth = 51;
            dgDSKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgDSKhachHang.Size = new Size(1036, 212);
            dgDSKhachHang.TabIndex = 0;
            dgDSKhachHang.CellContentClick += dataGridView1_CellContentClick;
            // 
            // lbTen
            // 
            lbTen.AutoSize = true;
            lbTen.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTen.ForeColor = Color.Red;
            lbTen.Location = new Point(608, 71);
            lbTen.Name = "lbTen";
            lbTen.Size = new Size(422, 38);
            lbTen.TabIndex = 7;
            lbTen.Text = "QUẢN LÝ KHÁCH HÀNG";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.SkyBlue;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { trangChủToolStripMenuItem, toolStripMenuItem1, đăngXuấtToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1582, 28);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // trangChủToolStripMenuItem
            // 
            trangChủToolStripMenuItem.Name = "trangChủToolStripMenuItem";
            trangChủToolStripMenuItem.Size = new Size(89, 24);
            trangChủToolStripMenuItem.Text = "Trang Chủ";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { kháchHàngToolStripMenuItem, đơnHàngToolStripMenuItem, thốngKêBáoCáoToolStripMenuItem, hoaToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(75, 24);
            toolStripMenuItem1.Text = "Quản Lý";
            // 
            // kháchHàngToolStripMenuItem
            // 
            kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            kháchHàngToolStripMenuItem.Size = new Size(218, 26);
            kháchHàngToolStripMenuItem.Text = "Khách Hàng";
            // 
            // đơnHàngToolStripMenuItem
            // 
            đơnHàngToolStripMenuItem.Name = "đơnHàngToolStripMenuItem";
            đơnHàngToolStripMenuItem.Size = new Size(218, 26);
            đơnHàngToolStripMenuItem.Text = "Đơn Hàng";
            // 
            // thốngKêBáoCáoToolStripMenuItem
            // 
            thốngKêBáoCáoToolStripMenuItem.Name = "thốngKêBáoCáoToolStripMenuItem";
            thốngKêBáoCáoToolStripMenuItem.Size = new Size(218, 26);
            thốngKêBáoCáoToolStripMenuItem.Text = "Thống Kê, Báo Cáo";
            // 
            // hoaToolStripMenuItem
            // 
            hoaToolStripMenuItem.Name = "hoaToolStripMenuItem";
            hoaToolStripMenuItem.Size = new Size(218, 26);
            hoaToolStripMenuItem.Text = "Hoa";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(93, 24);
            đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            // 
            // frmQuanLiKhachHang
            // 
            AutoScaleDimensions = new SizeF(13F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1582, 853);
            Controls.Add(lbTen);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnLuu);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThoat);
            Controls.Add(btnThem);
            Controls.Add(menuStrip1);
            Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "frmQuanLiKhachHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Khách Hàng";
            Load += frmQuanLiKhachHang_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgDSKhachHang).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnThem;
        private Button btnThoat;
        private Button btnXoa;
        private Button btnSua;
        private Button btnLuu;
        private GroupBox groupBox1;
        private Label lbDiaChi;
        private Label lbSĐT;
        private Label lbHoTen;
        private Label lbMaKH;
        private Label label5;
        private GroupBox groupBox2;
        private DataGridView dgDSKhachHang;
        private TextBox txtEmail;
        private TextBox txtDiaChi;
        private TextBox txtSĐT;
        private TextBox txtHoTen;
        private TextBox txtMaKH;
        private Label lbEmail;
        private Label lbTen;
        private TextBox txtSoluong;
        private Label lbSoluong;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem trangChủToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem kháchHàngToolStripMenuItem;
        private ToolStripMenuItem đơnHàngToolStripMenuItem;
        private ToolStripMenuItem thốngKêBáoCáoToolStripMenuItem;
        private ToolStripMenuItem hoaToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
    }
}
