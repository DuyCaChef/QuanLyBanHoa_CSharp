--------------------------------------------------
-- 1. TẠO DATABASE
--------------------------------------------------
CREATE DATABASE QuanLyBanHoa COLLATE Vietnamese_CI_AS;
GO

USE QuanLyBanHoa;
GO


--------------------------------------------------
-- 2. BẢNG HOA
--------------------------------------------------
CREATE TABLE Hoa (
    MaHoa INT IDENTITY(1,1) PRIMARY KEY,
    TenHoa NVARCHAR(100) NOT NULL,
    Gia DECIMAL(12,2) NOT NULL,
    SoLuong INT NOT NULL,
    MoTa NVARCHAR(MAX) NULL
);
GO


--------------------------------------------------
-- 3. BẢNG KHÁCH HÀNG
--------------------------------------------------
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TenKH NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(200) NULL,
    SoDienThoai VARCHAR(15) NULL,
    Email VARCHAR(100) NULL
);
GO


--------------------------------------------------
-- 4. BẢNG NHÂN VIÊN (THÔNG TIN)
--------------------------------------------------
CREATE TABLE NhanVien (
    MaNV INT IDENTITY(1,1) PRIMARY KEY,
    TenNV NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15) NULL
);
GO


--------------------------------------------------
-- 5. BẢNG USERS (ĐĂNG NHẬP + QUYỀN)
-- Admin KHÔNG thuộc NhanVien (MaNV NULL)
-- Nhân viên phải có MaNV (FK)
--------------------------------------------------
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    TaiKhoan NVARCHAR(50) UNIQUE NOT NULL,
    MatKhau NVARCHAR(100) NOT NULL,
    VaiTro NVARCHAR(20) NOT NULL DEFAULT 'NhanVien',   -- Admin / NhanVien
    MaNV INT NULL,
    CONSTRAINT FK_Users_NhanVien 
        FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV) ON DELETE CASCADE
);
GO


--------------------------------------------------
-- 6. BẢNG ĐƠN HÀNG (SNAPSHOT)
--------------------------------------------------
CREATE TABLE DonHang (
    MaDH INT IDENTITY(1,1) PRIMARY KEY,

    MaKH INT NULL,
    MaNV INT NULL,

    NgayDatHang DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    TongTien DECIMAL(12,2) NOT NULL,

    -- Snapshot khách hàng
    TenKH_DatHang NVARCHAR(100) NULL,
    DiaChi_DatHang NVARCHAR(200) NULL,
    SoDienThoai_DatHang VARCHAR(15) NULL,

    -- Snapshot nhân viên
    TenNV_BanHang NVARCHAR(100) NULL,

    CONSTRAINT FK_DonHang_KhachHang 
        FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH) ON DELETE SET NULL,

    CONSTRAINT FK_DonHang_NhanVien
        FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV) ON DELETE SET NULL
);
GO


--------------------------------------------------
-- 7. BẢNG CHI TIẾT ĐƠN HÀNG (SNAPSHOT)
--------------------------------------------------
CREATE TABLE ChiTietDonHang (
    MaDH INT NOT NULL,
    MaHoa INT NOT NULL,
    SoLuong INT NOT NULL,
    ThanhTien DECIMAL(12,2) NOT NULL,

    -- Snapshot
    TenHoa_DatHang NVARCHAR(100) NULL,
    DonGia DECIMAL(12,2) NULL,

    CONSTRAINT PK_ChiTietDonHang PRIMARY KEY (MaDH, MaHoa),

    CONSTRAINT FK_ChiTietDonHang_DH
        FOREIGN KEY (MaDH) REFERENCES DonHang(MaDH) ON DELETE CASCADE,

    CONSTRAINT FK_ChiTietDonHang_Hoa
        FOREIGN KEY (MaHoa) REFERENCES Hoa(MaHoa)
);
GO


--------------------------------------------------
-- 8. DỮ LIỆU MẪU
--------------------------------------------------

-- Nhân viên mẫu
INSERT INTO NhanVien (TenNV, SoDienThoai)
VALUES
(N'Nhân viên A', '0901111111'),
(N'Nhân viên B', '0902222222');
GO

-- Users mẫu: Admin + 2 nhân viên
INSERT INTO Users (TaiKhoan, MatKhau, VaiTro, MaNV)
VALUES
('admin', '123', 'Admin', NULL),  -- admin KHÔNG thuộc NhanVien!
('nv01', '123', 'NhanVien', 1),
('nv02', '123', 'NhanVien', 2);
GO
