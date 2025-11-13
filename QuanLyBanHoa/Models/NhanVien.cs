using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QuanLyBanHoa.Data;

namespace QuanLyBanHoa.Models
{
    public class NhanVien
    {
        // 1. Các thuộc tính (Properties) mô tả đối tượng NhanVien
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public string ChucVu { get; set; }
        public string SoDienThoai { get; set; }
        public int SoLuongDonHang { get; set; } // Số đơn hàng đã bán
        
        // Thêm 2 thuộc tính này nếu đã cập nhật DB cho chức năng đăng nhập
        // public string Email { get; set; }
        // public string MatKhau { get; set; }

        // Constructor không tham số
        public NhanVien() { }

        // Constructor đầy đủ tham số (tiện cho việc khởi tạo)
        public NhanVien(int maNV, string tenNV, string chucVu, string soDienThoai, int soLuongDonHang = 0)
        {
            MaNV = maNV;
            TenNV = tenNV;
            ChucVu = chucVu;
            SoDienThoai = soDienThoai;
            SoLuongDonHang = soLuongDonHang;
        }

        // 2. Các phương thức truy vấn dữ liệu (Static Methods)

        /// <summary>
        /// Lấy tất cả danh sách nhân viên kèm số lượng đơn hàng
        /// </summary>
        public static List<NhanVien> GetAll()
        {
            List<NhanVien> listNhanVien = new List<NhanVien>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT 
                                    nv.MaNV,
                                    nv.TenNV,
                                    nv.SoDienThoai,
                                    nv.ChucVu,
                                    COUNT(ct.MaDH) AS SoLuongDonHang
                                FROM NhanVien nv
                                LEFT JOIN ChiTietDonHang ct ON nv.MaNV = ct.MaNV
                                GROUP BY nv.MaNV, nv.TenNV, nv.SoDienThoai, nv.ChucVu
                                ORDER BY nv.MaNV DESC";
                
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listNhanVien.Add(new NhanVien()
                        {
                            MaNV = Convert.ToInt32(reader["MaNV"]),
                            TenNV = reader["TenNV"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            ChucVu = reader["ChucVu"].ToString(),
                            SoLuongDonHang = reader["SoLuongDonHang"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuongDonHang"])
                        });
                    }
                }
            }
            return listNhanVien;
        }

        /// <summary>
        /// Thêm nhân viên mới - SQL Server tự động tạo MaNV
        /// </summary>
        public static int Insert(NhanVien nhanVien)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                
                // Không insert MaNV - để SQL Server tự động tạo
                string query = @"INSERT INTO nhanvien (TenNV, SoDienThoai, ChucVu) 
                               VALUES (@TenNV, @SoDienThoai, @ChucVu);
                               SELECT CAST(SCOPE_IDENTITY() AS INT);";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenNV", nhanVien.TenNV);
                    cmd.Parameters.AddWithValue("@SoDienThoai", nhanVien.SoDienThoai ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ChucVu", nhanVien.ChucVu ?? (object)DBNull.Value);
                    
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        public static bool Update(NhanVien nhanVien)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE nhanvien 
                               SET TenNV = @TenNV, SoDienThoai = @SoDienThoai, ChucVu = @ChucVu 
                               WHERE MaNV = @MaNV";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", nhanVien.MaNV);
                    cmd.Parameters.AddWithValue("@TenNV", nhanVien.TenNV);
                    cmd.Parameters.AddWithValue("@SoDienThoai", nhanVien.SoDienThoai ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ChucVu", nhanVien.ChucVu ?? (object)DBNull.Value);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        public static bool Delete(int maNV)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                
                try
                {
                    // Disable all foreign key constraints on both tables
                    string disableFK = "ALTER TABLE DonHang NOCHECK CONSTRAINT ALL; ALTER TABLE ChiTietDonHang NOCHECK CONSTRAINT ALL;";
                    string enableFK = "ALTER TABLE DonHang CHECK CONSTRAINT ALL; ALTER TABLE ChiTietDonHang CHECK CONSTRAINT ALL;";
                    string deleteQuery = "DELETE FROM nhanvien WHERE MaNV = @MaNV";

                    using (var cmd = new SqlCommand(disableFK, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    bool result;
                    using (var cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", maNV);
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
                        string enableFK = "ALTER TABLE DonHang CHECK CONSTRAINT ALL; ALTER TABLE ChiTietDonHang CHECK CONSTRAINT ALL;";
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

        /// <summary>
        /// Tìm kiếm nhân viên theo từ khóa
        /// </summary>
        public static List<NhanVien> Search(string keyword)
        {
            List<NhanVien> listNhanVien = new List<NhanVien>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT 
                                    nv.MaNV,
                                    nv.TenNV,
                                    nv.SoDienThoai,
                                    nv.ChucVu,
                                    COUNT(ct.MaDH) AS SoLuongDonHang
                                FROM NhanVien nv
                                LEFT JOIN ChiTietDonHang ct ON nv.MaNV = ct.MaNV
                                WHERE nv.TenNV LIKE @Keyword 
                                   OR nv.SoDienThoai LIKE @Keyword 
                                   OR nv.ChucVu LIKE @Keyword 
                                   OR CAST(nv.MaNV AS NVARCHAR) LIKE @Keyword
                                GROUP BY nv.MaNV, nv.TenNV, nv.SoDienThoai, nv.ChucVu
                                ORDER BY nv.MaNV DESC";
                
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listNhanVien.Add(new NhanVien()
                            {
                                MaNV = Convert.ToInt32(reader["MaNV"]),
                                TenNV = reader["TenNV"].ToString(),
                                SoDienThoai = reader["SoDienThoai"].ToString(),
                                ChucVu = reader["ChucVu"].ToString(),
                                SoLuongDonHang = reader["SoLuongDonHang"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuongDonHang"])
                            });
                        }
                    }
                }
            }
            return listNhanVien;
        }

        /// <summary>
        /// Lấy nhân viên theo mã
        /// </summary>
        public static NhanVien GetById(int maNV)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT 
                                    nv.MaNV,
                                    nv.TenNV,
                                    nv.SoDienThoai,
                                    nv.ChucVu,
                                    COUNT(ct.MaDH) AS SoLuongDonHang
                                FROM NhanVien nv
                                LEFT JOIN ChiTietDonHang ct ON nv.MaNV = ct.MaNV
                                WHERE nv.MaNV = @MaNV
                                GROUP BY nv.MaNV, nv.TenNV, nv.SoDienThoai, nv.ChucVu";
                
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new NhanVien()
                            {
                                MaNV = Convert.ToInt32(reader["MaNV"]),
                                TenNV = reader["TenNV"].ToString(),
                                SoDienThoai = reader["SoDienThoai"].ToString(),
                                ChucVu = reader["ChucVu"].ToString(),
                                SoLuongDonHang = reader["SoLuongDonHang"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuongDonHang"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Kiểm tra mã nhân viên có tồn tại không
        /// </summary>
        public static bool CheckMaNVExists(int maNV)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM nhanvien WHERE MaNV = @MaNV";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}