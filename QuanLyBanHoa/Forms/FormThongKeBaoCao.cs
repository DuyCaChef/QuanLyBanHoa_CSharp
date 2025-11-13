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
using QuanLyBanHoa.Models;

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
                    sb.AppendLine(string.Join(",", cols.Select(c => '"' + c.HeaderText.Replace('"', '"') + '"')));

                    foreach (DataGridViewRow r in dgvThongKe.Rows)
                    {
                        if (r.IsNewRow) continue;
                        var cells = cols.Select(c => '"' + (r.Cells[c.Index].Value?.ToString()?.Replace('"', '"') ?? "") + '"');
                        sb.AppendLine(string.Join(",", cells));
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

                // Xóa đơn hàng theo ngày sử dụng hàm từ ThongKe
                int deleted = ThongKe.DeleteOrdersByDate(ngay);
                MessageBox.Show($"Đã xóa {deleted} đơn hàng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStatistics();
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

                // Tìm kiếm thống kê theo ngày với từ khóa
                var listThongKe = ThongKe.SearchThongKeTheoNgay(from, to, searchText);
                foreach (var item in listThongKe)
                {
<<<<<<< HEAD
                    dgvThongKe.Rows.Add(item.Ngay, item.SoDon, item.DoanhThu.ToString("N0"));
=======
                    // Định dạng ngày tháng trước khi thêm
                    string ngayHienThi = (item.Ngay != null && item.Ngay != DateTime.MinValue)
                                         ? item.Ngay.ToString("dd/MM/yyyy"): "";

                    dgvThongKe.Rows.Add(ngayHienThi, item.SoDon, item.DoanhThu.ToString("N0"), item.KMs, item.NhanVien);
>>>>>>> 821450bf0bd74fb3a00a2c278aa68b2b69209a0b
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

                // Lấy thống kê tổng quan
                var thongKeTongQuan = ThongKe.GetThongKeTongQuan(from, to);
                lblOrders.Text = thongKeTongQuan.SoDon.ToString();
                lblRevenue.Text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:N0} đ", thongKeTongQuan.DoanhThu);

                // Lấy thống kê theo ngày chi tiết
                var listThongKe = ThongKe.GetThongKeTheoNgayChiTiet(from, to);
                foreach (var item in listThongKe)
                {
<<<<<<< HEAD
                    dgvThongKe.Rows.Add(item.Ngay, item.SoDon, item.DoanhThu.ToString("N0"));
=======
                    // Định dạng ngày tháng trước khi thêm
                    string ngayHienThi = "";
                    if (item.Ngay != null && item.Ngay != DateTime.MinValue)
                    {
                        ngayHienThi = item.Ngay.ToString("dd/MM/yyyy");
                    }

                    // Thêm chuỗi đã định dạng (ngayHienThi) vào DGV
                    dgvThongKe.Rows.Add(ngayHienThi, item.SoDon, item.DoanhThu.ToString("N0"), item.KMs, item.NhanVien);
>>>>>>> 821450bf0bd74fb3a00a2c278aa68b2b69209a0b
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thống kê:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
