namespace QuanLyBanHoa.Forms
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLiKhachHang));
            headerPanel = new Panel();
            lblHeaderTitle = new Label();
            contentPanel = new Panel();
            groupBox2 = new GroupBox();
            dgDSKhachHang = new DataGridView();
            flpButtons = new FlowLayoutPanel();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            groupBox1 = new GroupBox();
            tlpInfo = new TableLayoutPanel();
            lbHoTen = new Label();
            txtHoTen = new TextBox();
            lbMaKH = new Label();
            txtMaKH = new TextBox();
            lbSĐT = new Label();
            txtSĐT = new TextBox();
            lbSoluong = new Label();
            txtSoluong = new TextBox();
            lbDiaChi = new Label();
            txtDiaChi = new TextBox();
            lbEmail = new Label();
            txtEmail = new TextBox();
            headerPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgDSKhachHang).BeginInit();
            flpButtons.SuspendLayout();
            groupBox1.SuspendLayout();
            tlpInfo.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(52, 152, 219);
            headerPanel.Controls.Add(lblHeaderTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(24, 12, 24, 12);
            headerPanel.Size = new Size(1280, 60);
            headerPanel.TabIndex = 100;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Dock = DockStyle.Left;
            lblHeaderTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(24, 12);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(239, 32);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Quản lý khách hàng";
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.WhiteSmoke;
            contentPanel.Controls.Add(groupBox2);
            contentPanel.Controls.Add(flpButtons);
            contentPanel.Controls.Add(groupBox1);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 60);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(16);
            contentPanel.Size = new Size(1280, 700);
            contentPanel.TabIndex = 101;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgDSKhachHang);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox2.Location = new Point(16, 242);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(12, 8, 12, 12);
            groupBox2.Size = new Size(1248, 390);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách khách hàng";
            // 
            // dgDSKhachHang
            // 
            dgDSKhachHang.AllowUserToAddRows = false;
            dgDSKhachHang.AllowUserToDeleteRows = false;
            dgDSKhachHang.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(242, 242, 242);
            dgDSKhachHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgDSKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgDSKhachHang.BackgroundColor = SystemColors.ButtonHighlight;
            dgDSKhachHang.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(33, 97, 140);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgDSKhachHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgDSKhachHang.ColumnHeadersHeight = 36;
            dgDSKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(189, 215, 238);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgDSKhachHang.DefaultCellStyle = dataGridViewCellStyle3;
            dgDSKhachHang.Dock = DockStyle.Fill;
            dgDSKhachHang.EnableHeadersVisualStyles = false;
            dgDSKhachHang.GridColor = Color.LightSteelBlue;
            dgDSKhachHang.Location = new Point(12, 31);
            dgDSKhachHang.Name = "dgDSKhachHang";
            dgDSKhachHang.ReadOnly = true;
            dgDSKhachHang.RowHeadersVisible = false;
            dgDSKhachHang.RowHeadersWidth = 51;
            dgDSKhachHang.RowTemplate.Height = 28;
            dgDSKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgDSKhachHang.Size = new Size(1224, 347);
            dgDSKhachHang.TabIndex = 0;
            dgDSKhachHang.CellContentClick += dataGridView1_CellContentClick;
            dgDSKhachHang.SelectionChanged += dgDSKhachHang_SelectionChanged;
            // 
            // flpButtons
            // 
            flpButtons.AutoSize = true;
            flpButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpButtons.Controls.Add(btnThem);
            flpButtons.Controls.Add(btnSua);
            flpButtons.Controls.Add(btnXoa);
            flpButtons.Controls.Add(btnLuu);
            flpButtons.Dock = DockStyle.Bottom;
            flpButtons.Location = new Point(16, 632);
            flpButtons.Name = "flpButtons";
            flpButtons.Padding = new Padding(0, 8, 0, 0);
            flpButtons.Size = new Size(1248, 52);
            flpButtons.TabIndex = 7;
            flpButtons.WrapContents = false;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(46, 204, 113);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(3, 11);
            btnThem.Margin = new Padding(3, 3, 12, 8);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(110, 33);
            btnThem.TabIndex = 0;
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
            btnSua.Location = new Point(128, 11);
            btnSua.Margin = new Padding(3, 3, 12, 8);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(110, 33);
            btnSua.TabIndex = 3;
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
            btnXoa.Location = new Point(253, 11);
            btnXoa.Margin = new Padding(3, 3, 12, 8);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(110, 33);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.Gainsboro;
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLuu.ForeColor = Color.Black;
            btnLuu.Location = new Point(378, 11);
            btnLuu.Margin = new Padding(3, 3, 12, 8);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(110, 33);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tlpInfo);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.Location = new Point(16, 16);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(12, 8, 12, 12);
            groupBox1.Size = new Size(1248, 226);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin khách hàng";
            // 
            // tlpInfo
            // 
            tlpInfo.ColumnCount = 4;
            tlpInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tlpInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlpInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tlpInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlpInfo.Controls.Add(lbHoTen, 0, 0);
            tlpInfo.Controls.Add(txtHoTen, 1, 0);
            tlpInfo.Controls.Add(lbMaKH, 2, 0);
            tlpInfo.Controls.Add(txtMaKH, 3, 0);
            tlpInfo.Controls.Add(lbSĐT, 0, 1);
            tlpInfo.Controls.Add(txtSĐT, 1, 1);
            tlpInfo.Controls.Add(lbSoluong, 2, 1);
            tlpInfo.Controls.Add(txtSoluong, 3, 1);
            tlpInfo.Controls.Add(lbDiaChi, 0, 2);
            tlpInfo.Controls.Add(txtDiaChi, 1, 2);
            tlpInfo.Controls.Add(lbEmail, 0, 3);
            tlpInfo.Controls.Add(txtEmail, 1, 3);
            tlpInfo.Dock = DockStyle.Fill;
            tlpInfo.Location = new Point(12, 31);
            tlpInfo.Name = "tlpInfo";
            tlpInfo.Padding = new Padding(8, 6, 8, 6);
            tlpInfo.RowCount = 5;
            tlpInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpInfo.Size = new Size(1224, 183);
            tlpInfo.TabIndex = 0;
            // 
            // lbHoTen
            // 
            lbHoTen.AutoSize = true;
            lbHoTen.Dock = DockStyle.Fill;
            lbHoTen.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbHoTen.Location = new Point(11, 9);
            lbHoTen.Margin = new Padding(3);
            lbHoTen.Name = "lbHoTen";
            lbHoTen.Size = new Size(175, 34);
            lbHoTen.TabIndex = 1;
            lbHoTen.Text = "Họ và tên:";
            lbHoTen.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtHoTen
            // 
            txtHoTen.Dock = DockStyle.Fill;
            txtHoTen.Font = new Font("Segoe UI", 9F);
            txtHoTen.Location = new Point(192, 9);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(416, 27);
            txtHoTen.TabIndex = 6;
            // 
            // lbMaKH
            // 
            lbMaKH.AutoSize = true;
            lbMaKH.Dock = DockStyle.Fill;
            lbMaKH.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbMaKH.Location = new Point(614, 9);
            lbMaKH.Margin = new Padding(3);
            lbMaKH.Name = "lbMaKH";
            lbMaKH.Size = new Size(175, 34);
            lbMaKH.TabIndex = 0;
            lbMaKH.Text = "Mã KH:";
            lbMaKH.TextAlign = ContentAlignment.MiddleRight;
            lbMaKH.Click += lbMaKH_Click;
            // 
            // txtMaKH
            // 
            txtMaKH.Dock = DockStyle.Fill;
            txtMaKH.Font = new Font("Segoe UI", 9F);
            txtMaKH.Location = new Point(795, 9);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(418, 27);
            txtMaKH.TabIndex = 6;
            // 
            // lbSĐT
            // 
            lbSĐT.AutoSize = true;
            lbSĐT.Dock = DockStyle.Fill;
            lbSĐT.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbSĐT.Location = new Point(11, 49);
            lbSĐT.Margin = new Padding(3);
            lbSĐT.Name = "lbSĐT";
            lbSĐT.Size = new Size(175, 34);
            lbSĐT.TabIndex = 2;
            lbSĐT.Text = "Số điện thoại:";
            lbSĐT.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtSĐT
            // 
            txtSĐT.Dock = DockStyle.Fill;
            txtSĐT.Font = new Font("Segoe UI", 9F);
            txtSĐT.Location = new Point(192, 49);
            txtSĐT.Name = "txtSĐT";
            txtSĐT.Size = new Size(416, 27);
            txtSĐT.TabIndex = 6;
            // 
            // lbSoluong
            // 
            lbSoluong.AutoSize = true;
            lbSoluong.Dock = DockStyle.Fill;
            lbSoluong.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbSoluong.Location = new Point(614, 49);
            lbSoluong.Margin = new Padding(3);
            lbSoluong.Name = "lbSoluong";
            lbSoluong.Size = new Size(175, 34);
            lbSoluong.TabIndex = 8;
            lbSoluong.Text = "Số lượng đơn hàng:";
            lbSoluong.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtSoluong
            // 
            txtSoluong.Dock = DockStyle.Fill;
            txtSoluong.Font = new Font("Segoe UI", 9F);
            txtSoluong.Location = new Point(795, 49);
            txtSoluong.Name = "txtSoluong";
            txtSoluong.ReadOnly = true;
            txtSoluong.Size = new Size(418, 27);
            txtSoluong.TabIndex = 9;
            // 
            // lbDiaChi
            // 
            lbDiaChi.AutoSize = true;
            lbDiaChi.Dock = DockStyle.Fill;
            lbDiaChi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbDiaChi.Location = new Point(11, 89);
            lbDiaChi.Margin = new Padding(3);
            lbDiaChi.Name = "lbDiaChi";
            lbDiaChi.Size = new Size(175, 34);
            lbDiaChi.TabIndex = 3;
            lbDiaChi.Text = "Địa chỉ:";
            lbDiaChi.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDiaChi
            // 
            tlpInfo.SetColumnSpan(txtDiaChi, 3);
            txtDiaChi.Dock = DockStyle.Fill;
            txtDiaChi.Font = new Font("Segoe UI", 9F);
            txtDiaChi.Location = new Point(192, 89);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(1021, 27);
            txtDiaChi.TabIndex = 6;
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Dock = DockStyle.Fill;
            lbEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbEmail.Location = new Point(11, 129);
            lbEmail.Margin = new Padding(3);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(175, 34);
            lbEmail.TabIndex = 7;
            lbEmail.Text = "Email:";
            lbEmail.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            tlpInfo.SetColumnSpan(txtEmail, 3);
            txtEmail.Dock = DockStyle.Fill;
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.Location = new Point(192, 129);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(1021, 27);
            txtEmail.TabIndex = 6;
            // 
            // frmQuanLiKhachHang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1280, 760);
            Controls.Add(contentPanel);
            Controls.Add(headerPanel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1000, 700);
            Name = "frmQuanLiKhachHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Khách Hàng";
            Load += frmQuanLiKhachHang_Load;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgDSKhachHang).EndInit();
            flpButtons.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tlpInfo.ResumeLayout(false);
            tlpInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.Label lbSoluong;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtSĐT;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label lbDiaChi;
        private System.Windows.Forms.Label lbSĐT;
        private System.Windows.Forms.Label lbMaKH;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgDSKhachHang;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.TableLayoutPanel tlpInfo;
        private Label lbHoTen;
    }
}
