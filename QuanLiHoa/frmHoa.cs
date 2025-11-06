using MySql.Data.MySqlClient;
using System.Data;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Text.RegularExpressions;
using QuanLyBanHoa_CSharp.Forms;

namespace Doan_QLDanhMucHoa
{
    public partial class FrmHoa : Form
    {
        public FrmHoa()
        {
            InitializeComponent();
        }

        private void lbSoLuongTon_Click(object sender, EventArgs e)
        {

        }

        private void frmQuanLiHoa_Load(object sender, EventArgs e)
        {
            LoadSoLuongCoSan();
            if (dgDSHoa != null)
            {
                // Prefer DAL-based loading
                LoadDataToDataGridView();
            }
        }
        private void LoadSoLuongCoSan()
        {
            for (int i = 1; i <= 100; i++)
            {
                cboSoLuong.Items.Add(i);
            }
        }
        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void hoaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        public void getData()
        {
            string conString = "server = localhost; uid= root; pwd = Aaaaa123@; database = quanlybanhoa;";
            MySqlConnection con = new MySqlConnection(conString);
            con.Open();
            string query = "select * from quanlybanhoa.hoa";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dgDSHoa.DataSource = dt;

        }
        private void ClearInputFields()
        {
            txtMaHoa.Clear();
            txtTenHoa.Clear();
            txtGia.Clear();
            txtLoaiHoa.Clear();
            txtGhichu.Clear();
         
            cboSoLuong.SelectedIndex = -1;

            btnLuu.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        private void dgDSHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtTenHoa.Text))
            {
                MessageBox.Show("Vui lòng nhập tên hoa.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rawGia = txtGia.Text.Trim();
            decimal gia;

            // Try multiple culture parsers and clean input to accept commas/dots and currency symbols
            bool parsed = decimal.TryParse(rawGia, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out gia)
                || decimal.TryParse(rawGia, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, new CultureInfo("vi-VN"), out gia)
                || decimal.TryParse(rawGia, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.InvariantCulture, out gia);

            if (!parsed)
            {
                // Remove any non-digit, non-separator characters
                string cleaned = Regex.Replace(rawGia, "[^0-9,.-]", "");

                // If both separators present (e.g. "1.234,56"), remove thousands dots
                if (cleaned.Contains(',') && cleaned.Contains('.'))
                {
                    cleaned = cleaned.Replace(".", "");
                    cleaned = cleaned.Replace(',', '.'); // normalize to dot for invariant
                }
                // Try parse cleaned with invariant and vi
                parsed = decimal.TryParse(cleaned, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.InvariantCulture, out gia)
                    || decimal.TryParse(cleaned, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, new CultureInfo("vi-VN"), out gia);
            }

            if (!parsed)
            {
                MessageBox.Show("Giá không hợp lệ. Vui lòng nhập số.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboSoLuong.SelectedItem == null || !int.TryParse(cboSoLuong.SelectedItem.ToString(), out int soLuong))
            {
                MessageBox.Show("Vui lòng chọn số lượng.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create new Hoa object
            Hoa newHoa = new Hoa
            {
                TenHoa = txtTenHoa.Text.Trim(),
                Gia = gia,
                SoLuong = soLuong,
                PhanLoai = txtLoaiHoa.Text.Trim(),
                Ghichu = txtGhichu.Text.Trim()
            };
            HoaDAL dal = new HoaDAL();
            try
            {
                bool ok = dal.InsertHoa(newHoa);
                if (ok)
                {
                    MessageBox.Show("Thêm hoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataToDataGridView();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Thêm hoa không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm hoa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
        }
        private void LoadDataToDataGridView()
        {
            HoaDAL dal = new HoaDAL();
            try
            {
                List<Hoa> listHoa = dal.GetAllHoa();
                if (listHoa != null && listHoa.Count > 0)
                {
                    dgDSHoa.DataSource = listHoa;
                    // Format Gia column if exists
                    if (dgDSHoa.Columns.Contains("Gia"))
                    {
                        dgDSHoa.Columns["Gia"].DefaultCellStyle.Format = "N2";
                    }
                }
                else
                {
                    dgDSHoa.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   
        private void cboSoLuong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgDSHoa.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Cảnh báo");
                return;
            }
            if (dgDSHoa.SelectedRows[0].Cells["MaHoa"].Value == null)
            {
                MessageBox.Show("Không tìm thấy Mã Hoa để xóa.", "Lỗi dữ liệu");
                return;
            }

            int maHoaCanXoa = Convert.ToInt32(dgDSHoa.SelectedRows[0].Cells["MaHoa"].Value);

            if (MessageBox.Show($"Xóa mã hoa {maHoaCanXoa} sẽ không thể phục hồi. Bạn có chắc chắn?", "Xác nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                HoaDAL dal = new HoaDAL();
                if (dal.DeleteHoa(maHoaCanXoa))
                {
                    MessageBox.Show("Xóa hoa thành công!");
                    LoadDataToDataGridView(); 
                    ClearInputFields(); 
                }
            }
        }
    }
}
