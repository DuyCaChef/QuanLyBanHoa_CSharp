using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyBanHoa.Data;

namespace QuanLyBanHoa_CSharp.Forms
{
    public partial class FormThongKeBaoCao : Form
    {
        public FormThongKeBaoCao()
        {
            InitializeComponent();

            // wire up events
            btnRefresh.Click += BtnRefresh_Click;
            btnExport.Click += BtnExport_Click;
            dtpFrom.ValueChanged += DtpRange_ValueChanged;
            dtpTo.ValueChanged += DtpRange_ValueChanged;

            // sensible defaults
            dtpTo.Value = DateTime.Today;
            dtpFrom.Value = DateTime.Today.AddDays(-30);

            LoadStatistics();
        }

        private void DtpRange_ValueChanged(object sender, EventArgs e)
        {
            // keep UI responsive: reload stats when range changed
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
                    // header
                    var cols = dgvThongKe.Columns.Cast<DataGridViewColumn>();
                    sb.AppendLine(string.Join(',', cols.Select(c => '"' + c.HeaderText.Replace('"', '"') + '"')));

                    foreach (DataGridViewRow r in dgvThongKe.Rows)
                    {
                        if (r.IsNewRow) continue;
                        var cells = r.Cells.Cast<DataGridViewCell>().Select(c => '"' + (c.Value?.ToString()?.Replace('"', '"') ?? "") + '"');
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
                    using (var cmd = new MySqlCommand(overviewSql, conn))
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

                                // For cancel rate, if there is no cancellation info in schema, show 0%
                                lblCancelRate.Text = "0 %";
                            }
                        }
                    }

                    // Per-day statistics
                    string daySql = @"SELECT d.NgayDatHang as Ngay, COUNT(d.MaDH) as SoDon, COALESCE(SUM(d.TongTien),0) as DoanhThu,
                                          GROUP_CONCAT(DISTINCT d.MaKM SEPARATOR ',') as KMs,
                                          (SELECT GROUP_CONCAT(DISTINCT n.TenNV SEPARATOR ', ') FROM DonHang dd JOIN NhanVien n ON dd.MaNV = n.MaNV WHERE dd.NgayDatHang = d.NgayDatHang LIMIT 1) as NhanVien
                                       FROM DonHang d
                                       WHERE d.NgayDatHang BETWEEN @from AND @to
                                       GROUP BY d.NgayDatHang
                                       ORDER BY d.NgayDatHang DESC";

                    using (var cmd = new MySqlCommand(daySql, conn))
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
