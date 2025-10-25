namespace QuanLyBanHoa_CSharp.Forms
{
    partial class FrmQuanLiNhanVien
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
            label1 = new Label();
            txtHoTen = new TextBox();
            label2 = new Label();
            txtMaSo = new TextBox();
            label3 = new Label();
            txtSDT = new TextBox();
            label4 = new Label();
            comboBox1 = new ComboBox();
            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            dgvNhanVien = new DataGridView();
            colHoTen = new DataGridViewTextBoxColumn();
            colMaSo = new DataGridViewTextBoxColumn();
            colSDT = new DataGridViewTextBoxColumn();
            colChucVu = new DataGridViewTextBoxColumn();
            colSoDonHang = new DataGridViewTextBoxColumn();
            menuStrip1 = new MenuStrip();
            trangChủToolStripMenuItem = new ToolStripMenuItem();
            quảnLýKháchHàngToolStripMenuItem = new ToolStripMenuItem();
            kháchHàngToolStripMenuItem = new ToolStripMenuItem();
            đơnHàngToolStripMenuItem = new ToolStripMenuItem();
            thốngKêBáoCáoToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            label5 = new Label();
            C = new Button();
            btnHuy = new Button();
            btnLuu = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(37, 154);
            label1.Name = "label1";
            label1.Size = new Size(90, 27);
            label1.TabIndex = 0;
            label1.Text = "Họ Tên:";
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtHoTen.ForeColor = SystemColors.WindowText;
            txtHoTen.HideSelection = false;
            txtHoTen.Location = new Point(37, 184);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(390, 35);
            txtHoTen.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(37, 254);
            label2.Name = "label2";
            label2.Size = new Size(80, 27);
            label2.TabIndex = 2;
            label2.Text = "Mã Số:";
            // 
            // txtMaSo
            // 
            txtMaSo.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaSo.Location = new Point(37, 284);
            txtMaSo.Name = "txtMaSo";
            txtMaSo.Size = new Size(390, 35);
            txtMaSo.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(37, 353);
            label3.Name = "label3";
            label3.Size = new Size(155, 27);
            label3.TabIndex = 4;
            label3.Text = "Số Điện Thoại:";
            // 
            // txtSDT
            // 
            txtSDT.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSDT.Location = new Point(37, 383);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(390, 35);
            txtSDT.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(37, 456);
            label4.Name = "label4";
            label4.Size = new Size(100, 27);
            label4.TabIndex = 6;
            label4.Text = "Chức vụ:";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(37, 486);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(390, 35);
            comboBox1.TabIndex = 7;
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.ButtonFace;
            btnThem.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = Color.Orange;
            btnThem.Location = new Point(37, 557);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(163, 45);
            btnThem.TabIndex = 8;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = SystemColors.ButtonFace;
            btnXoa.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(264, 557);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(163, 45);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            btnSua.BackColor = SystemColors.ButtonFace;
            btnSua.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.ForeColor = Color.Magenta;
            btnSua.Location = new Point(37, 650);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(163, 45);
            btnSua.TabIndex = 10;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.BackgroundColor = SystemColors.ButtonHighlight;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Columns.AddRange(new DataGridViewColumn[] { colHoTen, colMaSo, colSDT, colChucVu, colSoDonHang });
            dgvNhanVien.Location = new Point(479, 154);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.RowHeadersWidth = 62;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.Size = new Size(1021, 541);
            dgvNhanVien.TabIndex = 11;
            // 
            // colHoTen
            // 
            colHoTen.HeaderText = "Họ Tên";
            colHoTen.MinimumWidth = 8;
            colHoTen.Name = "colHoTen";
            colHoTen.ReadOnly = true;
            // 
            // colMaSo
            // 
            colMaSo.HeaderText = "Mã Số";
            colMaSo.MinimumWidth = 8;
            colMaSo.Name = "colMaSo";
            colMaSo.ReadOnly = true;
            // 
            // colSDT
            // 
            colSDT.HeaderText = "Số Điện Thoại";
            colSDT.MinimumWidth = 8;
            colSDT.Name = "colSDT";
            colSDT.ReadOnly = true;
            // 
            // colChucVu
            // 
            colChucVu.HeaderText = "Chức Vụ";
            colChucVu.MinimumWidth = 8;
            colChucVu.Name = "colChucVu";
            colChucVu.ReadOnly = true;
            // 
            // colSoDonHang
            // 
            colSoDonHang.HeaderText = "Số Đơn Hàng";
            colSoDonHang.MinimumWidth = 8;
            colSoDonHang.Name = "colSoDonHang";
            colSoDonHang.ReadOnly = true;
            // 
            // menuStrip1
            // 
            menuStrip1.AllowItemReorder = true;
            menuStrip1.BackColor = Color.SkyBlue;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { trangChủToolStripMenuItem, quảnLýKháchHàngToolStripMenuItem, đăngXuấtToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1578, 33);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // trangChủToolStripMenuItem
            // 
            trangChủToolStripMenuItem.Name = "trangChủToolStripMenuItem";
            trangChủToolStripMenuItem.Size = new Size(107, 29);
            trangChủToolStripMenuItem.Text = "Trang Chủ";
            // 
            // quảnLýKháchHàngToolStripMenuItem
            // 
            quảnLýKháchHàngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kháchHàngToolStripMenuItem, đơnHàngToolStripMenuItem, thốngKêBáoCáoToolStripMenuItem });
            quảnLýKháchHàngToolStripMenuItem.Name = "quảnLýKháchHàngToolStripMenuItem";
            quảnLýKháchHàngToolStripMenuItem.Size = new Size(89, 29);
            quảnLýKháchHàngToolStripMenuItem.Text = "Quản lý";
            // 
            // kháchHàngToolStripMenuItem
            // 
            kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            kháchHàngToolStripMenuItem.Size = new Size(270, 34);
            kháchHàngToolStripMenuItem.Text = "Khách Hàng";
            // 
            // đơnHàngToolStripMenuItem
            // 
            đơnHàngToolStripMenuItem.Name = "đơnHàngToolStripMenuItem";
            đơnHàngToolStripMenuItem.Size = new Size(270, 34);
            đơnHàngToolStripMenuItem.Text = "Đơn Hàng";
            // 
            // thốngKêBáoCáoToolStripMenuItem
            // 
            thốngKêBáoCáoToolStripMenuItem.BackColor = SystemColors.Control;
            thốngKêBáoCáoToolStripMenuItem.Name = "thốngKêBáoCáoToolStripMenuItem";
            thốngKêBáoCáoToolStripMenuItem.Size = new Size(270, 34);
            thốngKêBáoCáoToolStripMenuItem.Text = "Thống Kê, Báo Cáo";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(109, 29);
            đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(664, 81);
            label5.Name = "label5";
            label5.Size = new Size(429, 45);
            label5.TabIndex = 13;
            label5.Text = "QUẢN LÍ NHÂN VIÊN";
            // 
            // C
            // 
            C.BackColor = SystemColors.ButtonFace;
            C.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            C.ForeColor = Color.Blue;
            C.Location = new Point(264, 650);
            C.Name = "C";
            C.Size = new Size(163, 45);
            C.TabIndex = 14;
            C.Text = "Tìm kiếm";
            C.UseVisualStyleBackColor = false;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = SystemColors.ActiveCaptionText;
            btnHuy.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuy.ForeColor = SystemColors.ButtonHighlight;
            btnHuy.Location = new Point(479, 737);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(196, 64);
            btnHuy.TabIndex = 15;
            btnHuy.Text = "Huỷ";
            btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = SystemColors.ActiveCaptionText;
            btnLuu.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLuu.ForeColor = SystemColors.ButtonHighlight;
            btnLuu.Location = new Point(1304, 737);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(196, 64);
            btnLuu.TabIndex = 16;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            // 
            // FrmQuanLiNhanVien
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1578, 844);
            Controls.Add(btnLuu);
            Controls.Add(btnHuy);
            Controls.Add(C);
            Controls.Add(label5);
            Controls.Add(dgvNhanVien);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(txtSDT);
            Controls.Add(label3);
            Controls.Add(txtMaSo);
            Controls.Add(label2);
            Controls.Add(txtHoTen);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmQuanLiNhanVien";
            Text = "Quản lí Nhân Viên";
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtHoTen;
        private Label label2;
        private TextBox txtMaSo;
        private Label label3;
        private TextBox txtSDT;
        private Label label4;
        private ComboBox comboBox1;
        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
        private DataGridView dgvNhanVien;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colMaSo;
        private DataGridViewTextBoxColumn colSDT;
        private DataGridViewTextBoxColumn colChucVu;
        private DataGridViewTextBoxColumn colSoDonHang;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem trangChủToolStripMenuItem;
        private ToolStripMenuItem quảnLýKháchHàngToolStripMenuItem;
        private ToolStripMenuItem kháchHàngToolStripMenuItem;
        private ToolStripMenuItem đơnHàngToolStripMenuItem;
        private ToolStripMenuItem thốngKêBáoCáoToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private Label label5;
        private Button C;
        private Button btnHuy;
        private Button btnLuu;
    }
}