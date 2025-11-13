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
        
        // Thêm thuộc tính Vaitro
        public string Vaitro { get; set; }

        // Constructor không tham số
        public NhanVien() { }

        // Constructor đầy đủ tham số (tiện cho việc khởi tạo)
        public NhanVien(int maNV, string tenNV, string chucVu, string soDienThoai, int soLuongDonHang = 0, string vaitro = "NhanVien")
        {
            MaNV = maNV;
            TenNV = tenNV;
            ChucVu = chucVu;
            SoDienThoai = soDienThoai;
            SoLuongDonHang = soLuongDonHang;
            Vaitro = vaitro;
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
                                    nv.Vaitro,
                                    COUNT(ct.MaDH) AS SoLuongDonHang
                                FROM NhanVien nv
                                LEFT JOIN ChiTietDonHang ct ON nv.MaNV = ct.MaNV
                                WHERE nv.Vaitro = 'NhanVien'
                                GROUP BY nv.MaNV, nv.TenNV, nv.SoDienThoai, nv.ChucVu, nv.Vaitro
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
                            Vaitro = reader["Vaitro"].ToString(),
                            SoLuongDonHang = reader["SoLuongDonHang"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuongDonHang"])
                        });
                    }
                }
            }
            return listNhanVien;
        }

        /// <summary>
        /// Thêm nhân viên mới (chỉ insert vào bảng NhanVien, không insert Users)
        /// Trả về MaNV mới được tạo
        /// </summary>
        public static int Insert(NhanVien nhanVien, SqlConnection conn, SqlTransaction tran)
        {
      string query = @"INSERT INTO NhanVien (TenNV, SoDienThoai) 
           VALUES (@TenNV, @SoDienThoai);
     SELECT CAST(SCOPE_IDENTITY() AS INT);";
      
       using (var cmd = new SqlCommand(query, conn, tran))
 {
     cmd.Parameters.AddWithValue("@TenNV", nhanVien.TenNV);
         cmd.Parameters.AddWithValue("@SoDienThoai", nhanVien.SoDienThoai ?? (object)DBNull.Value);
           
        var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        /// <summary>
        /// Cập nhật nhân viên (chỉ update bảng NhanVien, không update Users)
    /// </summary>
    public static bool Update(NhanVien nhanVien, SqlConnection conn, SqlTransaction tran)
        {
      string query = @"UPDATE NhanVien 
             SET TenNV = @TenNV, SoDienThoai = @SoDienThoai 
       WHERE MaNV = @MaNV";
 
            using (var cmd = new SqlCommand(query, conn, tran))
  {
              cmd.Parameters.AddWithValue("@MaNV", nhanVien.MaNV);
     cmd.Parameters.AddWithValue("@TenNV", nhanVien.TenNV);
             cmd.Parameters.AddWithValue("@SoDienThoai", nhanVien.SoDienThoai ?? (object)DBNull.Value);
        return cmd.ExecuteNonQuery() > 0;
            }
     }

        /// <summary>
        /// Xóa nhân viên + reset IDENTITY (Users tự động xóa do CASCADE)
        /// </summary>
        public static bool DeleteAndResetIdentity(int maNV, SqlConnection conn, SqlTransaction tran)
        {
       // Xóa NhanVien (Users tự động xóa do CASCADE)
        string deleteQuery = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
            using (var cmd = new SqlCommand(deleteQuery, conn, tran))
   {
                cmd.Parameters.AddWithValue("@MaNV", maNV);
      int rows = cmd.ExecuteNonQuery();
             if (rows == 0) return false;
    }

    // Reset IDENTITY
         string resetIdentity = @"
IF EXISTS (SELECT 1 FROM NhanVien)
BEGIN
    DECLARE @maxID INT = (SELECT MAX(MaNV) FROM NhanVien);
    DBCC CHECKIDENT ('NhanVien', RESEED, @maxID);
END
ELSE
BEGIN
    DBCC CHECKIDENT ('NhanVien', RESEED, 0);
END";
            using (var resetCmd = new SqlCommand(resetIdentity, conn, tran))
 {
                resetCmd.ExecuteNonQuery();
            }

     return true;
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
nv.Vaitro,
       COUNT(ct.MaDH) AS SoLuongDonHang
        FROM NhanVien nv
            LEFT JOIN ChiTietDonHang ct ON nv.MaNV = ct.MaNV
         WHERE nv.Vaitro = 'NhanVien' AND (nv.TenNV LIKE @Keyword 
             OR nv.SoDienThoai LIKE @Keyword 
    OR nv.ChucVu LIKE @Keyword 
             OR CAST(nv.MaNV AS NVARCHAR) LIKE @Keyword)
        GROUP BY nv.MaNV, nv.TenNV, nv.SoDienThoai, nv.ChucVu, nv.Vaitro
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
     Vaitro = reader["Vaitro"].ToString(),
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
      nv.Vaitro,
      COUNT(ct.MaDH) AS SoLuongDonHang
        FROM NhanVien nv
         LEFT JOIN ChiTietDonHang ct ON nv.MaNV = ct.MaNV
          WHERE nv.MaNV = @MaNV
  GROUP BY nv.MaNV, nv.TenNV, nv.SoDienThoai, nv.ChucVu, nv.Vaitro";
 
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
 Vaitro = reader["Vaitro"].ToString(),
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
        string query = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";
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