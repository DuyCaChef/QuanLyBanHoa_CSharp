CREATE DATABASE QuanLyBanHoa;

-- Sử dụng database
USE QuanLyBanHoa;

-- Tạo bảng Hoa
CREATE TABLE Hoa (
    MaHoa INT IDENTITY(1,1) PRIMARY KEY,
    TenHoa NVARCHAR(100) NOT NULL,
    Gia DECIMAL(12,2) NOT NULL,
    SoLuong INT NOT NULL,
    MoTa NVARCHAR(MAX) 
);
-- Tạo bảng KhachHang
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TenKH NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(200),
    SoDienThoai VARCHAR(15) UNIQUE, -- Số điện thoại thường không cần Nvarchar
    Email VARCHAR(100) -- Email thường không cần Nvarchar
);
-- Tạo bảng NhanVien
CREATE TABLE NhanVien (
    MaNV INT IDENTITY(1,1) PRIMARY KEY,
    TenNV NVARCHAR(100) NOT NULL,
    ChucVu NVARCHAR(50),
    SoDienThoai VARCHAR(15) UNIQUE
);
-- Tạo bảng KhuyenMai
CREATE TABLE KhuyenMai (
    MaKM INT IDENTITY(1,1) PRIMARY KEY,
    TenCT NVARCHAR(100) NOT NULL,
    TyLeGiam DECIMAL(5,2) NOT NULL,
    NgayBD DATE NOT NULL,
    NgayKT DATE NOT NULL
);
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

ALTER TABLE ChiTietDonHang ADD MaNV INT NOT NULL;
ALTER TABLE ChiTietDonHang ADD CONSTRAINT FK_ChiTietDonHang_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV);

SELECT * FROM KhachHang
SELECT * FROM ChiTietDonHang
SELECT * FROM Hoa
SELECT * FROM NhanVien
SELECT * FROM KhuyenMai
SELECT * FROM DonHang



INSERT INTO NhanVien (TenNV, ChucVu, SoDienThoai) VALUES
(N'Nguyễn Văn An', N'Quản lý', '0901234561'),
(N'Trần Thị Bình', N'Thu ngân', '0901234562'),
(N'Lê Minh Cường', N'Nhân viên bán hàng', '0901234563'),
(N'Phạm Thị Dung', N'Nhân viên bán hàng', '0901234564'),
(N'Hoàng Văn Em', N'Nhân viên kho', '0901234565'),
(N'Đỗ Thị Giang', N'Nhân viên bán hàng', '0901234566'),
(N'Vũ Minh Hải', N'Quản lý kho', '0901234567'),
(N'Bùi Thị Kim', N'Kế toán', '0901234568'),
(N'Lý Văn Lộc', N'Nhân viên giao hàng', '0901234569'),
(N'Ngô Thị Mai', N'Nhân viên bán hàng', '0901234570');

INSERT INTO KhachHang (TenKH, DiaChi, SoDienThoai, Email) VALUES
(N'Trần Anh Tuấn', N'123 Nguyễn Trãi, Q1, TPHCM', '0987654321', 'tuan.tran@email.com'),
(N'Lê Thị Ngọc', N'456 Lê Lợi, Q3, TPHCM', '0987654322', 'ngoc.le@email.com'),
(N'Phạm Văn Hùng', N'789 Cách Mạng Tháng 8, Q10, TPHCM', '0987654323', 'hung.pham@email.com'),
(N'Nguyễn Thị Thu Hà', N'101 Võ Thị Sáu, Q3, TPHCM', '0987654324', 'ha.nguyen@email.com'),
(N'Đặng Minh Khôi', N'202 Trần Hưng Đạo, Q5, TPHCM', '0987654325', 'khoi.dang@email.com'),
(N'Võ Thị Lan Anh', N'303 Sư Vạn Hạnh, Q10, TPHCM', '0987654326', 'lananh.vo@email.com'),
(N'Hoàng Tuấn Kiệt', N'505 Nguyễn Văn Cừ, Q5, TPHCM', '0987654327', 'kiet.hoang@email.com'),
(N'Bùi Thanh Tâm', N'606 Lý Thường Kiệt, Q.Tân Bình, TPHCM', '0987654328', 'tam.bui@email.com'),
(N'Mai Anh Thư', N'707 An Dương Vương, Q5, TPHCM', '0987654329', 'thu.mai@email.com'),
(N'Lý Hùng Dũng', N'808 Điện Biên Phủ, Q.Bình Thạnh, TPHCM', '0987654330', 'dung.ly@email.com');


INSERT INTO Hoa (TenHoa, Gia, SoLuong, Mota) VALUES
(N'Hoa Hồng Đỏ Ecuador', 35000.00, 450, N'Loại hồng nhung cao cấp, cành dài 60cm, nhập khẩu.'),
(N'Hoa Baby Trắng', 180000.00, 25, N'Giá theo bó lớn (1kg), dùng để trang trí hoặc bó kèm.'),
(N'Hoa Tulip Vàng', 55000.00, 150, N'Tulip Hà Lan, tươi lâu, biểu tượng của sự may mắn.'),
(N'Lan Hồ Điệp Trắng', 450000.00, 20, N'Chậu 3 cành, loại A, dùng cho khai trương hoặc chúc mừng.'),
(N'Hoa Hướng Dương', 20000.00, 200, N'Hoa tươi nhập từ Đà Lạt, chất lượng A.'),
(N'Cây Phát Tài Búp Sen', 95000.00, 85, N'Cây phong thủy, hút tài lộc, thích hợp để bàn nhỏ.'),
(N'Hoa Tulip Trắng Nhỏ', 60000.00, 150, N'Thường dùng trong lễ cưới, biểu tượng tinh khiết.'),
(N'Bó Hoa Cúc Tana', 200000.00, 40, N'Phong cách Hàn Quốc, bó nhỏ, làm quà tặng.'),
(N'Hoa Ly Hồng', 135000.00, 55, N'Loại ly thơm, 5 tai/bó, nở to và bền.'),
(N'Xương Rồng Tai Thỏ', 55000.00, 110, N'Dễ chăm sóc, chậu nhỏ xinh, chịu hạn tốt.');

INSERT INTO KhuyenMai (TenCT, TyLeGiam, NgayBD, NgayKT) VALUES
(N'Chào mừng 20/10', 0.15, '2025-10-18', '2025-10-21'),
(N'Ngày Nhà Giáo 20/11', 0.20, '2025-11-15', '2025-11-20'),
(N'Black Friday Sale', 0.50, '2025-11-28', '2025-11-30'),
(N'Giáng Sinh An Lành', 0.10, '2025-12-20', '2025-12-25'),
(N'Chào Năm Mới 2026', 0.10, '2025-12-30', '2026-01-02'),
(N'Valentine 14/02', 0.25, '2026-02-12', '2026-02-15'),
(N'Quốc Tế Phụ Nữ 8/3', 0.20, '2026-03-05', '2026-03-09'),
(N'Lễ 30/4', 0.10, '2026-04-28', '2026-05-02'),
(N'Ngày của Mẹ', 0.15, '2026-05-08', '2026-05-10'),
(N'Hè Rực Rỡ (Hết hạn)', 0.30, '2025-06-01', '2025-06-15');

INSERT INTO DonHang (MaKH, MaNV, NgayDatHang, TongTien, MaKM) VALUES
(1, 3, '2025-10-19', 350000.00, 1), -- KH 1, NV 3, KM 20/10
(2, 4, '2025-10-20', 180000.00, NULL), -- KH 2, NV 4, Không KM
(3, 3, '2025-11-16', 710000.00, 2), -- KH 3, NV 3, KM 20/11
(4, 5, '2025-11-18', 400000.00, NULL), -- KH 4, NV 5, Không KM
(5, 6, '2025-11-28', 110000.00, 3), -- KH 5, NV 6, KM Black Friday
(6, 4, '2025-12-21', 1350000.00, 4), -- KH 6, NV 4, KM Giáng Sinh
(7, 3, '2025-12-22', 110000.00, 4), -- KH 7, NV 3, KM Giáng Sinh
(8, 6, '2026-01-01', 400000.00, 5), -- KH 8, NV 6, KM Năm Mới
(9, 5, '2026-02-13', 200000.00, 6), -- KH 9, NV 5, KM Valentine
(10, 4, '2026-03-06', 165000.00, 7); -- KH 10, NV 4, KM 8/3

INSERT INTO ChiTietDonHang (MaDH, MaHoa, SoLuong, ThanhTien, MaNV) VALUES
(1, 1, 10, 350000.00, 3),
(2, 2, 1, 180000.00, 4),
(3, 4, 1, 450000.00, 3),
(3, 5, 2, 40000.00, 3),
(3, 8, 1, 220000.00, 3), -- (Bó Cúc Tana, giá 200k + Hoa Hướng Dương 20k)
(4, 5, 20, 400000.00, 5),
(5, 10, 2, 110000.00, 6),
(6, 4, 3, 1350000.00, 4),
(7, 7, 2, 120000.00, 3), -- (Giá 60k, nhưng đã sửa thành 110k, cập nhật lại)
(8, 8, 2, 400000.00, 6),
(9, 8, 1, 200000.00, 5),
(10, 10, 3, 165000.00, 4);