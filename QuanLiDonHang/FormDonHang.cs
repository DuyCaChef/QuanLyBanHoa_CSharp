using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiDonHang
{
    public partial class FormDonHang : Form
    {
        public FormDonHang()
        {
            InitializeComponent();
        }

        // Khởi tạo mặc định: chi tiết trống, chờ chọn đơn
        private void FormDonHang_Load(object sender, EventArgs e)
        {
            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.Rows.Clear();
            if (dgvDonHang.SelectedRows.Count == 0 && dgvDonHang.Rows.Count > 0)
            {
                // Không tự chọn hàng nào để tránh hiểu nhầm nhập chi tiết
                dgvDonHang.ClearSelection();
            }
        }

        // Khi chọn một đơn ở danh sách -> hiển thị chi tiết (chỉ xem)
        private void dgvDonHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDonHang.SelectedRows.Count == 0)
            {
                dgvChiTiet.Rows.Clear();
                return;
            }

            var row = dgvDonHang.SelectedRows[0];

            // Lấy dữ liệu cơ bản từ danh sách đơn (nếu có)
            string tenHang = Convert.ToString(row.Cells["colTenHoa"].Value ?? "");
            string sSoLuong = Convert.ToString(row.Cells["colSoLuong"].Value ?? "0");
            string sTongTien = Convert.ToString(row.Cells["colGia"].Value ?? "0");

            int soLuong;
            if (!int.TryParse(sSoLuong, NumberStyles.Any, CultureInfo.CurrentCulture, out soLuong))
                soLuong = 0;

            decimal tongTien;
            if (!decimal.TryParse(sTongTien, NumberStyles.Any, CultureInfo.CurrentCulture, out tongTien))
                tongTien = 0m;

            // Cập nhật ô nhập tổng số lượng
            if (soLuong >= (int)nudTongSoLuong.Minimum && soLuong <= (int)nudTongSoLuong.Maximum)
            {
                nudTongSoLuong.Value = Math.Max(nudTongSoLuong.Minimum, Math.Min(nudTongSoLuong.Maximum, soLuong));
            }
            else if (soLuong > (int)nudTongSoLuong.Maximum)
            {
                nudTongSoLuong.Value = nudTongSoLuong.Maximum;
            }
            else
            {
                nudTongSoLuong.Value = nudTongSoLuong.Minimum;
            }

            // Tính đơn giá (nếu có số lượng)
            decimal donGia = 0m;
            if (soLuong > 0)
                donGia = tongTien / soLuong;

            // Hiển thị chi tiết: ở đây demo 1 dòng dựa trên dữ liệu lưới đơn hàng
            // Trong thực tế, có thể truy vấn DB theo mã đơn để lấy nhiều dòng chi tiết
            dgvChiTiet.Rows.Clear();
            if (!string.IsNullOrWhiteSpace(tenHang) || soLuong > 0 || tongTien > 0)
            {
                dgvChiTiet.Rows.Add(tenHang, soLuong, donGia);
            }
        }
    }
}
