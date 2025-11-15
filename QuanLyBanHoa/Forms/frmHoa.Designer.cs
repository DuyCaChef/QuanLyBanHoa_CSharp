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
            panelActions = new Panel();
            btnTaiLai = new Button();
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
            groupBox1.Location = new Point(380, 48);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(13);
            groupBox1.Size = new Size(882, 582);
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
            dgDSHoa.Location = new Point(13, 86);
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
            dgDSHoa.Size = new Size(856, 483);
            dgDSHoa.TabIndex = 11;
            dgDSHoa.SelectionChanged += dgDSHoa_SelectionChanged;
            // 
            // panelSearch
            // 
            panelSearch.Controls.Add(btnTim);
            panelSearch.Controls.Add(txtTim);
            panelSearch.Controls.Add(label8);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(13, 40);
            panelSearch.Name = "panelSearch";
            panelSearch.Padding = new Padding(0, 5, 0, 5);
            panelSearch.Size = new Size(856, 46);
            panelSearch.TabIndex = 100;
            // 
            // btnTim
            // 
            btnTim.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTim.BackColor = Color.FromArgb(255, 128, 128);
            btnTim.FlatAppearance.BorderSize = 0;
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTim.ForeColor = Color.White;
            btnTim.Location = new Point(714, 8);
            btnTim.Margin = new Padding(2);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(128, 34);
            btnTim.TabIndex = 8;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = false;
            btnTim.Click += btnTim_Click;
            // 
            // txtTim
            // 
            txtTim.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTim.Font = new Font("Segoe UI", 9F);
            txtTim.Location = new Point(97, 11);
            txtTim.Margin = new Padding(2);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(613, 27);
            txtTim.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(13, 14);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(78, 20);
            label8.TabIndex = 9;
            label8.Text = "Tìm kiếm:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(layoutInfo);
            groupBox2.Dock = DockStyle.Left;
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(0, 48);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(13);
            groupBox2.Size = new Size(380, 582);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông Tin Hoa";
            // 
            // layoutInfo
            // 
            layoutInfo.ColumnCount = 2;
            layoutInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
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
            layoutInfo.Location = new Point(13, 40);
            layoutInfo.Margin = new Padding(0);
            layoutInfo.Name = "layoutInfo";
            layoutInfo.Padding = new Padding(5);
            layoutInfo.RowCount = 6;
            layoutInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            layoutInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            layoutInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            layoutInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            layoutInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            layoutInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutInfo.Size = new Size(354, 529);
            layoutInfo.TabIndex = 0;
            // 
            // lbMaHoa
            // 
            lbMaHoa.AutoSize = true;
            lbMaHoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbMaHoa.Location = new Point(7, 11);
            lbMaHoa.Margin = new Padding(2, 6, 2, 0);
            lbMaHoa.Name = "lbMaHoa";
            lbMaHoa.Size = new Size(65, 20);
            lbMaHoa.TabIndex = 3;
            lbMaHoa.Text = "Mã hoa:";
            // 
            // txtMaHoa
            // 
            txtMaHoa.Dock = DockStyle.Fill;
            txtMaHoa.Font = new Font("Segoe UI", 9F);
            txtMaHoa.Location = new Point(97, 7);
            txtMaHoa.Margin = new Padding(2);
            txtMaHoa.Name = "txtMaHoa";
            txtMaHoa.ReadOnly = true;
            txtMaHoa.Size = new Size(250, 27);
            txtMaHoa.TabIndex = 0;
            // 
            // lbTenHoa
            // 
            lbTenHoa.AutoSize = true;
            lbTenHoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbTenHoa.Location = new Point(7, 45);
            lbTenHoa.Margin = new Padding(2, 6, 2, 0);
            lbTenHoa.Name = "lbTenHoa";
            lbTenHoa.Size = new Size(68, 20);
            lbTenHoa.TabIndex = 4;
            lbTenHoa.Text = "Tên hoa:";
            // 
            // txtTenHoa
            // 
            txtTenHoa.Dock = DockStyle.Fill;
            txtTenHoa.Font = new Font("Segoe UI", 9F);
            txtTenHoa.Location = new Point(97, 41);
            txtTenHoa.Margin = new Padding(2);
            txtTenHoa.Name = "txtTenHoa";
            txtTenHoa.Size = new Size(250, 27);
            txtTenHoa.TabIndex = 1;
            // 
            // lbGia
            // 
            lbGia.AutoSize = true;
            lbGia.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbGia.Location = new Point(7, 79);
            lbGia.Margin = new Padding(2, 6, 2, 0);
            lbGia.Name = "lbGia";
            lbGia.Size = new Size(66, 20);
            lbGia.TabIndex = 5;
            lbGia.Text = "Giá bán:";
            // 
            // txtGia
            // 
            txtGia.Dock = DockStyle.Fill;
            txtGia.Font = new Font("Segoe UI", 9F);
            txtGia.Location = new Point(97, 75);
            txtGia.Margin = new Padding(2);
            txtGia.Name = "txtGia";
            txtGia.Size = new Size(250, 27);
            txtGia.TabIndex = 2;
            // 
            // lbSoLuong
            // 
            lbSoLuong.AutoSize = true;
            lbSoLuong.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbSoLuong.Location = new Point(7, 113);
            lbSoLuong.Margin = new Padding(2, 6, 2, 0);
            lbSoLuong.Name = "lbSoLuong";
            lbSoLuong.Size = new Size(75, 20);
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
            cboSoLuong.Location = new Point(97, 109);
            cboSoLuong.Margin = new Padding(2);
            cboSoLuong.Name = "cboSoLuong";
            cboSoLuong.Size = new Size(121, 28);
            cboSoLuong.TabIndex = 3;
            cboSoLuong.SelectedIndexChanged += cboSoLuong_SelectedIndexChanged;
            // 
            // lbGhichu
            // 
            lbGhichu.AutoSize = true;
            lbGhichu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbGhichu.Location = new Point(7, 153);
            lbGhichu.Margin = new Padding(2, 6, 2, 0);
            lbGhichu.Name = "lbGhichu";
            lbGhichu.Size = new Size(54, 20);
            lbGhichu.TabIndex = 16;
            lbGhichu.Text = "Mô tả:";
            // 
            // txtGhichu
            // 
            layoutInfo.SetColumnSpan(txtGhichu, 2);
            txtGhichu.Dock = DockStyle.Fill;
            txtGhichu.Font = new Font("Segoe UI", 9F);
            txtGhichu.Location = new Point(7, 177);
            txtGhichu.Margin = new Padding(2);
            txtGhichu.Multiline = true;
            txtGhichu.Name = "txtGhichu";
            txtGhichu.ScrollBars = ScrollBars.Vertical;
            txtGhichu.Size = new Size(340, 345);
            txtGhichu.TabIndex = 4;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(46, 204, 113);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(13, 8);
            btnThem.Margin = new Padding(2);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(96, 32);
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
            btnSua.Location = new Point(122, 8);
            btnSua.Margin = new Padding(2);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(96, 32);
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
            btnXoa.Location = new Point(230, 8);
            btnXoa.Margin = new Padding(2);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(96, 32);
            btnXoa.TabIndex = 5;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // panelActions
            // 
            panelActions.BackColor = Color.WhiteSmoke;
            panelActions.Controls.Add(btnTaiLai);
            panelActions.Controls.Add(btnXoa);
            panelActions.Controls.Add(btnSua);
            panelActions.Controls.Add(btnThem);
            panelActions.Dock = DockStyle.Bottom;
            panelActions.Location = new Point(0, 630);
            panelActions.Margin = new Padding(2);
            panelActions.Name = "panelActions";
            panelActions.Padding = new Padding(6);
            panelActions.Size = new Size(1262, 45);
            panelActions.TabIndex = 102;
            // 
            // btnTaiLai
            // 
            btnTaiLai.BackColor = Color.Gold;
            btnTaiLai.FlatAppearance.BorderSize = 0;
            btnTaiLai.FlatStyle = FlatStyle.Flat;
            btnTaiLai.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTaiLai.ForeColor = Color.White;
            btnTaiLai.Location = new Point(340, 8);
            btnTaiLai.Margin = new Padding(2);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(96, 32);
            btnTaiLai.TabIndex = 6;
            btnTaiLai.Text = "Tải Lại";
            btnTaiLai.UseVisualStyleBackColor = false;
            btnTaiLai.Click += btnTaiLai_Click;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(255, 128, 128);
            headerPanel.Controls.Add(lblHeaderTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(2);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(19, 10, 19, 10);
            headerPanel.Size = new Size(1262, 48);
            headerPanel.TabIndex = 103;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(19, 12);
            lblHeaderTitle.Margin = new Padding(2, 0, 2, 0);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(151, 32);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Quản lý hoa";
            // 
            // frmHoa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1262, 675);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(panelActions);
            Controls.Add(headerPanel);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private Button btnTaiLai;
    }
}
