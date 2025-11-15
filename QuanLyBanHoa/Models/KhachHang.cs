using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanHoa.Data;

namespace QuanLyBanHoa.Models
{
    public class KhachHang
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public int SoLuongDonHang { get; set; }

        public KhachHang() { }

        public KhachHang(int maKH, string tenKH, string diaChi, string soDienThoai, string email, int soLuongDonHang)
        {
            MaKH = maKH;
            TenKH = tenKH;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            Email = email;
            SoLuongDonHang = soLuongDonHang;
        }

        public static List<KhachHang> GetAll()
        {
            List<KhachHang> list = new List<KhachHang>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT MaKH, TenKH, DiaChi, SoDienThoai, Email, (SELECT COUNT(*) FROM DonHang WHERE MaKH = KhachHang.MaKH) AS SoLuongDonHang FROM KhachHang ORDER BY MaKH DESC";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new KhachHang()
                        {
                            MaKH = reader["MaKH"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaKH"]),
                            TenKH = reader["TenKH"] == DBNull.Value ? string.Empty : reader["TenKH"].ToString(),
                            DiaChi = reader["DiaChi"] == DBNull.Value ? string.Empty : reader["DiaChi"].ToString(),
                            SoDienThoai = reader["SoDienThoai"] == DBNull.Value ? string.Empty : reader["SoDienThoai"].ToString(),
                            Email = reader["Email"] == DBNull.Value ? string.Empty : reader["Email"].ToString(),
                            SoLuongDonHang = reader["SoLuongDonHang"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuongDonHang"])
                        });
                    }
                }
            }
            return list;
        }

        public static bool Insert(KhachHang kh)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO KhachHang (TenKH, DiaChi, SoDienThoai, Email)
                               VALUES (@TenKH, @DiaChi, @SoDienThoai, @Email)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenKH", kh.TenKH ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoDienThoai", kh.SoDienThoai ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", kh.Email ?? (object)DBNull.Value);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool Update(KhachHang kh)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE KhachHang
                               SET TenKH = @TenKH, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, Email = @Email
                               WHERE MaKH = @MaKH";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);
                    cmd.Parameters.AddWithValue("@TenKH", kh.TenKH ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoDienThoai", kh.SoDienThoai ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", kh.Email ?? (object)DBNull.Value);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool Delete(int maKH)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
  
                // Xóa khách hàng
                string query3 = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
                using (var cmd3 = new SqlCommand(query3, conn))
                {
                    cmd3.Parameters.AddWithValue("@MaKH", maKH);
                    cmd3.ExecuteNonQuery();
                }
                return true;
            }
        }

        public static List<KhachHang> Search(string keyword)
        {
            List<KhachHang> list = new List<KhachHang>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT MaKH, TenKH, DiaChi, SoDienThoai, Email, (SELECT COUNT(*) FROM DonHang WHERE MaKH = KhachHang.MaKH) AS SoLuongDonHang
                               FROM KhachHang
                               WHERE TenKH LIKE @Keyword OR DiaChi LIKE @Keyword OR SoDienThoai LIKE @Keyword OR Email LIKE @Keyword OR CAST(MaKH AS NVARCHAR) LIKE @Keyword
                               ORDER BY MaKH DESC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new KhachHang()
                            {
                                MaKH = reader["MaKH"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaKH"]),
                                TenKH = reader["TenKH"] == DBNull.Value ? string.Empty : reader["TenKH"].ToString(),
                                DiaChi = reader["DiaChi"] == DBNull.Value ? string.Empty : reader["DiaChi"].ToString(),
                                SoDienThoai = reader["SoDienThoai"] == DBNull.Value ? string.Empty : reader["SoDienThoai"].ToString(),
                                Email = reader["Email"] == DBNull.Value ? string.Empty : reader["Email"].ToString(),
                                SoLuongDonHang = reader["SoLuongDonHang"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuongDonHang"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        // Lấy khách hàng theo số điện thoại
        public static KhachHang GetByPhone(string phone)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaKH, TenKH, DiaChi, SoDienThoai, Email, (SELECT COUNT(*) FROM DonHang WHERE MaKH = KhachHang.MaKH) AS SoLuongDonHang FROM KhachHang WHERE SoDienThoai = @Phone";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new KhachHang()
                            {
                                MaKH = reader["MaKH"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaKH"]),
                                TenKH = reader["TenKH"] == DBNull.Value ? string.Empty : reader["TenKH"].ToString(),
                                DiaChi = reader["DiaChi"] == DBNull.Value ? string.Empty : reader["DiaChi"].ToString(),
                                SoDienThoai = reader["SoDienThoai"] == DBNull.Value ? string.Empty : reader["SoDienThoai"].ToString(),
                                Email = reader["Email"] == DBNull.Value ? string.Empty : reader["Email"].ToString(),
                                SoLuongDonHang = reader["SoLuongDonHang"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuongDonHang"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        // Overload with connection and transaction
        public static KhachHang GetByPhone(string phone, SqlConnection conn, SqlTransaction tx = null)
        {
            string query = "SELECT MaKH, TenKH, DiaChi, SoDienThoai, Email, (SELECT COUNT(*) FROM DonHang WHERE MaKH = KhachHang.MaKH) AS SoLuongDonHang FROM KhachHang WHERE SoDienThoai = @Phone";
            using (var cmd = new SqlCommand(query, conn, tx))
            {
                cmd.Parameters.AddWithValue("@Phone", phone);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new KhachHang()
                        {
                            MaKH = reader["MaKH"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaKH"]),
                            TenKH = reader["TenKH"] == DBNull.Value ? string.Empty : reader["TenKH"].ToString(),
                            DiaChi = reader["DiaChi"] == DBNull.Value ? string.Empty : reader["DiaChi"].ToString(),
                            SoDienThoai = reader["SoDienThoai"] == DBNull.Value ? string.Empty : reader["SoDienThoai"].ToString(),
                            Email = reader["Email"] == DBNull.Value ? string.Empty : reader["Email"].ToString(),
                            SoLuongDonHang = reader["SoLuongDonHang"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuongDonHang"])
                        };
                    }
                }
            }
            return null;
        }

        // Overload with connection and transaction - Returns new ID
        public static int Insert(KhachHang kh, SqlConnection conn, SqlTransaction tx = null)
        {
            string query = @"INSERT INTO KhachHang (TenKH, DiaChi, SoDienThoai, Email)
                           VALUES (@TenKH, @DiaChi, @SoDienThoai, @Email);
                           SELECT CAST(SCOPE_IDENTITY() AS INT);";
            using (var cmd = new SqlCommand(query, conn, tx))
            {
                cmd.Parameters.AddWithValue("@TenKH", kh.TenKH ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SoDienThoai", kh.SoDienThoai ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", kh.Email ?? (object)DBNull.Value);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        // Overload with connection and transaction - Update customer
        public static bool Update(KhachHang kh, SqlConnection conn, SqlTransaction tx = null)
        {
            string query = @"UPDATE KhachHang
                           SET TenKH = @TenKH, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, Email = @Email
                           WHERE MaKH = @MaKH";
            using (var cmd = new SqlCommand(query, conn, tx))
            {
                cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);
                cmd.Parameters.AddWithValue("@TenKH", kh.TenKH ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SoDienThoai", kh.SoDienThoai ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", kh.Email ?? (object)DBNull.Value);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}