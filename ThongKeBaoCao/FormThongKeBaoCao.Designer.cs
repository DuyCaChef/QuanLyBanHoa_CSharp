namespace QuanLyBanHoa_CSharp.Forms
{
    partial class FormThongKeBaoCao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tlpFilters = new System.Windows.Forms.TableLayoutPanel();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.gbOverview = new System.Windows.Forms.GroupBox();
            this.tlpCards = new System.Windows.Forms.TableLayoutPanel();
            this.cardRevenue = new System.Windows.Forms.Panel();
            this.panelRevenueAccent = new System.Windows.Forms.Panel();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.lblRevenueTitle = new System.Windows.Forms.Label();
            this.cardOrders = new System.Windows.Forms.Panel();
            this.panelOrdersAccent = new System.Windows.Forms.Panel();
            this.lblOrders = new System.Windows.Forms.Label();
            this.lblOrdersTitle = new System.Windows.Forms.Label();
            this.cardDiscount = new System.Windows.Forms.Panel();
            this.panelDiscountAccent = new System.Windows.Forms.Panel();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblDiscountTitle = new System.Windows.Forms.Label();
            this.cardCancelRate = new System.Windows.Forms.Panel();
            this.panelCancelAccent = new System.Windows.Forms.Panel();
            this.lblCancelRate = new System.Windows.Forms.Label();
            this.lblCancelRateTitle = new System.Windows.Forms.Label();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.colNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDoanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKmDaDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuTrangChu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDonHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThongKeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.headerPanel.SuspendLayout();
            this.tlpFilters.SuspendLayout();
            this.gbOverview.SuspendLayout();
            this.tlpCards.SuspendLayout();
            this.cardRevenue.SuspendLayout();
            this.cardOrders.SuspendLayout();
            this.cardDiscount.SuspendLayout();
            this.cardCancelRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.flpActions.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(24, 12, 24, 12);
            this.headerPanel.Size = new System.Drawing.Size(1280, 60);
            this.headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(24, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(313, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thống kê đơn hàng";
            // 
            // tlpFilters
            // 
            this.tlpFilters.ColumnCount = 4;
            this.tlpFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFilters.Controls.Add(this.lblFrom, 0, 0);
            this.tlpFilters.Controls.Add(this.dtpFrom, 1, 0);
            this.tlpFilters.Controls.Add(this.lblTo, 2, 0);
            this.tlpFilters.Controls.Add(this.dtpTo, 3, 0);
            this.tlpFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpFilters.Location = new System.Drawing.Point(0, 93);
            this.tlpFilters.Name = "tlpFilters";
            this.tlpFilters.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.tlpFilters.RowCount = 1;
            this.tlpFilters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFilters.Size = new System.Drawing.Size(1280, 64);
            this.tlpFilters.TabIndex = 1;
            // 
            // lblFrom
            // 
            this.lblFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFrom.Location = new System.Drawing.Point(19, 18);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(83, 28);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "Ngày từ";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.CustomFormat = "dddd, dd/MM/yyyy";
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(116, 15);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(508, 34);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTo.Location = new System.Drawing.Point(643, 12);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(55, 40);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "Đến ngày";
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTo.CustomFormat = "dddd, dd/MM/yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(740, 15);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(508, 34);
            this.dtpTo.TabIndex = 3;
            // 
            // gbOverview
            // 
            this.gbOverview.Controls.Add(this.tlpCards);
            this.gbOverview.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbOverview.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.gbOverview.Location = new System.Drawing.Point(0, 157);
            this.gbOverview.Name = "gbOverview";
            this.gbOverview.Padding = new System.Windows.Forms.Padding(12, 8, 12, 12);
            this.gbOverview.Size = new System.Drawing.Size(1280, 140);
            this.gbOverview.TabIndex = 2;
            this.gbOverview.TabStop = false;
            this.gbOverview.Text = "Tổng quan";
            // 
            // tlpCards
            // 
            this.tlpCards.ColumnCount = 4;
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCards.Controls.Add(this.cardRevenue, 0, 0);
            this.tlpCards.Controls.Add(this.cardOrders, 1, 0);
            this.tlpCards.Controls.Add(this.cardDiscount, 2, 0);
            this.tlpCards.Controls.Add(this.cardCancelRate, 3, 0);
            this.tlpCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCards.Location = new System.Drawing.Point(12, 38);
            this.tlpCards.Name = "tlpCards";
            this.tlpCards.Padding = new System.Windows.Forms.Padding(8);
            this.tlpCards.RowCount = 1;
            this.tlpCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCards.Size = new System.Drawing.Size(1256, 90);
            this.tlpCards.TabIndex = 0;
            // 
            // cardRevenue
            // 
            this.cardRevenue.BackColor = System.Drawing.Color.White;
            this.cardRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardRevenue.Controls.Add(this.panelRevenueAccent);
            this.cardRevenue.Controls.Add(this.lblRevenue);
            this.cardRevenue.Controls.Add(this.lblRevenueTitle);
            this.cardRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardRevenue.Location = new System.Drawing.Point(11, 11);
            this.cardRevenue.Name = "cardRevenue";
            this.cardRevenue.Padding = new System.Windows.Forms.Padding(12);
            this.cardRevenue.Size = new System.Drawing.Size(304, 68);
            this.cardRevenue.TabIndex = 0;
            // 
            // panelRevenueAccent
            // 
            this.panelRevenueAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.panelRevenueAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelRevenueAccent.Location = new System.Drawing.Point(12, 12);
            this.panelRevenueAccent.Name = "panelRevenueAccent";
            this.panelRevenueAccent.Size = new System.Drawing.Size(6, 42);
            this.panelRevenueAccent.TabIndex = 2;
            // 
            // lblRevenue
            // 
            this.lblRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRevenue.AutoSize = true;
            this.lblRevenue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblRevenue.ForeColor = System.Drawing.Color.Black;
            this.lblRevenue.Location = new System.Drawing.Point(28, 29);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(67, 45);
            this.lblRevenue.TabIndex = 1;
            this.lblRevenue.Text = "0 đ";
            // 
            // lblRevenueTitle
            // 
            this.lblRevenueTitle.AutoSize = true;
            this.lblRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRevenueTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblRevenueTitle.Location = new System.Drawing.Point(28, 12);
            this.lblRevenueTitle.Name = "lblRevenueTitle";
            this.lblRevenueTitle.Size = new System.Drawing.Size(112, 28);
            this.lblRevenueTitle.TabIndex = 0;
            this.lblRevenueTitle.Text = "Doanh thu";
            // 
            // cardOrders
            // 
            this.cardOrders.BackColor = System.Drawing.Color.White;
            this.cardOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardOrders.Controls.Add(this.panelOrdersAccent);
            this.cardOrders.Controls.Add(this.lblOrders);
            this.cardOrders.Controls.Add(this.lblOrdersTitle);
            this.cardOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardOrders.Location = new System.Drawing.Point(321, 11);
            this.cardOrders.Name = "cardOrders";
            this.cardOrders.Padding = new System.Windows.Forms.Padding(12);
            this.cardOrders.Size = new System.Drawing.Size(304, 68);
            this.cardOrders.TabIndex = 1;
            // 
            // panelOrdersAccent
            // 
            this.panelOrdersAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelOrdersAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelOrdersAccent.Location = new System.Drawing.Point(12, 12);
            this.panelOrdersAccent.Name = "panelOrdersAccent";
            this.panelOrdersAccent.Size = new System.Drawing.Size(6, 42);
            this.panelOrdersAccent.TabIndex = 3;
            // 
            // lblOrders
            // 
            this.lblOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOrders.AutoSize = true;
            this.lblOrders.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblOrders.ForeColor = System.Drawing.Color.Black;
            this.lblOrders.Location = new System.Drawing.Point(28, 29);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(38, 45);
            this.lblOrders.TabIndex = 1;
            this.lblOrders.Text = "0";
            // 
            // lblOrdersTitle
            // 
            this.lblOrdersTitle.AutoSize = true;
            this.lblOrdersTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblOrdersTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblOrdersTitle.Location = new System.Drawing.Point(28, 12);
            this.lblOrdersTitle.Name = "lblOrdersTitle";
            this.lblOrdersTitle.Size = new System.Drawing.Size(132, 28);
            this.lblOrdersTitle.TabIndex = 0;
            this.lblOrdersTitle.Text = "Số đơn hàng";
            // 
            // cardDiscount
            // 
            this.cardDiscount.BackColor = System.Drawing.Color.White;
            this.cardDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardDiscount.Controls.Add(this.panelDiscountAccent);
            this.cardDiscount.Controls.Add(this.lblDiscount);
            this.cardDiscount.Controls.Add(this.lblDiscountTitle);
            this.cardDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardDiscount.Location = new System.Drawing.Point(631, 11);
            this.cardDiscount.Name = "cardDiscount";
            this.cardDiscount.Padding = new System.Windows.Forms.Padding(12);
            this.cardDiscount.Size = new System.Drawing.Size(304, 68);
            this.cardDiscount.TabIndex = 2;
            // 
            // panelDiscountAccent
            // 
            this.panelDiscountAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.panelDiscountAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelDiscountAccent.Location = new System.Drawing.Point(12, 12);
            this.panelDiscountAccent.Name = "panelDiscountAccent";
            this.panelDiscountAccent.Size = new System.Drawing.Size(6, 42);
            this.panelDiscountAccent.TabIndex = 3;
            // 
            // lblDiscount
            // 
            this.lblDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDiscount.ForeColor = System.Drawing.Color.Black;
            this.lblDiscount.Location = new System.Drawing.Point(28, 29);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(38, 45);
            this.lblDiscount.TabIndex = 1;
            this.lblDiscount.Text = "0";
            // 
            // lblDiscountTitle
            // 
            this.lblDiscountTitle.AutoSize = true;
            this.lblDiscountTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDiscountTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblDiscountTitle.Location = new System.Drawing.Point(28, 12);
            this.lblDiscountTitle.Name = "lblDiscountTitle";
            this.lblDiscountTitle.Size = new System.Drawing.Size(128, 28);
            this.lblDiscountTitle.TabIndex = 0;
            this.lblDiscountTitle.Text = "KM đã dùng";
            // 
            // cardCancelRate
            // 
            this.cardCancelRate.BackColor = System.Drawing.Color.White;
            this.cardCancelRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardCancelRate.Controls.Add(this.panelCancelAccent);
            this.cardCancelRate.Controls.Add(this.lblCancelRate);
            this.cardCancelRate.Controls.Add(this.lblCancelRateTitle);
            this.cardCancelRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardCancelRate.Location = new System.Drawing.Point(941, 11);
            this.cardCancelRate.Name = "cardCancelRate";
            this.cardCancelRate.Padding = new System.Windows.Forms.Padding(12);
            this.cardCancelRate.Size = new System.Drawing.Size(304, 68);
            this.cardCancelRate.TabIndex = 3;
            // 
            // panelCancelAccent
            // 
            this.panelCancelAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.panelCancelAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelCancelAccent.Location = new System.Drawing.Point(12, 12);
            this.panelCancelAccent.Name = "panelCancelAccent";
            this.panelCancelAccent.Size = new System.Drawing.Size(6, 42);
            this.panelCancelAccent.TabIndex = 3;
            // 
            // lblCancelRate
            // 
            this.lblCancelRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCancelRate.AutoSize = true;
            this.lblCancelRate.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCancelRate.ForeColor = System.Drawing.Color.Black;
            this.lblCancelRate.Location = new System.Drawing.Point(28, 29);
            this.lblCancelRate.Name = "lblCancelRate";
            this.lblCancelRate.Size = new System.Drawing.Size(75, 45);
            this.lblCancelRate.TabIndex = 1;
            this.lblCancelRate.Text = "0 %";
            // 
            // lblCancelRateTitle
            // 
            this.lblCancelRateTitle.AutoSize = true;
            this.lblCancelRateTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCancelRateTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblCancelRateTitle.Location = new System.Drawing.Point(28, 12);
            this.lblCancelRateTitle.Name = "lblCancelRateTitle";
            this.lblCancelRateTitle.Size = new System.Drawing.Size(94, 28);
            this.lblCancelRateTitle.TabIndex = 0;
            this.lblCancelRateTitle.Text = "Tỉ lệ huỷ";
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AllowUserToAddRows = false;
            this.dgvThongKe.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));

this.dgvThongKe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongKe.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThongKe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThongKe.ColumnHeadersHeight = 38;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvThongKe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNgay,
            this.colSoDon,
            this.colDoanhThu,
            this.colKmDaDung,
            this.colNhanVien});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvThongKe.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThongKe.EnableHeadersVisualStyles = false;
            this.dgvThongKe.GridColor = System.Drawing.Color.LightSteelBlue;
            this.dgvThongKe.Location = new System.Drawing.Point(0, 297);
            this.dgvThongKe.MultiSelect = false;
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.ReadOnly = true;
            this.dgvThongKe.RowHeadersVisible = false;
            this.dgvThongKe.RowHeadersWidth = 51;
            this.dgvThongKe.RowTemplate.Height = 32;
            this.dgvThongKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongKe.Size = new System.Drawing.Size(1280, 463);
            this.dgvThongKe.TabIndex = 3;
            // 
            // colNgay
            // 
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.colNgay.DefaultCellStyle = dataGridViewCellStyle3;
            this.colNgay.FillWeight = 16F;
            this.colNgay.HeaderText = "Ngày";
            this.colNgay.MinimumWidth = 6;
            this.colNgay.Name = "colNgay";
            this.colNgay.ReadOnly = true;
            // 
            // colSoDon
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.colSoDon.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSoDon.FillWeight = 14F;
            this.colSoDon.HeaderText = "Đơn hàng";
            this.colSoDon.MinimumWidth = 6;
            this.colSoDon.Name = "colSoDon";
            this.colSoDon.ReadOnly = true;
            // 
            // colDoanhThu
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.colDoanhThu.DefaultCellStyle = dataGridViewCellStyle5;
            this.colDoanhThu.FillWeight = 20F;
            this.colDoanhThu.HeaderText = "Doanh thu";
            this.colDoanhThu.MinimumWidth = 6;
            this.colDoanhThu.Name = "colDoanhThu";
            this.colDoanhThu.ReadOnly = true;
            // 
            // colKmDaDung
            // 
            this.colKmDaDung.FillWeight = 14F;
            this.colKmDaDung.HeaderText = "KM đã dùng";
            this.colKmDaDung.MinimumWidth = 6;
            this.colKmDaDung.Name = "colKmDaDung";
            this.colKmDaDung.ReadOnly = true;
            // 
            // colNhanVien
            // 
            this.colNhanVien.FillWeight = 36F;
            this.colNhanVien.HeaderText = "Nhân viên bán hàng";
            this.colNhanVien.MinimumWidth = 6;
            this.colNhanVien.Name = "colNhanVien";
            this.colNhanVien.ReadOnly = true;
            // 
            // flpActions
            // 
            this.flpActions.AutoSize = true;
            this.flpActions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpActions.Controls.Add(this.btnRefresh);
            this.flpActions.Controls.Add(this.btnExport);
            this.flpActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpActions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpActions.Location = new System.Drawing.Point(0, 710);
            this.flpActions.Name = "flpActions";
            this.flpActions.Padding = new System.Windows.Forms.Padding(0, 8, 16, 8);
            this.flpActions.Size = new System.Drawing.Size(1280, 50);
            this.flpActions.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1160, 11);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(96, 28);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Gainsboro;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.Black;
            this.btnExport.Location = new System.Drawing.Point(1043, 11);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(98, 28);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Xuất...";
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowItemReorder = true;
            this.menuStrip1.BackColor = System.Drawing.Color.SkyBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTrangChu,
            this.mnuQuanLy,
            this.mnuDangXuat});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1280, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuTrangChu
            // 
            this.mnuTrangChu.Name = "mnuTrangChu";
            this.mnuTrangChu.Size = new System.Drawing.Size(107, 29);
            this.mnuTrangChu.Text = "Trang Chủ";
            // 
            // mnuQuanLy
            // 
            this.mnuQuanLy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuKhachHang,
            this.mnuDonHang,
            this.mnuThongKeMenu});
            this.mnuQuanLy.Name = "mnuQuanLy";
            this.mnuQuanLy.Size = new System.Drawing.Size(89, 29);
            this.mnuQuanLy.Text = "Quản lý";
            // 
            // mnuKhachHang
            // 
            this.mnuKhachHang.Name = "mnuKhachHang";
            this.mnuKhachHang.Size = new System.Drawing.Size(209, 34);
            this.mnuKhachHang.Text = "Khách Hàng";
            // 
            // mnuDonHang
            // 
            this.mnuDonHang.Name = "mnuDonHang";
            this.mnuDonHang.Size = new System.Drawing.Size(209, 34);
            this.mnuDonHang.Text = "Đơn Hàng";
            // 
            // mnuThongKeMenu
            // 
            this.mnuThongKeMenu.Name = "mnuThongKeMenu";
            this.mnuThongKeMenu.Size = new System.Drawing.Size(209, 34);
            this.mnuThongKeMenu.Text = "Thống Kê";
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(109, 29);
            this.mnuDangXuat.Text = "Đăng xuất";
            // 
            // FormThongKeBaoCao
            // 
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.flpActions);
            this.Controls.Add(this.dgvThongKe);
            this.Controls.Add(this.gbOverview);
            this.Controls.Add(this.tlpFilters);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.headerPanel);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormThongKeBaoCao";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.tlpFilters.ResumeLayout(false);
            this.tlpFilters.PerformLayout();
            this.gbOverview.ResumeLayout(false);
            this.tlpCards.ResumeLayout(false);
            this.cardRevenue.ResumeLayout(false);
            this.cardRevenue.PerformLayout();
            this.cardOrders.ResumeLayout(false);
            this.cardOrders.PerformLayout();
            this.cardDiscount.ResumeLayout(false);
            this.cardDiscount.PerformLayout();
            this.cardCancelRate.ResumeLayout(false);
            this.cardCancelRate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.flpActions.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tlpFilters;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.GroupBox gbOverview;
        private System.Windows.Forms.TableLayoutPanel tlpCards;
        private System.Windows.Forms.Panel cardRevenue;
        private System.Windows.Forms.Label lblRevenueTitle;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.Panel cardOrders;
        private System.Windows.Forms.Label lblOrdersTitle;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.Panel cardDiscount;
        private System.Windows.Forms.Label lblDiscountTitle;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Panel cardCancelRate;
        private System.Windows.Forms.Label lblCancelRateTitle;
        private System.Windows.Forms.Label lblCancelRate;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoanhThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKmDaDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNhanVien;
        private System.Windows.Forms.FlowLayoutPanel flpActions;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelRevenueAccent;
        private System.Windows.Forms.Panel panelOrdersAccent;
        private System.Windows.Forms.Panel panelDiscountAccent;
        private System.Windows.Forms.Panel panelCancelAccent;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuTrangChu;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanLy;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuKhachHang;
        private System.Windows.Forms.ToolStripMenuItem mnuDonHang;
        private System.Windows.Forms.ToolStripMenuItem mnuThongKeMenu;
    }
}

