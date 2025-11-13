using System;

namespace QuanLyBanHoa.Models
{
    // Class dùng để lưu thông tin phiên làm việc của người dùng khi đăng nhập vào hệ thống
    public static class Session
    {
        // UserID từ bảng Users
        public static int UserID { get; set; }

        // Mã nhân viên (có thể NULL nếu là Admin)
        public static int? MaNV { get; set; }

        // Tên đăng nhập / tài khoản
        public static string TaiKhoan { get; set; }

        // Vai trò: "Admin" hoặc "NhanVien"
        public static string Vaitro { get; set; }

        // Helper để kiểm tra đã đăng nhập hay chưa (dựa vào tài khoản)
        public static bool IsLoggedIn => !string.IsNullOrEmpty(TaiKhoan);

        public static void Clear()
        {
            UserID =0;
            MaNV = null;
            TaiKhoan = null;
            Vaitro = null;
        }
    }
}
