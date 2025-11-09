using MySql.Data.MySqlClient;
using QuanLyBanHoa.Models;
using System.Collections.Generic;

namespace QuanLyBanHoa.Data
{
    public class HoaDAL
    {
        public List<Hoa> GetAllHoa()
        {
            var list = new List<Hoa>();
            using var conn = Database.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand("SELECT MaHoa, TenHoa, Gia, SoLuong, MoTa FROM Hoa ORDER BY MaHoa DESC", conn);
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(new Hoa
                {
                    MaHoa = rdr.GetInt32(0),
                    TenHoa = rdr.GetString(1),
                    Gia = rdr.GetDecimal(2),
                    SoLuong = rdr.GetInt32(3),
                    MoTa = rdr.IsDBNull(4) ? null : rdr.GetString(4)
                });
            }
            return list;
        }

        public bool InsertHoa(Hoa hoa)
        {
            using var conn = Database.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand("INSERT INTO Hoa (TenHoa, Gia, SoLuong, MoTa) VALUES (@TenHoa, @Gia, @SoLuong, @MoTa)", conn);
            cmd.Parameters.AddWithValue("@TenHoa", hoa.TenHoa);
            cmd.Parameters.AddWithValue("@Gia", hoa.Gia);
            cmd.Parameters.AddWithValue("@SoLuong", hoa.SoLuong);
            cmd.Parameters.AddWithValue("@MoTa", (object?)hoa.MoTa ?? DBNull.Value);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool DeleteHoa(int maHoa)
        {
            using var conn = Database.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand("DELETE FROM Hoa WHERE MaHoa = @MaHoa", conn);
            cmd.Parameters.AddWithValue("@MaHoa", maHoa);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool UpdateHoa(Hoa hoa)
        {
            using var conn = Database.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand("UPDATE Hoa SET TenHoa=@TenHoa, Gia=@Gia, SoLuong=@SoLuong, MoTa=@MoTa WHERE MaHoa=@MaHoa", conn);
            cmd.Parameters.AddWithValue("@TenHoa", hoa.TenHoa);
            cmd.Parameters.AddWithValue("@Gia", hoa.Gia);
            cmd.Parameters.AddWithValue("@SoLuong", hoa.SoLuong);
            cmd.Parameters.AddWithValue("@MoTa", (object?)hoa.MoTa ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@MaHoa", hoa.MaHoa);
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
