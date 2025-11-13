namespace QuanLyBanHoa.Forms
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThongKeBaoCao));
            headerPanel = new Panel();
            lblTitle = new Label();
            tlpFilters = new TableLayoutPanel();
            lblFrom = new Label();
            dtpFrom = new DateTimePicker();
            lblTo = new Label();
            dtpTo = new DateTimePicker();
            lblSearch = new Label();
            txtSearch = new TextBox();
            gbOverview = new GroupBox();
            tlpCards = new TableLayoutPanel();
            cardRevenue = new Panel();
            panelRevenueAccent = new Panel();
            lblRevenue = new Label();
            lblRevenueTitle = new Label();
            cardOrders = new Panel();
            panelOrdersAccent = new Panel();
            lblOrders = new Label();
            lblOrdersTitle = new Label();
            dgvThongKe = new DataGridView();
            colMaDH = new DataGridViewTextBoxColumn();
            colNgay = new DataGridViewTextBoxColumn();
            colSoDon = new DataGridViewTextBoxColumn();
            colDoanhThu = new DataGridViewTextBoxColumn();
            flpActions = new FlowLayoutPanel();
            btnRefresh = new Button();
            btnXoaDon = new Button();
            btnExport = new Button();
            headerPanel.SuspendLayout();
            tlpFilters.SuspendLayout();
            gbOverview.SuspendLayout();
            tlpCards.SuspendLayout();
            cardRevenue.SuspendLayout();
            cardOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThongKe).BeginInit();
            flpActions.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(128, 128, 255);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(24, 12, 24, 12);
            headerPanel.Size = new Size(1280, 60);
            headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Left;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(24, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(313, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Thống kê đơn hàng";
            // 
            // tlpFilters
            // 
            tlpFilters.ColumnCount = 6;
            tlpFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tlpFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tlpFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tlpFilters.Controls.Add(lblFrom, 0, 0);
            tlpFilters.Controls.Add(dtpFrom, 1, 0);
            tlpFilters.Controls.Add(lblTo, 2, 0);
            tlpFilters.Controls.Add(dtpTo, 3, 0);
            tlpFilters.Controls.Add(lblSearch, 4, 0);
            tlpFilters.Controls.Add(txtSearch, 5, 0);
            tlpFilters.Dock = DockStyle.Top;
            tlpFilters.Location = new Point(0, 60);
            tlpFilters.Name = "tlpFilters";
            tlpFilters.Padding = new Padding(16, 12, 16, 12);
            tlpFilters.RowCount = 1;
            tlpFilters.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpFilters.Size = new Size(1280, 64);
            tlpFilters.TabIndex = 1;
            // 
            // lblFrom
            // 
            lblFrom.Anchor = AnchorStyles.Left;
            lblFrom.AutoSize = true;
            lblFrom.Font = new Font("Segoe UI", 10F);
            lblFrom.Location = new Point(19, 18);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(83, 28);
            lblFrom.TabIndex = 0;
            lblFrom.Text = "Ngày từ";
            // 
            // dtpFrom
            // 
            dtpFrom.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpFrom.CustomFormat = "dddd, dd/MM/yyyy";
            dtpFrom.Font = new Font("Segoe UI", 10F);
            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.Location = new Point(116, 15);
            dtpFrom.Margin = new Padding(0, 3, 16, 3);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(293, 34);
            dtpFrom.TabIndex = 1;
            // 
            // lblTo
            // 
            lblTo.Anchor = AnchorStyles.Left;
            lblTo.AutoSize = true;
            lblTo.Font = new Font("Segoe UI", 10F);
            lblTo.Location = new Point(428, 12);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(55, 40);
            lblTo.TabIndex = 2;
            lblTo.Text = "Đến ngày";
            // 
            // dtpTo
            // 
            dtpTo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpTo.CustomFormat = "dddd, dd/MM/yyyy";
            dtpTo.Font = new Font("Segoe UI", 10F);
            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.Location = new Point(525, 15);
            dtpTo.Margin = new Padding(0, 3, 16, 3);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(293, 34);
            dtpTo.TabIndex = 3;
            // 
            // lblSearch
            // 
            lblSearch.Anchor = AnchorStyles.Left;
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F);
            lblSearch.Location = new Point(837, 12);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(81, 40);
            lblSearch.TabIndex = 4;
            lblSearch.Text = "Tìm mã đơn:";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(954, 15);
            txtSearch.Margin = new Padding(0, 3, 16, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập mã đơn hàng...";
            txtSearch.Size = new Size(294, 34);
            txtSearch.TabIndex = 5;
            // 
            // gbOverview
            // 
            gbOverview.Controls.Add(tlpCards);
            gbOverview.Dock = DockStyle.Top;
            gbOverview.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            gbOverview.Location = new Point(0, 124);
            gbOverview.Name = "gbOverview";
            gbOverview.Padding = new Padding(12, 8, 12, 12);
            gbOverview.Size = new Size(1280, 162);
            gbOverview.TabIndex = 2;
            gbOverview.TabStop = false;
            gbOverview.Text = "Tổng quan";
            // 
            // tlpCards
            // 
            tlpCards.ColumnCount = 2;
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpCards.Controls.Add(cardRevenue, 0, 0);
            tlpCards.Controls.Add(cardOrders, 1, 0);
            tlpCards.Dock = DockStyle.Fill;
            tlpCards.Location = new Point(12, 38);
            tlpCards.Name = "tlpCards";
            tlpCards.Padding = new Padding(8);
            tlpCards.RowCount = 2;
            tlpCards.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpCards.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpCards.Size = new Size(1256, 112);
            tlpCards.TabIndex = 0;
            // 
            // cardRevenue
            // 
            cardRevenue.BackColor = Color.White;
            cardRevenue.BorderStyle = BorderStyle.FixedSingle;
            cardRevenue.Controls.Add(panelRevenueAccent);
            cardRevenue.Controls.Add(lblRevenue);
            cardRevenue.Controls.Add(lblRevenueTitle);
            cardRevenue.Dock = DockStyle.Fill;
            cardRevenue.Location = new Point(11, 11);
            cardRevenue.Name = "cardRevenue";
            cardRevenue.Padding = new Padding(12);
            tlpCards.SetRowSpan(cardRevenue, 2);
            cardRevenue.Size = new Size(614, 90);
            cardRevenue.TabIndex = 0;
            // 
            // panelRevenueAccent
            // 
            panelRevenueAccent.BackColor = Color.FromArgb(39, 174, 96);
            panelRevenueAccent.Dock = DockStyle.Left;
            panelRevenueAccent.Location = new Point(12, 12);
            panelRevenueAccent.Name = "panelRevenueAccent";
            panelRevenueAccent.Size = new Size(6, 64);
            panelRevenueAccent.TabIndex = 2;
            // 
            // lblRevenue
            // 
            lblRevenue.AutoSize = true;
            lblRevenue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblRevenue.ForeColor = Color.Black;
            lblRevenue.Location = new Point(28, 35);
            lblRevenue.Name = "lblRevenue";
            lblRevenue.Size = new Size(67, 45);
            lblRevenue.TabIndex = 1;
            lblRevenue.Text = "0 đ";
            // 
            // lblRevenueTitle
            // 
            lblRevenueTitle.AutoSize = true;
            lblRevenueTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRevenueTitle.ForeColor = Color.DimGray;
            lblRevenueTitle.Location = new Point(28, 12);
            lblRevenueTitle.Name = "lblRevenueTitle";
            lblRevenueTitle.Size = new Size(112, 28);
            lblRevenueTitle.TabIndex = 0;
            lblRevenueTitle.Text = "Doanh thu";
            // 
            // cardOrders
            // 
            cardOrders.BackColor = Color.White;
            cardOrders.BorderStyle = BorderStyle.FixedSingle;
            cardOrders.Controls.Add(panelOrdersAccent);
            cardOrders.Controls.Add(lblOrders);
            cardOrders.Controls.Add(lblOrdersTitle);
            cardOrders.Dock = DockStyle.Fill;
            cardOrders.Location = new Point(631, 11);
            cardOrders.Name = "cardOrders";
            cardOrders.Padding = new Padding(12);
            tlpCards.SetRowSpan(cardOrders, 2);
            cardOrders.Size = new Size(614, 90);
            cardOrders.TabIndex = 1;
            // 
            // panelOrdersAccent
            // 
            panelOrdersAccent.BackColor = Color.FromArgb(41, 128, 185);
            panelOrdersAccent.Dock = DockStyle.Left;
            panelOrdersAccent.Location = new Point(12, 12);
            panelOrdersAccent.Name = "panelOrdersAccent";
            panelOrdersAccent.Size = new Size(6, 64);
            panelOrdersAccent.TabIndex = 3;
            // 
            // lblOrders
            // 
            lblOrders.AutoSize = true;
            lblOrders.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblOrders.ForeColor = Color.Black;
            lblOrders.Location = new Point(28, 35);
            lblOrders.Name = "lblOrders";
            lblOrders.Size = new Size(38, 45);
            lblOrders.TabIndex = 1;
            lblOrders.Text = "0";
            // 
            // lblOrdersTitle
            // 
            lblOrdersTitle.AutoSize = true;
            lblOrdersTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblOrdersTitle.ForeColor = Color.DimGray;
            lblOrdersTitle.Location = new Point(28, 12);
            lblOrdersTitle.Name = "lblOrdersTitle";
            lblOrdersTitle.Size = new Size(132, 28);
            lblOrdersTitle.TabIndex = 0;
            lblOrdersTitle.Text = "Số đơn hàng";
            // 
            // dgvThongKe
            // 
            dgvThongKe.AllowUserToAddRows = false;
            dgvThongKe.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 245, 245);
            dgvThongKe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongKe.BackgroundColor = Color.White;
            dgvThongKe.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Gainsboro;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvThongKe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvThongKe.ColumnHeadersHeight = 38;
            dgvThongKe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvThongKe.Columns.AddRange(new DataGridViewColumn[] { colMaDH, colNgay, colSoDon, colDoanhThu });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvThongKe.DefaultCellStyle = dataGridViewCellStyle6;
            dgvThongKe.Dock = DockStyle.Fill;
            dgvThongKe.EnableHeadersVisualStyles = false;
            dgvThongKe.GridColor = Color.LightSteelBlue;
            dgvThongKe.Location = new Point(0, 286);
            dgvThongKe.MultiSelect = false;
            dgvThongKe.Name = "dgvThongKe";
            dgvThongKe.ReadOnly = true;
            dgvThongKe.RowHeadersVisible = false;
            dgvThongKe.RowHeadersWidth = 51;
            dgvThongKe.RowTemplate.Height = 32;
            dgvThongKe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThongKe.Size = new Size(1280, 474);
            dgvThongKe.TabIndex = 3;
            // 
            // colMaDH
            // 
            colMaDH.FillWeight = 10F;
            colMaDH.HeaderText = "Mã ĐH";
            colMaDH.MinimumWidth = 6;
            colMaDH.Name = "colMaDH";
            colMaDH.ReadOnly = true;
            colMaDH.Visible = false;
            // 
            // colNgay
            // 
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            colNgay.DefaultCellStyle = dataGridViewCellStyle3;
            colNgay.FillWeight = 16F;
            colNgay.HeaderText = "Ngày";
            colNgay.MinimumWidth = 6;
            colNgay.Name = "colNgay";
            colNgay.ReadOnly = true;
            // 
            // colSoDon
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            colSoDon.DefaultCellStyle = dataGridViewCellStyle4;
            colSoDon.FillWeight = 14F;
            colSoDon.HeaderText = "Đơn hàng";
            colSoDon.MinimumWidth = 6;
            colSoDon.Name = "colSoDon";
            colSoDon.ReadOnly = true;
            // 
            // colDoanhThu
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            colDoanhThu.DefaultCellStyle = dataGridViewCellStyle5;
            colDoanhThu.FillWeight = 34F;
            colDoanhThu.HeaderText = "Doanh thu";
            colDoanhThu.MinimumWidth = 6;
            colDoanhThu.Name = "colDoanhThu";
            colDoanhThu.ReadOnly = true;
            // 
            // flpActions
            // 
            flpActions.AutoSize = true;
            flpActions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpActions.Controls.Add(btnRefresh);
            flpActions.Controls.Add(btnXoaDon);
            flpActions.Controls.Add(btnExport);
            flpActions.Dock = DockStyle.Bottom;
            flpActions.FlowDirection = FlowDirection.RightToLeft;
            flpActions.Location = new Point(0, 693);
            flpActions.Name = "flpActions";
            flpActions.Padding = new Padding(0, 8, 16, 8);
            flpActions.Size = new Size(1280, 67);
            flpActions.TabIndex = 4;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(1153, 11);
            btnRefresh.Margin = new Padding(3, 3, 8, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(103, 45);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnXoaDon
            // 
            btnXoaDon.BackColor = Color.FromArgb(231, 76, 60);
            btnXoaDon.FlatAppearance.BorderSize = 0;
            btnXoaDon.FlatStyle = FlatStyle.Flat;
            btnXoaDon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnXoaDon.ForeColor = Color.White;
            btnXoaDon.Location = new Point(1033, 11);
            btnXoaDon.Margin = new Padding(3, 3, 8, 3);
            btnXoaDon.Name = "btnXoaDon";
            btnXoaDon.Size = new Size(109, 45);
            btnXoaDon.TabIndex = 2;
            btnXoaDon.Text = "Xóa đơn";
            btnXoaDon.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.Gainsboro;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExport.ForeColor = Color.Black;
            btnExport.Location = new Point(906, 11);
            btnExport.Margin = new Padding(3, 3, 16, 3);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(108, 45);
            btnExport.TabIndex = 0;
            btnExport.Text = "Xuất...";
            btnExport.UseVisualStyleBackColor = false;
            // 
            // FormThongKeBaoCao
            // 
            ClientSize = new Size(1280, 760);
            Controls.Add(flpActions);
            Controls.Add(dgvThongKe);
            Controls.Add(gbOverview);
            Controls.Add(tlpFilters);
            Controls.Add(headerPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormThongKeBaoCao";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            tlpFilters.ResumeLayout(false);
            tlpFilters.PerformLayout();
            gbOverview.ResumeLayout(false);
            tlpCards.ResumeLayout(false);
            cardRevenue.ResumeLayout(false);
            cardRevenue.PerformLayout();
            cardOrders.ResumeLayout(false);
            cardOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThongKe).EndInit();
            flpActions.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tlpFilters;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox gbOverview;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoanhThu;
        private System.Windows.Forms.FlowLayoutPanel flpActions;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnXoaDon;
        private TableLayoutPanel tlpCards;
        private Panel cardRevenue;
        private Panel panelRevenueAccent;
        private Label lblRevenue;
        private Label lblRevenueTitle;
        private Panel cardOrders;
        private Panel panelOrdersAccent;
        private Label lblOrders;
        private Label lblOrdersTitle;
    }
}

