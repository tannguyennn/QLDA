DROP DATABASE QLKS_QLDA
create database QLKS_QLDA
go
use QLKS_QLDA

CREATE TABLE NHANVIEN (
    MaNV VARCHAR(10) PRIMARY KEY,
    HoNV NVARCHAR(50) NOT NULL,
    TenNV NVARCHAR(50) NOT NULL,
    NgaySinh DATE NOT NULL,
    DiaChi NVARCHAR(255) NOT NULL,
    SDT VARCHAR(15) NOT NULL,
    ChucVu NVARCHAR(50) NOT NULL,
	MatKhau VARCHAR(20) NOT NULL,
);

CREATE TABLE KHACHHANG (
	MaKH VARCHAR(10) PRIMARY KEY,
	HoKH NVARCHAR(50) NOT NULL,
	TenKH NVARCHAR(50) NOT NULL,
	CMND VARCHAR(20) NOT NULL,
	Sdt VARCHAR(20) NOT NULL,
)

CREATE TABLE LOAIPHONG (
	MaLoaiPhong VARCHAR(10) PRIMARY KEY,
	LoaiPhong NVARCHAR(50) NOT NULL,
	Gia INT NOT NULL,
	Anh NVARCHAR(50) NOT NULL,
)

CREATE TABLE TANG (
	MaTang VARCHAR(10) PRIMARY KEY,
	Tang INT,
	TinhTrangPhong BIT NOT NULL,
	Anh NVARCHAR(50) NOT NULL,
)

CREATE TABLE PHONG (
	MaPhong VARCHAR(10) PRIMARY KEY,
	MaLoaiPhong VARCHAR(10) NOT NULL FOREIGN KEY REFERENCES LOAIPHONG(MaLoaiPhong),
	MaTang VARCHAR(10) NOT NULL FOREIGN KEY REFERENCES TANG(MaTang),
)

CREATE TABLE DICHVU (
	MaDV VARCHAR(10) PRIMARY KEY,
	TenDV NVARCHAR(50) NOT NULL,
	Gia INT NOT NULL,
	TonKho INT NOT NULL,
	DonVi NVARCHAR(50) NOT NULL,
	Anh NVARCHAR(50) NOT NULL,
)

CREATE TABLE PHIEUDAT (
	MaNV VARCHAR(10) FOREIGN KEY REFERENCES NHANVIEN(MaNV),
    MaKH VARCHAR(10) FOREIGN KEY REFERENCES KHACHHANG(MaKH),
    NgayDat DATE NOT NULL,
    NgayVao DATE NOT NULL,
    NgayRa DATE NOT NULL,
    MaPhong VARCHAR(10) NOT NULL FOREIGN KEY REFERENCES PHONG(MaPhong),
    TinhTrang BIT NOT NULL,
	PRIMARY KEY(MaNV,MaKH,MaPhong),
);

GO
CREATE TABLE QuanTri (
	Email varchar(50) PRIMARY KEY,
	Admin bit,
	HoTen nvarchar(50),
	Password nvarchar(50)
)

GO 
INSERT INTO NHANVIEN VALUES
('NV001', N'Nguyễn', N'Văn A', '1990-01-01', N'123 ABC Street', '123456789', 'Manager', '123'),
('NV002', N'Nguyễn', N'Vân B', '1990-01-01', N'123 ABC Street', '123456789', 'Manager', '123'),
('NV003', N'Trần', N'Thị C', '1995-05-15', N'456 XYZ Street', '987654321', 'Employee', '456'),
('NV004', N'Lê', N'Tuấn D', '1988-07-20', N'789 DEF Street', '555666777', 'Supervisor', '789'),
('NV005', N'Phạm', N'Thị E', '1993-12-10', N'321 GHI Street', '444333222', 'Employee', '321');
GO
INSERT INTO KHACHHANG VALUES
('KH001', N'Nguyễn', N'Thị A', '123456789', '0901234567'),
('KH002', N'Trần', N'Văn B', '987654321', '0912345678'),
('KH003', N'Lê', N'Thị C', '456789012', '0923456789'),
('KH004', N'Phạm', N'Văn D', '654321098', '0934567890'),
('KH005', N'Huỳnh', N'Thị E', '789012345', '0945678901');
GO
INSERT INTO LOAIPHONG VALUES
('LP001', N'Phòng Đơn', 1000000, N'phongdon.jpg'),
('LP002', N'Phòng Đôi', 1500000, N'phongdoi.jpg'),
('LP003', N'Phòng Gia Đình', 2000000, N'phonggiadinh.jpg'),
('LP004', N'Suite', 2500000, N'suite.jpg'),
('LP005', N'Phòng Executive', 3000000, N'phongexecutive.jpg');
GO
INSERT INTO TANG VALUES
('T001', 1, 1, N'tang1.jpg'),
('T002', 2, 1, N'tang2.jpg'),
('T003', 3, 0, N'tang3.jpg'),
('T004', 4, 1, N'tang4.jpg'),
('T005', 5, 0, N'tang5.jpg');
GO
INSERT INTO PHONG VALUES
('P001', 'LP001', 'T001'),
('P002', 'LP002', 'T002'),
('P003', 'LP003', 'T003'),
('P004', 'LP004', 'T004'),
('P005', 'LP005', 'T005');
GO
INSERT INTO DICHVU VALUES
('DV001', N'Điểm tâm', 500000, 20, N'Cái', N'dichvu1.jpg'),
('DV002', N'Coca cola', 700000, 15, N'Cái', N'dichvu2.jpg'),
('DV003', N'7 Up', 1000000, 10, N'Cái', N'dichvu3.jpg'),
('DV004', N'Thức ăn nhanh', 800000, 25, N'Cái', N'dichvu4.jpg'),
('DV005', N'Ăn tối', 1200000, 18, N'Phần', N'dichvu5.jpg');
GO
INSERT INTO PHIEUDAT VALUES
('NV001', 'KH001', '2023-01-15', '2023-01-20', '2023-01-25', 'P001', 1),
('NV002', 'KH002', '2023-02-10', '2023-02-15', '2023-02-20', 'P002', 1),
('NV003', 'KH003', '2023-03-05', '2023-03-10', '2023-03-15', 'P003', 0),
('NV004', 'KH004', '2023-04-20', '2023-04-25', '2023-04-30', 'P004', 1),
('NV005', 'KH005', '2023-05-15', '2023-05-20', '2023-05-25', 'P005', 0);
GO 
INSERT INTO QuanTri VALUES
('miinhtri1310@gmail.com',1,N'Admin','123')