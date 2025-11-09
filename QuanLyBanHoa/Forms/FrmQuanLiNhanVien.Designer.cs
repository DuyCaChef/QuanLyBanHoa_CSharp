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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            headerPanel = new System.Windows.Forms.Panel();
            lblHeaderTitle = new System.Windows.Forms.Label();
            groupThongTin = new System.Windows.Forms.GroupBox();
            label1 = new System.Windows.Forms.Label();
            txtHoTen = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtMaSo = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtSDT = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            cboChucVu = new System.Windows.Forms.ComboBox();
            btnThem = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            C = new System.Windows.Forms.Button();
            groupDanhSach = new System.Windows.Forms.GroupBox();
            txtTimKiem = new System.Windows.Forms.TextBox();
            lblTimKiem = new System.Windows.Forms.Label();
            dgvNhanVien = new System.Windows.Forms.DataGridView();
            btnTaiLai = new System.Windows.Forms.Button();
            headerPanel.SuspendLayout();
            groupThongTin.SuspendLayout();
            groupDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            headerPanel.Controls.Add(lblHeaderTitle);
            headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            headerPanel.Location = new System.Drawing.Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new System.Windows.Forms.Padding(24, 12, 24, 12);
            headerPanel.Size = new System.Drawing.Size(1578, 60);
            headerPanel.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            lblHeaderTitle.Location = new System.Drawing.Point(24, 15);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new System.Drawing.Size(234, 32);
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
            groupThongTin.Controls.Add(label4);
            groupThongTin.Controls.Add(cboChucVu);
            groupThongTin.Controls.Add(btnThem);
            groupThongTin.Controls.Add(btnSua);
            groupThongTin.Controls.Add(btnXoa);
            groupThongTin.Controls.Add(C);
            groupThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            groupThongTin.Location = new System.Drawing.Point(60, 108);
            groupThongTin.Name = "groupThongTin";
            groupThongTin.Size = new System.Drawing.Size(480, 640);
            groupThongTin.TabIndex = 1;
            groupThongTin.TabStop = false;
            groupThongTin.Text = "Thông tin nhân viên";
            // 
            // label1 (Họ Tên)
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            label1.Location = new System.Drawing.Point(34, 50);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(57, 20);
            label1.TabIndex = 0;
            label1.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtHoTen.Location = new System.Drawing.Point(144, 46);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new System.Drawing.Size(300, 27);
            txtHoTen.TabIndex = 1;
            // 
            // label2 (Mã số)
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            label2.Location = new System.Drawing.Point(34, 100);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(55, 20);
            label2.TabIndex = 2;
            label2.Text = "Mã số:";
            // 
            // txtMaSo
            // 
            txtMaSo.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtMaSo.Location = new System.Drawing.Point(144, 96);
            txtMaSo.Name = "txtMaSo";
            txtMaSo.Size = new System.Drawing.Size(300, 27);
            txtMaSo.TabIndex = 3;
            // 
            // label3 (SDT)
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            label3.Location = new System.Drawing.Point(34, 150);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(99, 20);
            label3.TabIndex = 4;
            label3.Text = "Số điện thoại:";
            // 
            // txtSDT
            // 
            txtSDT.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtSDT.Location = new System.Drawing.Point(144, 146);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new System.Drawing.Size(300, 27);
            txtSDT.TabIndex = 5;
            // 
            // label4 (Chức vụ)
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            label4.Location = new System.Drawing.Point(34, 200);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(63, 20);
            label4.TabIndex = 6;
            label4.Text = "Chức vụ:";
            // 
            // cboChucVu
            // 
            cboChucVu.Font = new System.Drawing.Font("Segoe UI", 9F);
            cboChucVu.FormattingEnabled = true;
            cboChucVu.Items.AddRange(new object[] { "Nhân viên bán hàng", "Nhân viên tư vấn", "Shipper", "Bảo vệ", "Thủ kho" });
            cboChucVu.Location = new System.Drawing.Point(144, 196);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new System.Drawing.Size(300, 28);
            cboChucVu.TabIndex = 7;
            // 
            // btnThem
            // 
            btnThem.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnThem.ForeColor = System.Drawing.Color.White;
            btnThem.Location = new System.Drawing.Point(34, 270);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(110, 36);
            btnThem.TabIndex = 8;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnSua.ForeColor = System.Drawing.Color.White;
            btnSua.Location = new System.Drawing.Point(168, 270);
            btnSua.Name = "btnSua";
            btnSua.Size = new System.Drawing.Size(110, 36);
            btnSua.TabIndex = 10;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnXoa.ForeColor = System.Drawing.Color.White;
            btnXoa.Location = new System.Drawing.Point(302, 270);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new System.Drawing.Size(110, 36);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // C (Tìm kiếm)
            // 
            C.BackColor = System.Drawing.Color.Gainsboro;
            C.FlatAppearance.BorderSize = 0;
            C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            C.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            C.ForeColor = System.Drawing.Color.Black;
            C.Location = new System.Drawing.Point(34, 322);
            C.Name = "C";
            C.Size = new System.Drawing.Size(378, 36);
            C.TabIndex = 14;
            C.Text = "Tìm kiếm theo thông tin đã nhập";
            C.UseVisualStyleBackColor = false;
            C.Click += C_Click;
            // 
            // groupDanhSach
            // 
            groupDanhSach.Controls.Add(txtTimKiem);
            groupDanhSach.Controls.Add(lblTimKiem);
            groupDanhSach.Controls.Add(dgvNhanVien);
            groupDanhSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            groupDanhSach.Location = new System.Drawing.Point(580, 108);
            groupDanhSach.Name = "groupDanhSach";
            groupDanhSach.Padding = new System.Windows.Forms.Padding(12, 8, 12, 12);
            groupDanhSach.Size = new System.Drawing.Size(950, 640);
            groupDanhSach.TabIndex = 2;
            groupDanhSach.TabStop = false;
            groupDanhSach.Text = "Danh sách nhân viên";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtTimKiem.Location = new System.Drawing.Point(132, 42);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new System.Drawing.Size(555, 27);
            txtTimKiem.TabIndex = 16;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblTimKiem.Location = new System.Drawing.Point(24, 48);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new System.Drawing.Size(73, 20);
            lblTimKiem.TabIndex = 15;
            lblTimKiem.Text = "Tìm kiếm:";
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            dgvNhanVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.BackgroundColor = System.Drawing.Color.White;
            dgvNhanVien.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvNhanVien.ColumnHeadersHeight = 36;
            dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvNhanVien.DefaultCellStyle = dataGridViewCellStyle3;
            dgvNhanVien.Location = new System.Drawing.Point(24, 90);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.RowTemplate.Height = 36;
            dgvNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.Size = new System.Drawing.Size(902, 526);
            dgvNhanVien.TabIndex = 11;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            // 
            // btnTaiLai
            // 
            btnTaiLai.BackColor = System.Drawing.Color.Black;
            btnTaiLai.FlatAppearance.BorderSize = 0;
            btnTaiLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTaiLai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnTaiLai.ForeColor = System.Drawing.Color.White;
            btnTaiLai.Location = new System.Drawing.Point(1320, 764);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new System.Drawing.Size(210, 50);
            btnTaiLai.TabIndex = 15;
            btnTaiLai.Text = "Tải lại";
            btnTaiLai.UseVisualStyleBackColor = false;
            btnTaiLai.Click += btnTaiLai_Click;
            // 
            // FrmQuanLiNhanVien
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.WhiteSmoke;
            ClientSize = new System.Drawing.Size(1578, 844);
            Controls.Add(btnTaiLai);
            Controls.Add(groupDanhSach);
            Controls.Add(groupThongTin);
            Controls.Add(headerPanel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "FrmQuanLiNhanVien";
            Text = "Quản lí Nhân Viên";
            Load += FrmQuanLiNhanVien_Load;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            groupThongTin.ResumeLayout(false);
            groupThongTin.PerformLayout();
            groupDanhSach.ResumeLayout(false);
            groupDanhSach.PerformLayout();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboChucVu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button C;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
    }
}