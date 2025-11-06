namespace QuanLiDonHang
{
    partial class FormDonHang
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            headerPanel = new Panel();
            lblTitle = new Label();
            tlpInfo = new TableLayoutPanel();
            lblTenKhach = new Label();
            txtTenKhach = new TextBox();
            lblMaDon = new Label();
            txtMaDon = new TextBox();
            lblSdt = new Label();
            txtSdt = new TextBox();
            lblMaKM = new Label();
            txtMaKM = new TextBox();
            lblMaNV = new Label();
            txtMaNV = new TextBox();
            lblNgay = new Label();
            dtpNgay = new DateTimePicker();
            lblTongSoLuong = new Label();
            nudTongSoLuong = new NumericUpDown();
            splitMain = new SplitContainer();
            gbDonHang = new GroupBox();
            dgvDonHang = new DataGridView();
            colMaDon = new DataGridViewTextBoxColumn();
            colNgay = new DataGridViewTextBoxColumn();
            colTenKhach = new DataGridViewTextBoxColumn();
            colSDT = new DataGridViewTextBoxColumn();
            colMaNV = new DataGridViewTextBoxColumn();
            colTenHoa = new DataGridViewTextBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colGia = new DataGridViewTextBoxColumn();
            flpDonButtons = new FlowLayoutPanel();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            gbChiTiet = new GroupBox();
            dgvChiTiet = new DataGridView();
            colCT_SanPham = new DataGridViewTextBoxColumn();
            colCT_SoLuong = new DataGridViewTextBoxColumn();
            colCT_DonGia = new DataGridViewTextBoxColumn();
            menuStrip1 = new MenuStrip();
            mnuTrangChu = new ToolStripMenuItem();
            mnuQuanLy = new ToolStripMenuItem();
            mnuKhachHang = new ToolStripMenuItem();
            mnuDonHang = new ToolStripMenuItem();
            mnuThongKe = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            headerPanel.SuspendLayout();
            tlpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudTongSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            gbDonHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDonHang).BeginInit();
            flpDonButtons.SuspendLayout();
            gbChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(52, 152, 219);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(0);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(24, 12, 24, 12);
            headerPanel.Size = new Size(1280, 60);
            headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Left;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(24, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(218, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý đơn hàng";
            // 
            // tlpInfo
            // 
            tlpInfo.ColumnCount = 4;
            tlpInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tlpInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlpInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tlpInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlpInfo.Controls.Add(lblTenKhach, 0, 0);
            tlpInfo.Controls.Add(txtTenKhach, 1, 0);
            tlpInfo.Controls.Add(lblMaDon, 2, 0);
            tlpInfo.Controls.Add(txtMaDon, 3, 0);
            tlpInfo.Controls.Add(lblSdt, 0, 1);
            tlpInfo.Controls.Add(txtSdt, 1, 1);
            tlpInfo.Controls.Add(lblMaKM, 2, 1);
            tlpInfo.Controls.Add(txtMaKM, 3, 1);
            tlpInfo.Controls.Add(lblMaNV, 0, 2);
            tlpInfo.Controls.Add(txtMaNV, 1, 2);
            tlpInfo.Controls.Add(lblNgay, 2, 2);
            tlpInfo.Controls.Add(dtpNgay, 3, 2);
            tlpInfo.Controls.Add(lblTongSoLuong, 0, 3);
            tlpInfo.Controls.Add(nudTongSoLuong, 1, 3);
            tlpInfo.Dock = DockStyle.Top;
            tlpInfo.Location = new Point(0, 88);
            tlpInfo.Name = "tlpInfo";
            tlpInfo.Padding = new Padding(16, 12, 16, 12);
            tlpInfo.RowCount = 4;
            tlpInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpInfo.Size = new Size(1280, 188);
            tlpInfo.TabIndex = 1;
            // 
            // lblTenKhach
            // 
            lblTenKhach.Anchor = AnchorStyles.Left;
            lblTenKhach.AutoSize = true;
            lblTenKhach.Font = new Font("Segoe UI", 10F);
            lblTenKhach.Location = new Point(19, 20);
            lblTenKhach.Name = "lblTenKhach";
            lblTenKhach.Size = new Size(130, 23);
            lblTenKhach.TabIndex = 0;
            lblTenKhach.Text = "Tên khách hàng";
            // 
            // txtTenKhach
            // 
            txtTenKhach.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTenKhach.Font = new Font("Segoe UI", 10F);
            txtTenKhach.Location = new Point(206, 17);
            txtTenKhach.Margin = new Padding(3, 3, 16, 3);
            txtTenKhach.Name = "txtTenKhach";
            txtTenKhach.Size = new Size(417, 30);
            txtTenKhach.TabIndex = 1;
            // 
            // lblMaDon
            // 
            lblMaDon.Anchor = AnchorStyles.Left;
            lblMaDon.AutoSize = true;
            lblMaDon.Font = new Font("Segoe UI", 10F);
            lblMaDon.Location = new Point(642, 20);
            lblMaDon.Name = "lblMaDon";
            lblMaDon.Size = new Size(69, 23);
            lblMaDon.TabIndex = 2;
            lblMaDon.Text = "Mã đơn";
            // 
            // txtMaDon
            // 
            txtMaDon.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtMaDon.Font = new Font("Segoe UI", 10F);
            txtMaDon.Location = new Point(829, 17);
            txtMaDon.Margin = new Padding(3, 3, 16, 3);
            txtMaDon.Name = "txtMaDon";
            txtMaDon.Size = new Size(419, 30);
            txtMaDon.TabIndex = 3;
            // 
            // lblSdt
            // 
            lblSdt.Anchor = AnchorStyles.Left;
            lblSdt.AutoSize = true;
            lblSdt.Font = new Font("Segoe UI", 10F);
            lblSdt.Location = new Point(19, 60);
            lblSdt.Name = "lblSdt";
            lblSdt.Size = new Size(134, 23);
            lblSdt.TabIndex = 4;
            lblSdt.Text = "SĐT khách hàng";
            // 
            // txtSdt
            // 
            txtSdt.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSdt.Font = new Font("Segoe UI", 10F);
            txtSdt.Location = new Point(206, 57);
            txtSdt.Margin = new Padding(3, 3, 16, 3);
            txtSdt.Name = "txtSdt";
            txtSdt.Size = new Size(417, 30);
            txtSdt.TabIndex = 5;
            // 
            // lblMaKM
            // 
            lblMaKM.Anchor = AnchorStyles.Left;
            lblMaKM.AutoSize = true;
            lblMaKM.Font = new Font("Segoe UI", 10F);
            lblMaKM.Location = new Point(642, 60);
            lblMaKM.Name = "lblMaKM";
            lblMaKM.Size = new Size(127, 23);
            lblMaKM.TabIndex = 6;
            lblMaKM.Text = "Mã khuyến mãi";
            // 
            // txtMaKM
            // 
            txtMaKM.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtMaKM.Font = new Font("Segoe UI", 10F);
            txtMaKM.Location = new Point(829, 57);
            txtMaKM.Margin = new Padding(3, 3, 16, 3);
            txtMaKM.Name = "txtMaKM";
            txtMaKM.Size = new Size(419, 30);
            txtMaKM.TabIndex = 7;
            // 
            // lblMaNV
            // 
            lblMaNV.Anchor = AnchorStyles.Left;
            lblMaNV.AutoSize = true;
            lblMaNV.Font = new Font("Segoe UI", 10F);
            lblMaNV.Location = new Point(19, 100);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Size = new Size(114, 23);
            lblMaNV.TabIndex = 8;
            lblMaNV.Text = "Mã nhân viên";
            // 
            // txtMaNV
            // 
            txtMaNV.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtMaNV.Font = new Font("Segoe UI", 10F);
            txtMaNV.Location = new Point(206, 97);
            txtMaNV.Margin = new Padding(3, 3, 16, 3);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(417, 30);
            txtMaNV.TabIndex = 9;
            // 
            // lblNgay
            // 
            lblNgay.Anchor = AnchorStyles.Left;
            lblNgay.AutoSize = true;
            lblNgay.Font = new Font("Segoe UI", 10F);
            lblNgay.Location = new Point(642, 100);
            lblNgay.Name = "lblNgay";
            lblNgay.Size = new Size(50, 23);
            lblNgay.TabIndex = 10;
            lblNgay.Text = "Ngày";
            // 
            // dtpNgay
            // 
            dtpNgay.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpNgay.CalendarFont = new Font("Segoe UI", 10F);
            dtpNgay.CustomFormat = "dddd, dd/MM/yyyy";
            dtpNgay.Font = new Font("Segoe UI", 10F);
            dtpNgay.Format = DateTimePickerFormat.Custom;
            dtpNgay.Location = new Point(829, 97);
            dtpNgay.Margin = new Padding(3, 3, 16, 3);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.Size = new Size(419, 30);
            dtpNgay.TabIndex = 11;
            // 
            // lblTongSoLuong
            // 
            lblTongSoLuong.Anchor = AnchorStyles.Left;
            lblTongSoLuong.AutoSize = true;
            lblTongSoLuong.Font = new Font("Segoe UI", 10F);
            lblTongSoLuong.Location = new Point(19, 142);
            lblTongSoLuong.Name = "lblTongSoLuong";
            lblTongSoLuong.Size = new Size(120, 23);
            lblTongSoLuong.TabIndex = 12;
            lblTongSoLuong.Text = "Tổng số lượng";
            // 
            // nudTongSoLuong
            // 
            nudTongSoLuong.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nudTongSoLuong.Font = new Font("Segoe UI", 10F);
            nudTongSoLuong.Location = new Point(206, 139);
            nudTongSoLuong.Margin = new Padding(3, 3, 16, 3);
            nudTongSoLuong.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudTongSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudTongSoLuong.Name = "nudTongSoLuong";
            nudTongSoLuong.Size = new Size(417, 30);
            nudTongSoLuong.TabIndex = 13;
            nudTongSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // splitMain
            // 
            splitMain.Dock = DockStyle.Fill;
            splitMain.Location = new Point(0, 276);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(gbDonHang);
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(gbChiTiet);
            splitMain.Size = new Size(1280, 484);
            splitMain.SplitterDistance = 760;
            splitMain.TabIndex = 2;
            // 
            // gbDonHang
            // 
            gbDonHang.Controls.Add(dgvDonHang);
            gbDonHang.Controls.Add(flpDonButtons);
            gbDonHang.Dock = DockStyle.Fill;
            gbDonHang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbDonHang.Location = new Point(0, 0);
            gbDonHang.Name = "gbDonHang";
            gbDonHang.Padding = new Padding(12, 8, 12, 12);
            gbDonHang.Size = new Size(760, 484);
            gbDonHang.TabIndex = 0;
            gbDonHang.TabStop = false;
            gbDonHang.Text = "Danh sách đơn hàng";
            // 
            // dgvDonHang
            // 
            dgvDonHang.AllowUserToAddRows = false;
            dgvDonHang.AllowUserToDeleteRows = false;
            dgvDonHang.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(242, 242, 242);
            dgvDonHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDonHang.BackgroundColor = Color.White;
            dgvDonHang.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.LightGray;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvDonHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDonHang.ColumnHeadersHeight = 40;
            dgvDonHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDonHang.Columns.AddRange(new DataGridViewColumn[] { colMaDon, colNgay, colTenKhach, colSDT, colMaNV, colTenHoa, colSoLuong, colGia });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Window;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle7.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dgvDonHang.DefaultCellStyle = dataGridViewCellStyle7;
            dgvDonHang.Dock = DockStyle.Fill;
            dgvDonHang.EnableHeadersVisualStyles = false;
            dgvDonHang.GridColor = Color.LightSteelBlue;
            dgvDonHang.Location = new Point(12, 31);
            dgvDonHang.MultiSelect = false;
            dgvDonHang.Name = "dgvDonHang";
            dgvDonHang.ReadOnly = true;
            dgvDonHang.RowHeadersVisible = false;
            dgvDonHang.RowHeadersWidth = 51;
            dgvDonHang.RowTemplate.Height = 32;
            dgvDonHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDonHang.Size = new Size(736, 381);
            dgvDonHang.TabIndex = 0;
            dgvDonHang.SelectionChanged += dgvDonHang_SelectionChanged;
            // 
            // colMaDon
            // 
            colMaDon.FillWeight = 15F;
            colMaDon.HeaderText = "Mã Đơn";
            colMaDon.MinimumWidth = 6;
            colMaDon.Name = "colMaDon";
            colMaDon.ReadOnly = true;
            colMaDon.Width = 80;
            // 
            // colNgay
            // 
            colNgay.FillWeight = 14F;
            colNgay.HeaderText = "Ngày";
            colNgay.MinimumWidth = 6;
            colNgay.Name = "colNgay";
            colNgay.ReadOnly = true;
            colNgay.Width = 120;
            // 
            // colTenKhach
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            colTenKhach.DefaultCellStyle = dataGridViewCellStyle3;
            colTenKhach.FillWeight = 22F;
            colTenKhach.HeaderText = "Tên khách";
            colTenKhach.MinimumWidth = 6;
            colTenKhach.Name = "colTenKhach";
            colTenKhach.ReadOnly = true;
            colTenKhach.Width = 220;
            // 
            // colSDT
            // 
            colSDT.FillWeight = 12F;
            colSDT.HeaderText = "SĐT";
            colSDT.MinimumWidth = 6;
            colSDT.Name = "colSDT";
            colSDT.ReadOnly = true;
            colSDT.Width = 120;
            // 
            // colMaNV
            // 
            colMaNV.FillWeight = 10F;
            colMaNV.HeaderText = "Mã NV";
            colMaNV.MinimumWidth = 6;
            colMaNV.Name = "colMaNV";
            colMaNV.ReadOnly = true;
            colMaNV.Width = 80;
            // 
            // colTenHoa
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            colTenHoa.DefaultCellStyle = dataGridViewCellStyle4;
            colTenHoa.FillWeight = 20F;
            colTenHoa.HeaderText = "Tên Hàng";
            colTenHoa.MinimumWidth = 6;
            colTenHoa.Name = "colTenHoa";
            colTenHoa.ReadOnly = true;
            colTenHoa.Width = 260;
            // 
            // colSoLuong
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
            colSoLuong.DefaultCellStyle = dataGridViewCellStyle5;
            colSoLuong.FillWeight = 6F;
            colSoLuong.HeaderText = "Số Lượng";
            colSoLuong.MinimumWidth = 6;
            colSoLuong.Name = "colSoLuong";
            colSoLuong.ReadOnly = true;
            colSoLuong.Width = 80;
            // 
            // colGia
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
            colGia.DefaultCellStyle = dataGridViewCellStyle6;
            colGia.FillWeight = 14F;
            colGia.HeaderText = "Tổng tiền";
            colGia.MinimumWidth = 6;
            colGia.Name = "colGia";
            colGia.ReadOnly = true;
            colGia.Width = 120;
            // 
            // flpDonButtons
            // 
            flpDonButtons.AutoSize = true;
            flpDonButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpDonButtons.Controls.Add(btnThem);
            flpDonButtons.Controls.Add(btnSua);
            flpDonButtons.Controls.Add(btnXoa);
            flpDonButtons.Dock = DockStyle.Bottom;
            flpDonButtons.Location = new Point(12, 412);
            flpDonButtons.Name = "flpDonButtons";
            flpDonButtons.Padding = new Padding(0, 8, 0, 0);
            flpDonButtons.Size = new Size(736, 60);
            flpDonButtons.TabIndex = 1;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(46, 204, 113);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(3, 19);
            btnThem.Margin = new Padding(3, 11, 8, 8);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(90, 33);
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
            btnSua.Location = new Point(104, 19);
            btnSua.Margin = new Padding(3, 11, 8, 8);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(90, 33);
            btnSua.TabIndex = 1;
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
            btnXoa.Location = new Point(205, 19);
            btnXoa.Margin = new Padding(3, 11, 8, 8);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(90, 33);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // gbChiTiet
            // 
            gbChiTiet.Controls.Add(dgvChiTiet);
            gbChiTiet.Dock = DockStyle.Fill;
            gbChiTiet.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbChiTiet.Location = new Point(0, 0);
            gbChiTiet.Name = "gbChiTiet";
            gbChiTiet.Padding = new Padding(12, 8, 12, 12);
            gbChiTiet.Size = new Size(516, 484);
            gbChiTiet.TabIndex = 0;
            gbChiTiet.TabStop = false;
            gbChiTiet.Text = "Chi tiết đơn hàng";
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AllowUserToDeleteRows = false;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(242, 242, 242);
            dgvChiTiet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.BackgroundColor = Color.White;
            dgvChiTiet.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.LightGray;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle9.ForeColor = Color.Black;
            dataGridViewCellStyle9.Padding = new Padding(8, 0, 8, 0);
            dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvChiTiet.ColumnHeadersHeight = 36;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvChiTiet.Columns.AddRange(new DataGridViewColumn[] { colCT_SanPham, colCT_SoLuong, colCT_DonGia });
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = SystemColors.Window;
            dataGridViewCellStyle13.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle13.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle13.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle13.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle13.SelectionForeColor = Color.White;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.False;
            dgvChiTiet.DefaultCellStyle = dataGridViewCellStyle13;
            dgvChiTiet.Dock = DockStyle.Fill;
            dgvChiTiet.EnableHeadersVisualStyles = false;
            dgvChiTiet.GridColor = Color.LightSteelBlue;
            dgvChiTiet.Location = new Point(12, 31);
            dgvChiTiet.MultiSelect = false;
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.RowHeadersVisible = false;
            dgvChiTiet.RowHeadersWidth = 51;
            dgvChiTiet.RowTemplate.Height = 32;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.Size = new Size(492, 441);
            dgvChiTiet.TabIndex = 2;
            // 
            // colCT_SanPham
            // 
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            colCT_SanPham.DefaultCellStyle = dataGridViewCellStyle10;
            colCT_SanPham.FillWeight = 70F;
            colCT_SanPham.HeaderText = "Sản phẩm";
            colCT_SanPham.MinimumWidth = 160;
            colCT_SanPham.Name = "colCT_SanPham";
            colCT_SanPham.ReadOnly = true;
            // 
            // colCT_SoLuong
            // 
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCT_SoLuong.DefaultCellStyle = dataGridViewCellStyle11;
            colCT_SoLuong.FillWeight = 15F;
            colCT_SoLuong.HeaderText = "Số lượng";
            colCT_SoLuong.MinimumWidth = 70;
            colCT_SoLuong.Name = "colCT_SoLuong";
            colCT_SoLuong.ReadOnly = true;
            // 
            // colCT_DonGia
            // 
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCT_DonGia.DefaultCellStyle = dataGridViewCellStyle12;
            colCT_DonGia.FillWeight = 15F;
            colCT_DonGia.HeaderText = "Đơn giá";
            colCT_DonGia.MinimumWidth = 90;
            colCT_DonGia.Name = "colCT_DonGia";
            colCT_DonGia.ReadOnly = true;
            // 
            // menuStrip1
            // 
            menuStrip1.AllowItemReorder = true;
            menuStrip1.BackColor = Color.SkyBlue;
            menuStrip1.Font = new Font("Segoe UI", 9F);
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuTrangChu, mnuQuanLy, mnuDangXuat });
            menuStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            menuStrip1.Location = new Point(0, 60);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1280, 28);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuTrangChu
            // 
            mnuTrangChu.Name = "mnuTrangChu";
            mnuTrangChu.Size = new Size(89, 24);
            mnuTrangChu.Text = "Trang Chủ";
            // 
            // mnuQuanLy
            // 
            mnuQuanLy.DropDownItems.AddRange(new ToolStripItem[] { mnuKhachHang, mnuDonHang, mnuThongKe });
            mnuQuanLy.Name = "mnuQuanLy";
            mnuQuanLy.Size = new Size(73, 24);
            mnuQuanLy.Text = "Quản lý";
            // 
            // mnuKhachHang
            // 
            mnuKhachHang.Name = "mnuKhachHang";
            mnuKhachHang.Size = new Size(218, 26);
            mnuKhachHang.Text = "Khách Hàng";
            // 
            // mnuDonHang
            // 
            mnuDonHang.Name = "mnuDonHang";
            mnuDonHang.Size = new Size(218, 26);
            mnuDonHang.Text = "Đơn Hàng";
            // 
            // mnuThongKe
            // 
            mnuThongKe.Name = "mnuThongKe";
            mnuThongKe.Size = new Size(218, 26);
            mnuThongKe.Text = "Thống Kê, Báo Cáo";
            // 
            // mnuDangXuat
            // 
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Size = new Size(91, 24);
            mnuDangXuat.Text = "Đăng xuất";
            // 
            // FormDonHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1280, 760);
            Controls.Add(splitMain);
            Controls.Add(tlpInfo);
            Controls.Add(menuStrip1);
            Controls.Add(headerPanel);
            Font = new Font("Segoe UI", 9F);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1000, 700);
            Name = "FormDonHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý đơn hàng";
            Load += FormDonHang_Load;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            tlpInfo.ResumeLayout(false);
            tlpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudTongSoLuong).EndInit();
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            gbDonHang.ResumeLayout(false);
            gbDonHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDonHang).EndInit();
            flpDonButtons.ResumeLayout(false);
            gbChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tlpInfo;
        private System.Windows.Forms.Label lblTenKhach;
        private System.Windows.Forms.TextBox txtTenKhach;
        private System.Windows.Forms.Label lblMaDon;
        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Label lblSdt;
        private System.Windows.Forms.TextBox txtSdt;
        private System.Windows.Forms.Label lblMaKM;
        private System.Windows.Forms.TextBox txtMaKM;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Label lblTongSoLuong;
        private System.Windows.Forms.NumericUpDown nudTongSoLuong;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.GroupBox gbDonHang;
        private System.Windows.Forms.DataGridView dgvDonHang;
        private System.Windows.Forms.FlowLayoutPanel flpDonButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.GroupBox gbChiTiet;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuTrangChu;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanLy;
        private System.Windows.Forms.ToolStripMenuItem mnuKhachHang;
        private System.Windows.Forms.ToolStripMenuItem mnuDonHang;
        private System.Windows.Forms.ToolStripMenuItem mnuThongKe;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;

        // Columns for DataGridView (design-time)
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKhach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenHoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGia;

        private System.Windows.Forms.DataGridViewTextBoxColumn colCT_SanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCT_SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCT_DonGia;
    }
}

