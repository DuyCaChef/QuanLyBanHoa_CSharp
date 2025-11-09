namespace QuanLyBanHoa.Forms
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
            cboChucVu = new ComboBox();
            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            dgvNhanVien = new DataGridView();
            label5 = new Label();
            C = new Button();
            btnTaiLai = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
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
            // cboChucVu
            // 
            cboChucVu.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboChucVu.FormattingEnabled = true;
            cboChucVu.Items.AddRange(new object[] { "Nhân viên bán hàng", "Nhân viên tư vấn\t", "Shipper", "Bảo vệ", "Thủ kho" });
            cboChucVu.Location = new Point(37, 486);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new Size(390, 35);
            cboChucVu.TabIndex = 7;
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
            btnThem.Click += btnThem_Click;
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
            btnXoa.Click += btnXoa_Click;
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
            btnSua.Click += btnSua_Click;
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvNhanVien.BackgroundColor = SystemColors.ButtonHighlight;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Location = new Point(479, 154);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.RowHeadersWidth = 62;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.Size = new Size(1021, 541);
            dgvNhanVien.TabIndex = 11;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
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
            C.Click += C_Click;
            // 
            // btnTaiLai
            // 
            btnTaiLai.BackColor = SystemColors.ActiveCaptionText;
            btnTaiLai.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTaiLai.ForeColor = SystemColors.ButtonHighlight;
            btnTaiLai.Location = new Point(1304, 734);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(196, 64);
            btnTaiLai.TabIndex = 15;
            btnTaiLai.Text = "Tải Lại";
            btnTaiLai.UseVisualStyleBackColor = false;
            btnTaiLai.Click += btnTaiLai_Click;
            // 
            // FrmQuanLiNhanVien
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1578, 844);
            Controls.Add(btnTaiLai);
            Controls.Add(C);
            Controls.Add(label5);
            Controls.Add(dgvNhanVien);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(cboChucVu);
            Controls.Add(label4);
            Controls.Add(txtSDT);
            Controls.Add(label3);
            Controls.Add(txtMaSo);
            Controls.Add(label2);
            Controls.Add(txtHoTen);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None; // Changed to None for child form
            Name = "FrmQuanLiNhanVien";
            Text = "Quản lí Nhân Viên";
            Load += FrmQuanLiNhanVien_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
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
        private ComboBox cboChucVu;
        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
        private DataGridView dgvNhanVien;
        private Label label5;
        private Button C;
        private Button btnTaiLai;
    }
}