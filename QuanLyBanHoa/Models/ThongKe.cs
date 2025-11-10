using MySql.Data.MySqlClient;
using QuanLyBanHoa.Data;
using System;
using System.Collections.Generic;

namespace QuanLyBanHoa.Models
{
    public class ThongKe
    {
        // Class ?? ch?a d? li?u th?ng kê doanh thu theo ngày
        public class DoanhThuTheoNgay
        {
            public DateTime Ngay { get; set; }
            public decimal TongDoanhThu { get; set; }
            public int SoDonHang { get; set; }
        }

        // Class ?? ch?a d? li?u th?ng kê hoa bán ch?y
        public class HoaBanChay
        {
            public int MaHoa { get; set; }
            public string TenHoa { get; set; }
            public int TongSoLuongBan { get; set; }
            public decimal TongDoanhThu { get; set; }
            public string PhanLoai { get; set; }
        }

        // Class ?? ch?a d? li?u th?ng kê nhân viên
        public class ThongKeNhanVien
        {
            public int MaNV { get; set; }
            public string TenNV { get; set; }
            public int SoDonHang { get; set; }
            public decimal TongDoanhThu { get; set; }
        }

        // Class ?? ch?a d? li?u th?ng kê khách hàng
        public class ThongKeKhachHang
        {
            public int MaKH { get; set; }
            public string TenKH { get; set; }
            public int SoDonHang { get; set; }
            public decimal TongChiTieu { get; set; }
        }

        // L?y doanh thu theo kho?ng th?i gian
        public static List<DoanhThuTheoNgay> GetDoanhThuTheoNgay(DateTime fromDate, DateTime toDate)
        {
            List<DoanhThuTheoNgay> listDoanhThu = new List<DoanhThuTheoNgay>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT DATE(NgayDatHang) AS Ngay, 
                                      SUM(TongTien) AS TongDoanhThu,
                                      COUNT(MaDH) AS SoDonHang
                               FROM donhang
                               WHERE NgayDatHang BETWEEN @FromDate AND @ToDate
                               GROUP BY DATE(NgayDatHang)
                               ORDER BY Ngay DESC";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                    cmd.Parameters.AddWithValue("@ToDate", toDate.Date.AddDays(1).AddSeconds(-1));
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listDoanhThu.Add(new DoanhThuTheoNgay()
                            {
                                Ngay = reader["Ngay"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["Ngay"]),
                                TongDoanhThu = reader["TongDoanhThu"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["TongDoanhThu"]),
                                SoDonHang = reader["SoDonHang"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoDonHang"])
                            });
                        }
                    }
                }
            }
            return listDoanhThu;
        }

        // L?y t?ng doanh thu theo kho?ng th?i gian
        public static decimal GetTongDoanhThu(DateTime fromDate, DateTime toDate)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT COALESCE(SUM(TongTien), 0) AS TongDoanhThu
                               FROM donhang
                               WHERE NgayDatHang BETWEEN @FromDate AND @ToDate";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                    cmd.Parameters.AddWithValue("@ToDate", toDate.Date.AddDays(1).AddSeconds(-1));
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToDecimal(result) : 0m;
                }
            }
        }

        // L?y danh sách hoa bán ch?y
        public static List<HoaBanChay> GetHoaBanChay(DateTime fromDate, DateTime toDate, int top = 10)
        {
            List<HoaBanChay> listHoaBanChay = new List<HoaBanChay>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT h.MaHoa, h.TenHoa, h.PhanLoai,
                                      SUM(ct.SoLuong) AS TongSoLuongBan,
                                      SUM(ct.ThanhTien) AS TongDoanhThu
                               FROM chitietdonhang ct
                               INNER JOIN hoa h ON ct.MaHoa = h.MaHoa
                               INNER JOIN donhang dh ON ct.MaDH = dh.MaDH
                               WHERE dh.NgayDatHang BETWEEN @FromDate AND @ToDate
                               GROUP BY h.MaHoa, h.TenHoa, h.PhanLoai
                               ORDER BY TongSoLuongBan DESC
                               LIMIT @Top";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                    cmd.Parameters.AddWithValue("@ToDate", toDate.Date.AddDays(1).AddSeconds(-1));
                    cmd.Parameters.AddWithValue("@Top", top);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listHoaBanChay.Add(new HoaBanChay()
                            {
                                MaHoa = reader["MaHoa"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaHoa"]),
                                TenHoa = reader["TenHoa"] == DBNull.Value ? string.Empty : reader["TenHoa"].ToString(),
                                PhanLoai = reader["PhanLoai"] == DBNull.Value ? string.Empty : reader["PhanLoai"].ToString(),
                                TongSoLuongBan = reader["TongSoLuongBan"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TongSoLuongBan"]),
                                TongDoanhThu = reader["TongDoanhThu"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["TongDoanhThu"])
                            });
                        }
                    }
                }
            }
            return listHoaBanChay;
        }

        // Th?ng kê theo nhân viên
        public static List<ThongKeNhanVien> GetThongKeNhanVien(DateTime fromDate, DateTime toDate)
        {
            List<ThongKeNhanVien> listThongKe = new List<ThongKeNhanVien>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT dh.MaNV, nv.TenNV,
                                      COUNT(dh.MaDH) AS SoDonHang,
                                      SUM(dh.TongTien) AS TongDoanhThu
                               FROM donhang dh
                               INNER JOIN nhanvien nv ON dh.MaNV = nv.MaNV
                               WHERE dh.NgayDatHang BETWEEN @FromDate AND @ToDate
                               GROUP BY dh.MaNV, nv.TenNV
                               ORDER BY TongDoanhThu DESC";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                    cmd.Parameters.AddWithValue("@ToDate", toDate.Date.AddDays(1).AddSeconds(-1));
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listThongKe.Add(new ThongKeNhanVien()
                            {
                                MaNV = reader["MaNV"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaNV"]),
                                TenNV = reader["TenNV"] == DBNull.Value ? string.Empty : reader["TenNV"].ToString(),
                                SoDonHang = reader["SoDonHang"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoDonHang"]),
                                TongDoanhThu = reader["TongDoanhThu"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["TongDoanhThu"])
                            });
                        }
                    }
                }
            }
            return listThongKe;
        }

        // Th?ng kê theo khách hàng
        public static List<ThongKeKhachHang> GetThongKeKhachHang(DateTime fromDate, DateTime toDate, int top = 10)
        {
            List<ThongKeKhachHang> listThongKe = new List<ThongKeKhachHang>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT dh.MaKH, kh.TenKH,
                                      COUNT(dh.MaDH) AS SoDonHang,
                                      SUM(dh.TongTien) AS TongChiTieu
                               FROM donhang dh
                               INNER JOIN khachhang kh ON dh.MaKH = kh.MaKH
                               WHERE dh.NgayDatHang BETWEEN @FromDate AND @ToDate
                               GROUP BY dh.MaKH, kh.TenKH
                               ORDER BY TongChiTieu DESC
                               LIMIT @Top";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                    cmd.Parameters.AddWithValue("@ToDate", toDate.Date.AddDays(1).AddSeconds(-1));
                    cmd.Parameters.AddWithValue("@Top", top);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listThongKe.Add(new ThongKeKhachHang()
                            {
                                MaKH = reader["MaKH"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaKH"]),
                                TenKH = reader["TenKH"] == DBNull.Value ? string.Empty : reader["TenKH"].ToString(),
                                SoDonHang = reader["SoDonHang"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoDonHang"]),
                                TongChiTieu = reader["TongChiTieu"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["TongChiTieu"])
                            });
                        }
                    }
                }
            }
            return listThongKe;
        }

        // L?y t?ng s? ??n hàng theo kho?ng th?i gian
        public static int GetTongSoDonHang(DateTime fromDate, DateTime toDate)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT COUNT(MaDH) AS TongDonHang
                               FROM donhang
                               WHERE NgayDatHang BETWEEN @FromDate AND @ToDate";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                    cmd.Parameters.AddWithValue("@ToDate", toDate.Date.AddDays(1).AddSeconds(-1));
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        // Th?ng kê theo phân lo?i hoa
        public static List<dynamic> GetThongKeTheoPhanLoai(DateTime fromDate, DateTime toDate)
        {
            List<dynamic> listThongKe = new List<dynamic>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT h.PhanLoai,
                                      SUM(ct.SoLuong) AS TongSoLuong,
                                      SUM(ct.ThanhTien) AS TongDoanhThu,
                                      COUNT(DISTINCT ct.MaDH) AS SoDonHang
                               FROM chitietdonhang ct
                               INNER JOIN hoa h ON ct.MaHoa = h.MaHoa
                               INNER JOIN donhang dh ON ct.MaDH = dh.MaDH
                               WHERE dh.NgayDatHang BETWEEN @FromDate AND @ToDate
                               GROUP BY h.PhanLoai
                               ORDER BY TongDoanhThu DESC";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                    cmd.Parameters.AddWithValue("@ToDate", toDate.Date.AddDays(1).AddSeconds(-1));
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listThongKe.Add(new
                            {
                                PhanLoai = reader["PhanLoai"] == DBNull.Value ? string.Empty : reader["PhanLoai"].ToString(),
                                TongSoLuong = reader["TongSoLuong"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TongSoLuong"]),
                                TongDoanhThu = reader["TongDoanhThu"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["TongDoanhThu"]),
                                SoDonHang = reader["SoDonHang"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoDonHang"])
                            });
                        }
                    }
                }
            }
            return listThongKe;
        }

        // L?y doanh thu trung bình m?i ??n hàng
        public static decimal GetDoanhThuTrungBinh(DateTime fromDate, DateTime toDate)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT COALESCE(AVG(TongTien), 0) AS DoanhThuTrungBinh
                               FROM donhang
                               WHERE NgayDatHang BETWEEN @FromDate AND @ToDate";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                    cmd.Parameters.AddWithValue("@ToDate", toDate.Date.AddDays(1).AddSeconds(-1));
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToDecimal(result) : 0m;
                }
            }
        }
    }
}
