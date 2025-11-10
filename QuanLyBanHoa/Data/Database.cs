using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;

namespace QuanLyBanHoa.Data
{
    public class Database
    {
        // Đã thêm 'charset=utf8mb4' để hỗ trợ tốt tiếng Việt
        private static readonly string connectionString =
            "server=localhost;uid=root;pwd=Aaaaa123@;database=quanlybanhoa;charset=utf8mb4;";

        /// <summary>
        /// Trả về một kết nối MySQL mới.
        /// </summary>
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Kiểm tra xem thông tin kết nối có đúng không.
        /// </summary>
        public static bool TestConnection()
        {
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kết nối thất bại: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}