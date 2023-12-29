﻿USE master
GO
IF  EXISTS (SELECT name FROM sys.databases 
			WHERE name = 'QLBanHang' )
DROP DATABASE QLBanHang 
GO
CREATE DATABASE QLBanHang 
GO
USE QLBanHang
GO
CREATE TABLE LoaiSP
( MaLoai char(3) PRIMARY KEY,
  TenLoai nvarchar(50))
GO
INSERT INTO LoaiSP VALUES('L01',N'Điện dân dụng')
INSERT INTO LoaiSP VALUES('L02',N'Điện lạnh')
INSERT INTO LoaiSP VALUES('L03',N'Điện tử')
INSERT INTO LoaiSP VALUES('L04',N'Máy tính')
GO
CREATE TABLE SanPham
( MaSP char(4) PRIMARY KEY,
  TenSP nvarchar(50),
  DonGia int,
  SoLuongCo int,
  MaLoai char(3) REFERENCES LoaiSP(MaLoai) 
)
GO
INSERT INTO SanPham
VALUES('SP01',N'Ti vi',1000,10,'L03')
INSERT INTO SanPham
VALUES('SP02',N'Robot hút bụi',2000,20,'L01')
INSERT INTO SanPham
VALUES('SP03',N'Tủ lạnh',3000,30,'L02')
INSERT INTO SanPham
VALUES('SP04',N'Điều hòa',4000,40,'L02')
GO

CREATE TABLE ChiTietHoaDon
( MaHD char(4),
  MaSP char(4),
  SoLuongMua int,
  PRIMARY KEY(MaHD, MaSP),
  FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
)
GO
INSERT INTO ChiTietHoaDon
VALUES('HD01','SP01',1)
INSERT INTO ChiTietHoaDon
VALUES('HD01','SP02',2)
INSERT INTO ChiTietHoaDon
VALUES('HD02','SP03',3)
INSERT INTO ChiTietHoaDon
VALUES('HD02','SP04',4)
INSERT INTO ChiTietHoaDon
VALUES('HD03','SP01',5)

GO
SELECT * FROM SanPham
SELECT * FROM LoaiSP
SELECT * FROM ChiTietHoaDon

