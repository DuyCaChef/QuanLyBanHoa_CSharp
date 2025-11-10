using QuanLyBanHoa.Models;
using System;
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
            string username = txtEmail.Text.Trim();
            string password = txtPass.Text.Trim();

            string adminUsername = "admin";
            string adminPassword = "123";
            string staffUsername = "staff123@gmail.com";
            string staffPassword = "staff@123";

            if ((username == adminUsername && password == adminPassword) ||
                (username == staffUsername && password == staffPassword))
            {
                Session.UserName = username;
                Session.Role = username == adminUsername ? "Admin" : "Nhân viên";
                Session.IsLoggedIn = true;

                MessageBox.Show($"Đăng nhập thành công với quyền {Session.Role}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở form Main (form chính chứa navigation). FrmMain sẽ tự mở frmHoa đầu tiên.
                FrmMain main = new FrmMain();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng. Vui lòng thử lại.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
