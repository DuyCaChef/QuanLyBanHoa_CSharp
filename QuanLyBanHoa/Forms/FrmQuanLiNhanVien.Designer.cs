namespace QuanLyBanHoa.Forms
{
    partial class FrmQuanLiNhanVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuanLiNhanVien));
            headerPanel = new Panel();
            lblHeaderTitle = new Label();
            groupThongTin = new GroupBox();
            label1 = new Label();
            txtHoTen = new TextBox();
            label2 = new Label();
            txtMaSo = new TextBox();
            label3 = new Label();
            txtSDT = new TextBox();
            lblTaiKhoan = new Label();
            txtTaiKhoan = new TextBox();
            lblMatKhau = new Label();
            txtMatKhau = new TextBox();
            lblVaiTro = new Label();
            cmbVaiTro = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            C = new Button();
            groupDanhSach = new GroupBox();
            panelBottomNVList = new Panel();
            btnTaiLai = new Button();
            dgvNhanVien = new DataGridView();
            headerPanel.SuspendLayout();
            groupThongTin.SuspendLayout();
            groupDanhSach.SuspendLayout();
            panelBottomNVList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.Green;
            headerPanel.Controls.Add(lblHeaderTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(2);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(19, 10, 19, 10);
            headerPanel.Size = new Size(1010, 48);
            headerPanel.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(19, 12);
            lblHeaderTitle.Margin = new Padding(2, 0, 2, 0);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(221, 32);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Quản lý nhân viên";
            // 
            // groupThongTin
            // 
            groupThongTin.Controls.Add(label1);
            groupThongTin.Controls.Add(txtHoTen);
            groupThongTin.Controls.Add(label2);
            groupThongTin.Controls.Add(txtMaSo);
            groupThongTin.Controls.Add(label3);
            groupThongTin.Controls.Add(txtSDT);
            groupThongTin.Controls.Add(lblTaiKhoan);
            groupThongTin.Controls.Add(txtTaiKhoan);
            groupThongTin.Controls.Add(lblMatKhau);
            groupThongTin.Controls.Add(txtMatKhau);
            groupThongTin.Controls.Add(lblVaiTro);
            groupThongTin.Controls.Add(cmbVaiTro);
            groupThongTin.Controls.Add(btnThem);
            groupThongTin.Controls.Add(btnSua);
            groupThongTin.Controls.Add(btnXoa);
            groupThongTin.Controls.Add(C);
            groupThongTin.Dock = DockStyle.Left;
            groupThongTin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupThongTin.Location = new Point(0, 48);
            groupThongTin.Margin = new Padding(2);
            groupThongTin.Name = "groupThongTin";
            groupThongTin.Padding = new Padding(2);
            groupThongTin.Size = new Size(304, 492);
            groupThongTin.TabIndex = 1;
            groupThongTin.TabStop = false;
            groupThongTin.Text = "Thông tin nhân viên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(19, 78);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 0;
            label1.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Segoe UI", 9F);
            txtHoTen.Location = new Point(120, 78);
            txtHoTen.Margin = new Padding(2);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(164, 27);
            txtHoTen.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(19, 45);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 2;
            label2.Text = "Mã số:";
            // 
            // txtMaSo
            // 
            txtMaSo.Font = new Font("Segoe UI", 9F);
            txtMaSo.Location = new Point(120, 40);
            txtMaSo.Margin = new Padding(2);
            txtMaSo.Name = "txtMaSo";
            txtMaSo.Size = new Size(164, 27);
            txtMaSo.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(19, 120);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 4;
            label3.Text = "Số điện thoại:";
            // 
            // txtSDT
            // 
            txtSDT.Font = new Font("Segoe UI", 9F);
            txtSDT.Location = new Point(120, 117);
            txtSDT.Margin = new Padding(2);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(164, 27);
            txtSDT.TabIndex = 2;
            // 
            // lblTaiKhoan
            // 
            lblTaiKhoan.AutoSize = true;
            lblTaiKhoan.Font = new Font("Segoe UI", 9F);
            lblTaiKhoan.Location = new Point(19, 160);
            lblTaiKhoan.Margin = new Padding(2, 0, 2, 0);
            lblTaiKhoan.Name = "lblTaiKhoan";
            lblTaiKhoan.Size = new Size(74, 20);
            lblTaiKhoan.TabIndex = 20;
            lblTaiKhoan.Text = "Tài khoản:";
            // 
            // txtTaiKhoan
            // 
            txtTaiKhoan.Font = new Font("Segoe UI", 9F);
            txtTaiKhoan.Location = new Point(120, 157);
            txtTaiKhoan.Margin = new Padding(2);
            txtTaiKhoan.Name = "txtTaiKhoan";
            txtTaiKhoan.Size = new Size(164, 27);
            txtTaiKhoan.TabIndex = 3;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Font = new Font("Segoe UI", 9F);
            lblMatKhau.Location = new Point(19, 198);
            lblMatKhau.Margin = new Padding(2, 0, 2, 0);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(73, 20);
            lblMatKhau.TabIndex = 22;
            lblMatKhau.Text = "Mật khẩu:";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 9F);
            txtMatKhau.Location = new Point(120, 195);
            txtMatKhau.Margin = new Padding(2);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(164, 27);
            txtMatKhau.TabIndex = 4;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // lblVaiTro
            // 
            lblVaiTro.AutoSize = true;
            lblVaiTro.Font = new Font("Segoe UI", 9F);
            lblVaiTro.Location = new Point(19, 238);
            lblVaiTro.Margin = new Padding(2, 0, 2, 0);
            lblVaiTro.Name = "lblVaiTro";
            lblVaiTro.Size = new Size(55, 20);
            lblVaiTro.TabIndex = 24;
            lblVaiTro.Text = "Vai trò:";
            // 
            // cmbVaiTro
            // 
            cmbVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVaiTro.Font = new Font("Segoe UI", 9F);
            cmbVaiTro.FormattingEnabled = true;
            cmbVaiTro.Items.AddRange(new object[] { "Admin", "NhanVien" });
            cmbVaiTro.Location = new Point(120, 235);
            cmbVaiTro.Margin = new Padding(2);
            cmbVaiTro.Name = "cmbVaiTro";
            cmbVaiTro.Size = new Size(164, 28);
            cmbVaiTro.TabIndex = 5;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(46, 204, 113);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(19, 290);
            btnThem.Margin = new Padding(2);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(80, 40);
            btnThem.TabIndex = 8;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(52, 152, 219);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(112, 290);
            btnSua.Margin = new Padding(2);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(80, 40);
            btnSua.TabIndex = 10;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(205, 290);
            btnXoa.Margin = new Padding(2);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(79, 40);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // C
            // 
            C.BackColor = Color.Gainsboro;
            C.FlatAppearance.BorderSize = 0;
            C.FlatStyle = FlatStyle.Flat;
            C.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            C.ForeColor = Color.Black;
            C.Location = new Point(19, 347);
            C.Margin = new Padding(2);
            C.Name = "C";
            C.Size = new Size(265, 35);
            C.TabIndex = 14;
            C.Text = "Tìm kiếm theo thông tin đã nhập";
            C.UseVisualStyleBackColor = false;
            C.Click += C_Click;
            // 
            // groupDanhSach
            // 
            groupDanhSach.Controls.Add(panelBottomNVList);
            groupDanhSach.Controls.Add(dgvNhanVien);
            groupDanhSach.Dock = DockStyle.Fill;
            groupDanhSach.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupDanhSach.Location = new Point(304, 48);
            groupDanhSach.Margin = new Padding(2);
            groupDanhSach.Name = "groupDanhSach";
            groupDanhSach.Padding = new Padding(10, 6, 10, 10);
            groupDanhSach.Size = new Size(706, 492);
            groupDanhSach.TabIndex = 2;
            groupDanhSach.TabStop = false;
            groupDanhSach.Text = "Danh sách nhân viên";
            // 
            // panelBottomNVList
            // 
            panelBottomNVList.Controls.Add(btnTaiLai);
            panelBottomNVList.Dock = DockStyle.Bottom;
            panelBottomNVList.Location = new Point(10, 442);
            panelBottomNVList.Margin = new Padding(2);
            panelBottomNVList.Name = "panelBottomNVList";
            panelBottomNVList.Padding = new Padding(0, 3, 0, 0);
            panelBottomNVList.Size = new Size(686, 40);
            panelBottomNVList.TabIndex = 101;
            // 
            // btnTaiLai
            // 
            btnTaiLai.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTaiLai.BackColor = Color.Gold;
            btnTaiLai.FlatAppearance.BorderSize = 0;
            btnTaiLai.FlatStyle = FlatStyle.Flat;
            btnTaiLai.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTaiLai.ForeColor = Color.White;
            btnTaiLai.Location = new Point(512, 0);
            btnTaiLai.Margin = new Padding(2);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(168, 40);
            btnTaiLai.TabIndex = 15;
            btnTaiLai.Text = "Tải lại";
            btnTaiLai.UseVisualStyleBackColor = false;
            btnTaiLai.Click += btnTaiLai_Click;
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(242, 242, 242);
            dgvNhanVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.BackgroundColor = Color.White;
            dgvNhanVien.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.LightGray;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.Padding = new Padding(6, 0, 6, 0);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvNhanVien.ColumnHeadersHeight = 36;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvNhanVien.DefaultCellStyle = dataGridViewCellStyle3;
            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.Location = new Point(10, 29);
            dgvNhanVien.Margin = new Padding(2);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.RowTemplate.Height = 36;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.Size = new Size(686, 453);
            dgvNhanVien.TabIndex = 11;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            // 
            // FrmQuanLiNhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1010, 540);
            Controls.Add(groupDanhSach);
            Controls.Add(groupThongTin);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "FrmQuanLiNhanVien";
            Text = "Quản lí Nhân Viên";
            Load += FrmQuanLiNhanVien_Load;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            groupThongTin.ResumeLayout(false);
            groupThongTin.PerformLayout();
            groupDanhSach.ResumeLayout(false);
            panelBottomNVList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.GroupBox groupThongTin;
        private System.Windows.Forms.GroupBox groupDanhSach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaSo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button C;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.Panel panelBottomNVList;
        private System.Windows.Forms.Button btnTaiLai;
        // New controls for Users table
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.ComboBox cmbVaiTro;
    }
}