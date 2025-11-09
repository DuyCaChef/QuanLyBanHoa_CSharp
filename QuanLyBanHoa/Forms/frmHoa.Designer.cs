namespace QuanLyBanHoa.Forms
{
    partial class FrmHoa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHoa));
            headerPanel = new Panel();
            lblHeaderTitle = new Label();
            contentPanel = new Panel();
            splitMain = new SplitContainer();
            groupBox2 = new GroupBox();
            txtGhichu = new TextBox();
            lbGhichu = new Label();
            txtTenHoa = new TextBox();
            txtGia = new TextBox();
            cboSoLuong = new ComboBox();
            txtLoaiHoa = new TextBox();
            txtMaHoa = new TextBox();
            lbLoaiHoa = new Label();
            lbSoLuong = new Label();
            lbGia = new Label();
            lbTenHoa = new Label();
            lbMaHoa = new Label();
            groupBox1 = new GroupBox();
            dgDSHoa = new DataGridView();
            pnlSearch = new Panel();
            btnTim = new Button();
            txtTim = new TextBox();
            label8 = new Label();
            flpButtons = new FlowLayoutPanel();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            headerPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgDSHoa).BeginInit();
            pnlSearch.SuspendLayout();
            flpButtons.SuspendLayout();
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
            lblHeaderTitle.Size = new Size(151, 32);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Quản lý hoa";
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.WhiteSmoke;
            contentPanel.Controls.Add(splitMain);
            contentPanel.Controls.Add(flpButtons);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 60);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(16);
            contentPanel.Size = new Size(1280, 700);
            contentPanel.TabIndex = 101;
            // 
            // splitMain
            // 
            splitMain.Dock = DockStyle.Fill;
            splitMain.Location = new Point(16, 16);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(groupBox2);
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(groupBox1);
            splitMain.Size = new Size(1248, 616);
            splitMain.SplitterDistance = 480;
            splitMain.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtGhichu);
            groupBox2.Controls.Add(lbGhichu);
            groupBox2.Controls.Add(txtTenHoa);
            groupBox2.Controls.Add(txtGia);
            groupBox2.Controls.Add(cboSoLuong);
            groupBox2.Controls.Add(txtLoaiHoa);
            groupBox2.Controls.Add(txtMaHoa);
            groupBox2.Controls.Add(lbLoaiHoa);
            groupBox2.Controls.Add(lbSoLuong);
            groupBox2.Controls.Add(lbGia);
            groupBox2.Controls.Add(lbTenHoa);
            groupBox2.Controls.Add(lbMaHoa);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(12, 8, 12, 12);
            groupBox2.Size = new Size(480, 616);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin hoa";
            // 
            // txtGhichu
            // 
            txtGhichu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtGhichu.Font = new Font("Segoe UI", 9F);
            txtGhichu.Location = new Point(26, 325);
            txtGhichu.Multiline = true;
            txtGhichu.Name = "txtGhichu";
            txtGhichu.Size = new Size(430, 265);
            txtGhichu.TabIndex = 17;
            // 
            // lbGhichu
            // 
            lbGhichu.AutoSize = true;
            lbGhichu.Font = new Font("Segoe UI", 9F);
            lbGhichu.Location = new Point(22, 296);
            lbGhichu.Name = "lbGhichu";
            lbGhichu.Size = new Size(61, 20);
            lbGhichu.TabIndex = 16;
            lbGhichu.Text = "Ghi chú:";
            // 
            // txtTenHoa
            // 
            txtTenHoa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTenHoa.Font = new Font("Segoe UI", 9F);
            txtTenHoa.Location = new Point(138, 95);
            txtTenHoa.Name = "txtTenHoa";
            txtTenHoa.Size = new Size(318, 27);
            txtTenHoa.TabIndex = 15;
            // 
            // txtGia
            // 
            txtGia.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtGia.Font = new Font("Segoe UI", 9F);
            txtGia.Location = new Point(138, 140);
            txtGia.Name = "txtGia";
            txtGia.Size = new Size(318, 27);
            txtGia.TabIndex = 14;
            // 
            // cboSoLuong
            // 
            cboSoLuong.DropDownHeight = 250;
            cboSoLuong.Font = new Font("Segoe UI", 9F);
            cboSoLuong.FormattingEnabled = true;
            cboSoLuong.IntegralHeight = false;
            cboSoLuong.Location = new Point(138, 185);
            cboSoLuong.Name = "cboSoLuong";
            cboSoLuong.Size = new Size(136, 28);
            cboSoLuong.TabIndex = 8;
            cboSoLuong.SelectedIndexChanged += cboSoLuong_SelectedIndexChanged;
            // 
            // txtLoaiHoa
            // 
            txtLoaiHoa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLoaiHoa.Font = new Font("Segoe UI", 9F);
            txtLoaiHoa.Location = new Point(138, 239);
            txtLoaiHoa.Name = "txtLoaiHoa";
            txtLoaiHoa.Size = new Size(318, 27);
            txtLoaiHoa.TabIndex = 11;
            // 
            // txtMaHoa
            // 
            txtMaHoa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMaHoa.Font = new Font("Segoe UI", 9F);
            txtMaHoa.Location = new Point(138, 50);
            txtMaHoa.Name = "txtMaHoa";
            txtMaHoa.Size = new Size(318, 27);
            txtMaHoa.TabIndex = 11;
            // 
            // lbLoaiHoa
            // 
            lbLoaiHoa.AutoSize = true;
            lbLoaiHoa.Font = new Font("Segoe UI", 9F);
            lbLoaiHoa.Location = new Point(22, 239);
            lbLoaiHoa.Name = "lbLoaiHoa";
            lbLoaiHoa.Size = new Size(69, 20);
            lbLoaiHoa.TabIndex = 8;
            lbLoaiHoa.Text = "Loại hoa:";
            // 
            // lbSoLuong
            // 
            lbSoLuong.AutoSize = true;
            lbSoLuong.Font = new Font("Segoe UI", 9F);
            lbSoLuong.Location = new Point(22, 193);
            lbSoLuong.Name = "lbSoLuong";
            lbSoLuong.Size = new Size(72, 20);
            lbSoLuong.TabIndex = 6;
            lbSoLuong.Text = "Số lượng:";
            // 
            // lbGia
            // 
            lbGia.AutoSize = true;
            lbGia.Font = new Font("Segoe UI", 9F);
            lbGia.Location = new Point(22, 149);
            lbGia.Name = "lbGia";
            lbGia.Size = new Size(63, 20);
            lbGia.TabIndex = 5;
            lbGia.Text = "Giá bán:";
            // 
            // lbTenHoa
            // 
            lbTenHoa.AutoSize = true;
            lbTenHoa.Font = new Font("Segoe UI", 9F);
            lbTenHoa.Location = new Point(22, 101);
            lbTenHoa.Name = "lbTenHoa";
            lbTenHoa.Size = new Size(64, 20);
            lbTenHoa.TabIndex = 4;
            lbTenHoa.Text = "Tên hoa:";
            // 
            // lbMaHoa
            // 
            lbMaHoa.AutoSize = true;
            lbMaHoa.Font = new Font("Segoe UI", 9F);
            lbMaHoa.Location = new Point(22, 53);
            lbMaHoa.Name = "lbMaHoa";
            lbMaHoa.Size = new Size(62, 20);
            lbMaHoa.TabIndex = 3;
            lbMaHoa.Text = "Mã hoa:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgDSHoa);
            groupBox1.Controls.Add(pnlSearch);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(12, 8, 12, 12);
            groupBox1.Size = new Size(764, 616);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách hoa";
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
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.Padding = new Padding(6, 0, 6, 0);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgDSHoa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgDSHoa.ColumnHeadersHeight = 36;
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
            dgDSHoa.Location = new Point(12, 76);
            dgDSHoa.Name = "dgDSHoa";
            dgDSHoa.ReadOnly = true;
            dgDSHoa.RowHeadersVisible = false;
            dgDSHoa.RowHeadersWidth = 51;
            dgDSHoa.RowTemplate.Height = 36;
            dgDSHoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgDSHoa.Size = new Size(740, 528);
            dgDSHoa.TabIndex = 11;
            dgDSHoa.CellContentClick += dgDSHoa_CellContentClick;
            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(btnTim);
            pnlSearch.Controls.Add(txtTim);
            pnlSearch.Controls.Add(label8);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(12, 31);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Padding = new Padding(8, 6, 8, 6);
            pnlSearch.Size = new Size(740, 45);
            pnlSearch.TabIndex = 12;
            // 
            // btnTim
            // 
            btnTim.BackColor = Color.FromArgb(52, 152, 219);
            btnTim.Dock = DockStyle.Right;
            btnTim.FlatAppearance.BorderSize = 0;
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTim.ForeColor = Color.White;
            btnTim.Location = new Point(640, 6);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(92, 33);
            btnTim.TabIndex = 8;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = false;
            // 
            // txtTim
            // 
            txtTim.Dock = DockStyle.Fill;
            txtTim.Font = new Font("Segoe UI", 9F);
            txtTim.Location = new Point(81, 6);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(651, 27);
            txtTim.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Left;
            label8.Font = new Font("Segoe UI", 9F);
            label8.Location = new Point(8, 6);
            label8.Name = "label8";
            label8.Size = new Size(73, 20);
            label8.TabIndex = 9;
            label8.Text = "Tìm kiếm:";
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
            btnThem.Size = new Size(120, 33);
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
            btnSua.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(138, 11);
            btnSua.Margin = new Padding(3, 3, 12, 8);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(120, 33);
            btnSua.TabIndex = 4;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(273, 11);
            btnXoa.Margin = new Padding(3, 3, 12, 8);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(120, 33);
            btnXoa.TabIndex = 5;
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
            btnLuu.Location = new Point(408, 11);
            btnLuu.Margin = new Padding(3, 3, 12, 8);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(120, 33);
            btnLuu.TabIndex = 6;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // FrmHoa
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
            Name = "FrmHoa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Hoa";
            Load += frmQuanLiHoa_Load;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgDSHoa).EndInit();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            flpButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label lbGia;
        private Label lbTenHoa;
        private Label lbMaHoa;
        private Label lbTen;
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
        private DataGridView dgDSHoa;
        private ComboBox cboSoLuong;
        private TextBox txtTenHoa;
        private TextBox txtGia;
        private TextBox txtGhichu;
        private Label lbGhichu;
    }
}
