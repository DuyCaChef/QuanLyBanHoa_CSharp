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

            string adminUsername = "admin123@gmail.com";
            string adminPassword = "admin@123";
            string staffUsername = "staff123@gmail.com";
            string staffPassword = "staff@123";

            if (username == adminUsername && password == adminPassword)
            {
                Session.UserName = username;
                Session.Role = "Admin";
                Session.IsLoggedIn = true;
                
                MessageBox.Show("Đăng nhập thành công với quyền Admin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở form Hoa
                frmHoa main = new frmHoa();
                main.Show();
                this.Hide(); // Ẩn form đăng nhập
            }
            else if (username == staffUsername && password == staffPassword)
            {
                Session.UserName = username;
                Session.Role = "Nhân viên";
                Session.IsLoggedIn = true;
                
                MessageBox.Show("Đăng nhập thành công với vai trò Nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở form Hoa
                frmHoa main = new frmHoa();
                main.Show();
                this.Hide(); // Ẩn form đăng nhập
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

            // Nếu đang đăng nhập và đóng form đăng nhập thì thoát ứng dụng
            if (!Session.IsLoggedIn)
            {
                Application.Exit();
            }
        }
    }
}
