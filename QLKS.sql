create database QLKS

use QLKS

drop database QLKS

CREATE TABLE LoaiKhachHang (
	MaLoaiKhachHang nvarchar(10) PRIMARY KEY,
	TenLoaiKhachHang nvarchar(50) NOT NULL
)

-- Tạo bảng KhachHang
CREATE TABLE KhachHang (
	MaKH nvarchar(10) PRIMARY KEY,
	HoKH nvarchar(50) NOT NULL,
	TenKH nvarchar(10) NOT NULL,
	GioiTinh bit DEFAULT(1),
	NgaySinh date,
	AnhKH nvarchar(50),
	DiaChi nvarchar(100) NOT NULL,
	MaLoaiKhachHang nvarchar(10) NOT NULL FOREIGN KEY REFERENCES LoaiKhachHang(MaLoaiKhachHang)
)

INSERT INTO LoaiKhachHang (MaLoaiKhachHang, TenLoaiKhachHang)
VALUES
    (N'LKH01', N'Công Nhân'),
    (N'LKH02', N'Giáo Viên'),
    (N'LKH03', N'Học Sinh');
    

-- Chèn dữ liệu vào bảng SINHVIEN
INSERT INTO KhachHang (MaKH, HoKH, TenKH, GioiTinh, NgaySinh, AnhKH, DiaChi, MaLoaiKhachHang)
VALUES
	('KH001', N'Nguyễn', N'Văn Anh', 1, '2000-01-05', 'avatar001.jpg', N'123 Đường ABC', 'LKH01'),
    ('KH002', N'Trần', N'Thị Bình', 0, '1999-03-10', 'avatar001.jpg', N'456 Đường XYZ', 'LKH02'),
    ('KH003', N'Lê', N'Hoàng Chi', 1, '2001-06-15', 'avatar001.jpg', N'789 Đường DEF', 'LKH02'),
    ('KH004', N'Phạm', N'Thị Dung', 0, '2002-08-20', 'avatar001.jpg', N'101 Đường LMN', 'LKH03'),
    ('KH005', N'Nguyễn', N'Minh Em', 1, '1998-12-25', 'avatar001.jpg', N'222 Đường PQR', 'LKH01'),
    ('KH006', N'Trần', N'Thị Fhun', 0, '2003-04-30', 'avatar001.jpg', N'333 Đường GHI', 'LKH02'),
    ('KH007', N'Lê', N'Văn Gang', 1, '2004-10-02', 'avatar001.jpg', N'444 Đường UVW', 'LKH01'),
    ('KH008', N'Vũ', N'Thị Hinh', 0, '2002-09-18', 'avatar001.jpg', N'555 Đường KLM', 'LKH03'),
    ('KH009', N'Trầm', N'Quang Vinh', 1, '2000-07-12', 'avatar001.jpg', N'666 Đường STU', 'LKH03'),
    ('KH010', N'Nguyễn', N'Minh Long', 1, '2001-05-07', 'avatar001.jpg', N'777 Đường NOP','LKH03'),
    ('KH011', N'Lê', N'Thị KHánh', 0, '1999-02-14', 'avatar001.jpg', N'888 Đường VWX', 'LKH02'),
    ('KH012', N'Phạm', N'Hoàng Lịch', 1, '2003-03-25', 'avatar001.jpg', N'999 Đường YZA', 'LKH01');