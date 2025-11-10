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
        // Dictionary to store flower data: TenHoa -> (MaHoa, Gia)
        private Dictionary<string, (int MaHoa, decimal Gia)> flowerData = new Dictionary<string, (int, decimal)>();
        
        // Dictionary to store employee data: DisplayText -> MaNV
        private Dictionary<string, int> employeeData = new Dictionary<string, int>();
        
        // Flag để ngăn SelectionChanged khi đang nhập liệu
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
                MessageBox.Show($"Lỗi khởi tạo form Đơn Hàng:\n{ex.Message}\n\nChi tiết:\n{ex.StackTrace}",
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
                LoadDonHang();
                
                // txtMaDon cho phép nhập thủ công
                txtMaDon.ReadOnly = false;
                
                // Subscribe to TextChanged events để detect khi user bắt đầu nhập
                txtTenKhach.TextChanged += (s, ev) => { if (!isInputting && !string.IsNullOrWhiteSpace(txtTenKhach.Text)) isInputting = true; };
                txtSdt.TextChanged += (s, ev) => { if (!isInputting && !string.IsNullOrWhiteSpace(txtSdt.Text)) isInputting = true; };
                txtMaDon.TextChanged += (s, ev) => { if (!isInputting && !string.IsNullOrWhiteSpace(txtMaDon.Text)) isInputting = true; };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load form Đơn Hàng:\n{ex.Message}\n\nChi tiết:\n{ex.StackTrace}",
                    "Lỗi Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load danh sách nhân viên vào ComboBox
        /// </summary>
        private void LoadNhanVienToComboBox()
        {
            try
            {
                employeeData.Clear();
                cboMaNV.Items.Clear();

                // Sử dụng class NhanVien để lấy danh sách
                List<NhanVien> listNhanVien = NhanVien.GetAll();

                foreach (var nv in listNhanVien)
                {
                    // Format: "Mã: 1 - Nguyễn Văn A (Quản lý)"
                    string displayText = $"Mã: {nv.MaNV} - {nv.TenNV} ({nv.ChucVu})";
                    employeeData[displayText] = nv.MaNV;
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

                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT MaHoa, TenHoa, Gia FROM Hoa ORDER BY TenHoa";
                    
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        using (var rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                int maHoa = rdr.GetInt32(0);
                                string tenHoa = rdr.GetString(1);
                                decimal gia = rdr.GetDecimal(2);

                                flowerData[tenHoa] = (maHoa, gia);
                                cboTenHoa.Items.Add(tenHoa);
                            }
                        }
                    }
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
        /// Load chi tiết đơn hàng - hiển thị từng dòng chi tiết (mỗi lần thêm hoa)
        /// Giúp dễ kiểm soát đơn hàng hơn
        /// </summary>
        private void LoadDonHang()
        {
            try
            {
                dgvDonHang.Rows.Clear();

                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    // Query hiển thị CHI TIẾT từng dòng - mỗi lần thêm hoa là 1 dòng
                    string sql = @"SELECT TOP 500 
                                    ct.MaDH, 
                                    d.NgayDatHang, 
                                    k.TenKH, 
                                    k.SoDienThoai, 
                                    ct.MaNV,
                                    h.TenHoa,
                                    ct.SoLuong
                                  FROM ChiTietDonHang ct
                                  INNER JOIN DonHang d ON ct.MaDH = d.MaDH
                                  LEFT JOIN KhachHang k ON d.MaKH = k.MaKH
                                  LEFT JOIN Hoa h ON ct.MaHoa = h.MaHoa
                                  ORDER BY ct.MaDH DESC, h.TenHoa";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        using (var rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                int maDH = rdr.IsDBNull(0) ? 0 : rdr.GetInt32(0);
                                DateTime ngay = rdr.IsDBNull(1) ? DateTime.MinValue : rdr.GetDateTime(1);
                                string tenKH = rdr.IsDBNull(2) ? string.Empty : rdr.GetString(2);
                                string sdt = rdr.IsDBNull(3) ? string.Empty : rdr.GetString(3);
                                int maNV = rdr.IsDBNull(4) ? 0 : rdr.GetInt32(4);
                                string tenHoa = rdr.IsDBNull(5) ? string.Empty : rdr.GetString(5);
                                int soLuong = rdr.IsDBNull(6) ? 0 : rdr.GetInt32(6);

                                dgvDonHang.Rows.Add(maDH, ngay.ToString("g"), tenKH, sdt, maNV.ToString(), tenHoa, soLuong);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách đơn hàng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Khi chọn đơn hàng -> hiển thị chi tiết và tính tổng tiền theo MaDon
        /// </summary>
        private void dgvDonHang_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // KHÔNG load dữ liệu nếu đang trong quá trình nhập liệu mới
                if (isInputting)
                    return;

                if (dgvDonHang.SelectedRows.Count == 0)
                {
                    if (dgvChiTiet != null)
                        dgvChiTiet.Rows.Clear();

                    if (lblTongTienValue != null) lblTongTienValue.Text = "0 đ";
                    
                    return;
                }

                var row = dgvDonHang.SelectedRows[0];

                string maDonStr = Convert.ToString(row.Cells["colMaDon"].Value ?? "");
                string ngayStr = Convert.ToString(row.Cells["colNgay"].Value ?? "");
                string tenKH = Convert.ToString(row.Cells["colTenKhach"].Value ?? "");
                string sdt = Convert.ToString(row.Cells["colSDT"].Value ?? "");
                string sMaNV = Convert.ToString(row.Cells["colMaNV"].Value ?? "");

                if (!string.IsNullOrWhiteSpace(maDonStr)) txtMaDon.Text = maDonStr;
                else txtMaDon.Clear();

                if (dtpNgay != null && DateTime.TryParse(ngayStr, out DateTime ngayVal))
                    dtpNgay.Value = ngayVal;

                txtTenKhach.Text = tenKH;
                txtSdt.Text = sdt;
                
                // Set selected employee in ComboBox
                if (int.TryParse(sMaNV, out int maNV))
                {
                    SetSelectedEmployee(maNV);
                }

                // Load chi tiết đơn hàng theo MaDon và tính tổng tiền
                if (dgvChiTiet != null)
                {
                    dgvChiTiet.Rows.Clear();

                    if (int.TryParse(maDonStr, out int maDH))
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
                // Hủy đánh dấu nhập liệu
                isInputting = false;
            }
        }

        /// <summary>
        /// Load chi tiết đơn hàng theo MaDH và tính tổng tiền
        /// </summary>
        private void LoadChiTietDonHang(int maDH)
        {
            try
            {
                int tongSoLuong = 0;
                decimal tongTien = 0m;

                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT ct.MaHoa, h.TenHoa, ct.SoLuong, ct.ThanhTien, ct.MaNV
                                   FROM ChiTietDonHang ct
                                   LEFT JOIN Hoa h ON ct.MaHoa = h.MaHoa
                                   WHERE ct.MaDH = @MaDH";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDH", maDH);
                        using (var rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                string tenHoa = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1);
                                int sl = rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2);
                                decimal thanhTien = rdr.IsDBNull(3) ? 0m : rdr.GetDecimal(3);
                                decimal donGia = sl > 0 ? thanhTien / sl : 0m;

                                dgvChiTiet.Rows.Add(tenHoa, sl, donGia.ToString("N2"));

                                tongSoLuong += sl;
                                tongTien += thanhTien;
                            }
                        }
                    }
                }

                // Cập nhật tổng số lượng
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

                // Cập nhật tổng tiền
                if (lblTongTienValue != null)
                {
                    lblTongTienValue.Text = tongTien.ToString("N0") + " đ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết đơn:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// Kiểm tra đơn hàng đã tồn tại chưa, nếu có thì cập nhật, nếu không thì tạo mới
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
                    MessageBox.Show("Vui lòng nhập số điện thoại khách hàng.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                var (maHoa, gia) = flowerData[tenHoa];
                int soLuong = (int)nudTongSoLuong.Value;

                if (soLuong <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudTongSoLuong.Focus();
                    return;
                }

                decimal thanhTien = soLuong * gia;

                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    using (var tx = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1) Ensure MaKH exists
                            int maKH = 0;
                            using (var cmdFind = new SqlCommand("SELECT TOP 1 MaKH FROM KhachHang WHERE SoDienThoai = @sdt", conn, tx))
                            {
                                cmdFind.Parameters.AddWithValue("@sdt", txtSdt.Text.Trim());
                                var obj = cmdFind.ExecuteScalar();
                                if (obj != null && int.TryParse(obj.ToString(), out int found))
                                    maKH = found;
                            }

                            if (maKH == 0)
                            {
                                using (var cmdInsKH = new SqlCommand("INSERT INTO KhachHang (TenKH, SoDienThoai) VALUES (@ten, @sdt); SELECT CAST(SCOPE_IDENTITY() AS INT);", conn, tx))
                                {
                                    cmdInsKH.Parameters.AddWithValue("@ten", txtTenKhach.Text.Trim());
                                    cmdInsKH.Parameters.AddWithValue("@sdt", txtSdt.Text.Trim());
                                    var id = cmdInsKH.ExecuteScalar();
                                    if (id == null) throw new Exception("Không tạo được khách hàng.");
                                    maKH = Convert.ToInt32(id);
                                }
                            }

                            object maKmDb = DBNull.Value;
                            int maDH;
                            bool identityInsertEnabled = false;
                            bool isExistingOrder = false;

                            try
                            {
                                // 2) Kiểm tra xem có nhập MaDon không
                                if (!string.IsNullOrWhiteSpace(txtMaDon.Text) && int.TryParse(txtMaDon.Text.Trim(), out int maDHInput))
                                {
                                    // Kiểm tra đơn hàng đã tồn tại chưa
                                    using (var cmdCheck = new SqlCommand("SELECT COUNT(*) FROM DonHang WHERE MaDH = @MaDH", conn, tx))
                                    {
                                        cmdCheck.Parameters.AddWithValue("@MaDH", maDHInput);
                                        int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                                        isExistingOrder = count > 0;
                                    }

                                    maDH = maDHInput;

                                    if (!isExistingOrder)
                                    {
                                        // Bật IDENTITY_INSERT để insert MaDH thủ công
                                        using (var cmdIdentity = new SqlCommand("SET IDENTITY_INSERT DonHang ON", conn, tx))
                                        {
                                            cmdIdentity.ExecuteNonQuery();
                                            identityInsertEnabled = true;
                                        }

                                        // Tạo đơn hàng mới với MaDH được chỉ định
                                        string insertDon = @"INSERT INTO DonHang (MaDH, MaKH, MaNV, NgayDatHang, TongTien, MaKM) 
                                                            VALUES (@MaDH, @MaKH, @MaNV, @NgayDatHang, @TongTien, @MaKM);";
                                        using (var cmdDon = new SqlCommand(insertDon, conn, tx))
                                        {
                                            cmdDon.Parameters.AddWithValue("@MaDH", maDH);
                                            cmdDon.Parameters.AddWithValue("@MaKH", maKH);
                                            cmdDon.Parameters.AddWithValue("@MaNV", maNV);
                                            cmdDon.Parameters.AddWithValue("@NgayDatHang", dtpNgay.Value.Date);
                                            cmdDon.Parameters.AddWithValue("@TongTien", thanhTien);
                                            cmdDon.Parameters.AddWithValue("@MaKM", maKmDb);
                                            cmdDon.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        // Đơn hàng đã tồn tại - cập nhật TongTien
                                        string updateDon = @"UPDATE DonHang 
                                                            SET TongTien = TongTien + @ThemTien 
                                                            WHERE MaDH = @MaDH";
                                        using (var cmdUpdate = new SqlCommand(updateDon, conn, tx))
                                        {
                                            cmdUpdate.Parameters.AddWithValue("@ThemTien", thanhTien);
                                            cmdUpdate.Parameters.AddWithValue("@MaDH", maDH);
                                            cmdUpdate.ExecuteNonQuery();
                                        }
                                    }
                                }
                                else
                                {
                                    // Không nhập MaDon - tạo đơn hàng mới với IDENTITY
                                    string insertDon = @"INSERT INTO DonHang (MaKH, MaNV, NgayDatHang, TongTien, MaKM) 
                                                        VALUES (@MaKH, @MaNV, @NgayDatHang, @TongTien, @MaKM); 
                                                        SELECT CAST(SCOPE_IDENTITY() AS INT);";
                                    using (var cmdDon = new SqlCommand(insertDon, conn, tx))
                                    {
                                        cmdDon.Parameters.AddWithValue("@MaKH", maKH);
                                        cmdDon.Parameters.AddWithValue("@MaNV", maNV);
                                        cmdDon.Parameters.AddWithValue("@NgayDatHang", dtpNgay.Value.Date);
                                        cmdDon.Parameters.AddWithValue("@TongTien", thanhTien);
                                        cmdDon.Parameters.AddWithValue("@MaKM", maKmDb);
                                        
                                        var idObj = cmdDon.ExecuteScalar();
                                        if (idObj == null) throw new Exception("Không lấy được ID DonHang.");
                                        maDH = Convert.ToInt32(idObj);
                                    }
                                }

                                // 3) Insert ChiTietDonHang
                                string insertCt = @"INSERT INTO ChiTietDonHang (MaDH, MaHoa, SoLuong, ThanhTien, MaNV) 
                                                  VALUES (@MaDH, @MaHoa, @SoLuong, @ThanhTien, @MaNV);";
                                using (var cmdCt = new SqlCommand(insertCt, conn, tx))
                                {
                                    cmdCt.Parameters.AddWithValue("@MaDH", maDH);
                                    cmdCt.Parameters.AddWithValue("@MaHoa", maHoa);
                                    cmdCt.Parameters.AddWithValue("@SoLuong", soLuong);
                                    cmdCt.Parameters.AddWithValue("@ThanhTien", thanhTien);
                                    cmdCt.Parameters.AddWithValue("@MaNV", maNV);
                                    cmdCt.ExecuteNonQuery();
                                }
                            }
                            finally
                            {
                                // Tắt IDENTITY_INSERT nếu đã bật
                                if (identityInsertEnabled)
                                {
                                    try
                                    {
                                        using (var cmdIdentity = new SqlCommand("SET IDENTITY_INSERT DonHang OFF", conn, tx))
                                        {
                                            cmdIdentity.ExecuteNonQuery();
                                        }
                                    }
                                    catch { }
                                }
                            }

                            tx.Commit();

                            string message = isExistingOrder 
                                ? $"Đã thêm {tenHoa} ({soLuong}) vào đơn hàng #{maDH}."
                                : $"Tạo đơn hàng mới (Mã: {maDH}).\nĐã thêm {tenHoa} ({soLuong}).";
                            
                            MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Reload danh sách đơn hàng
                            LoadDonHang();
                            
                            // Clear TẤT CẢ các ô nhập để sẵn sàng nhập đơn mới
                            ClearAllInputs();
                            

                            // Focus vào Tên khách hàng để bắt đầu đơn mới
                            txtTenKhach.Focus();
                        }
                        catch (Exception ex)
                        {
                            try { tx.Rollback(); } catch { }
                            MessageBox.Show($"Lỗi khi thêm đơn hàng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu đơn hàng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Clear tất cả các ô nhập liệu sau khi thêm đơn hàng thành công
        /// </summary>
        private void ClearAllInputs()
        {
            // Bật flag để ngăn SelectionChanged ghi đè dữ liệu
            isInputting = true;
            
            txtMaDon.Clear();
            txtTenKhach.Clear();
            txtSdt.Clear();
            cboMaNV.SelectedIndex = -1;
            cboTenHoa.SelectedIndex = -1;
            txtMaHoa.Clear();
            nudTongSoLuong.Value = 1;
            dtpNgay.Value = DateTime.Now;
            
            // Clear selection trong dgvDonHang để tránh conflict
            if (dgvDonHang.Rows.Count > 0)
            {
                dgvDonHang.ClearSelection();
            }
            
            // Tắt flag sau khi clear xong
            isInputting = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaDon.Text) || !int.TryParse(txtMaDon.Text.Trim(), out int maDH))
                {
                    MessageBox.Show("Vui lòng chọn một đơn hàng để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cboMaNV.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string selectedEmployee = cboMaNV.SelectedItem.ToString();
                if (!employeeData.ContainsKey(selectedEmployee))
                {
                    MessageBox.Show("Không tìm thấy thông tin nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int maNV = employeeData[selectedEmployee];

                object maKmDb = DBNull.Value;
                decimal tongTien = 0m;

                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    
                    // Tính lại tổng tiền từ ChiTietDonHang
                    using (var cmdSum = new SqlCommand("SELECT COALESCE(SUM(ThanhTien), 0) FROM ChiTietDonHang WHERE MaDH = @MaDH", conn))
                    {
                        cmdSum.Parameters.AddWithValue("@MaDH", maDH);
                        var result = cmdSum.ExecuteScalar();
                        if (result != null) tongTien = Convert.ToDecimal(result);
                    }
                    
                    using (var tx = conn.BeginTransaction())
                    {
                        try
                        {
                            using (var cmd = new SqlCommand("UPDATE DonHang SET MaNV = @MaNV, NgayDatHang = @Ngay, TongTien = @TongTien, MaKM = @MaKM WHERE MaDH = @MaDH", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@MaNV", maNV);
                                cmd.Parameters.AddWithValue("@Ngay", dtpNgay.Value.Date);
                                cmd.Parameters.AddWithValue("@TongTien", tongTien);
                                cmd.Parameters.AddWithValue("@MaKM", maKmDb);
                                cmd.Parameters.AddWithValue("@MaDH", maDH);
                                cmd.ExecuteNonQuery();
                            }

                            tx.Commit();

                            MessageBox.Show("Cập nhật đơn hàng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDonHang();
                        }
                        catch (Exception ex)
                        {
                            try { tx.Rollback(); } catch { }
                            MessageBox.Show($"Lỗi khi cập nhật đơn hàng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa đơn hàng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDonHang.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn đơn hàng để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var row = dgvDonHang.SelectedRows[0];
                if (!int.TryParse(Convert.ToString(row.Cells["colMaDon"].Value ?? ""), out int maDH))
                {
                    MessageBox.Show("Mã đơn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var res = MessageBox.Show($"Bạn có chắc muốn xóa đơn hàng #{maDH}?\nHành động này không thể hoàn tác.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res != DialogResult.Yes) return;

                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    using (var tx = conn.BeginTransaction())
                    {
                        try
                        {
                            using (var cmdDelCt = new SqlCommand("DELETE FROM ChiTietDonHang WHERE MaDH = @MaDH", conn, tx))
                            {
                                cmdDelCt.Parameters.AddWithValue("@MaDH", maDH);
                                cmdDelCt.ExecuteNonQuery();
                            }

                            using (var cmdDel = new SqlCommand("DELETE FROM DonHang WHERE MaDH = @MaDH", conn, tx))
                            {
                                cmdDel.Parameters.AddWithValue("@MaDH", maDH);
                                cmdDel.ExecuteNonQuery();
                            }

                            tx.Commit();

                            dgvDonHang.Rows.Remove(row);
                            MessageBox.Show("Xóa đơn hàng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            try { tx.Rollback(); } catch { }
                            MessageBox.Show($"Lỗi khi xóa đơn hàng:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
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
    }
}
