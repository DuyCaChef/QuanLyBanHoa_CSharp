namespace QuanLyBanHoa.Forms
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
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            headerPanel = new Panel();
            lblTitle = new Label();
            mainScrollPanel = new Panel();
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
            flpDonButtons = new FlowLayoutPanel();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            gbChiTiet = new GroupBox();
            dgvChiTiet = new DataGridView();
            colCT_SanPham = new DataGridViewTextBoxColumn();
            colCT_SoLuong = new DataGridViewTextBoxColumn();
            colCT_DonGia = new DataGridViewTextBoxColumn();
            pnlTongTien = new Panel();
            lblTongTienValue = new Label();
            lblTongTienLabel = new Label();
            gbThongTin = new GroupBox();
            tlpInfo = new TableLayoutPanel();
            lblTenKhach = new Label();
            txtTenKhach = new TextBox();
            lblMaDon = new Label();
            txtMaDon = new TextBox();
            lblTenHoa = new Label();
            cboTenHoa = new ComboBox();
            lblSdt = new Label();
            txtSdt = new TextBox();
            lblNgay = new Label();
            dtpNgay = new DateTimePicker();
            lblMaNV = new Label();
            txtMaNV = new TextBox();
            lblMaHoa = new Label();
            txtMaHoa = new TextBox();
            lblTongSoLuong = new Label();
            nudTongSoLuong = new NumericUpDown();
            headerPanel.SuspendLayout();
            mainScrollPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            gbDonHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDonHang).BeginInit();
            flpDonButtons.SuspendLayout();
            gbChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            pnlTongTien.SuspendLayout();
            gbThongTin.SuspendLayout();
            tlpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudTongSoLuong).BeginInit();
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
            headerPanel.Padding = new Padding(30, 15, 30, 15);
            headerPanel.Size = new Size(1600, 75);
            headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Left;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(30, 15);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(253, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý đơn hàng";
            // 
            // mainScrollPanel
            // 
            mainScrollPanel.AutoScroll = true;
            mainScrollPanel.Controls.Add(splitMain);
            mainScrollPanel.Controls.Add(gbThongTin);
            mainScrollPanel.Dock = DockStyle.Fill;
            mainScrollPanel.Location = new Point(0, 75);
            mainScrollPanel.Margin = new Padding(4, 4, 4, 4);
            mainScrollPanel.Name = "mainScrollPanel";
            mainScrollPanel.Size = new Size(1600, 875);
            mainScrollPanel.TabIndex = 5;
            // 
            // splitMain
            // 
            splitMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitMain.Location = new Point(0, 212);
            splitMain.Margin = new Padding(4, 4, 4, 4);
            splitMain.MinimumSize = new Size(1250, 500);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(gbDonHang);
            splitMain.Panel1MinSize = 500;
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(gbChiTiet);
            splitMain.Panel2MinSize = 400;
            splitMain.Size = new Size(1600, 628);
            splitMain.SplitterDistance = 950;
            splitMain.SplitterWidth = 5;
            splitMain.TabIndex = 2;
            // 
            // gbDonHang
            // 
            gbDonHang.Controls.Add(dgvDonHang);
            gbDonHang.Controls.Add(flpDonButtons);
            gbDonHang.Dock = DockStyle.Fill;
            gbDonHang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbDonHang.Location = new Point(0, 0);
            gbDonHang.Margin = new Padding(4, 4, 4, 4);
            gbDonHang.Name = "gbDonHang";
            gbDonHang.Padding = new Padding(15, 10, 15, 15);
            gbDonHang.Size = new Size(950, 628);
            gbDonHang.TabIndex = 0;
            gbDonHang.TabStop = false;
            gbDonHang.Text = "Danh sách đơn hàng";
            // 
            // dgvDonHang
            // 
            dgvDonHang.AllowUserToAddRows = false;
            dgvDonHang.AllowUserToDeleteRows = false;
            dgvDonHang.AllowUserToOrderColumns = true;
            dgvDonHang.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(242, 242, 242);
            dgvDonHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDonHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            dgvDonHang.Columns.AddRange(new DataGridViewColumn[] { colMaDon, colNgay, colTenKhach, colSDT, colMaNV, colTenHoa, colSoLuong });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.Padding = new Padding(8, 4, 8, 4);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvDonHang.DefaultCellStyle = dataGridViewCellStyle6;
            dgvDonHang.Dock = DockStyle.Fill;
            dgvDonHang.EnableHeadersVisualStyles = false;
            dgvDonHang.GridColor = Color.LightSteelBlue;
            dgvDonHang.Location = new Point(15, 37);
            dgvDonHang.Margin = new Padding(4, 4, 4, 4);
            dgvDonHang.MultiSelect = false;
            dgvDonHang.Name = "dgvDonHang";
            dgvDonHang.ReadOnly = true;
            dgvDonHang.RowHeadersVisible = false;
            dgvDonHang.RowHeadersWidth = 51;
            dgvDonHang.RowTemplate.Height = 40;
            dgvDonHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDonHang.Size = new Size(920, 501);
            dgvDonHang.TabIndex = 0;
            dgvDonHang.CellFormatting += dgvDonHang_CellFormatting;
            dgvDonHang.SelectionChanged += dgvDonHang_SelectionChanged;
            // 
            // colMaDon
            // 
            colMaDon.FillWeight = 10F;
            colMaDon.HeaderText = "Mã Đơn";
            colMaDon.MinimumWidth = 60;
            colMaDon.Name = "colMaDon";
            colMaDon.ReadOnly = true;
            // 
            // colNgay
            // 
            colNgay.FillWeight = 12F;
            colNgay.HeaderText = "Ngày";
            colNgay.MinimumWidth = 100;
            colNgay.Name = "colNgay";
            colNgay.ReadOnly = true;
            // 
            // colTenKhach
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            colTenKhach.DefaultCellStyle = dataGridViewCellStyle3;
            colTenKhach.FillWeight = 20F;
            colTenKhach.HeaderText = "Tên khách";
            colTenKhach.MinimumWidth = 120;
            colTenKhach.Name = "colTenKhach";
            colTenKhach.ReadOnly = true;
            // 
            // colSDT
            // 
            colSDT.FillWeight = 14F;
            colSDT.HeaderText = "SĐT";
            colSDT.MinimumWidth = 100;
            colSDT.Name = "colSDT";
            colSDT.ReadOnly = true;
            // 
            // colMaNV
            // 
            colMaNV.FillWeight = 10F;
            colMaNV.HeaderText = "Mã NV";
            colMaNV.MinimumWidth = 70;
            colMaNV.Name = "colMaNV";
            colMaNV.ReadOnly = true;
            // 
            // colTenHoa
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            colTenHoa.DefaultCellStyle = dataGridViewCellStyle4;
            colTenHoa.FillWeight = 14F;
            colTenHoa.HeaderText = "Tên Hàng";
            colTenHoa.MinimumWidth = 110;
            colTenHoa.Name = "colTenHoa";
            colTenHoa.ReadOnly = true;
            // 
            // colSoLuong
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
            colSoLuong.DefaultCellStyle = dataGridViewCellStyle5;
            colSoLuong.FillWeight = 8F;
            colSoLuong.HeaderText = "Số Lượng";
            colSoLuong.MinimumWidth = 80;
            colSoLuong.Name = "colSoLuong";
            colSoLuong.ReadOnly = true;
            // 
            // flpDonButtons
            // 
            flpDonButtons.AutoSize = true;
            flpDonButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpDonButtons.Controls.Add(btnThem);
            flpDonButtons.Controls.Add(btnSua);
            flpDonButtons.Controls.Add(btnXoa);
            flpDonButtons.Dock = DockStyle.Bottom;
            flpDonButtons.Location = new Point(15, 538);
            flpDonButtons.Margin = new Padding(4, 4, 4, 4);
            flpDonButtons.Name = "flpDonButtons";
            flpDonButtons.Padding = new Padding(0, 10, 0, 0);
            flpDonButtons.Size = new Size(920, 75);
            flpDonButtons.TabIndex = 1;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(46, 204, 113);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(4, 24);
            btnThem.Margin = new Padding(4, 14, 10, 10);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(112, 41);
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
            btnSua.Location = new Point(130, 24);
            btnSua.Margin = new Padding(4, 14, 10, 10);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(112, 41);
            btnSua.TabIndex = 1;
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
            btnXoa.Location = new Point(256, 24);
            btnXoa.Margin = new Padding(4, 14, 10, 10);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(112, 41);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // gbChiTiet
            // 
            gbChiTiet.Controls.Add(dgvChiTiet);
            gbChiTiet.Controls.Add(pnlTongTien);
            gbChiTiet.Dock = DockStyle.Fill;
            gbChiTiet.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbChiTiet.Location = new Point(0, 0);
            gbChiTiet.Margin = new Padding(4, 4, 4, 4);
            gbChiTiet.Name = "gbChiTiet";
            gbChiTiet.Padding = new Padding(15, 10, 15, 15);
            gbChiTiet.Size = new Size(645, 628);
            gbChiTiet.TabIndex = 0;
            gbChiTiet.TabStop = false;
            gbChiTiet.Text = "Chi tiết đơn hàng";
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AllowUserToDeleteRows = false;
            dgvChiTiet.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(242, 242, 242);
            dgvChiTiet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.BackgroundColor = Color.White;
            dgvChiTiet.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.LightGray;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.Padding = new Padding(8, 0, 8, 0);
            dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvChiTiet.ColumnHeadersHeight = 36;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvChiTiet.Columns.AddRange(new DataGridViewColumn[] { colCT_SanPham, colCT_SoLuong, colCT_DonGia });
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = SystemColors.Window;
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle12.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle12.Padding = new Padding(8, 4, 8, 4);
            dataGridViewCellStyle12.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle12.SelectionForeColor = Color.White;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            dgvChiTiet.DefaultCellStyle = dataGridViewCellStyle12;
            dgvChiTiet.Dock = DockStyle.Fill;
            dgvChiTiet.EnableHeadersVisualStyles = false;
            dgvChiTiet.GridColor = Color.LightSteelBlue;
            dgvChiTiet.Location = new Point(15, 37);
            dgvChiTiet.Margin = new Padding(4, 4, 4, 4);
            dgvChiTiet.MultiSelect = false;
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.RowHeadersVisible = false;
            dgvChiTiet.RowHeadersWidth = 51;
            dgvChiTiet.RowTemplate.Height = 40;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.Size = new Size(615, 501);
            dgvChiTiet.TabIndex = 2;
            dgvChiTiet.CellFormatting += dgvChiTiet_CellFormatting;
            // 
            // colCT_SanPham
            // 
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            colCT_SanPham.DefaultCellStyle = dataGridViewCellStyle9;
            colCT_SanPham.FillWeight = 60F;
            colCT_SanPham.HeaderText = "Sản phẩm";
            colCT_SanPham.MinimumWidth = 150;
            colCT_SanPham.Name = "colCT_SanPham";
            colCT_SanPham.ReadOnly = true;
            // 
            // colCT_SoLuong
            // 
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCT_SoLuong.DefaultCellStyle = dataGridViewCellStyle10;
            colCT_SoLuong.FillWeight = 20F;
            colCT_SoLuong.HeaderText = "Số lượng";
            colCT_SoLuong.MinimumWidth = 80;
            colCT_SoLuong.Name = "colCT_SoLuong";
            colCT_SoLuong.ReadOnly = true;
            // 
            // colCT_DonGia
            // 
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCT_DonGia.DefaultCellStyle = dataGridViewCellStyle11;
            colCT_DonGia.FillWeight = 20F;
            colCT_DonGia.HeaderText = "Đơn giá";
            colCT_DonGia.MinimumWidth = 90;
            colCT_DonGia.Name = "colCT_DonGia";
            colCT_DonGia.ReadOnly = true;
            // 
            // pnlTongTien
            // 
            pnlTongTien.BackColor = Color.FromArgb(236, 240, 245);
            pnlTongTien.Controls.Add(lblTongTienValue);
            pnlTongTien.Controls.Add(lblTongTienLabel);
            pnlTongTien.Dock = DockStyle.Bottom;
            pnlTongTien.Location = new Point(15, 538);
            pnlTongTien.Margin = new Padding(4, 4, 4, 4);
            pnlTongTien.Name = "pnlTongTien";
            pnlTongTien.Padding = new Padding(15, 10, 15, 10);
            pnlTongTien.Size = new Size(615, 75);
            pnlTongTien.TabIndex = 3;
            // 
            // lblTongTienValue
            // 
            lblTongTienValue.Dock = DockStyle.Fill;
            lblTongTienValue.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTongTienValue.ForeColor = Color.FromArgb(231, 76, 60);
            lblTongTienValue.Location = new Point(165, 10);
            lblTongTienValue.Margin = new Padding(4, 0, 4, 0);
            lblTongTienValue.Name = "lblTongTienValue";
            lblTongTienValue.Size = new Size(435, 55);
            lblTongTienValue.TabIndex = 1;
            lblTongTienValue.Text = "0 đ";
            lblTongTienValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTongTienLabel
            // 
            lblTongTienLabel.Dock = DockStyle.Left;
            lblTongTienLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTongTienLabel.ForeColor = Color.FromArgb(52, 73, 94);
            lblTongTienLabel.Location = new Point(15, 10);
            lblTongTienLabel.Margin = new Padding(4, 0, 4, 0);
            lblTongTienLabel.Name = "lblTongTienLabel";
            lblTongTienLabel.Size = new Size(150, 55);
            lblTongTienLabel.TabIndex = 0;
            lblTongTienLabel.Text = "Tổng tiền:";
            lblTongTienLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gbThongTin
            // 
            gbThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbThongTin.Controls.Add(tlpInfo);
            gbThongTin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbThongTin.Location = new Point(0, 0);
            gbThongTin.Margin = new Padding(4, 4, 4, 4);
            gbThongTin.MinimumSize = new Size(1250, 212);
            gbThongTin.Name = "gbThongTin";
            gbThongTin.Padding = new Padding(15, 10, 15, 12);
            gbThongTin.Size = new Size(1600, 212);
            gbThongTin.TabIndex = 4;
            gbThongTin.TabStop = false;
            gbThongTin.Text = "Thông tin đơn hàng";
            // 
            // tlpInfo
            // 
            tlpInfo.ColumnCount = 6;
            tlpInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tlpInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tlpInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tlpInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
            tlpInfo.Controls.Add(lblTenKhach, 0, 0);
            tlpInfo.Controls.Add(txtTenKhach, 1, 0);
            tlpInfo.Controls.Add(lblMaDon, 2, 0);
            tlpInfo.Controls.Add(txtMaDon, 3, 0);
            tlpInfo.Controls.Add(lblTenHoa, 4, 0);
            tlpInfo.Controls.Add(cboTenHoa, 5, 0);
            tlpInfo.Controls.Add(lblSdt, 0, 1);
            tlpInfo.Controls.Add(txtSdt, 1, 1);
            tlpInfo.Controls.Add(lblNgay, 2, 1);
            tlpInfo.Controls.Add(dtpNgay, 3, 1);
            tlpInfo.Controls.Add(lblMaNV, 4, 1);
            tlpInfo.Controls.Add(txtMaNV, 5, 1);
            tlpInfo.Controls.Add(lblMaHoa, 0, 2);
            tlpInfo.Controls.Add(txtMaHoa, 1, 2);
            tlpInfo.Controls.Add(lblTongSoLuong, 2, 2);
            tlpInfo.Controls.Add(nudTongSoLuong, 3, 2);
            tlpInfo.Dock = DockStyle.Fill;
            tlpInfo.Location = new Point(15, 37);
            tlpInfo.Margin = new Padding(4, 4, 4, 4);
            tlpInfo.Name = "tlpInfo";
            tlpInfo.Padding = new Padding(0, 2, 0, 2);
            tlpInfo.RowCount = 3;
            tlpInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tlpInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tlpInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tlpInfo.Size = new Size(1570, 163);
            tlpInfo.TabIndex = 1;
            // 
            // lblTenKhach
            // 
            lblTenKhach.Anchor = AnchorStyles.Left;
            lblTenKhach.AutoSize = true;
            lblTenKhach.Font = new Font("Segoe UI", 9F);
            lblTenKhach.Location = new Point(4, 14);
            lblTenKhach.Margin = new Padding(4, 0, 4, 0);
            lblTenKhach.Name = "lblTenKhach";
            lblTenKhach.Size = new Size(134, 25);
            lblTenKhach.TabIndex = 0;
            lblTenKhach.Text = "Tên khách hàng";
            // 
            // txtTenKhach
            // 
            txtTenKhach.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTenKhach.Font = new Font("Segoe UI", 9F);
            txtTenKhach.Location = new Point(192, 11);
            txtTenKhach.Margin = new Padding(4, 8, 10, 8);
            txtTenKhach.Name = "txtTenKhach";
            txtTenKhach.Size = new Size(300, 31);
            txtTenKhach.TabIndex = 1;
            // 
            // lblMaDon
            // 
            lblMaDon.Anchor = AnchorStyles.Left;
            lblMaDon.AutoSize = true;
            lblMaDon.Font = new Font("Segoe UI", 9F);
            lblMaDon.Location = new Point(506, 14);
            lblMaDon.Margin = new Padding(4, 0, 4, 0);
            lblMaDon.Name = "lblMaDon";
            lblMaDon.Size = new Size(74, 25);
            lblMaDon.TabIndex = 2;
            lblMaDon.Text = "Mã đơn";
            // 
            // txtMaDon
            // 
            txtMaDon.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtMaDon.Font = new Font("Segoe UI", 9F);
            txtMaDon.Location = new Point(694, 11);
            txtMaDon.Margin = new Padding(4, 8, 10, 8);
            txtMaDon.Name = "txtMaDon";
            txtMaDon.Size = new Size(300, 31);
            txtMaDon.TabIndex = 3;
            // 
            // lblTenHoa
            // 
            lblTenHoa.Anchor = AnchorStyles.Left;
            lblTenHoa.AutoSize = true;
            lblTenHoa.Font = new Font("Segoe UI", 9F);
            lblTenHoa.Location = new Point(1008, 14);
            lblTenHoa.Margin = new Padding(4, 0, 4, 0);
            lblTenHoa.Name = "lblTenHoa";
            lblTenHoa.Size = new Size(73, 25);
            lblTenHoa.TabIndex = 12;
            lblTenHoa.Text = "Tên hoa";
            // 
            // cboTenHoa
            // 
            cboTenHoa.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboTenHoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTenHoa.Font = new Font("Segoe UI", 9F);
            cboTenHoa.Location = new Point(1196, 10);
            cboTenHoa.Margin = new Padding(4, 8, 10, 8);
            cboTenHoa.Name = "cboTenHoa";
            cboTenHoa.Size = new Size(364, 33);
            cboTenHoa.TabIndex = 13;
            cboTenHoa.SelectedIndexChanged += cboTenHoa_SelectedIndexChanged;
            // 
            // lblSdt
            // 
            lblSdt.Anchor = AnchorStyles.Left;
            lblSdt.AutoSize = true;
            lblSdt.Font = new Font("Segoe UI", 9F);
            lblSdt.Location = new Point(4, 64);
            lblSdt.Margin = new Padding(4, 0, 4, 0);
            lblSdt.Name = "lblSdt";
            lblSdt.Size = new Size(140, 25);
            lblSdt.TabIndex = 4;
            lblSdt.Text = "SĐT khách hàng";
            // 
            // txtSdt
            // 
            txtSdt.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSdt.Font = new Font("Segoe UI", 9F);
            txtSdt.Location = new Point(192, 61);
            txtSdt.Margin = new Padding(4, 8, 10, 8);
            txtSdt.Name = "txtSdt";
            txtSdt.Size = new Size(300, 31);
            txtSdt.TabIndex = 5;
            // 
            // lblNgay
            // 
            lblNgay.Anchor = AnchorStyles.Left;
            lblNgay.AutoSize = true;
            lblNgay.Font = new Font("Segoe UI", 9F);
            lblNgay.Location = new Point(506, 64);
            lblNgay.Margin = new Padding(4, 0, 4, 0);
            lblNgay.Name = "lblNgay";
            lblNgay.Size = new Size(54, 25);
            lblNgay.TabIndex = 10;
            lblNgay.Text = "Ngày";
            // 
            // dtpNgay
            // 
            dtpNgay.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpNgay.CalendarFont = new Font("Segoe UI", 9F);
            dtpNgay.CustomFormat = "dd/MM/yyyy";
            dtpNgay.Font = new Font("Segoe UI", 9F);
            dtpNgay.Format = DateTimePickerFormat.Custom;
            dtpNgay.Location = new Point(694, 61);
            dtpNgay.Margin = new Padding(4, 8, 10, 8);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.Size = new Size(300, 31);
            dtpNgay.TabIndex = 11;
            // 
            // lblMaNV
            // 
            lblMaNV.Anchor = AnchorStyles.Left;
            lblMaNV.AutoSize = true;
            lblMaNV.Font = new Font("Segoe UI", 9F);
            lblMaNV.Location = new Point(1008, 64);
            lblMaNV.Margin = new Padding(4, 0, 4, 0);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Size = new Size(118, 25);
            lblMaNV.TabIndex = 8;
            lblMaNV.Text = "Mã nhân viên";
            // 
            // txtMaNV
            // 
            txtMaNV.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtMaNV.Font = new Font("Segoe UI", 9F);
            txtMaNV.Location = new Point(1196, 61);
            txtMaNV.Margin = new Padding(4, 8, 10, 8);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(364, 31);
            txtMaNV.TabIndex = 9;
            // 
            // lblMaHoa
            // 
            lblMaHoa.Anchor = AnchorStyles.Left;
            lblMaHoa.AutoSize = true;
            lblMaHoa.Font = new Font("Segoe UI", 9F);
            lblMaHoa.Location = new Point(4, 119);
            lblMaHoa.Margin = new Padding(4, 0, 4, 0);
            lblMaHoa.Name = "lblMaHoa";
            lblMaHoa.Size = new Size(72, 25);
            lblMaHoa.TabIndex = 14;
            lblMaHoa.Text = "Mã hoa";
            // 
            // txtMaHoa
            // 
            txtMaHoa.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtMaHoa.Font = new Font("Segoe UI", 9F);
            txtMaHoa.Location = new Point(192, 116);
            txtMaHoa.Margin = new Padding(4, 8, 10, 8);
            txtMaHoa.Name = "txtMaHoa";
            txtMaHoa.ReadOnly = true;
            txtMaHoa.Size = new Size(300, 31);
            txtMaHoa.TabIndex = 15;
            // 
            // lblTongSoLuong
            // 
            lblTongSoLuong.Anchor = AnchorStyles.Left;
            lblTongSoLuong.AutoSize = true;
            lblTongSoLuong.Font = new Font("Segoe UI", 9F);
            lblTongSoLuong.Location = new Point(506, 119);
            lblTongSoLuong.Margin = new Padding(4, 0, 4, 0);
            lblTongSoLuong.Name = "lblTongSoLuong";
            lblTongSoLuong.Size = new Size(85, 25);
            lblTongSoLuong.TabIndex = 16;
            lblTongSoLuong.Text = "Số lượng";
            // 
            // nudTongSoLuong
            // 
            nudTongSoLuong.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nudTongSoLuong.Font = new Font("Segoe UI", 9F);
            nudTongSoLuong.Location = new Point(694, 116);
            nudTongSoLuong.Margin = new Padding(4, 8, 10, 8);
            nudTongSoLuong.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudTongSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudTongSoLuong.Name = "nudTongSoLuong";
            nudTongSoLuong.Size = new Size(300, 31);
            nudTongSoLuong.TabIndex = 17;
            nudTongSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // FormDonHang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1600, 950);
            Controls.Add(mainScrollPanel);
            Controls.Add(headerPanel);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(4, 4, 4, 4);
            MinimumSize = new Size(1244, 861);
            Name = "FormDonHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý đơn hàng";
            Load += FormDonHang_Load;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            mainScrollPanel.ResumeLayout(false);
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
            pnlTongTien.ResumeLayout(false);
            gbThongTin.ResumeLayout(false);
            tlpInfo.ResumeLayout(false);
            tlpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudTongSoLuong).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel mainScrollPanel;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.TableLayoutPanel tlpInfo;
        private System.Windows.Forms.Label lblTenKhach;
        private System.Windows.Forms.TextBox txtTenKhach;
        private System.Windows.Forms.Label lblMaDon;
        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Label lblSdt;
        private System.Windows.Forms.TextBox txtSdt;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Label lblTenHoa;
        private System.Windows.Forms.ComboBox cboTenHoa;
        private System.Windows.Forms.Label lblMaHoa;
        private System.Windows.Forms.TextBox txtMaHoa;
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
        private System.Windows.Forms.Panel pnlTongTien;
        private System.Windows.Forms.Label lblTongTienLabel;
        private System.Windows.Forms.Label lblTongTienValue;

        // Columns for DataGridView (design-time)
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKhach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenHoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;

        private System.Windows.Forms.DataGridViewTextBoxColumn colCT_SanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCT_SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCT_DonGia;
    }
}

