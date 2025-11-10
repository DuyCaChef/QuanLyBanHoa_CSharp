namespace QuanLyBanHoa.Forms
{
    partial class frmHoa
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoa));
            groupBox1 = new GroupBox();
            dgDSHoa = new DataGridView();
            panelSearch = new Panel();
            btnTim = new Button();
            txtTim = new TextBox();
            label8 = new Label();
            groupBox2 = new GroupBox();
            layoutInfo = new TableLayoutPanel();
            lbMaHoa = new Label();
            txtMaHoa = new TextBox();
            lbTenHoa = new Label();
            txtTenHoa = new TextBox();
            lbGia = new Label();
            txtGia = new TextBox();
            lbSoLuong = new Label();
            cboSoLuong = new ComboBox();
            lbGhichu = new Label();
            txtGhichu = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            panelActions = new Panel();
            headerPanel = new Panel();
            lblHeaderTitle = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgDSHoa).BeginInit();
            panelSearch.SuspendLayout();
            groupBox2.SuspendLayout();
            layoutInfo.SuspendLayout();
            panelActions.SuspendLayout();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgDSHoa);
            groupBox1.Controls.Add(panelSearch);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(475, 60);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(16, 16, 16, 16);
            groupBox1.Size = new Size(1103, 728);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh Sách Hoa";
            // 
            // dgDSHoa
            // 
            dgDSHoa.AllowUserToAddRows = false;
            dgDSHoa.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(242, 242, 242);
            dgDSHoa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgDSHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgDSHoa.BackgroundColor = Color.White;
            dgDSHoa.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.LightGray;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.Padding = new Padding(4, 0, 4, 0);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgDSHoa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgDSHoa.ColumnHeadersHeight = 30;
            dgDSHoa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgDSHoa.DefaultCellStyle = dataGridViewCellStyle3;
            dgDSHoa.Dock = DockStyle.Fill;
            dgDSHoa.Location = new Point(16, 106);
            dgDSHoa.Margin = new Padding(2);
            dgDSHoa.Name = "dgDSHoa";
            dgDSHoa.ReadOnly = true;
            dgDSHoa.RowHeadersVisible = false;
            dgDSHoa.RowHeadersWidth = 51;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgDSHoa.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgDSHoa.RowTemplate.Height = 26;
            dgDSHoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgDSHoa.Size = new Size(1071, 606);
            dgDSHoa.TabIndex = 11;
            dgDSHoa.SelectionChanged += dgDSHoa_SelectionChanged;
            // 
            // panelSearch
            // 
            panelSearch.Controls.Add(btnTim);
            panelSearch.Controls.Add(txtTim);
            panelSearch.Controls.Add(label8);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(16, 48);
            panelSearch.Margin = new Padding(4, 4, 4, 4);
            panelSearch.Name = "panelSearch";
            panelSearch.Padding = new Padding(0, 6, 0, 6);
            panelSearch.Size = new Size(1071, 58);
            panelSearch.TabIndex = 100;
            // 
            // btnTim
            // 
            btnTim.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTim.BackColor = Color.FromArgb(52, 152, 219);
            btnTim.FlatAppearance.BorderSize = 0;
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTim.ForeColor = Color.White;
            btnTim.Location = new Point(893, 15);
            btnTim.Margin = new Padding(2);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(160, 32);
            btnTim.TabIndex = 8;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = false;
            btnTim.Click += btnTim_Click;
            // 
            // txtTim
            // 
            txtTim.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTim.Font = new Font("Segoe UI", 9F);
            txtTim.Location = new Point(121, 14);
            txtTim.Margin = new Padding(2);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(766, 31);
            txtTim.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(16, 18);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(95, 25);
            label8.TabIndex = 9;
            label8.Text = "Tìm kiếm:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(layoutInfo);
            groupBox2.Dock = DockStyle.Left;
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(0, 60);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(16, 16, 16, 16);
            groupBox2.Size = new Size(475, 728);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông Tin Hoa";
            // 
            // layoutInfo
            // 
            layoutInfo.ColumnCount = 2;
            layoutInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 112F));
            layoutInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutInfo.Controls.Add(lbMaHoa, 0, 0);
            layoutInfo.Controls.Add(txtMaHoa, 1, 0);
            layoutInfo.Controls.Add(lbTenHoa, 0, 1);
            layoutInfo.Controls.Add(txtTenHoa, 1, 1);
            layoutInfo.Controls.Add(lbGia, 0, 2);
            layoutInfo.Controls.Add(txtGia, 1, 2);
            layoutInfo.Controls.Add(lbSoLuong, 0, 3);
            layoutInfo.Controls.Add(cboSoLuong, 1, 3);
            layoutInfo.Controls.Add(lbGhichu, 0, 4);
            layoutInfo.Controls.Add(txtGhichu, 0, 5);
            layoutInfo.Dock = DockStyle.Fill;
            layoutInfo.Location = new Point(16, 48);
            layoutInfo.Margin = new Padding(0);
            layoutInfo.Name = "layoutInfo";
            layoutInfo.Padding = new Padding(6, 6, 6, 6);
            layoutInfo.RowCount = 6;
            layoutInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            layoutInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            layoutInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            layoutInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            layoutInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutInfo.Size = new Size(443, 664);
            layoutInfo.TabIndex = 0;
            // 
            // lbMaHoa
            // 
            lbMaHoa.AutoSize = true;
            lbMaHoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbMaHoa.Location = new Point(8, 14);
            lbMaHoa.Margin = new Padding(2, 8, 2, 0);
            lbMaHoa.Name = "lbMaHoa";
            lbMaHoa.Size = new Size(81, 25);
            lbMaHoa.TabIndex = 3;
            lbMaHoa.Text = "Mã hoa:";
            // 
            // txtMaHoa
            // 
            txtMaHoa.Dock = DockStyle.Fill;
            txtMaHoa.Font = new Font("Segoe UI", 9F);
            txtMaHoa.Location = new Point(120, 8);
            txtMaHoa.Margin = new Padding(2);
            txtMaHoa.Name = "txtMaHoa";
            txtMaHoa.ReadOnly = true;
            txtMaHoa.Size = new Size(315, 31);
            txtMaHoa.TabIndex = 0;
            // 
            // lbTenHoa
            // 
            lbTenHoa.AutoSize = true;
            lbTenHoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbTenHoa.Location = new Point(8, 56);
            lbTenHoa.Margin = new Padding(2, 8, 2, 0);
            lbTenHoa.Name = "lbTenHoa";
            lbTenHoa.Size = new Size(84, 25);
            lbTenHoa.TabIndex = 4;
            lbTenHoa.Text = "Tên hoa:";
            // 
            // txtTenHoa
            // 
            txtTenHoa.Dock = DockStyle.Fill;
            txtTenHoa.Font = new Font("Segoe UI", 9F);
            txtTenHoa.Location = new Point(120, 50);
            txtTenHoa.Margin = new Padding(2);
            txtTenHoa.Name = "txtTenHoa";
            txtTenHoa.Size = new Size(315, 31);
            txtTenHoa.TabIndex = 1;
            // 
            // lbGia
            // 
            lbGia.AutoSize = true;
            lbGia.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbGia.Location = new Point(8, 98);
            lbGia.Margin = new Padding(2, 8, 2, 0);
            lbGia.Name = "lbGia";
            lbGia.Size = new Size(82, 25);
            lbGia.TabIndex = 5;
            lbGia.Text = "Giá bán:";
            // 
            // txtGia
            // 
            txtGia.Dock = DockStyle.Fill;
            txtGia.Font = new Font("Segoe UI", 9F);
            txtGia.Location = new Point(120, 92);
            txtGia.Margin = new Padding(2);
            txtGia.Name = "txtGia";
            txtGia.Size = new Size(315, 31);
            txtGia.TabIndex = 2;
            // 
            // lbSoLuong
            // 
            lbSoLuong.AutoSize = true;
            lbSoLuong.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbSoLuong.Location = new Point(8, 140);
            lbSoLuong.Margin = new Padding(2, 8, 2, 0);
            lbSoLuong.Name = "lbSoLuong";
            lbSoLuong.Size = new Size(93, 25);
            lbSoLuong.TabIndex = 6;
            lbSoLuong.Text = "Số lượng:";
            // 
            // cboSoLuong
            // 
            cboSoLuong.DropDownHeight = 250;
            cboSoLuong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSoLuong.Font = new Font("Segoe UI", 9F);
            cboSoLuong.FormattingEnabled = true;
            cboSoLuong.IntegralHeight = false;
            cboSoLuong.Location = new Point(120, 134);
            cboSoLuong.Margin = new Padding(2);
            cboSoLuong.Name = "cboSoLuong";
            cboSoLuong.Size = new Size(150, 33);
            cboSoLuong.TabIndex = 3;
            cboSoLuong.SelectedIndexChanged += cboSoLuong_SelectedIndexChanged;
            // 
            // lbGhichu
            // 
            lbGhichu.AutoSize = true;
            lbGhichu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbGhichu.Location = new Point(8, 190);
            lbGhichu.Margin = new Padding(2, 8, 2, 0);
            lbGhichu.Name = "lbGhichu";
            lbGhichu.Size = new Size(82, 25);
            lbGhichu.TabIndex = 16;
            lbGhichu.Text = "Ghi chú:";
            // 
            // txtGhichu
            // 
            layoutInfo.SetColumnSpan(txtGhichu, 2);
            txtGhichu.Dock = DockStyle.Fill;
            txtGhichu.Font = new Font("Segoe UI", 9F);
            txtGhichu.Location = new Point(8, 219);
            txtGhichu.Margin = new Padding(2);
            txtGhichu.Multiline = true;
            txtGhichu.Name = "txtGhichu";
            txtGhichu.ScrollBars = ScrollBars.Vertical;
            txtGhichu.Size = new Size(427, 437);
            txtGhichu.TabIndex = 4;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(46, 204, 113);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(16, 10);
            btnThem.Margin = new Padding(2);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(120, 40);
            btnThem.TabIndex = 3;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(52, 152, 219);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(152, 10);
            btnSua.Margin = new Padding(2);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(120, 40);
            btnSua.TabIndex = 4;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(288, 10);
            btnXoa.Margin = new Padding(2);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(120, 40);
            btnXoa.TabIndex = 5;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.Gold;
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(424, 10);
            btnLuu.Margin = new Padding(2);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(120, 40);
            btnLuu.TabIndex = 6;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // panelActions
            // 
            panelActions.BackColor = Color.WhiteSmoke;
            panelActions.Controls.Add(btnLuu);
            panelActions.Controls.Add(btnXoa);
            panelActions.Controls.Add(btnSua);
            panelActions.Controls.Add(btnThem);
            panelActions.Dock = DockStyle.Bottom;
            panelActions.Location = new Point(0, 788);
            panelActions.Margin = new Padding(2);
            panelActions.Name = "panelActions";
            panelActions.Padding = new Padding(8, 8, 8, 8);
            panelActions.Size = new Size(1578, 56);
            panelActions.TabIndex = 102;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(52, 152, 219);
            headerPanel.Controls.Add(lblHeaderTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(2);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(24, 12, 24, 12);
            headerPanel.Size = new Size(1578, 60);
            headerPanel.TabIndex = 103;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(24, 15);
            lblHeaderTitle.Margin = new Padding(2, 0, 2, 0);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(175, 38);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Quản lý hoa";
            // 
            // frmHoa
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1578, 844);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(panelActions);
            Controls.Add(headerPanel);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 4, 4, 4);
            Name = "frmHoa";
            Text = "Quản Lý Hoa";
            Load += frmQuanLiHoa_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgDSHoa).EndInit();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            groupBox2.ResumeLayout(false);
            layoutInfo.ResumeLayout(false);
            layoutInfo.PerformLayout();
            panelActions.ResumeLayout(false);
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ResumeLayout(false);
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
        private TextBox txtMaHoa;
        private Label lbSoLuong;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLuu;
        private DataGridView dgDSHoa;
        private ComboBox cboSoLuong;
        private TextBox txtTenHoa;
        private TextBox txtGia;
        private TextBox txtGhichu;
        private Label lbGhichu;
        private Panel panelActions;
        private Panel headerPanel;
        private Label lblHeaderTitle;
        private Panel panelSearch; // new panel for search controls
        private TableLayoutPanel layoutInfo; // new field
    }
}
