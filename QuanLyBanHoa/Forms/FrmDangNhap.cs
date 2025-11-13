using QuanLyBanHoa.Models;
using QuanLyBanHoa.Data;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHoa.Forms
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tk = txtEmail.Text.Trim();
            string mk = txtPass.Text; // giữ nguyên theo yêu cầu (không hash)

            if (string.IsNullOrEmpty(tk) || string.IsNullOrEmpty(mk))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "SELECT MaNV, TaiKhoan, Vaitro FROM NhanVien WHERE TaiKhoan = @tk AND MatKhau = @mk";

            try
            {
                using (var conn = Database.GetConnection())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@tk", tk);
                    cmd.Parameters.AddWithValue("@mk", mk);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Session.MaNV = reader["MaNV"] == DBNull.Value ?0 : Convert.ToInt32(reader["MaNV"]);
                            Session.TaiKhoan = reader["TaiKhoan"] == DBNull.Value ? string.Empty : reader["TaiKhoan"].ToString();
                            Session.Vaitro = reader["Vaitro"] == DBNull.Value ? string.Empty : reader["Vaitro"].ToString();

                            // Mở FormMain vàẩn FormDangNhap
                            FrmMain main = new FrmMain();
                            main.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối đăng nhập:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ckbHienMK_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !ckbHienMK.Checked;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (!Session.IsLoggedIn)
            {
                Application.Exit();
            }
        }
    }
}
