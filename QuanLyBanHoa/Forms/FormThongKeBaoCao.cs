using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHoa.Data;

namespace QuanLyBanHoa.Forms
{
    public partial class FormThongKeBaoCao : Form
    {
        private DataTable dtAllData;

        public FormThongKeBaoCao()
        {
            InitializeComponent();

            btnRefresh.Click += BtnRefresh_Click;
            btnExport.Click += BtnExport_Click;
            btnXoaDon.Click += BtnXoaDon_Click;
            dtpFrom.ValueChanged += DtpRange_ValueChanged;
            dtpTo.ValueChanged += DtpRange_ValueChanged;
            txtSearch.TextChanged += TxtSearch_TextChanged;

            frmHoa.HoaDataChanged += FrmHoa_HoaDataChanged;

            dtpTo.Value = DateTime.Today;
            dtpFrom.Value = DateTime.Today.AddDays(-30);

            dtAllData = new DataTable();
            LoadStatistics();
        }

        private void FrmHoa_HoaDataChanged(object sender, EventArgs e)
        {
            // Optionally reload statistics if needed
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            frmHoa.HoaDataChanged -= FrmHoa_HoaDataChanged;
            base.OnFormClosing(e);
        }

        private void DtpRange_ValueChanged(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvThongKe.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    sfd.FileName = $"thongke_{DateTime.Now:yyyyMMdd}.csv";
                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    var sb = new StringBuilder();
                    var cols = dgvThongKe.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible);
                    sb.AppendLine(string.Join(',', cols.Select(c => '"' + c.HeaderText.Replace('"', '"') + '"')));

                    foreach (DataGridViewRow r in dgvThongKe.Rows)
                    {
                        if (r.IsNewRow) continue;
                        var cells = cols.Select(c => '"' + (r.Cells[c.Index].Value?.ToString()?.Replace('"', '"') ?? "") + '"');
                        sb.AppendLine(string.Join(',', cells));
                    }

                    System.IO.File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Xuất file thành công.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất dữ liệu:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvThongKe.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một đơn hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var row = dgvThongKe.SelectedRows[0];
                string ngayStr = row.Cells["colNgay"].Value?.ToString();
                
                if (string.IsNullOrEmpty(ngayStr))
                {
                    MessageBox.Show("Không tìm thấy thông tin đơn hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show($"Bạn có chắc muốn xóa tất cả đơn hàng ngày {ngayStr}?\nHành động này không thể hoàn tác.", 
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if (result != DialogResult.Yes) return;

                if (!DateTime.TryParse(ngayStr, out DateTime ngay))
                {
                    MessageBox.Show("Định dạng ngày không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    using (var tx = conn.BeginTransaction())
                    {
                        try
                        {
                            // Get all order IDs for this date - SQL Server: CAST...AS DATE thay vì DATE()
                            var orderIds = new List<int>();
                            using (var cmdGetOrders = new SqlCommand("SELECT MaDH FROM DonHang WHERE CAST(NgayDatHang AS DATE) = @Ngay", conn, tx))
                            {
                                cmdGetOrders.Parameters.AddWithValue("@Ngay", ngay.Date);
                                using (var rdr = cmdGetOrders.ExecuteReader())
                                {
                                    while (rdr.Read())
                                    {
                                        orderIds.Add(rdr.GetInt32(0));
                                    }
                                }
                            }

                            // Delete details first
                            foreach (var orderId in orderIds)
                            {
                                using (var cmdDelDetails = new SqlCommand("DELETE FROM ChiTietDonHang WHERE MaDH = @MaDH", conn, tx))
                                {
                                    cmdDelDetails.Parameters.AddWithValue("@MaDH", orderId);
                                    cmdDelDetails.ExecuteNonQuery();
                                }
                            }

                            // Delete orders - SQL Server: CAST...AS DATE
                            using (var cmdDelOrders = new SqlCommand("DELETE FROM DonHang WHERE CAST(NgayDatHang AS DATE) = @Ngay", conn, tx))
                            {
                                cmdDelOrders.Parameters.AddWithValue("@Ngay", ngay.Date);
                                int deleted = cmdDelOrders.ExecuteNonQuery();
                                
                                tx.Commit();
                                MessageBox.Show($"Đã xóa {deleted} đơn hàng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadStatistics();
                            }
                        }
                        catch (Exception ex)
                        {
                            try { tx.Rollback(); } catch { }
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa đơn hàng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text.Trim();
                
                if (string.IsNullOrEmpty(searchText))
                {
                    LoadStatistics();
                    return;
                }

                DateTime from = dtpFrom.Value.Date;
                DateTime to = dtpTo.Value.Date;

                dgvThongKe.Rows.Clear();

                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    // SQL Server: STRING_AGG thay vì GROUP_CONCAT, CAST thay vì CAST...AS CHAR
                    string searchSql = @"SELECT d.NgayDatHang as Ngay, COUNT(d.MaDH) as SoDon, COALESCE(SUM(d.TongTien),0) as DoanhThu,
                                          STRING_AGG(CAST(d.MaKM AS NVARCHAR), ',') as KMs,
                                          (SELECT TOP 1 STRING_AGG(n.TenNV, ', ') FROM DonHang dd JOIN NhanVien n ON dd.MaNV = n.MaNV WHERE dd.NgayDatHang = d.NgayDatHang GROUP BY dd.NgayDatHang) as NhanVien
                                       FROM DonHang d
                                       WHERE d.NgayDatHang BETWEEN @from AND @to
                                       AND CAST(d.MaDH AS NVARCHAR) LIKE @search
                                       GROUP BY d.NgayDatHang
                                       ORDER BY d.NgayDatHang DESC";

                    using (var cmd = new SqlCommand(searchSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@from", from);
                        cmd.Parameters.AddWithValue("@to", to);
                        cmd.Parameters.AddWithValue("@search", $"%{searchText}%");

                        using (var rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                DateTime ngay = rdr.IsDBNull(0) ? DateTime.MinValue : rdr.GetDateTime(0);
                                int sodon = rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1);
                                decimal doanhthu = rdr.IsDBNull(2) ? 0m : rdr.GetDecimal(2);
                                string km = rdr.IsDBNull(3) ? string.Empty : rdr.GetString(3);
                                string nhanvien = rdr.IsDBNull(4) ? string.Empty : rdr.GetString(4);

                                dgvThongKe.Rows.Add(ngay, sodon, doanhthu.ToString("N0"), km, nhanvien);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatistics()
        {
            try
            {
                DateTime from = dtpFrom.Value.Date;
                DateTime to = dtpTo.Value.Date;
                if (from > to) { MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                dgvThongKe.Rows.Clear();

                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    // Overview cards
                    string overviewSql = @"SELECT COUNT(DISTINCT d.MaDH) as SoDon, COALESCE(SUM(d.TongTien),0) as DoanhThu, COALESCE(SUM(CASE WHEN d.MaKM IS NOT NULL THEN 1 ELSE 0 END),0) as KmDung
                                           FROM DonHang d
                                           WHERE d.NgayDatHang BETWEEN @from AND @to";
                    using (var cmd = new SqlCommand(overviewSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@from", from);
                        cmd.Parameters.AddWithValue("@to", to);
                        using (var rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                int soDon = rdr.IsDBNull(0) ? 0 : rdr.GetInt32(0);
                                decimal doanhThu = rdr.IsDBNull(1) ? 0m : rdr.GetDecimal(1);
                                int km = rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2);

                                lblOrders.Text = soDon.ToString();
                                lblRevenue.Text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:N0} đ", doanhThu);
                                lblDiscount.Text = km.ToString();
                                lblCancelRate.Text = "0 %";
                            }
                        }
                    }

                    // Per-day statistics - SQL Server: STRING_AGG thay vì GROUP_CONCAT
                    string daySql = @"SELECT d.NgayDatHang as Ngay, COUNT(d.MaDH) as SoDon, COALESCE(SUM(d.TongTien),0) as DoanhThu,
                                          STRING_AGG(CAST(d.MaKM AS NVARCHAR), ',') as KMs,
                                          (SELECT TOP 1 STRING_AGG(n.TenNV, ', ') FROM DonHang dd JOIN NhanVien n ON dd.MaNV = n.MaNV WHERE dd.NgayDatHang = d.NgayDatHang GROUP BY dd.NgayDatHang) as NhanVien
                                       FROM DonHang d
                                       WHERE d.NgayDatHang BETWEEN @from AND @to
                                       GROUP BY d.NgayDatHang
                                       ORDER BY d.NgayDatHang DESC";

                    using (var cmd = new SqlCommand(daySql, conn))
                    {
                        cmd.Parameters.AddWithValue("@from", from);
                        cmd.Parameters.AddWithValue("@to", to);

                        using (var rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                DateTime ngay = rdr.IsDBNull(0) ? DateTime.MinValue : rdr.GetDateTime(0);
                                int sodon = rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1);
                                decimal doanhthu = rdr.IsDBNull(2) ? 0m : rdr.GetDecimal(2);
                                string km = rdr.IsDBNull(3) ? string.Empty : rdr.GetString(3);
                                string nhanvien = rdr.IsDBNull(4) ? string.Empty : rdr.GetString(4);

                                dgvThongKe.Rows.Add(ngay, sodon, doanhthu.ToString("N0"), km, nhanvien);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thống kê:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
