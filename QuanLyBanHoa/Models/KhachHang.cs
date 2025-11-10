using MySql.Data.MySqlClient;
using QuanLyBanHoa.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyBanHoa.Models
{
    public class KhachHang
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }

        public KhachHang() { }

        public KhachHang(int maKH, string tenKH, string diaChi, string soDienThoai, string email)
        {
            MaKH = maKH;
            TenKH = tenKH;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            Email = email;
        }

        public static List<KhachHang> GetAll()
        {
            List<KhachHang> list = new List<KhachHang>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaKH, TenKH, DiaChi, SoDienThoai, Email FROM khachhang ORDER BY MaKH DESC";
                using (var cmd = new MySqlCommand(query, conn))
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
                            Email = reader["Email"] == DBNull.Value ? string.Empty : reader["Email"].ToString()
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
                string query = @"INSERT INTO khachhang (TenKH, DiaChi, SoDienThoai, Email)
                               VALUES (@TenKH, @DiaChi, @SoDienThoai, @Email)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenKH", kh.TenKH ?? string.Empty);
                    cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi ?? string.Empty);
                    cmd.Parameters.AddWithValue("@SoDienThoai", kh.SoDienThoai ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Email", kh.Email ?? string.Empty);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool Update(KhachHang kh)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE khachhang
                               SET TenKH = @TenKH, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, Email = @Email
                               WHERE MaKH = @MaKH";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);
                    cmd.Parameters.AddWithValue("@TenKH", kh.TenKH ?? string.Empty);
                    cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi ?? string.Empty);
                    cmd.Parameters.AddWithValue("@SoDienThoai", kh.SoDienThoai ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Email", kh.Email ?? string.Empty);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool Delete(int maKH)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM khachhang WHERE MaKH = @MaKH";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKH", maKH);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<KhachHang> Search(string keyword)
        {
            List<KhachHang> list = new List<KhachHang>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT MaKH, TenKH, DiaChi, SoDienThoai, Email
                               FROM khachhang
                               WHERE TenKH LIKE @Keyword OR DiaChi LIKE @Keyword OR SoDienThoai LIKE @Keyword OR Email LIKE @Keyword OR MaKH LIKE @Keyword
                               ORDER BY MaKH DESC";
                using (var cmd = new MySqlCommand(query, conn))
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
                                Email = reader["Email"] == DBNull.Value ? string.Empty : reader["Email"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}