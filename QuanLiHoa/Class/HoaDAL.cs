using MySql.Data.MySqlClient;
using QuanLyBanHoa;
using QuanLyBanHoa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyBanHoa_CSharp;
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
                        // Read available column names from reader schema
                        HashSet<string> cols = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                        DataTable schema = reader.GetSchemaTable();
                        if (schema != null)
                        {
                            foreach (DataRow row in schema.Rows)
                            {
                                cols.Add(row["ColumnName"].ToString());
                            }
                        }

                        while (reader.Read())
                        {
                            // Helper to get value by trying multiple possible column names
                            object GetValue(params string[] candidates)
                            {
                                foreach (var c in candidates)
                                {
                                    if (cols.Contains(c) && !reader.IsDBNull(reader.GetOrdinal(c)))
                                        return reader[c];
                                }
                                return null;
                            }

                            var hoa = new Hoa();

                            var vMa = GetValue("MaHoa", "ID", "Ma_Hoa");
                            if (vMa != null) hoa.MaHoa = Convert.ToInt32(vMa);

                            var vTen = GetValue("TenHoa", "Ten_Hoa", "Ten");
                            if (vTen != null) hoa.TenHoa = vTen.ToString();

                            var vGia = GetValue("GiaBan", "Gia", "Gia_ban", "Price");
                            if (vGia != null)
                            {
                                try { hoa.Gia = Convert.ToDecimal(vGia); } catch { hoa.Gia = 0; }
                            }

                            var vSoLuong = GetValue("SoLuong", "So_Luong", "Quantity", "SoLuongTon");
                            if (vSoLuong != null)
                            {
                                try { hoa.SoLuong = Convert.ToInt32(vSoLuong); } catch { hoa.SoLuong = 0; }
                            }

                            var vPhanLoai = GetValue("PhanLoai", "Loai", "Phan_Loai");
                            if (vPhanLoai != null) hoa.PhanLoai = vPhanLoai.ToString();

                            var vGhiChu = GetValue("GhiChu", "Ghi_Chu", "Ghichu", "Note");
                            if (vGhiChu != null) hoa.Ghichu = vGhiChu.ToString();

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
            // Use DB column name 'Gia' to match database schema
            string query = @"
        INSERT INTO Hoa (TenHoa, Gia, SoLuong, PhanLoai, GhiChu) 
        VALUES (@TenHoa, @Gia, @SoLuong, @PhanLoai, @GhiChu);";

            using (MySqlConnection connection = Database.GetConnection())
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                try
                {
                    command.Parameters.AddWithValue("@TenHoa", newHoa.TenHoa);
                    command.Parameters.AddWithValue("@Gia", newHoa.Gia);
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
            // Use DB column name 'Gia' in update as well
            string query = @"
        UPDATE Hoa SET 
        TenHoa = @TenHoa, Gia = @Gia, SoLuong = @SoLuong, 
        PhanLoai = @PhanLoai, GhiChu = @GhiChu 
        WHERE MaHoa = @MaHoa";

            using (MySqlConnection connection = Database.GetConnection())
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                try
                {
                    command.Parameters.AddWithValue("@TenHoa", editedHoa.TenHoa);
                    command.Parameters.AddWithValue("@Gia", editedHoa.Gia);
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