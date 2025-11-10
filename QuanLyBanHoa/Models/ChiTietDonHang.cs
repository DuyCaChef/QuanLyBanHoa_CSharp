using MySql.Data.MySqlClient;
using QuanLyBanHoa.Data;
using System;
using System.Collections.Generic;

namespace QuanLyBanHoa.Models
{
    public class ChiTietDonHang
    {
        // Properties
        public int MaDH { get; set; }
        public int MaHoa { get; set; }
        public int SoLuong { get; set; }
        public decimal ThanhTien { get; set; }
        public int MaNV { get; set; }

        // Parameterless constructor
        public ChiTietDonHang() { }

        public ChiTietDonHang(int maDH, int maHoa, int soLuong, decimal thanhTien, int maNV)
        {
            MaDH = maDH;
            MaHoa = maHoa;
            SoLuong = soLuong;
            ThanhTien = thanhTien;
            MaNV = maNV;
        }

        // Lấy tất cả chi tiết đơn hàng
        public static List<ChiTietDonHang> GetAll()
        {
            List<ChiTietDonHang> listChiTiet = new List<ChiTietDonHang>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaDH, MaHoa, SoLuong, ThanhTien, MaNV FROM chitietdonhang ORDER BY MaDH DESC";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listChiTiet.Add(new ChiTietDonHang()
                        {
                            MaDH = reader["MaDH"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaDH"]),
                            MaHoa = reader["MaHoa"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaHoa"]),
                            SoLuong = reader["SoLuong"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuong"]),
                            ThanhTien = reader["ThanhTien"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["ThanhTien"]),
                            MaNV = reader["MaNV"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaNV"])
                        });
                    }
                }
            }
            return listChiTiet;
        }

        // Lấy chi tiết đơn hàng theo MaDH
        public static List<ChiTietDonHang> GetByMaDH(int maDH)
        {
            List<ChiTietDonHang> listChiTiet = new List<ChiTietDonHang>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaDH, MaHoa, SoLuong, ThanhTien, MaNV FROM chitietdonhang WHERE MaDH = @MaDH";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDH", maDH);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listChiTiet.Add(new ChiTietDonHang()
                            {
                                MaDH = reader["MaDH"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaDH"]),
                                MaHoa = reader["MaHoa"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaHoa"]),
                                SoLuong = reader["SoLuong"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuong"]),
                                ThanhTien = reader["ThanhTien"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["ThanhTien"]),
                                MaNV = reader["MaNV"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaNV"])
                            });
                        }
                    }
                }
            }
            return listChiTiet;
        }

        // Thêm chi tiết đơn hàng mới
        public static bool Insert(ChiTietDonHang chiTiet)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO chitietdonhang (MaDH, MaHoa, SoLuong, ThanhTien, MaNV) 
                               VALUES (@MaDH, @MaHoa, @SoLuong, @ThanhTien, @MaNV)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDH", chiTiet.MaDH);
                    cmd.Parameters.AddWithValue("@MaHoa", chiTiet.MaHoa);
                    cmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                    cmd.Parameters.AddWithValue("@ThanhTien", chiTiet.ThanhTien);
                    cmd.Parameters.AddWithValue("@MaNV", chiTiet.MaNV);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Cập nhật chi tiết đơn hàng
        public static bool Update(ChiTietDonHang chiTiet, int oldMaHoa)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE chitietdonhang 
                               SET MaHoa = @MaHoa, SoLuong = @SoLuong, ThanhTien = @ThanhTien, MaNV = @MaNV
                               WHERE MaDH = @MaDH AND MaHoa = @OldMaHoa";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDH", chiTiet.MaDH);
                    cmd.Parameters.AddWithValue("@MaHoa", chiTiet.MaHoa);
                    cmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                    cmd.Parameters.AddWithValue("@ThanhTien", chiTiet.ThanhTien);
                    cmd.Parameters.AddWithValue("@MaNV", chiTiet.MaNV);
                    cmd.Parameters.AddWithValue("@OldMaHoa", oldMaHoa);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Xóa chi tiết đơn hàng
        public static bool Delete(int maDH, int maHoa)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM chitietdonhang WHERE MaDH = @MaDH AND MaHoa = @MaHoa";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDH", maDH);
                    cmd.Parameters.AddWithValue("@MaHoa", maHoa);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Xóa tất cả chi tiết của một đơn hàng
        public static bool DeleteByMaDH(int maDH)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM chitietdonhang WHERE MaDH = @MaDH";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDH", maDH);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Lấy chi tiết đơn hàng kèm thông tin hoa (JOIN)
        public static List<dynamic> GetDetailWithHoaInfo(int maDH)
        {
            List<dynamic> listDetail = new List<dynamic>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT ct.MaDH, ct.MaHoa, h.TenHoa, ct.SoLuong, h.Gia, ct.ThanhTien, ct.MaNV
                               FROM chitietdonhang ct
                               INNER JOIN hoa h ON ct.MaHoa = h.MaHoa
                               WHERE ct.MaDH = @MaDH";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDH", maDH);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listDetail.Add(new
                            {
                                MaDH = reader["MaDH"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaDH"]),
                                MaHoa = reader["MaHoa"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaHoa"]),
                                TenHoa = reader["TenHoa"] == DBNull.Value ? string.Empty : reader["TenHoa"].ToString(),
                                SoLuong = reader["SoLuong"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuong"]),
                                Gia = reader["Gia"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["Gia"]),
                                ThanhTien = reader["ThanhTien"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["ThanhTien"]),
                                MaNV = reader["MaNV"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaNV"])
                            });
                        }
                    }
                }
            }
            return listDetail;
        }
    }
}