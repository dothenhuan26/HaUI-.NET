USE master
GO
-- Drop the database if it already exists
IF  EXISTS (SELECT name FROM sys.databases WHERE name = 'QLNhanSu')
	DROP DATABASE QLNhanSu
GO
CREATE DATABASE QLNhanSu
GO
USE QLNhanSu
GO
CREATE TABLE PhongBan
(MaPB char(4) PRIMARY KEY,
 TenPB nvarchar(30),
 NgayThanhLap Date)
GO
INSERT INTO PhongBan
VALUES('PB01',N'Tổ chức','2000-12-15')
INSERT INTO PhongBan
VALUES('PB02',N'Tài chính','2000-12-15')
INSERT INTO PhongBan
VALUES('PB03',N'Vật tư','2008-12-1')
INSERT INTO PhongBan
VALUES('PB04',N'An ninh','2020-12-30')
GO
CREATE TABLE NhanVien
(MaNV char(5) PRIMARY KEY,
 HoTen nvarchar(30),
 NgaySinh DateTime,
 Gioitinh nvarchar(3),
 NgoaiNgu nvarchar(20),
 MaPB char(4) REFERENCES PhongBan(MaPB)
 )
 GO
 INSERT INTO NhanVien
 VALUES('NV01',N'Trần Văn Phúc','2000-12-31',N'Nam','Anh, Pháp','PB01')


