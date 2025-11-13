using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QuanLyBanHoa.Data;

namespace QuanLyBanHoa.Models
{
    public class Hoa
    {
        // 1. Các thu?c tính (Properties) mô t? ??i t??ng Hoa
        public int MaHoa { get; set; }
        public string TenHoa { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public string MoTa { get; set; }

        // Constructor không tham s?
        public Hoa() { }

        // Constructor ??y ?? tham s? (ti?n cho vi?c kh?i t?o)
        public Hoa(int maHoa, string tenHoa, decimal gia, int soLuong, string moTa)
        {
            MaHoa = maHoa;
            TenHoa = tenHoa;
            Gia = gia;
            SoLuong = soLuong;
            MoTa = moTa;
        }

        // 2. Các ph??ng th?c truy v?n d? li?u (Static Methods)

        // L?y t?t c? danh sách hoa
        public static List<Hoa> GetAll()
        {
            List<Hoa> listHoa = new List<Hoa>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaHoa, TenHoa, Gia, SoLuong, MoTa FROM hoa ORDER BY MaHoa DESC";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listHoa.Add(new Hoa()
                        {
                            MaHoa = Convert.ToInt32(reader["MaHoa"]),
                            TenHoa = reader["TenHoa"].ToString(),
                            Gia = Convert.ToDecimal(reader["Gia"]),
                            SoLuong = Convert.ToInt32(reader["SoLuong"]),
                            MoTa = reader["MoTa"].ToString()
                        });
                    }
                }
            }
            return listHoa;
        }

        // Thêm hoa m?i 
        public static bool Insert(Hoa hoa)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO hoa (TenHoa, Gia, SoLuong, MoTa) 
                               VALUES (@TenHoa, @Gia, @SoLuong, @MoTa)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenHoa", hoa.TenHoa);
                    cmd.Parameters.AddWithValue("@Gia", hoa.Gia);
                    cmd.Parameters.AddWithValue("@SoLuong", hoa.SoLuong);
                    cmd.Parameters.AddWithValue("@MoTa", hoa.MoTa ?? (object)DBNull.Value);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // C?p nh?t hoa
        public static bool Update(Hoa hoa)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE hoa 
                               SET TenHoa = @TenHoa, Gia = @Gia, SoLuong = @SoLuong, MoTa = @MoTa 
                               WHERE MaHoa = @MaHoa";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHoa", hoa.MaHoa);
                    cmd.Parameters.AddWithValue("@TenHoa", hoa.TenHoa);
                    cmd.Parameters.AddWithValue("@Gia", hoa.Gia);
                    cmd.Parameters.AddWithValue("@SoLuong", hoa.SoLuong);
                    cmd.Parameters.AddWithValue("@MoTa", hoa.MoTa ?? (object)DBNull.Value);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    // Tr? v? true n?u không có l?i, b?t k? có hàng nào b? ?nh h??ng
                    return rowsAffected >= 0;
                }
            }
        }

        // Xóa hoa
        public static bool Delete(int maHoa)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                
                try
                {
                    // Disable all foreign key constraints
                    string disableFK = "ALTER TABLE ChiTietDonHang NOCHECK CONSTRAINT ALL";
                    string enableFK = "ALTER TABLE ChiTietDonHang CHECK CONSTRAINT ALL";
                    string deleteQuery = "DELETE FROM hoa WHERE MaHoa = @MaHoa";

                    using (var cmd = new SqlCommand(disableFK, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    bool result;
                    using (var cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHoa", maHoa);
                        result = cmd.ExecuteNonQuery() > 0;
                    }

                    using (var cmd = new SqlCommand(enableFK, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    return result;
                }
                catch (Exception)
                {
                    // Try to re-enable constraints even if delete failed
                    try
                    {
                        string enableFK = "ALTER TABLE ChiTietDonHang CHECK CONSTRAINT ALL";
                        using (var cmd = new SqlCommand(enableFK, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch { }
                    
                    throw;
                }
            }
        }

        // Tìm ki?m hoa
        public static List<Hoa> Search(string keyword)
        {
            List<Hoa> listHoa = new List<Hoa>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT MaHoa, TenHoa, Gia, SoLuong, MoTa 
                               FROM hoa 
                               WHERE TenHoa LIKE @Keyword OR MoTa LIKE @Keyword OR CAST(MaHoa AS NVARCHAR) LIKE @Keyword 
                               ORDER BY MaHoa DESC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listHoa.Add(new Hoa()
                            {
                                MaHoa = Convert.ToInt32(reader["MaHoa"]),
                                TenHoa = reader["TenHoa"].ToString(),
                                Gia = Convert.ToDecimal(reader["Gia"]),
                                SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                MoTa = reader["MoTa"].ToString()
                            });
                        }
                    }
                }
            }
            return listHoa;
        }
    }
}