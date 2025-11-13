using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanHoa.Data;

namespace QuanLyBanHoa.Models
{
    public class DonHang
    {
        // Properties
        public int MaDH { get; set; }
        public int MaKH { get; set; }
        public int MaNV { get; set; }
        public DateTime NgayDatHang { get; set; }
        public decimal TongTien { get; set; }
        public int? MaKM { get; set; } // Dấu ? cho phép giá trị null
        public string TenKH_DatHang { get; set; }
        public string DiaChi_DatHang { get; set; }
        public string SoDienThoai_DatHang { get; set; }
        public string TenNV_BanHang { get; set; }

        // Parameterless constructor
        public DonHang() { }

        public DonHang(int maDH, int maKH, int maNV, DateTime ngayDatHang, decimal tongTien, int? maKM)
        {
            MaDH = maDH;
            MaKH = maKH;
            MaNV = maNV;
            NgayDatHang = ngayDatHang;
            TongTien = tongTien;
            MaKM = maKM;
        }

        // Lấy tất cả đơn hàng
        public static List<DonHang> GetAll()
        {
            List<DonHang> listDonHang = new List<DonHang>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaDH, MaKH, MaNV, NgayDatHang, TongTien, MaKM, TenKH_DatHang, DiaChi_DatHang, SoDienThoai_DatHang, TenNV_BanHang FROM DonHang ORDER BY MaDH DESC";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listDonHang.Add(new DonHang()
                        {
                            MaDH = reader["MaDH"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaDH"]),
                            MaKH = reader["MaKH"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaKH"]),
                            MaNV = reader["MaNV"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaNV"]),
                            NgayDatHang = reader["NgayDatHang"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["NgayDatHang"]),
                            TongTien = reader["TongTien"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["TongTien"]),
                            MaKM = reader["MaKM"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["MaKM"]),
                            TenKH_DatHang = reader["TenKH_DatHang"] == DBNull.Value ? string.Empty : reader["TenKH_DatHang"].ToString(),
                            DiaChi_DatHang = reader["DiaChi_DatHang"] == DBNull.Value ? string.Empty : reader["DiaChi_DatHang"].ToString(),
                            SoDienThoai_DatHang = reader["SoDienThoai_DatHang"] == DBNull.Value ? string.Empty : reader["SoDienThoai_DatHang"].ToString(),
                            TenNV_BanHang = reader["TenNV_BanHang"] == DBNull.Value ? string.Empty : reader["TenNV_BanHang"].ToString()
                        });
                    }
                }
            }
            return listDonHang;
        }

        // Lấy đơn hàng theo mã
        public static DonHang GetById(int maDH)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaDH, MaKH, MaNV, NgayDatHang, TongTien, MaKM, TenKH_DatHang, DiaChi_DatHang, SoDienThoai_DatHang, TenNV_BanHang FROM DonHang WHERE MaDH = @MaDH";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDH", maDH);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DonHang()
                            {
                                MaDH = reader["MaDH"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaDH"]),
                                MaKH = reader["MaKH"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaKH"]),
                                MaNV = reader["MaNV"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaNV"]),
                                NgayDatHang = reader["NgayDatHang"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["NgayDatHang"]),
                                TongTien = reader["TongTien"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["TongTien"]),
                                MaKM = reader["MaKM"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["MaKM"]),
                                TenKH_DatHang = reader["TenKH_DatHang"] == DBNull.Value ? string.Empty : reader["TenKH_DatHang"].ToString(),
                                DiaChi_DatHang = reader["DiaChi_DatHang"] == DBNull.Value ? string.Empty : reader["DiaChi_DatHang"].ToString(),
                                SoDienThoai_DatHang = reader["SoDienThoai_DatHang"] == DBNull.Value ? string.Empty : reader["SoDienThoai_DatHang"].ToString(),
                                TenNV_BanHang = reader["TenNV_BanHang"] == DBNull.Value ? string.Empty : reader["TenNV_BanHang"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        // Thêm đơn hàng mới
        public static int Insert(DonHang donHang)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                // SQL Server: SCOPE_IDENTITY() thay vì LAST_INSERT_ID()
                string query = @"INSERT INTO DonHang (MaKH, MaNV, NgayDatHang, TongTien, MaKM, TenKH_DatHang, DiaChi_DatHang, SoDienThoai_DatHang, TenNV_BanHang) 
                               VALUES (@MaKH, @MaNV, @NgayDatHang, @TongTien, @MaKM, @TenKH_DatHang, @DiaChi_DatHang, @SoDienThoai_DatHang, @TenNV_BanHang);
                               SELECT CAST(SCOPE_IDENTITY() AS INT);";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKH", donHang.MaKH);
                    cmd.Parameters.AddWithValue("@MaNV", donHang.MaNV);
                    cmd.Parameters.AddWithValue("@NgayDatHang", donHang.NgayDatHang);
                    cmd.Parameters.AddWithValue("@TongTien", donHang.TongTien);
                    cmd.Parameters.AddWithValue("@MaKM", donHang.MaKM.HasValue ? (object)donHang.MaKM.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenKH_DatHang", donHang.TenKH_DatHang ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiaChi_DatHang", donHang.DiaChi_DatHang ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoDienThoai_DatHang", donHang.SoDienThoai_DatHang ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenNV_BanHang", donHang.TenNV_BanHang ?? (object)DBNull.Value);
                    
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        // Cập nhật đơn hàng
        public static bool Update(DonHang donHang)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE DonHang 
                               SET MaKH = @MaKH, MaNV = @MaNV, NgayDatHang = @NgayDatHang, TongTien = @TongTien, MaKM = @MaKM,
                                   TenKH_DatHang = @TenKH_DatHang, DiaChi_DatHang = @DiaChi_DatHang, SoDienThoai_DatHang = @SoDienThoai_DatHang, TenNV_BanHang = @TenNV_BanHang
                               WHERE MaDH = @MaDH";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDH", donHang.MaDH);
                    cmd.Parameters.AddWithValue("@MaKH", donHang.MaKH);
                    cmd.Parameters.AddWithValue("@MaNV", donHang.MaNV);
                    cmd.Parameters.AddWithValue("@NgayDatHang", donHang.NgayDatHang);
                    cmd.Parameters.AddWithValue("@TongTien", donHang.TongTien);
                    cmd.Parameters.AddWithValue("@MaKM", donHang.MaKM.HasValue ? (object)donHang.MaKM.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenKH_DatHang", donHang.TenKH_DatHang ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiaChi_DatHang", donHang.DiaChi_DatHang ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoDienThoai_DatHang", donHang.SoDienThoai_DatHang ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenNV_BanHang", donHang.TenNV_BanHang ?? (object)DBNull.Value);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Xóa đơn hàng
        public static bool Delete(int maDH)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM DonHang WHERE MaDH = @MaDH";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDH", maDH);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Tìm kiếm đơn hàng
        public static List<DonHang> Search(string keyword)
        {
            List<DonHang> listDonHang = new List<DonHang>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT MaDH, MaKH, MaNV, NgayDatHang, TongTien, MaKM, TenKH_DatHang, DiaChi_DatHang, SoDienThoai_DatHang, TenNV_BanHang 
                               FROM DonHang 
                               WHERE CAST(MaDH AS NVARCHAR) LIKE @Keyword OR CAST(MaKH AS NVARCHAR) LIKE @Keyword OR CAST(MaNV AS NVARCHAR) LIKE @Keyword
                               ORDER BY MaDH DESC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listDonHang.Add(new DonHang()
                            {
                                MaDH = reader["MaDH"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaDH"]),
                                MaKH = reader["MaKH"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaKH"]),
                                MaNV = reader["MaNV"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaNV"]),
                                NgayDatHang = reader["NgayDatHang"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["NgayDatHang"]),
                                TongTien = reader["TongTien"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["TongTien"]),
                                MaKM = reader["MaKM"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["MaKM"]),
                                TenKH_DatHang = reader["TenKH_DatHang"] == DBNull.Value ? string.Empty : reader["TenKH_DatHang"].ToString(),
                                DiaChi_DatHang = reader["DiaChi_DatHang"] == DBNull.Value ? string.Empty : reader["DiaChi_DatHang"].ToString(),
                                SoDienThoai_DatHang = reader["SoDienThoai_DatHang"] == DBNull.Value ? string.Empty : reader["SoDienThoai_DatHang"].ToString(),
                                TenNV_BanHang = reader["TenNV_BanHang"] == DBNull.Value ? string.Empty : reader["TenNV_BanHang"].ToString()
                            });
                        }
                    }
                }
            }
            return listDonHang;
        }

        // Tìm kiếm đơn hàng theo khoảng thời gian
        public static List<DonHang> SearchByDateRange(DateTime fromDate, DateTime toDate)
        {
            List<DonHang> listDonHang = new List<DonHang>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT MaDH, MaKH, MaNV, NgayDatHang, TongTien, MaKM, TenKH_DatHang, DiaChi_DatHang, SoDienThoai_DatHang, TenNV_BanHang 
                               FROM DonHang 
                               WHERE NgayDatHang BETWEEN @FromDate AND @ToDate
                               ORDER BY MaDH DESC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                    cmd.Parameters.AddWithValue("@ToDate", toDate.Date.AddDays(1).AddSeconds(-1));
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listDonHang.Add(new DonHang()
                            {
                                MaDH = reader["MaDH"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaDH"]),
                                MaKH = reader["MaKH"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaKH"]),
                                MaNV = reader["MaNV"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaNV"]),
                                NgayDatHang = reader["NgayDatHang"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["NgayDatHang"]),
                                TongTien = reader["TongTien"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["TongTien"]),
                                MaKM = reader["MaKM"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["MaKM"]),
                                TenKH_DatHang = reader["TenKH_DatHang"] == DBNull.Value ? string.Empty : reader["TenKH_DatHang"].ToString(),
                                DiaChi_DatHang = reader["DiaChi_DatHang"] == DBNull.Value ? string.Empty : reader["DiaChi_DatHang"].ToString(),
                                SoDienThoai_DatHang = reader["SoDienThoai_DatHang"] == DBNull.Value ? string.Empty : reader["SoDienThoai_DatHang"].ToString(),
                                TenNV_BanHang = reader["TenNV_BanHang"] == DBNull.Value ? string.Empty : reader["TenNV_BanHang"].ToString()
                            });
                        }
                    }
                }
            }
            return listDonHang;
        }

        // Lấy danh sách đơn hàng với chi tiết
        public static List<dynamic> GetOrdersWithDetails()
        {
            List<dynamic> list = new List<dynamic>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT TOP 500 
                                ct.MaDH, 
                                d.NgayDatHang, 
                                d.TenKH_DatHang AS TenKH, 
                                d.SoDienThoai_DatHang AS SoDienThoai, 
                                ct.MaNV,
                                ct.TenHoa_DatHang AS TenHoa,
                                ct.SoLuong,
                                ct.ThanhTien,
                                ct.DonGia AS Gia,
                                ct.MaHoa
                              FROM ChiTietDonHang ct
                              INNER JOIN DonHang d ON ct.MaDH = d.MaDH
                              ORDER BY ct.MaDH DESC, ct.TenHoa_DatHang";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new
                        {
                            MaDH = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            NgayDatHang = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1),
                            TenKH = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                            SoDienThoai = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                            MaNV = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                            TenHoa = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                            SoLuong = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                            ThanhTien = reader.IsDBNull(7) ? 0m : reader.GetDecimal(7),
                            Gia = reader.IsDBNull(8) ? 0m : reader.GetDecimal(8),
                            MaHoa = reader.IsDBNull(9) ? 0 : reader.GetInt32(9)
                        });
                    }
                }
            }
            return list;
        }

        // Cập nhật tổng tiền đơn hàng
        public static bool UpdateTongTien(int maDH, decimal themTien)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE DonHang SET TongTien = TongTien + @ThemTien WHERE MaDH = @MaDH";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDH", maDH);
                    cmd.Parameters.AddWithValue("@ThemTien", themTien);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Thêm đơn hàng với ID cụ thể
        public static bool InsertWithId(DonHang donHang)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SET IDENTITY_INSERT DonHang ON;
                               INSERT INTO DonHang (MaDH, MaKH, MaNV, NgayDatHang, TongTien, MaKM, TenKH_DatHang, DiaChi_DatHang, SoDienThoai_DatHang, TenNV_BanHang) 
                               VALUES (@MaDH, @MaKH, @MaNV, @NgayDatHang, @TongTien, @MaKM, @TenKH_DatHang, @DiaChi_DatHang, @SoDienThoai_DatHang, @TenNV_BanHang);
                               SET IDENTITY_INSERT DonHang OFF;";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDH", donHang.MaDH);
                    cmd.Parameters.AddWithValue("@MaKH", donHang.MaKH);
                    cmd.Parameters.AddWithValue("@MaNV", donHang.MaNV);
                    cmd.Parameters.AddWithValue("@NgayDatHang", donHang.NgayDatHang);
                    cmd.Parameters.AddWithValue("@TongTien", donHang.TongTien);
                    cmd.Parameters.AddWithValue("@MaKM", donHang.MaKM.HasValue ? (object)donHang.MaKM.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenKH_DatHang", donHang.TenKH_DatHang ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiaChi_DatHang", donHang.DiaChi_DatHang ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoDienThoai_DatHang", donHang.SoDienThoai_DatHang ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenNV_BanHang", donHang.TenNV_BanHang ?? (object)DBNull.Value);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Tính tổng tiền từ chi tiết
        public static decimal GetTotalTien(int maDH)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT COALESCE(SUM(ThanhTien), 0) FROM ChiTietDonHang WHERE MaDH = @MaDH";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDH", maDH);
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToDecimal(result) : 0m;
                }
            }
        }

        // Overload with connection and transaction
        public static DonHang GetById(int maDH, SqlConnection conn, SqlTransaction tx = null)
        {
            string query = "SELECT MaDH, MaKH, MaNV, NgayDatHang, TongTien, MaKM, TenKH_DatHang, DiaChi_DatHang, SoDienThoai_DatHang, TenNV_BanHang FROM DonHang WHERE MaDH = @MaDH";
            using (var cmd = new SqlCommand(query, conn, tx))
            {
                cmd.Parameters.AddWithValue("@MaDH", maDH);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new DonHang()
                        {
                            MaDH = reader["MaDH"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaDH"]),
                            MaKH = reader["MaKH"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaKH"]),
                            MaNV = reader["MaNV"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaNV"]),
                            NgayDatHang = reader["NgayDatHang"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["NgayDatHang"]),
                            TongTien = reader["TongTien"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["TongTien"]),
                            MaKM = reader["MaKM"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["MaKM"]),
                            TenKH_DatHang = reader["TenKH_DatHang"] == DBNull.Value ? string.Empty : reader["TenKH_DatHang"].ToString(),
                            DiaChi_DatHang = reader["DiaChi_DatHang"] == DBNull.Value ? string.Empty : reader["DiaChi_DatHang"].ToString(),
                            SoDienThoai_DatHang = reader["SoDienThoai_DatHang"] == DBNull.Value ? string.Empty : reader["SoDienThoai_DatHang"].ToString(),
                            TenNV_BanHang = reader["TenNV_BanHang"] == DBNull.Value ? string.Empty : reader["TenNV_BanHang"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        // Overload with connection and transaction
        public static int Insert(DonHang donHang, SqlConnection conn, SqlTransaction tx = null)
        {
            string query = @"INSERT INTO DonHang (MaKH, MaNV, NgayDatHang, TongTien, MaKM, TenKH_DatHang, DiaChi_DatHang, SoDienThoai_DatHang, TenNV_BanHang) 
                           VALUES (@MaKH, @MaNV, @NgayDatHang, @TongTien, @MaKM, @TenKH_DatHang, @DiaChi_DatHang, @SoDienThoai_DatHang, @TenNV_BanHang);
                           SELECT CAST(SCOPE_IDENTITY() AS INT);";
            using (var cmd = new SqlCommand(query, conn, tx))
            {
                cmd.Parameters.AddWithValue("@MaKH", donHang.MaKH);
                cmd.Parameters.AddWithValue("@MaNV", donHang.MaNV);
                cmd.Parameters.AddWithValue("@NgayDatHang", donHang.NgayDatHang);
                cmd.Parameters.AddWithValue("@TongTien", donHang.TongTien);
                cmd.Parameters.AddWithValue("@MaKM", donHang.MaKM.HasValue ? (object)donHang.MaKM.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@TenKH_DatHang", donHang.TenKH_DatHang ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DiaChi_DatHang", donHang.DiaChi_DatHang ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SoDienThoai_DatHang", donHang.SoDienThoai_DatHang ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TenNV_BanHang", donHang.TenNV_BanHang ?? (object)DBNull.Value);
                
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        // Overload with connection and transaction
        public static bool InsertWithId(DonHang donHang, SqlConnection conn, SqlTransaction tx = null)
        {
            string query = @"SET IDENTITY_INSERT DonHang ON;
                           INSERT INTO DonHang (MaDH, MaKH, MaNV, NgayDatHang, TongTien, MaKM, TenKH_DatHang, DiaChi_DatHang, SoDienThoai_DatHang, TenNV_BanHang) 
                           VALUES (@MaDH, @MaKH, @MaNV, @NgayDatHang, @TongTien, @MaKM, @TenKH_DatHang, @DiaChi_DatHang, @SoDienThoai_DatHang, @TenNV_BanHang);
                           SET IDENTITY_INSERT DonHang OFF;";
            using (var cmd = new SqlCommand(query, conn, tx))
            {
                cmd.Parameters.AddWithValue("@MaDH", donHang.MaDH);
                cmd.Parameters.AddWithValue("@MaKH", donHang.MaKH);
                cmd.Parameters.AddWithValue("@MaNV", donHang.MaNV);
                cmd.Parameters.AddWithValue("@NgayDatHang", donHang.NgayDatHang);
                cmd.Parameters.AddWithValue("@TongTien", donHang.TongTien);
                cmd.Parameters.AddWithValue("@MaKM", donHang.MaKM.HasValue ? (object)donHang.MaKM.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@TenKH_DatHang", donHang.TenKH_DatHang ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DiaChi_DatHang", donHang.DiaChi_DatHang ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SoDienThoai_DatHang", donHang.SoDienThoai_DatHang ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TenNV_BanHang", donHang.TenNV_BanHang ?? (object)DBNull.Value);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Overload with connection and transaction
        public static bool UpdateTongTien(int maDH, decimal themTien, SqlConnection conn, SqlTransaction tx = null)
        {
            string query = @"UPDATE DonHang SET TongTien = TongTien + @ThemTien WHERE MaDH = @MaDH";
            using (var cmd = new SqlCommand(query, conn, tx))
            {
                cmd.Parameters.AddWithValue("@MaDH", maDH);
                cmd.Parameters.AddWithValue("@ThemTien", themTien);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Overload with connection and transaction
        public static bool Update(DonHang donHang, SqlConnection conn, SqlTransaction tx = null)
        {
            string query = @"UPDATE DonHang 
                           SET MaKH = @MaKH, MaNV = @MaNV, NgayDatHang = @NgayDatHang, TongTien = @TongTien, MaKM = @MaKM,
                               TenKH_DatHang = @TenKH_DatHang, DiaChi_DatHang = @DiaChi_DatHang, SoDienThoai_DatHang = @SoDienThoai_DatHang, TenNV_BanHang = @TenNV_BanHang
                           WHERE MaDH = @MaDH";
            using (var cmd = new SqlCommand(query, conn, tx))
            {
                cmd.Parameters.AddWithValue("@MaDH", donHang.MaDH);
                cmd.Parameters.AddWithValue("@MaKH", donHang.MaKH);
                cmd.Parameters.AddWithValue("@MaNV", donHang.MaNV);
                cmd.Parameters.AddWithValue("@NgayDatHang", donHang.NgayDatHang);
                cmd.Parameters.AddWithValue("@TongTien", donHang.TongTien);
                cmd.Parameters.AddWithValue("@MaKM", donHang.MaKM.HasValue ? (object)donHang.MaKM.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@TenKH_DatHang", donHang.TenKH_DatHang ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DiaChi_DatHang", donHang.DiaChi_DatHang ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SoDienThoai_DatHang", donHang.SoDienThoai_DatHang ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TenNV_BanHang", donHang.TenNV_BanHang ?? (object)DBNull.Value);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Overload with connection and transaction
        public static decimal GetTotalTien(int maDH, SqlConnection conn, SqlTransaction tx = null)
        {
            string query = "SELECT COALESCE(SUM(ThanhTien), 0) FROM ChiTietDonHang WHERE MaDH = @MaDH";
            using (var cmd = new SqlCommand(query, conn, tx))
            {
                cmd.Parameters.AddWithValue("@MaDH", maDH);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToDecimal(result) : 0m;
            }
        }

        // Cập nhật đơn hàng với chi tiết (dùng cho btnSua)
        public static bool UpdateOrderWithDetails(int maDH, int maNV, DateTime ngayDatHang, int newMaHoa, int newSoLuong, decimal gia, int oldMaHoa, SqlConnection conn, SqlTransaction tx = null)
        {
            // Lấy thông tin đơn hàng hiện tại
            DonHang currentOrder = GetById(maDH, conn, tx);
            if (currentOrder == null)
            {
                throw new Exception("Không tìm thấy đơn hàng để sửa.");
            }
            int maKH = currentOrder.MaKH;

            // Tính toán thanh tiền mới
            decimal newThanhTien = gia * newSoLuong;

            // Cập nhật chi tiết đơn hàng nếu có thay đổi hoa
            if (oldMaHoa != 0 && oldMaHoa != newMaHoa)
            {
                ChiTietDonHang.Update(new ChiTietDonHang { MaDH = maDH, MaHoa = newMaHoa, SoLuong = newSoLuong, ThanhTien = newThanhTien, MaNV = maNV }, oldMaHoa, conn, tx);
            }

            // Tính lại tổng tiền từ chi tiết
            decimal tongTien = GetTotalTien(maDH, conn, tx);

            // Cập nhật đơn hàng
            Update(new DonHang { MaDH = maDH, MaKH = maKH, MaNV = maNV, NgayDatHang = ngayDatHang, TongTien = tongTien, MaKM = null }, conn, tx);

            return true;
        }

        // Overload with connection and transaction
        public static bool Delete(int maDH, SqlConnection conn, SqlTransaction tx = null)
        {
            string query = "DELETE FROM DonHang WHERE MaDH = @MaDH";
            using (var cmd = new SqlCommand(query, conn, tx))
            {
                cmd.Parameters.AddWithValue("@MaDH", maDH);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}