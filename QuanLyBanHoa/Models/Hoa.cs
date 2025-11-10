using MySql.Data.MySqlClient;
using QuanLyBanHoa.Data; // ensure Database class namespace
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyBanHoa.Models
{
    public class Hoa
    {
        // Properties
        public int MaHoa { get; set; }
        public string TenHoa { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public string GhiChu { get; set; }

        // Parameterless constructor (needed for object initializers)
        public Hoa() { }

        public Hoa(int maHoa, string tenHoa, decimal gia, int soLuong, string ghiChu)
        {
            MaHoa = maHoa;
            TenHoa = tenHoa;
            Gia = gia;
            SoLuong = soLuong;
            GhiChu = ghiChu;
        }

        public static List<Hoa> GetAll()
        {
            List<Hoa> listHoa = new List<Hoa>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaHoa, TenHoa, Gia, SoLuong, GhiChu FROM hoa ORDER BY MaHoa DESC";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listHoa.Add(new Hoa()
                        {
                            MaHoa = reader["MaHoa"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaHoa"]),
                            TenHoa = reader["TenHoa"] == DBNull.Value ? string.Empty : reader["TenHoa"].ToString(),
                            Gia = reader["Gia"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["Gia"]),
                            SoLuong = reader["SoLuong"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuong"]),
                            GhiChu = reader["GhiChu"] == DBNull.Value ? string.Empty : reader["GhiChu"].ToString()
                        });
                    }
                }
            }
            return listHoa;
        }

        public static bool Insert(Hoa hoa)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO hoa (TenHoa, Gia, SoLuong, GhiChu) 
                               VALUES (@TenHoa, @Gia, @SoLuong, @GhiChu)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenHoa", hoa.TenHoa ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Gia", hoa.Gia);
                    cmd.Parameters.AddWithValue("@SoLuong", hoa.SoLuong);
                    cmd.Parameters.AddWithValue("@GhiChu", hoa.GhiChu ?? string.Empty);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool Update(Hoa hoa)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE hoa 
                               SET TenHoa = @TenHoa, Gia = @Gia, SoLuong = @SoLuong, GhiChu = @GhiChu
                               WHERE MaHoa = @MaHoa";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHoa", hoa.MaHoa);
                    cmd.Parameters.AddWithValue("@TenHoa", hoa.TenHoa ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Gia", hoa.Gia);
                    cmd.Parameters.AddWithValue("@SoLuong", hoa.SoLuong);
                    cmd.Parameters.AddWithValue("@GhiChu", hoa.GhiChu ?? string.Empty);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool Delete(int maHoa)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM hoa WHERE MaHoa = @MaHoa";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHoa", maHoa);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<Hoa> Search(string keyword)
        {
            List<Hoa> listHoa = new List<Hoa>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT MaHoa, TenHoa, Gia, SoLuong, GhiChu 
                               FROM hoa 
                               WHERE TenHoa LIKE @Keyword OR GhiChu LIKE @Keyword OR MaHoa LIKE @Keyword 
                               ORDER BY MaHoa DESC";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listHoa.Add(new Hoa()
                            {
                                MaHoa = reader["MaHoa"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaHoa"]),
                                TenHoa = reader["TenHoa"] == DBNull.Value ? string.Empty : reader["TenHoa"].ToString(),
                                Gia = reader["Gia"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["Gia"]),
                                SoLuong = reader["SoLuong"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuong"]),
                                GhiChu = reader["GhiChu"] == DBNull.Value ? string.Empty : reader["GhiChu"].ToString()
                            });
                        }
                    }
                }
            }
            return listHoa;
        }
    }
}