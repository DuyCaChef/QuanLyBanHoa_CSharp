using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyBanHoa.Data;

namespace QuanLyBanHoa_CSharp.Forms
{
    public partial class FormDonHang : Form
    {
        public FormDonHang()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo form Đơn Hàng:\n{ex.Message}\n\nChi tiết:\n{ex.StackTrace}",
                    "Lỗi khởi tạo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; // Re-throw để caller biết có lỗi
            }
        }

        // Khởi tạo mặc định: chi tiết trống, chờ chọn đơn
        private void FormDonHang_Load(object sender, EventArgs e)
        {
            try
            {
                if (dgvChiTiet != null)
                {
                    dgvChiTiet.AutoGenerateColumns = false;
                    dgvChiTiet.Rows.Clear();
                }

                if (dgvDonHang != null && dgvDonHang.SelectedRows.Count == 0 && dgvDonHang.Rows.Count > 0)
                {
                    // Không tự chọn hàng nào để tránh hiểu nhầm nhập chi tiết
                    dgvDonHang.ClearSelection();
                }

                // Load initial orders from database
                LoadDonHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load form Đơn Hàng:\n{ex.Message}\n\nChi tiết:\n{ex.StackTrace}",
                    "Lỗi Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load orders from database and populate dgvDonHang.
        /// Shows one representative product per order, total quantity and total amount.
        /// </summary>
        private void LoadDonHang()
        {
            try
            {
                dgvDonHang.Rows.Clear();

                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    // Query: join DonHang with KhachHang and get one product + sums from ChiTietDonHang
                    string sql = @"SELECT d.MaDH, d.NgayDatHang, k.TenKH, k.SoDienThoai, d.MaNV,
                                    (SELECT h.TenHoa FROM ChiTietDonHang ct JOIN Hoa h ON ct.MaHoa = h.MaHoa WHERE ct.MaDH = d.MaDH LIMIT 1) AS TenHoa,
                                    (SELECT SUM(SoLuong) FROM ChiTietDonHang WHERE MaDH = d.MaDH) AS SumSoLuong,
                                    d.TongTien
                                  FROM DonHang d
                                  LEFT JOIN KhachHang k ON d.MaKH = k.MaKH
                                  ORDER BY d.NgayDatHang DESC, d.MaDH DESC LIMIT 500";

                    using (var cmd = new MySqlCommand(sql, conn))
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
                                int soLuong = rdr.IsDBNull(6) ? 0 : Convert.ToInt32(rdr.GetValue(6));
                                decimal tongTien = rdr.IsDBNull(7) ? 0m : rdr.GetDecimal(7);

                                dgvDonHang.Rows.Add(maDH, ngay.ToString("g"), tenKH, sdt, maNV.ToString(), tenHoa, soLuong, tongTien.ToString("N2"));
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

        // Khi chọn một đơn ở danh sách -> hiển thị chi tiết (chỉ xem)
        private void dgvDonHang_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvDonHang.SelectedRows.Count == 0)
                {
                    if (dgvChiTiet != null)
                        dgvChiTiet.Rows.Clear();

                    // Clear input fields
                    txtMaDon.Clear();
                    txtTenKhach.Clear();
                    txtSdt.Clear();
                    txtMaNV.Clear();
                    txtMaKM.Clear();
                    if (nudTongSoLuong != null) nudTongSoLuong.Value = nudTongSoLuong.Minimum;
                    return;
                }

                var row = dgvDonHang.SelectedRows[0];

                // Lấy dữ liệu cơ bản từ danh sách đơn (nếu có)
                string maDonStr = Convert.ToString(row.Cells["colMaDon"].Value ?? "");
                string ngayStr = Convert.ToString(row.Cells["colNgay"].Value ?? "");
                string tenKH = Convert.ToString(row.Cells["colTenKhach"].Value ?? "");
                string sSoLuong = Convert.ToString(row.Cells["colSoLuong"].Value ?? "0");
                string sTongTien = Convert.ToString(row.Cells["colGia"].Value ?? "0");
                string sdt = Convert.ToString(row.Cells["colSDT"].Value ?? "");
                string sMaNV = Convert.ToString(row.Cells["colMaNV"].Value ?? "");

                int soLuong;
                if (!int.TryParse(sSoLuong, NumberStyles.Any, CultureInfo.CurrentCulture, out soLuong))
                    soLuong = 0;

                decimal tongTien;
                if (!decimal.TryParse(sTongTien, NumberStyles.Any, CultureInfo.CurrentCulture, out tongTien))
                    tongTien = 0m;

                // Cập nhật controls
                if (!string.IsNullOrWhiteSpace(maDonStr)) txtMaDon.Text = maDonStr;
                else txtMaDon.Clear();

                if (dtpNgay != null && DateTime.TryParse(ngayStr, out DateTime ngayVal))
                    dtpNgay.Value = ngayVal;

                txtTenKhach.Text = tenKH;
                txtSdt.Text = sdt;
                txtMaNV.Text = sMaNV;

                if (nudTongSoLuong != null)
                {
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
                }

                // Tính đơn giá (nếu có số lượng)
                decimal donGia = 0m;
                if (soLuong > 0)
                    donGia = tongTien / soLuong;

                // Hiển thị chi tiết: truy vấn ChiTietDonHang thực tế
                if (dgvChiTiet != null)
                {
                    dgvChiTiet.Rows.Clear();

                    if (int.TryParse(maDonStr, out int maDH))
                    {
                        try
                        {
                            using (var conn = Database.GetConnection())
                            {
                                conn.Open();
                                string sql = @"SELECT ct.MaHoa, h.TenHoa, ct.SoLuong, ct.ThanhTien, ct.MaNV
                                               FROM ChiTietDonHang ct
                                               LEFT JOIN Hoa h ON ct.MaHoa = h.MaHoa
                                               WHERE ct.MaDH = @MaDH";
                                using (var cmd = new MySqlCommand(sql, conn))
                                {
                                    cmd.Parameters.AddWithValue("@MaDH", maDH);
                                    using (var rdr = cmd.ExecuteReader())
                                    {
                                        while (rdr.Read())
                                        {
                                            string prod = rdr.IsDBNull(0) ? string.Empty : rdr.GetInt32(0).ToString();
                                            if (rdr.FieldCount >= 2 && !rdr.IsDBNull(1)) prod = rdr.GetString(1);
                                            int sl = rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2);
                                            decimal dg = 0m;
                                            if (!rdr.IsDBNull(3)) dg = rdr.GetDecimal(3) / Math.Max(1, sl);

                                            dgvChiTiet.Rows.Add(prod, sl, dg);
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi tải chi tiết đơn:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // fallback: use row data
                        if (!string.IsNullOrWhiteSpace(row.Cells["colTenHoa"].Value?.ToString()) || soLuong > 0 || tongTien > 0)
                        {
                            dgvChiTiet.Rows.Add(row.Cells["colTenHoa"].Value?.ToString() ?? string.Empty, soLuong, donGia);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý selection:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(txtTenKhach.Text) || string.IsNullOrWhiteSpace(txtSdt.Text) || string.IsNullOrWhiteSpace(txtMaNV.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng và mã nhân viên.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Parse MaNV
                if (!int.TryParse(txtMaNV.Text.Trim(), out int maNV))
                {
                    MessageBox.Show("Mã nhân viên phải là số nguyên.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Determine totals from chi tiết if present
                int tongSoLuong = 0;
                decimal tongTien = 0m;
                bool hasChiTiet = false;

                if (dgvChiTiet != null && dgvChiTiet.Rows.Count > 0)
                {
                    foreach (DataGridViewRow r in dgvChiTiet.Rows)
                    {
                        if (r.IsNewRow) continue;
                        hasChiTiet = true;

                        int soLuong = 0;
                        decimal donGia = 0m;

                        if (r.Cells.Count > 1 && r.Cells[1].Value != null)
                            int.TryParse(r.Cells[1].Value.ToString(), out soLuong);

                        if (r.Cells.Count > 2 && r.Cells[2].Value != null)
                            decimal.TryParse(r.Cells[2].Value.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out donGia);

                        tongSoLuong += soLuong;
                        tongTien += soLuong * donGia;
                    }
                }

                if (!hasChiTiet)
                {
                    // fallback
                    tongSoLuong = nudTongSoLuong != null ? (int)nudTongSoLuong.Value : 0;
                    tongTien = 0m;
                }

                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    using (var tx = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1) Ensure MaKH exists: try find by phone, otherwise insert new KhachHang
                            int maKH = 0;
                            using (var cmdFind = new MySqlCommand("SELECT MaKH FROM KhachHang WHERE SoDienThoai = @sdt LIMIT 1", conn, tx))
                            {
                                cmdFind.Parameters.AddWithValue("@sdt", txtSdt.Text.Trim());
                                var obj = cmdFind.ExecuteScalar();
                                if (obj != null && int.TryParse(obj.ToString(), out int found))
                                    maKH = found;
                            }

                            if (maKH == 0)
                            {
                                using (var cmdInsKH = new MySqlCommand("INSERT INTO KhachHang (TenKH, SoDienThoai) VALUES (@ten, @sdt); SELECT LAST_INSERT_ID();", conn, tx))
                                {
                                    cmdInsKH.Parameters.AddWithValue("@ten", txtTenKhach.Text.Trim());
                                    cmdInsKH.Parameters.AddWithValue("@sdt", txtSdt.Text.Trim());
                                    var id = cmdInsKH.ExecuteScalar();
                                    if (id == null) throw new Exception("Không tạo được khách hàng.");
                                    maKH = Convert.ToInt32(id);
                                }
                            }

                            // 2) Prepare MaKM (nullable)
                            object maKmDb = DBNull.Value;
                            if (!string.IsNullOrWhiteSpace(txtMaKM.Text) && int.TryParse(txtMaKM.Text.Trim(), out int maKmParsed))
                                maKmDb = maKmParsed;

                            // 3) Insert DonHang
                            string insertDon = @"INSERT INTO DonHang (MaKH, MaNV, NgayDatHang, TongTien, MaKM) VALUES (@MaKH, @MaNV, @NgayDatHang, @TongTien, @MaKM); SELECT LAST_INSERT_ID();";

                            int maDH;
                            using (var cmdDon = new MySqlCommand(insertDon, conn, tx))
                            {
                                cmdDon.Parameters.AddWithValue("@MaKH", maKH);
                                cmdDon.Parameters.AddWithValue("@MaNV", maNV);
                                cmdDon.Parameters.AddWithValue("@NgayDatHang", dtpNgay.Value.Date);
                                cmdDon.Parameters.AddWithValue("@TongTien", tongTien);
                                cmdDon.Parameters.AddWithValue("@MaKM", maKmDb);

                                var idObj = cmdDon.ExecuteScalar();
                                if (idObj == null) throw new Exception("Không lấy được ID DonHang.");
                                maDH = Convert.ToInt32(idObj);
                            }

                            // 4) Insert ChiTietDonHang rows if any. Need MaHoa for each row.
                            if (hasChiTiet)
                            {
                                string insertCt = @"INSERT INTO ChiTietDonHang (MaDH, MaHoa, SoLuong, ThanhTien, MaNV) VALUES (@MaDH, @MaHoa, @SoLuong, @ThanhTien, @MaNV);";
                                using (var cmdCt = new MySqlCommand(insertCt, conn, tx))
                                {
                                    cmdCt.Parameters.Add("@MaDH", MySqlDbType.Int32);
                                    cmdCt.Parameters.Add("@MaHoa", MySqlDbType.Int32);
                                    cmdCt.Parameters.Add("@SoLuong", MySqlDbType.Int32);
                                    cmdCt.Parameters.Add("@ThanhTien", MySqlDbType.Decimal);
                                    cmdCt.Parameters.Add("@MaNV", MySqlDbType.Int32);

                                    foreach (DataGridViewRow r in dgvChiTiet.Rows)
                                    {
                                        if (r.IsNewRow) continue;

                                        // Determine MaHoa: if numeric provided use it, otherwise lookup by TenHoa
                                        int maHoa = 0;
                                        string prodCell = r.Cells.Count > 0 && r.Cells[0].Value != null ? r.Cells[0].Value.ToString() : string.Empty;

                                        if (int.TryParse(prodCell, out int parsedId))
                                        {
                                            maHoa = parsedId;
                                        }
                                        else if (!string.IsNullOrWhiteSpace(prodCell))
                                        {
                                            using (var cmdFindHoa = new MySqlCommand("SELECT MaHoa FROM Hoa WHERE TenHoa = @ten LIMIT 1", conn, tx))
                                            {
                                                cmdFindHoa.Parameters.AddWithValue("@ten", prodCell);
                                                var obj = cmdFindHoa.ExecuteScalar();
                                                if (obj != null && int.TryParse(obj.ToString(), out int h)) maHoa = h;
                                            }

                                            if (maHoa == 0)
                                            {
                                                // If product name not found, try to create? here we throw to avoid inconsistent data
                                                throw new Exception($"Không tìm thấy sản phẩm '{prodCell}' trong bảng Hoa.");
                                            }
                                        }

                                        int soLuong = 0;
                                        decimal donGia = 0m;

                                        if (r.Cells.Count > 1 && r.Cells[1].Value != null)
                                            int.TryParse(r.Cells[1].Value.ToString(), out soLuong);

                                        if (r.Cells.Count > 2 && r.Cells[2].Value != null)
                                            decimal.TryParse(r.Cells[2].Value.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out donGia);

                                        decimal thanhTien = soLuong * donGia;

                                        cmdCt.Parameters["@MaDH"].Value = maDH;
                                        cmdCt.Parameters["@MaHoa"].Value = maHoa;
                                        cmdCt.Parameters["@SoLuong"].Value = soLuong;
                                        cmdCt.Parameters["@ThanhTien"].Value = thanhTien;
                                        cmdCt.Parameters["@MaNV"].Value = maNV;

                                        cmdCt.ExecuteNonQuery();
                                    }
                                }
                            }

                            tx.Commit();

                            // Update dgvDonHang immediately
                            if (dgvDonHang != null)
                            {
                                string ngayStr = dtpNgay.Value.ToString("g");
                                string firstProduct = string.Empty;
                                if (hasChiTiet && dgvChiTiet.Rows.Count > 0 && dgvChiTiet.Rows[0].Cells.Count > 0 && dgvChiTiet.Rows[0].Cells[0].Value != null)
                                    firstProduct = dgvChiTiet.Rows[0].Cells[0].Value.ToString();

                                dgvDonHang.Rows.Add(maDH, ngayStr, txtTenKhach.Text.Trim(), txtSdt.Text.Trim(), maNV.ToString(), firstProduct, tongSoLuong, tongTien.ToString("N2"));
                            }

                            MessageBox.Show($"Thêm đơn hàng thành công (Mã: {maDH}).", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear inputs
                            txtTenKhach.Clear();
                            txtSdt.Clear();
                            txtMaNV.Clear();
                            txtMaKM.Clear();
                            if (nudTongSoLuong != null) nudTongSoLuong.Value = nudTongSoLuong.Minimum;
                            if (dgvChiTiet != null) dgvChiTiet.Rows.Clear();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaDon.Text) || !int.TryParse(txtMaDon.Text.Trim(), out int maDH))
                {
                    MessageBox.Show("Vui lòng chọn một đơn hàng để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtMaNV.Text.Trim(), out int maNV))
                {
                    MessageBox.Show("Mã nhân viên không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                object maKmDb = DBNull.Value;
                if (!string.IsNullOrWhiteSpace(txtMaKM.Text) && int.TryParse(txtMaKM.Text.Trim(), out int maKmParsed))
                    maKmDb = maKmParsed;

                // Recompute totals from dgvChiTiet if present
                int tongSoLuong = 0;
                decimal tongTien = 0m;
                bool hasChiTiet = false;

                if (dgvChiTiet != null && dgvChiTiet.Rows.Count > 0)
                {
                    foreach (DataGridViewRow r in dgvChiTiet.Rows)
                    {
                        if (r.IsNewRow) continue;
                        hasChiTiet = true;

                        int soLuong = 0;
                        decimal donGia = 0m;
                        if (r.Cells.Count > 1 && r.Cells[1].Value != null) int.TryParse(r.Cells[1].Value.ToString(), out soLuong);
                        if (r.Cells.Count > 2 && r.Cells[2].Value != null) decimal.TryParse(r.Cells[2].Value.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out donGia);

                        tongSoLuong += soLuong;
                        tongTien += soLuong * donGia;
                    }
                }

                // If no chi tiết rows, keep existing tongTien from selected grid
                if (!hasChiTiet)
                {
                    var sel = dgvDonHang.SelectedRows.Count > 0 ? dgvDonHang.SelectedRows[0] : null;
                    if (sel != null)
                    {
                        string sTong = Convert.ToString(sel.Cells["colGia"].Value ?? "0");
                        decimal.TryParse(sTong, NumberStyles.Any, CultureInfo.CurrentCulture, out tongTien);
                    }
                }

                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    using (var tx = conn.BeginTransaction())
                    {
                        try
                        {
                            // Update DonHang
                            using (var cmd = new MySqlCommand("UPDATE DonHang SET MaNV = @MaNV, NgayDatHang = @Ngay, TongTien = @TongTien, MaKM = @MaKM WHERE MaDH = @MaDH", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@MaNV", maNV);
                                cmd.Parameters.AddWithValue("@Ngay", dtpNgay.Value.Date);
                                cmd.Parameters.AddWithValue("@TongTien", tongTien);
                                cmd.Parameters.AddWithValue("@MaKM", maKmDb);
                                cmd.Parameters.AddWithValue("@MaDH", maDH);
                                cmd.ExecuteNonQuery();
                            }

                            // If chi tiết provided, delete existing chi tiết and re-insert
                            if (hasChiTiet)
                            {
                                using (var cmdDel = new MySqlCommand("DELETE FROM ChiTietDonHang WHERE MaDH = @MaDH", conn, tx))
                                {
                                    cmdDel.Parameters.AddWithValue("@MaDH", maDH);
                                    cmdDel.ExecuteNonQuery();
                                }

                                string insertCt = @"INSERT INTO ChiTietDonHang (MaDH, MaHoa, SoLuong, ThanhTien, MaNV) VALUES (@MaDH, @MaHoa, @SoLuong, @ThanhTien, @MaNV);";
                                using (var cmdCt = new MySqlCommand(insertCt, conn, tx))
                                {
                                    cmdCt.Parameters.Add("@MaDH", MySqlDbType.Int32);
                                    cmdCt.Parameters.Add("@MaHoa", MySqlDbType.Int32);
                                    cmdCt.Parameters.Add("@SoLuong", MySqlDbType.Int32);
                                    cmdCt.Parameters.Add("@ThanhTien", MySqlDbType.Decimal);
                                    cmdCt.Parameters.Add("@MaNV", MySqlDbType.Int32);

                                    foreach (DataGridViewRow r in dgvChiTiet.Rows)
                                    {
                                        if (r.IsNewRow) continue;

                                        int maHoa = 0;
                                        string prodCell = r.Cells.Count > 0 && r.Cells[0].Value != null ? r.Cells[0].Value.ToString() : string.Empty;

                                        if (int.TryParse(prodCell, out int parsedId)) maHoa = parsedId;
                                        else if (!string.IsNullOrWhiteSpace(prodCell))
                                        {
                                            using (var cmdFindHoa = new MySqlCommand("SELECT MaHoa FROM Hoa WHERE TenHoa = @ten LIMIT 1", conn, tx))
                                            {
                                                cmdFindHoa.Parameters.AddWithValue("@ten", prodCell);
                                                var obj = cmdFindHoa.ExecuteScalar();
                                                if (obj != null && int.TryParse(obj.ToString(), out int h)) maHoa = h;
                                            }

                                            if (maHoa == 0) throw new Exception($"Không tìm thấy sản phẩm '{prodCell}' trong bảng Hoa.");
                                        }

                                        int soLuong = 0;
                                        decimal donGia = 0m;
                                        if (r.Cells.Count > 1 && r.Cells[1].Value != null) int.TryParse(r.Cells[1].Value.ToString(), out soLuong);
                                        if (r.Cells.Count > 2 && r.Cells[2].Value != null) decimal.TryParse(r.Cells[2].Value.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out donGia);

                                        decimal thanhTien = soLuong * donGia;

                                        cmdCt.Parameters["@MaDH"].Value = maDH;
                                        cmdCt.Parameters["@MaHoa"].Value = maHoa;
                                        cmdCt.Parameters["@SoLuong"].Value = soLuong;
                                        cmdCt.Parameters["@ThanhTien"].Value = thanhTien;
                                        cmdCt.Parameters["@MaNV"].Value = maNV;

                                        cmdCt.ExecuteNonQuery();
                                    }
                                }
                            }

                            tx.Commit();

                            MessageBox.Show("Cập nhật đơn hàng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh grid
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
                            using (var cmdDelCt = new MySqlCommand("DELETE FROM ChiTietDonHang WHERE MaDH = @MaDH", conn, tx))
                            {
                                cmdDelCt.Parameters.AddWithValue("@MaDH", maDH);
                                cmdDelCt.ExecuteNonQuery();
                            }

                            using (var cmdDel = new MySqlCommand("DELETE FROM DonHang WHERE MaDH = @MaDH", conn, tx))
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
    }
}
