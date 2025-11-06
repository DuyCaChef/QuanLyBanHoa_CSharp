using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;

namespace QuanLyBanHoa.Data
{
    public static class Database
    {
        // ✅ Connection string: nên dùng chữ thường hoặc thống nhất theo tên DB trong MySQL
        private static readonly string connectionString =
            "server = localhost; uid= root; pwd = Aaaaa123@; database = quanlybanhoa;";

        /// <summary>
        /// Trả về một kết nối MySQL đã cấu hình sẵn.
        /// </summary>
        /// <returns>MySqlConnection object</returns>
        public static MySqlConnection GetConnection()
        {
            try
            {
                return new MySqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                // ❗ Có thể log hoặc hiện thông báo khi lỗi (phục vụ debug)
                throw new Exception("Không thể tạo kết nối tới MySQL: " + ex.Message);
            }
        }
    }
}
