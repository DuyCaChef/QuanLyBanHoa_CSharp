using MySql.Data.MySqlClient;
using QLHoa;
using QLHoa.Class;
using System.Data;
using System.Runtime.InteropServices;

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
                getData();
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
