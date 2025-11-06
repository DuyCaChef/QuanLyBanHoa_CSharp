using MySql.Data.MySqlClient;
using System.Data;

namespace Doan_QLKhachhang
{
    public partial class frmQuanLiKhachHang : Form
    {
        public frmQuanLiKhachHang()
        {
            InitializeComponent();
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
            dgDSKhachHang.DataSource = dt;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lbSoluong_Click(object sender, EventArgs e)
        {

        }

        private void frmQuanLiKhachHang_Load(object sender, EventArgs e)
        {
            if (dgDSKhachHang != null)
            {
                getData();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
