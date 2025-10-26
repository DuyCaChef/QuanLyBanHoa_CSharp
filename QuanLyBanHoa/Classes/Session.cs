using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHoa
{
    //Class dùng để lưu thông tin phiên làm việc của người dùng khi đăng nhập vào hệ thống
    public static class Session
    {
        public static string UserName { get; set; }
        public static string Role { get; set; }
        public static bool IsLoggedIn { get; set; } = false;

        public static void Logout()
        {
            UserName = "";
            Role = "";
            IsLoggedIn = false;
        }
    }
}
