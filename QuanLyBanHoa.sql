-- Tạo database QuanLyBanHoa
-- Lưu ý: SQL Server thường quản lý collation ở cấp server hoặc database.
-- Dòng dưới tạo DB với collation hỗ trợ tiếng Việt không phân biệt hoa thường, có phân biệt dấu.
CREATE DATABASE QuanLyBanHoa COLLATE Vietnamese_CI_AS;
GO

-- Sử dụng database
USE QuanLyBanHoa;
GO

-- Tạo bảng Hoa
CREATE TABLE Hoa (
    MaHoa INT IDENTITY(1,1) PRIMARY KEY,
    TenHoa NVARCHAR(100) NOT NULL,
    Gia DECIMAL(12,2) NOT NULL,
    SoLuong INT NOT NULL,
    MoTa NVARCHAR(MAX) -- Thay TEXT bằng NVARCHAR(MAX) cho Unicode tốt hơn
);
GO
-- SELECT * FROM Hoa; -- Không cần thiết chạy ngay khi tạo script

-- Tạo bảng KhachHang
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TenKH NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(200),
    SoDienThoai VARCHAR(15) UNIQUE, -- Số điện thoại thường không cần Nvarchar
    Email VARCHAR(100) -- Email thường không cần Nvarchar
);
GO

-- Tạo bảng NhanVien
CREATE TABLE NhanVien (
    MaNV INT IDENTITY(1,1) PRIMARY KEY,
    TenNV NVARCHAR(100) NOT NULL,
    ChucVu NVARCHAR(50),
    SoDienThoai VARCHAR(15) UNIQUE
);
GO

-- Tạo bảng KhuyenMai
CREATE TABLE KhuyenMai (
    MaKM INT IDENTITY(1,1) PRIMARY KEY,
    TenCT NVARCHAR(100) NOT NULL,
    TyLeGiam DECIMAL(5,2) NOT NULL,
    NgayBD DATE NOT NULL,
    NgayKT DATE NOT NULL
);
GO

-- Tạo bảng DonHang
CREATE TABLE DonHang (
    MaDH INT IDENTITY(1,1) PRIMARY KEY,
    MaKH INT NOT NULL,
    MaNV INT NOT NULL,
    NgayDatHang DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE), -- Sử dụng GETDATE() và ép kiểu về DATE
    TongTien DECIMAL(12,2) NOT NULL,
    MaKM INT,
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    FOREIGN KEY (MaKM) REFERENCES KhuyenMai(MaKM)
);
GO

-- Tạo bảng ChiTietDonHang
CREATE TABLE ChiTietDonHang (
    MaDH INT NOT NULL,
    MaHoa INT NOT NULL,
    SoLuong INT NOT NULL,
    ThanhTien DECIMAL(12,2) NOT NULL,
    PRIMARY KEY (MaDH, MaHoa),
    FOREIGN KEY (MaDH) REFERENCES DonHang(MaDH),
    FOREIGN KEY (MaHoa) REFERENCES Hoa(MaHoa)
);
GO

-- Thêm cột MaNV vào ChiTietDonHang và tạo khoá ngoại
-- Lưu ý: Nếu bảng đã có dữ liệu, việc thêm cột NOT NULL mà không có DEFAULT sẽ gây lỗi.
-- Ở đây giả sử bảng mới tạo chưa có dữ liệu.
ALTER TABLE ChiTietDonHang ADD MaNV INT NOT NULL;
GO
ALTER TABLE ChiTietDonHang ADD CONSTRAINT FK_ChiTietDonHang_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV);
GO

--Thêm các thuộc tính cho bảng DonHang và ChiTietDonHang để sử dụng biến tạm
ALTER TABLE DonHang
ADD TenKH_DatHang NVARCHAR(100) NULL,
    DiaChi_DatHang NVARCHAR(200),
    SoDienThoai_DatHang VARCHAR(15),
    TenNV_BanHang NVARCHAR(100);
GO

ALTER TABLE ChiTietDonHang
ADD TenHoa_DatHang NVARCHAR(100) NULL,
    DonGia DECIMAL(12,2) NULL;
GO
--thêm thuộc tính cho nhân viên để quản lý và phân quyền
ALTER TABLE NhanVien
ADD 
    TaiKhoan NVARCHAR(50) UNIQUE NOT NULL,
    MatKhau NVARCHAR(100) NOT NULL,
    Vaitro NVARCHAR(20) NOT NULL DEFAULT 'NhanVien';
GO

INSERT INTO NhanVien (TenNV, ChucVu, SoDienThoai, TaiKhoan, MatKhau, Vaitro)
VALUES 
(N'Quản trị hệ thống', N'Admin', '0123456789', 'admin', '123', 'Admin'),
(N'Nhân viên bán hàng', N'Nhân viên', ' 0873858388', 'nv01', '123', 'NhanVien');
GO