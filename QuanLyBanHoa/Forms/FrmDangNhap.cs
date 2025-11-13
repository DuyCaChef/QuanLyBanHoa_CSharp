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
            string mk = txtPass.Text; // giữ nguyên không hash

            if (string.IsNullOrEmpty(tk) || string.IsNullOrEmpty(mk))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Sử dụng User.Login từ Model
                User user = User.Login(tk, mk);

                if (user != null)
                {
                    // Lưu thông tin vào Session
                    Session.UserID = user.UserID;
                    Session.TaiKhoan = user.TaiKhoan;
                    Session.Vaitro = user.VaiTro;
                    Session.MaNV = user.MaNV;

                    // Mở FormMain và ẩn FormDangNhap
                    FrmMain main = new FrmMain();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
