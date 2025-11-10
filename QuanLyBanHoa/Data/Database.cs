using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHoa.Data
{
    public class Database
    {
        // Đọc connection string từ App.config
        private static readonly string connectionString = GetConnectionString();


        /// <summary>
        /// Lấy connection string từ App.config
        /// </summary>
        private static string GetConnectionString()
        {
            try
            {
                // Đọc từ App.config
                string connStr = ConfigurationManager.ConnectionStrings["QuanLyBanHoaDB"]?.ConnectionString;
                
                if (string.IsNullOrEmpty(connStr))
                {
                    // Fallback: Connection string mặc định nếu không tìm thấy trong App.config
                    return "Data Source=localhost;Initial Catalog=QuanLyBanHoa;Integrated Security=True;TrustServerCertificate=True;";
                }
                
                return connStr;
            }
            catch (Exception)
            {
                // Fallback: Connection string mặc định nếu có lỗi
                return "Data Source=localhost;Initial Catalog=QuanLyBanHoa;Integrated Security=True;TrustServerCertificate=True;";
            }
        }

        /// <summary>
        /// Trả về một kết nối SQL Server mới.
        /// </summary>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
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

        /// <summary>
        /// Lấy thông tin connection string hiện tại (để debug)
        /// </summary>
        public static string GetCurrentConnectionString()
        {
            return connectionString;
        }
    }
}