using MySql.Data.MySqlClient;
using QuanLyBanHoa.Data;
using System;
using System.Collections.Generic;
using System.Data;

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
                string query = "SELECT MaDH, MaKH, MaNV, NgayDatHang, TongTien, MaKM FROM donhang ORDER BY MaDH DESC";
                using (var cmd = new MySqlCommand(query, conn))
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
                            MaKM = reader["MaKM"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["MaKM"])
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
                string query = "SELECT MaDH, MaKH, MaNV, NgayDatHang, TongTien, MaKM FROM donhang WHERE MaDH = @MaDH";
                using (var cmd = new MySqlCommand(query, conn))
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
                                MaKM = reader["MaKM"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["MaKM"])
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
                string query = @"INSERT INTO donhang (MaKH, MaNV, NgayDatHang, TongTien, MaKM) 
                               VALUES (@MaKH, @MaNV, @NgayDatHang, @TongTien, @MaKM);
                               SELECT LAST_INSERT_ID();";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKH", donHang.MaKH);
                    cmd.Parameters.AddWithValue("@MaNV", donHang.MaNV);
                    cmd.Parameters.AddWithValue("@NgayDatHang", donHang.NgayDatHang);
                    cmd.Parameters.AddWithValue("@TongTien", donHang.TongTien);
                    cmd.Parameters.AddWithValue("@MaKM", donHang.MaKM.HasValue ? (object)donHang.MaKM.Value : DBNull.Value);
                    
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
                string query = @"UPDATE donhang 
                               SET MaKH = @MaKH, MaNV = @MaNV, NgayDatHang = @NgayDatHang, TongTien = @TongTien, MaKM = @MaKM
                               WHERE MaDH = @MaDH";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDH", donHang.MaDH);
                    cmd.Parameters.AddWithValue("@MaKH", donHang.MaKH);
                    cmd.Parameters.AddWithValue("@MaNV", donHang.MaNV);
                    cmd.Parameters.AddWithValue("@NgayDatHang", donHang.NgayDatHang);
                    cmd.Parameters.AddWithValue("@TongTien", donHang.TongTien);
                    cmd.Parameters.AddWithValue("@MaKM", donHang.MaKM.HasValue ? (object)donHang.MaKM.Value : DBNull.Value);
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
                string query = "DELETE FROM donhang WHERE MaDH = @MaDH";
                using (var cmd = new MySqlCommand(query, conn))
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
                string query = @"SELECT MaDH, MaKH, MaNV, NgayDatHang, TongTien, MaKM 
                               FROM donhang 
                               WHERE MaDH LIKE @Keyword OR MaKH LIKE @Keyword OR MaNV LIKE @Keyword
                               ORDER BY MaDH DESC";
                using (var cmd = new MySqlCommand(query, conn))
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
                                MaKM = reader["MaKM"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["MaKM"])
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
                string query = @"SELECT MaDH, MaKH, MaNV, NgayDatHang, TongTien, MaKM 
                               FROM donhang 
                               WHERE NgayDatHang BETWEEN @FromDate AND @ToDate
                               ORDER BY MaDH DESC";
                using (var cmd = new MySqlCommand(query, conn))
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
                                MaKM = reader["MaKM"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["MaKM"])
                            });
                        }
                    }
                }
            }
            return listDonHang;
        }
    }
}