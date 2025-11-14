using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHoa.Data;
using QuanLyBanHoa.Models;
using System.Collections.Generic;

namespace QuanLyBanHoa.Forms
{
    public partial class FormDonHang : Form
    {
        // Class ?? l?u d? li?u t?m th?i v?i giá tr? copy
        private class ChiTietDonHangTam
        {
            public int MaDH { get; set; }
            public DateTime NgayDatHang { get; set; }
            public string TenKH { get; set; }
            public string Sdt { get; set; }
            public int MaNV { get; set; }
            public string TenNV { get; set; }
            public int MaHoa { get; set; }
            public string TenHoa { get; set; }
            public int SoLuong { get; set; }
            public decimal Gia { get; set; }
            public decimal ThanhTien { get; set; }
        }

        // Dictionary to store flower data: TenHoa -> (MaHoa, Gia)
        private Dictionary<string, (int MaHoa, decimal Gia)> flowerData = new Dictionary<string, (int, decimal)>();

        // Dictionary to store employee data: DisplayText -> MaNV
        private Dictionary<string, int> employeeData = new Dictionary<string, int>();

        // Dictionary to store employee names: MaNV -> TenNV
        private Dictionary<int, string> employeeNames = new Dictionary<int, string>();

        // Danh sách t?m th?i l?u d? li?u ??n hàng v?i giá tr? copy
        private List<ChiTietDonHangTam> listTam = new List<ChiTietDonHangTam>();

        // Flag ?? ng?n SelectionChanged khi ?ang nh?p li?u
        private bool isInputting = false;

        public FormDonHang()
        {
            try
            {
                InitializeComponent();

                // Subscribe to flower data change event
                frmHoa.HoaDataChanged += FrmHoa_HoaDataChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo form đơn hàng:\n{ex.Message}\n\nChi tiết:\n{ex.StackTrace}",
                    "Lỗi khởi tạo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void FrmHoa_HoaDataChanged(object sender, EventArgs e)
        {
            LoadHoaToComboBox();
        }

        private void FormDonHang_Load(object sender, EventArgs e)
        {
            try
            {
                if (dgvChiTiet != null)
                {
                    dgvChiTiet.AutoGenerateColumns = false;
                    dgvChiTiet.Rows.Clear();
                }

                if (dgvDonHang != null)
                {
                    dgvDonHang.ClearSelection();
                }

                // Load initial data
                LoadHoaToComboBox();
                LoadNhanVienToComboBox();
                LoadListTamFromDB();
                LoadDonHang();

                // txtMaDon cho phép nh?p th? công
                txtMaDon.ReadOnly = false;

                // Subscribe to TextChanged events ?? detect khi user b?t ??u nh?p
                txtTenKhach.TextChanged += (s, ev) => { if (!isInputting && !string.IsNullOrWhiteSpace(txtTenKhach.Text)) isInputting = true; };
                txtSdt.TextChanged += (s, ev) => { if (!isInputting && !string.IsNullOrWhiteSpace(txtSdt.Text)) isInputting = true; };
                txtMaDon.TextChanged += (s, ev) => { if (!isInputting && !string.IsNullOrWhiteSpace(txtMaDon.Text)) isInputting = true; };

                // Phân quy?n
                if (string.Equals(Session.Vaitro, "NhanVien", StringComparison.OrdinalIgnoreCase))
                {
                    btnXoa.Enabled = false;
                    btnThem.Enabled = true;
                }
                else if (string.Equals(Session.Vaitro, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    btnXoa.Enabled = true;
                    btnThem.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load form đơn Hàng:\n{ex.Message}\n\nChi ti?t:\n{ex.StackTrace}",
                    "Lỗi Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load danh sách nhân viên vào ComboBox - CH? nh?ng nhân viên có Users.VaiTro='NhanVien'
        /// </summary>
        private void LoadNhanVienToComboBox()
        {
            try
            {
                employeeData.Clear();
                employeeNames.Clear();
                cboMaNV.Items.Clear();

                // S? d?ng User.GetNhanVienOnly() t? Model
                var listNV = User.GetNhanVienOnly();

                foreach (var (maNV, tenNV) in listNV)
                {
                    string displayText = $"Mã: {maNV} - {tenNV}";
                    employeeData[displayText] = maNV;
                    employeeNames[maNV] = tenNV;
                    cboMaNV.Items.Add(displayText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân viên:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load flowers from database to ComboBox
        /// </summary>
        private void LoadHoaToComboBox()
        {
            try
            {
                flowerData.Clear();
                cboTenHoa.Items.Clear();

                List<Hoa> listHoa = Hoa.GetAll();
                foreach (var h in listHoa)
                {
                    flowerData[h.TenHoa] = (h.MaHoa, h.Gia);
                    cboTenHoa.Items.Add(h.TenHoa);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hoa:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTenHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboTenHoa.SelectedItem != null)
                {
                    string tenHoa = cboTenHoa.SelectedItem.ToString();

                    if (flowerData.ContainsKey(tenHoa))
                    {
                        var (maHoa, gia) = flowerData[tenHoa];
                        txtMaHoa.Text = maHoa.ToString();
                    }
                    else
                    {
                        txtMaHoa.Clear();
                    }
                }
                else
                {
                    txtMaHoa.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn hoa:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            frmHoa.HoaDataChanged -= FrmHoa_HoaDataChanged;
            base.OnFormClosing(e);
        }

        /// <summary>
        /// Load chi ti?t ??n hàng - KHÔNG PH? THU?C VÀO KhachHang
        /// Dùng snapshot t? b?ng DonHang: TenKH_DatHang, SoDienThoai_DatHang, TenNV_BanHang
        /// </summary>
        private void LoadDonHang()
        {
            try
            {
                dgvDonHang.Rows.Clear();

                // L?y DataTable t? Model - KHÔNG JOIN KhachHang
                DataTable dt = DonHang.LayDanhSachDonHang();

                foreach (DataRow row in dt.Rows)
                {
                    int maDH = row["MaDH"] != DBNull.Value ? Convert.ToInt32(row["MaDH"]) : 0;
                    string ngay = row["NgayDatHang"] != DBNull.Value ? Convert.ToDateTime(row["NgayDatHang"]).ToString("g") : "";
                    string tenKH = row["TenKH_DatHang"] != DBNull.Value ? row["TenKH_DatHang"].ToString() : "";
                    string sdt = row["SoDienThoai_DatHang"] != DBNull.Value ? row["SoDienThoai_DatHang"].ToString() : "";
                    string nhanVien = row["TenNV_BanHang"] != DBNull.Value ? row["TenNV_BanHang"].ToString() : "";
                    string tenHoa = row["TenHoa"] != DBNull.Value ? row["TenHoa"].ToString() : "";
                    int soLuong = row["SoLuong"] != DBNull.Value ? Convert.ToInt32(row["SoLuong"]) : 0;

                    // Thêm row vào DataGridView
                    int rowIndex = dgvDonHang.Rows.Add(maDH, ngay, tenKH, sdt, nhanVien, tenHoa, soLuong);

                    // L?u MaDH vào Tag ?? dùng khi c?n
                    dgvDonHang.Rows[rowIndex].Tag = maDH;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách đơn hàng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Khi ch?n ??n hàng -> hi?n th? chi ti?t và tính t?ng ti?n theo MaDon
        /// ??C T? CÁC C?T M?I: colTenKhach, colSDT, colNhanVien (không dùng colMaNV)
        /// </summary>
        private void dgvDonHang_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // KHÔNG load d? li?u n?u ?ang trong quá trình nh?p li?u m?i
                if (isInputting)
                    return;

                if (dgvDonHang.SelectedRows.Count == 0)
                {
                    if (dgvChiTiet != null)
                        dgvChiTiet.Rows.Clear();

                    if (lblTongTienValue != null) lblTongTienValue.Text = "0 VNĐ";

                    return;
                }

                var row = dgvDonHang.SelectedRows[0];

                string maDonStr = Convert.ToString(row.Cells["colMaDon"].Value ?? "");
                string ngayStr = Convert.ToString(row.Cells["colNgay"].Value ?? "");
                string tenKH = Convert.ToString(row.Cells["colTenKhach"].Value ?? "");
                string sdt = Convert.ToString(row.Cells["colSDT"].Value ?? "");
                string nhanVien = Convert.ToString(row.Cells["colNhanVien"].Value ?? ""); // ??i t? colMaNV sang colNhanVien

                // L?u mã ??n t? Tag c?a row
                int maDH = row.Tag != null ? Convert.ToInt32(row.Tag) : 0;

                if (!string.IsNullOrWhiteSpace(maDonStr)) txtMaDon.Text = maDonStr;
                else txtMaDon.Clear();

                if (dtpNgay != null && DateTime.TryParse(ngayStr, out DateTime ngayVal))
                    dtpNgay.Value = ngayVal;

                txtTenKhach.Text = tenKH;
                txtSdt.Text = sdt;

                // Try set flower selection based on displayed TenHoa
                string tenHoaDisplay = Convert.ToString(row.Cells["colTenHoa"].Value ?? "");
                if (!string.IsNullOrEmpty(tenHoaDisplay) && cboTenHoa.Items.Contains(tenHoaDisplay))
                {
                    cboTenHoa.SelectedItem = tenHoaDisplay;
                    // Ensure txtMaHoa reflects selected flower id
                    if (flowerData.ContainsKey(tenHoaDisplay))
                        txtMaHoa.Text = flowerData[tenHoaDisplay].MaHoa.ToString();
                }
                else
                {
                    txtMaHoa.Clear();
                }

                // Set nhân viên trong ComboBox d?a vào tên t? snapshot (n?u c?n)
                // N?u mu?n ch?n ?ứng nhân viên, tìm theo tên
                foreach (var emp in employeeData)
                {
                    if (employeeNames.ContainsKey(emp.Value) && employeeNames[emp.Value] == nhanVien)
                    {
                        cboMaNV.SelectedItem = emp.Key;
                        break;
                    }
                }

                // Load chi ti?t ??n hàng theo MaDon và tính t?ng ti?n
                if (dgvChiTiet != null)
                {
                    dgvChiTiet.Rows.Clear();

                    if (maDH > 0)
                    {
                        LoadChiTietDonHang(maDH);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý selection:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // H?y ?anh d?u nh?p li?u
                isInputting = false;
            }
        }

        /// <summary>
        /// Load chi ti?t ??n hàng theo MaDH và tính t?ng ti?n
        /// </summary>
        private void LoadChiTietDonHang(int maDH)
        {
            try
            {
                int tongSoLuong = 0;
                decimal tongTien = 0m;

                List<dynamic> listDetails = ChiTietDonHang.GetDetailWithHoaInfo(maDH);
                foreach (var detail in listDetails)
                {
                    string tenHoa = detail.TenHoa;
                    int sl = detail.SoLuong;
                    decimal thanhTien = detail.ThanhTien;
                    decimal donGia = sl > 0 ? thanhTien / sl : 0m;

                    dgvChiTiet.Rows.Add(tenHoa, sl, donGia.ToString("N2"));

                    tongSoLuong += sl;
                    tongTien += thanhTien;
                }

                // C?p nh?t t?ng s? l??ng
                if (nudTongSoLuong != null)
                {
                    if (tongSoLuong >= (int)nudTongSoLuong.Minimum && tongSoLuong <= (int)nudTongSoLuong.Maximum)
                    {
                        nudTongSoLuong.Value = tongSoLuong;
                    }
                    else if (tongSoLuong > (int)nudTongSoLuong.Maximum)
                    {
                        nudTongSoLuong.Value = nudTongSoLuong.Maximum;
                    }
                    else
                    {
                        nudTongSoLuong.Value = nudTongSoLuong.Minimum;
                    }
                }

                // C?p nh?t t?ng ti?n
                if (lblTongTienValue != null)
                {
                    var culture = new CultureInfo("vi-VN");
                    lblTongTienValue.Text = tongTien.ToString("c0", culture);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiếtt đơn:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Set selected employee trong ComboBox theo MaNV
        /// </summary>
        private void SetSelectedEmployee(int maNV)
        {
            foreach (var item in employeeData)
            {
                if (item.Value == maNV)
                {
                    cboMaNV.SelectedItem = item.Key;
                    return;
                }
            }
            cboMaNV.SelectedIndex = -1;
        }

        /// <summary>
        /// Ki?m tra ??n hàng ?ã t?n t?i chưa, n?u có thì c?p nh?t, n?u không thì t?o m?i
        /// </summary>
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(txtTenKhach.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenKhach.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSdt.Text))
                {
                    MessageBox.Show("Vui lòng nh?p s? ?iễn tho?i khách hàng.", "Thi?u thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSdt.Focus();
                    return;
                }

                if (cboMaNV.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMaNV.Focus();
                    return;
                }

                // Validate flower selection
                if (cboTenHoa.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn loại hoa.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboTenHoa.Focus();
                    return;
                }

                string tenHoa = cboTenHoa.SelectedItem.ToString();

                if (!flowerData.ContainsKey(tenHoa))
                {
                    MessageBox.Show("Không tìm thấy thông tin hoa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get MaNV from ComboBox
                string selectedEmployee = cboMaNV.SelectedItem.ToString();
                if (!employeeData.ContainsKey(selectedEmployee))
                {
                    MessageBox.Show("Không tìm thấy thông tin nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int maNV = employeeData[selectedEmployee];
                string tenNV = employeeNames.ContainsKey(maNV) ? employeeNames[maNV] : "Unknown";

                var (maHoa, gia) = flowerData[tenHoa];
                int soLuong = (int)nudTongSoLuong.Value;

                if (soLuong <= 0)
                {
                    MessageBox.Show("Só lượng phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudTongSoLuong.Focus();
                    return;
                }

                decimal thanhTien = soLuong * gia;

                // T?o d? li?u t?m v?i giá tr? copy
                ChiTietDonHangTam tam = new ChiTietDonHangTam
                {
                    NgayDatHang = dtpNgay.Value.Date,
                    TenKH = txtTenKhach.Text.Trim(),
                    Sdt = txtSdt.Text.Trim(),
                    MaNV = maNV,
                    TenNV = tenNV,
                    MaHoa = maHoa,
                    TenHoa = tenHoa,
                    SoLuong = soLuong,
                    Gia = gia,
                    ThanhTien = thanhTien
                };

                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    // 1) Ensure MaKH exists và l?y thông tin snapshot
                    int maKH = 0;
                    string snapshotTenKH = txtTenKhach.Text.Trim();
                    string snapshotDiaChi = "";
                    string snapshotSDT = txtSdt.Text.Trim();

                    KhachHang existingKH = KhachHang.GetByPhone(txtSdt.Text.Trim(), conn);
                    if (existingKH != null)
                    {
                        maKH = existingKH.MaKH;

                        // L?y snapshot t? KhachHang hi?n t?i
                        snapshotTenKH = !string.IsNullOrWhiteSpace(txtTenKhach.Text.Trim()) ? txtTenKhach.Text.Trim() : existingKH.TenKH;
                        snapshotDiaChi = existingKH.DiaChi ?? "";
                        snapshotSDT = existingKH.SoDienThoai;

                        // C?p nh?t tên khách hàng n?u khác v?i tên ?ã l?u
                        string newTenKH = txtTenKhach.Text.Trim();
                        if (!string.IsNullOrWhiteSpace(newTenKH) && newTenKH != existingKH.TenKH)
                        {
                            existingKH.TenKH = newTenKH;
                            KhachHang.Update(existingKH, conn);
                        }
                    }
                    else
                    {
                        // Khách hàng m?i - t?o record m?i
                        KhachHang newKH = new KhachHang
                        {
                            TenKH = txtTenKhach.Text.Trim(),
                            SoDienThoai = txtSdt.Text.Trim()
                        };
                        maKH = KhachHang.Insert(newKH, conn);
                        if (maKH == 0)
                            throw new Exception("Không thể tạo khách hàng mới.");

                        snapshotTenKH = newKH.TenKH;
                        snapshotDiaChi = newKH.DiaChi ?? "";
                        snapshotSDT = newKH.SoDienThoai;
                    }

                    // L?y snapshot tên nhân viên
                    string snapshotTenNV = tenNV;

                    int maDH;
                    bool isExistingOrder = false;

                    // 2) Ki?m tra xem có nh?p MaDon không
                    if (!string.IsNullOrWhiteSpace(txtMaDon.Text) && int.TryParse(txtMaDon.Text.Trim(), out int maDHInput))
                    {
                        // Ki?m tra ??n hàng ?ã t?n t?i ch?a
                        DonHang dh = DonHang.GetById(maDHInput, conn);
                        isExistingOrder = dh != null;

                        maDH = maDHInput;

                        if (!isExistingOrder)
                        {
                            // T?o ??n hàng m?i v?i MaDH ???c ch? ??nh - DÙNG SNAPSHOT
                            if (!DonHang.InsertWithId(new DonHang {
                                MaDH = maDH,
                                MaKH = maKH,
                                MaNV = maNV,
                                NgayDatHang = dtpNgay.Value.Date,
                                TongTien = thanhTien,
                                MaKM = null,
                                TenKH_DatHang = snapshotTenKH,
                                DiaChi_DatHang = snapshotDiaChi,
                                SoDienThoai_DatHang = snapshotSDT,
                                TenNV_BanHang = snapshotTenNV
                            }, conn))
                                throw new Exception("Không thể tạo đơn hàng mớii.");
                        }
                        else
                        {
                            // ??n hàng ?ã t?n t?i - c?p nh?t TongTien
                            DonHang.UpdateTongTien(maDH, thanhTien, conn);
                        }
                    }
                    else
                    {
                        // Không nh?p MaDon - t?o ??n hàng m?i v?i IDENTITY - DÙNG SNAPSHOT
                        maDH = DonHang.Insert(new DonHang {
                            MaKH = maKH,
                            MaNV = maNV,
                            NgayDatHang = dtpNgay.Value.Date,
                            TongTien = thanhTien,
                            MaKM = null,
                            TenKH_DatHang = snapshotTenKH,
                            DiaChi_DatHang = snapshotDiaChi,
                            SoDienThoai_DatHang = snapshotSDT,
                            TenNV_BanHang = snapshotTenNV
                        }, conn);
                        if (maDH == 0)
                            throw new Exception("Không thể tạo đơn hàng mới.");
                    }

                    // Set MaDH cho d? li?u t?m
                    tam.MaDH = maDH;

                    // 3) Insert ChiTietDonHang - KHÔNG TRUY?N MaNV
                    ChiTietDonHang.Insert(new ChiTietDonHang { MaDH = maDH, MaHoa = maHoa, SoLuong = soLuong, ThanhTien = thanhTien, TenHoa_DatHang = tam.TenHoa, DonGia = tam.Gia }, conn);

                    // Thêm vào danh sách t?m
                    listTam.Add(tam);

                    string message = isExistingOrder
                        ? $"Đã thêm {tenHoa} ({soLuong}) vào đen hàng #{maDH}."
                        : $"Tạo đơn hàng mới (Mã: {maDH}).\nĐã thêm {tenHoa} ({soLuong}).";

                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload danh sách ??n hàng
                    LoadDonHang();

                    // Clear T?T C? các ô nh?p ?? s?n sàng nh?p ??n m?i
                    ClearAllInputs();

                    // Focus vào Tên khách hàng ?? b?t ??u ??n m?i
                    txtTenKhach.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu đơn hàng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Clear t?t c? các ô nh?p li?u sau khi thêm ??n hàng thành công
        /// </summary>
        private void ClearAllInputs()
        {
            // B?t flag ?? ng?n SelectionChanged ghi ?è d? li?u
            isInputting = true;

            txtMaDon.Clear();
            txtTenKhach.Clear();
            txtSdt.Clear();
            cboMaNV.SelectedIndex = -1;
            cboTenHoa.SelectedIndex = -1;
            txtMaHoa.Clear();
            nudTongSoLuong.Value = 1;
            dtpNgay.Value = DateTime.Now;

            // Clear selection trong dgvDonHang ?? tránh conflict
            if (dgvDonHang.Rows.Count > 0)
            {
                dgvDonHang.ClearSelection();
            }

            // T?t flag sau khi clear xong
            isInputting = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.Equals(Session.Vaitro, "NhanVien", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Bạn không có quyền xóa đơn hàng!", "Không có quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (dgvDonHang.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn đơn hàng xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var row = dgvDonHang.SelectedRows[0];
                if (!int.TryParse(Convert.ToString(row.Cells["colMaDon"].Value ?? ""), out int maDH))
                {
                    MessageBox.Show("Mã đơn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var res = MessageBox.Show($"Bạn có chắcc muốn xóa đơn hàng #{maDH}?\nHành động này không thể hoàn tác.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res != DialogResult.Yes) return;

                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    ChiTietDonHang.DeleteByMaDH(maDH, conn);

                    DonHang.Delete(maDH, conn);

                    MessageBox.Show("Xóa đơn hàng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListTamFromDB();
                    LoadDonHang();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa đơn hàng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler for cell formatting in dgvDonHang - adds tooltip for long text
        /// </summary>
        private void dgvDonHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.Value != null && (dgvDonHang.Columns[e.ColumnIndex].Name == "colTenKhach" ||
                    dgvDonHang.Columns[e.ColumnIndex].Name == "colTenHoa"))
                {
                    string cellText = e.Value.ToString();
                    if (!string.IsNullOrEmpty(cellText))
                    {
                        dgvDonHang.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = cellText;
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Event handler for cell formatting in dgvChiTiet - adds tooltip for long text
        /// </summary>
        private void dgvChiTiet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.Value != null && dgvChiTiet.Columns[e.ColumnIndex].Name == "colCT_SanPham")
                {
                    string cellText = e.Value.ToString();
                    if (!string.IsNullOrEmpty(cellText))
                    {
                        dgvChiTiet.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = cellText;
                    }
                }
            }
            catch { }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear t?t c? các ô nh?p
                ClearAllInputs();

                // Focus vào ô tên khách hàng
                txtTenKhach.Focus();

                MessageBox.Show("Đã làm mới form.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load danh sách t?m t? database v?i giá tr? snapshot
        /// </summary>
        private void LoadListTamFromDB()
        {
            try
            {
                listTam.Clear();
                List<dynamic> listDetails = DonHang.GetOrdersWithDetails();
                foreach (var detail in listDetails)
                {
                    string tenNV = employeeNames.ContainsKey(detail.MaNV) ? employeeNames[detail.MaNV] : "Unknown";
                    listTam.Add(new ChiTietDonHangTam
                    {
                        MaDH = detail.MaDH,
                        NgayDatHang = detail.NgayDatHang,
                        TenKH = detail.TenKH,
                        Sdt = detail.SoDienThoai,
                        MaNV = detail.MaNV,
                        TenNV = tenNV,
                        MaHoa = detail.MaHoa,
                        TenHoa = detail.TenHoa,
                        SoLuong = detail.SoLuong,
                        Gia = detail.Gia,
                        ThanhTien = detail.ThanhTien
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
