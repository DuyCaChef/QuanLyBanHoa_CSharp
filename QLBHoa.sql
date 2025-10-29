#tạo database QuanLyBanHoa
CREATE DATABASE QuanLyBanHoa CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

#sử dụng database
USE QuanLyBanHoa;

CREATE TABLE Hoa(	
	MaHoa int auto_increment primary key,
    TenHoa varchar(100) not null,
    Gia decimal(12,2) not null,
    SoLuong int not null,
    MoTa text
);
SELECT * FROM Hoa;

CREATE TABLE KhachHang(
	MaKH int auto_increment primary key,
    TenKH varchar(100) not null,
    DiaChi varchar(200),
    SoDienThoai varchar(15) unique,
    Email varchar(100)
);
SELECT * FROM KhachHang;

CREATE TABLE NhanVien(
	MaNV int auto_increment primary key,
    TenNV varchar(100) not null,
    ChucVu varchar(50),
    SoDienThoai varchar(15) unique
);
SElECT * FROM NhanVien;

CREATE TABLE KhuyenMai(
	MaKM int auto_increment primary key,
    TenCT varchar(100) not null,
    TyLeGiam decimal(5,2) not null,
    NgayBD date not null,
    NgayKT date not null
);
SELECT * FROM KhuyenMai;

CREATE TABLE DonHang(
	MaDH int auto_increment primary key,
    MaKH int not null,
    MaNV int not null,
    NgayDatHang date not null default (current_date),
    TongTien decimal(12,2) not null,
    MaKM int,
    foreign key (MaKH) references KhachHang(MaKH),
    foreign key (MaNV) references NhanVien(MaNV),
    foreign key (MaKM) references KhuyenMai(MaKM)
);
SELECT * FROM DonHang;

CREATE TABLE ChiTietDonHang(
	MaDH int not null,
    MaHoa int not null,
    SoLuong int not null,
    ThanhTien decimal(12,2) not null,
    primary key (MaDH, MaHoa),
    foreign key (MaDH) references DonHang(MaDH),
    foreign key (MaHoa) references Hoa(MaHoa)
);
SELECT * FROM ChiTietDonHang;

# Thêm MaNV vào ChiTietDonHang làm khoá ngoại của NhanVien(MaNV)
ALTER TABLE chitietdonhang add column MaNV int not null;
alter table chitietdonhang add foreign key (MaNV) references nhanvien(MaNV);






