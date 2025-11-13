using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanHoa.Data;

namespace QuanLyBanHoa.Models
{
    /// <summary>
    /// Class qu?n lý thông tin Users trong h? th?ng
    /// </summary>
  public class User
    {
        // Properties
        public int UserID { get; set; }
  public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; } // 'Admin' ho?c 'NhanVien'
        public int? MaNV { get; set; } // NULL cho Admin

    // Constructor
        public User() { }

        public User(int userID, string taiKhoan, string matKhau, string vaiTro, int? maNV)
        {
   UserID = userID;
            TaiKhoan = taiKhoan;
      MatKhau = matKhau;
        VaiTro = vaiTro;
        MaNV = maNV;
 }

      /// <summary>
   /// ??ng nh?p - Ki?m tra tài kho?n và m?t kh?u
        /// </summary>
        public static User Login(string taiKhoan, string matKhau)
        {
   using (var conn = Database.GetConnection())
{
         conn.Open();
     string query = "SELECT UserID, TaiKhoan, MatKhau, VaiTro, MaNV FROM Users WHERE TaiKhoan = @tk AND MatKhau = @mk";
                using (var cmd = new SqlCommand(query, conn))
      {
          cmd.Parameters.AddWithValue("@tk", taiKhoan);
         cmd.Parameters.AddWithValue("@mk", matKhau);
    
      using (var reader = cmd.ExecuteReader())
     {
              if (reader.Read())
     {
               return new User
       {
      UserID = reader["UserID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["UserID"]),
         TaiKhoan = reader["TaiKhoan"] == DBNull.Value ? string.Empty : reader["TaiKhoan"].ToString(),
    VaiTro = reader["VaiTro"] == DBNull.Value ? string.Empty : reader["VaiTro"].ToString(),
  MaNV = reader["MaNV"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["MaNV"])
            };
        }
            }
      }
   }
  return null;
        }

      /// <summary>
/// L?y t?t c? users kèm thông tin nhân viên
        /// </summary>
        public static DataTable GetAllWithNhanVien()
        {
          using (var conn = Database.GetConnection())
        {
       string query = @"SELECT nv.MaNV, nv.TenNV, nv.SoDienThoai, u.TaiKhoan, u.MatKhau, u.VaiTro
  FROM NhanVien nv
              LEFT JOIN Users u ON nv.MaNV = u.MaNV
                ORDER BY nv.MaNV DESC";
  
      using (var da = new SqlDataAdapter(query, conn))
                {
      var dt = new DataTable();
           da.Fill(dt);
 return dt;
     }
     }
        }

   /// <summary>
   /// Thêm user m?i
 /// </summary>
     public static bool Insert(User user, SqlConnection conn, SqlTransaction tran)
        {
       string query = @"INSERT INTO Users (TaiKhoan, MatKhau, VaiTro, MaNV) 
      VALUES (@TK, @MK, @Role, @MaNV)";
     using (var cmd = new SqlCommand(query, conn, tran))
         {
              cmd.Parameters.AddWithValue("@TK", user.TaiKhoan);
                cmd.Parameters.AddWithValue("@MK", user.MatKhau);
      cmd.Parameters.AddWithValue("@Role", user.VaiTro);
  cmd.Parameters.AddWithValue("@MaNV", user.MaNV.HasValue ? (object)user.MaNV.Value : DBNull.Value);
 return cmd.ExecuteNonQuery() > 0;
    }
        }

   /// <summary>
        /// C?p nh?t user
        /// </summary>
        public static bool Update(User user, SqlConnection conn, SqlTransaction tran)
        {
        string query = @"UPDATE Users SET TaiKhoan = @TK, MatKhau = @MK, VaiTro = @Role 
        WHERE MaNV = @MaNV";
            using (var cmd = new SqlCommand(query, conn, tran))
            {
          cmd.Parameters.AddWithValue("@TK", user.TaiKhoan);
       cmd.Parameters.AddWithValue("@MK", user.MatKhau);
    cmd.Parameters.AddWithValue("@Role", user.VaiTro);
      cmd.Parameters.AddWithValue("@MaNV", user.MaNV);
       return cmd.ExecuteNonQuery() > 0;
            }
  }

        /// <summary>
        /// L?y vai trò hi?n t?i c?a user theo MaNV
        /// </summary>
        public static string GetVaiTroByMaNV(int maNV, SqlConnection conn, SqlTransaction tran)
     {
     string query = "SELECT VaiTro FROM Users WHERE MaNV = @MaNV";
            using (var cmd = new SqlCommand(query, conn, tran))
 {
       cmd.Parameters.AddWithValue("@MaNV", maNV);
                var result = cmd.ExecuteScalar();
    return result == null || result == DBNull.Value ? null : result.ToString();
            }
   }

        /// <summary>
        /// Ki?m tra user ?ã t?n t?i cho MaNV ch?a
        /// </summary>
      public static bool ExistsByMaNV(int maNV, SqlConnection conn, SqlTransaction tran)
      {
   string query = "SELECT COUNT(1) FROM Users WHERE MaNV = @MaNV";
          using (var cmd = new SqlCommand(query, conn, tran))
     {
        cmd.Parameters.AddWithValue("@MaNV", maNV);
         int count = Convert.ToInt32(cmd.ExecuteScalar());
   return count > 0;
 }
        }

     /// <summary>
 /// Tìm ki?m users kèm thông tin nhân viên
      /// </summary>
 public static DataTable SearchWithNhanVien(string keyword, int? maNVFilter)
        {
      using (var conn = Database.GetConnection())
            {
         string query = @"SELECT nv.MaNV, nv.TenNV, nv.SoDienThoai, u.TaiKhoan, u.MatKhau, u.VaiTro
              FROM NhanVien nv LEFT JOIN Users u ON nv.MaNV = u.MaNV
WHERE (nv.TenNV LIKE @kw OR nv.SoDienThoai LIKE @kw OR u.TaiKhoan LIKE @kw OR u.VaiTro LIKE @kw)";
     
    if (maNVFilter.HasValue)
     {
         query += " AND nv.MaNV = @id";
                }
           
  query += " ORDER BY nv.MaNV DESC";
 
                using (var cmd = new SqlCommand(query, conn))
 {
       cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
             if (maNVFilter.HasValue)
         {
 cmd.Parameters.AddWithValue("@id", maNVFilter.Value);
   }
    
        using (var da = new SqlDataAdapter(cmd))
{
       var dt = new DataTable();
   da.Fill(dt);
          return dt;
    }
                }
            }
      }

   /// <summary>
        /// L?y danh sách nhân viên có VaiTro = 'NhanVien' (cho ComboBox ??n hàng)
        /// </summary>
        public static List<(int MaNV, string TenNV)> GetNhanVienOnly()
     {
  var list = new List<(int, string)>();
         using (var conn = Database.GetConnection())
            {
        conn.Open();
                string query = @"SELECT nv.MaNV, nv.TenNV
   FROM Users u 
            JOIN NhanVien nv ON nv.MaNV = u.MaNV
   WHERE u.VaiTro = 'NhanVien'
  ORDER BY nv.TenNV";
       
     using (var cmd = new SqlCommand(query, conn))
        using (var reader = cmd.ExecuteReader())
         {
    while (reader.Read())
   {
  int maNV = reader.GetInt32(0);
          string tenNV = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
         list.Add((maNV, tenNV));
 }
    }
    }
            return list;
 }
    }
}
