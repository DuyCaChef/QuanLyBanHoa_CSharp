using MySql.Data.MySqlClient;
using QuanLyBanHoa;
using QuanLyBanHoa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHoa.Class
{
    internal class HoaDAL
    {
        public List<Hoa> GetAllHoa()
        {
            List<Hoa> listHoa = new List<Hoa>();
            string query = "SELECT * FROM Hoa";

            try
            {
                using (MySqlConnection connection = Database.GetConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Hoa hoa = new Hoa
                            {
                                MaHoa = Convert.ToInt32(reader["MaHoa"]),
                                TenHoa = reader["TenHoa"].ToString(),
                                GiaBan = Convert.ToDecimal(reader["GiaBan"]),
                                SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                PhanLoai = reader["PhanLoai"].ToString(),
                                Ghichu = reader["GhiChu"].ToString()
                            };
                            listHoa.Add(hoa);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi Database");
                return null;
            }
            return listHoa;
        }
        public bool InsertHoa(Hoa newHoa)
        {
            string query = @"
        INSERT INTO Hoa (TenHoa, GiaBan, SoLuong, PhanLoai, GhiChu) 
        VALUES (@TenHoa, @Gia, @SoLuong, @PhanLoai, @GhiChu);";

            using (MySqlConnection connection = Database.GetConnection())
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                try
                {
                    command.Parameters.AddWithValue("@TenHoa", newHoa.TenHoa);
                    command.Parameters.AddWithValue("@Gia", newHoa.GiaBan);
                    command.Parameters.AddWithValue("@SoLuong", newHoa.SoLuong);
                    command.Parameters.AddWithValue("@PhanLoai", newHoa.PhanLoai);
                    command.Parameters.AddWithValue("@GhiChu", newHoa.Ghichu);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Lỗi SQL khi thêm hoa: " + ex.Message, "Lỗi Database");
                    return false;
                }
            }
        }
        public bool UpdateHoa(Hoa editedHoa)
        {
            string query = @"
        UPDATE Hoa SET 
        TenHoa = @TenHoa, GiaBan = @Gia, SoLuong = @SoLuong, 
        PhanLoai = @PhanLoai, GhiChu = @GhiChu 
        WHERE MaHoa = @MaHoa";

            using (MySqlConnection connection = Database.GetConnection())
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                try
                {
                    command.Parameters.AddWithValue("@TenHoa", editedHoa.TenHoa);
                    command.Parameters.AddWithValue("@Gia", editedHoa.GiaBan);
                    command.Parameters.AddWithValue("@SoLuong", editedHoa.SoLuong);
                    command.Parameters.AddWithValue("@PhanLoai", editedHoa.PhanLoai);
                    command.Parameters.AddWithValue("@GhiChu", editedHoa.Ghichu);
                    command.Parameters.AddWithValue("@MaHoa", editedHoa.MaHoa); 

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Lỗi SQL khi cập nhật: " + ex.Message, "Lỗi Database");
                    return false;
                }
            }
        }
        public bool DeleteHoa(int maHoa)
        {
            string query = "DELETE FROM Hoa WHERE MaHoa = @MaHoa";

            using (MySqlConnection connection = Database.GetConnection())
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                try
                {
                    command.Parameters.AddWithValue("@MaHoa", maHoa);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Lỗi SQL: Không thể xóa vì ràng buộc dữ liệu. Chi tiết: " + ex.Message, "Lỗi Database");
                    return false;
                }
            }
        }
    }
}