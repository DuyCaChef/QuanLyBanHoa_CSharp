using System;

namespace QuanLyBanHoa.Models
{
    // Class dùng để lưu thông tin phiên làm việc của người dùng khi đăng nhập vào hệ thống
    public static class Session
    {
        // Mã nhân viên (identity)
        public static int MaNV { get; set; }

        // Tên đăng nhập / tài khoản
        public static string TaiKhoan { get; set; }

        // Vai trò: expected values: "Admin" hoặc "NhanVien" (hoặc "Nhân viên")
        public static string Vaitro { get; set; }

        // Helper để kiểm tra đã đăng nhập hay chưa (dựa vào tài khoản)
        public static bool IsLoggedIn => !string.IsNullOrEmpty(TaiKhoan);

        public static void Clear()
        {
            MaNV =0;
            TaiKhoan = null;
            Vaitro = null;
        }
    }
}
