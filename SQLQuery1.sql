create Database QuanLyKhachSan -- Tạo CSDL QuanLyKhachSan
use QuanLyKhachSan  
go
create table TaiKhoan (
	TenDN nvarchar(10) not null,
	MatKhau nvarchar(15) not null,
	constraint pk_TenDN primary key (TenDN)
)-- Tạo bảng Tài khoản để đăng nhập hệ thống
INSERT INTO TaiKhoan (TenDN, MatKhau) values ('admin', '123') --Thêm tài khoản admin và mật khẩu
create table NhanVien 
(
	MaNV nvarchar(30) not null,
    TenNV nvarchar(30) not null,
    SĐT varchar(30) not null,
	DiaChi nvarchar(30) not null,
	constraint pk_MaNV primary key (MaNV))-- Tạo bảng nhân viên
INSERT INTO NhanVien (MaNV, TenNV, SĐT, DiaChi)
VALUES 
('NV01', N'Nguyễn Mai Hồng', '079376',N'TP.HCM'),
('NV02', N'Trần Lâm An', '098765', N'Hà Nội'),
('NV03', N'Nguyễn Bình', '012345', N'Đà Nẵng'),
('NV04', N'Lê Nguyệt Mỹ', '033333', N'Hải Phòng'),
('NV05', N'Phạm Thị Hà', '055555', N'Cần Thơ'),
('NV06', N'Nguyễn Văn Linh', '077777', N'Huế'),
('NV07', N'Trần Thị Thanh', '099999', N'Nha Trang'),
('NV08', N'Lê Minh Tâm', '088888', N'Đà Lạt'),
('NV09', N'Hoàng Văn Hùng', '011111', N'Vũng Tàu'),
('NV10', N'Nguyễn Thị Thúy', '022222', N'An Giang')
-- Tạp procedure lấy thông tin của nhân viên
create proc sp_GetAllNhanVien
as
select * from NhanVien
-- Tạo proc thêm nhân viên
create proc sp_InsertNhanVien
@MaNV nvarchar(30),
@TenNV nvarchar(30),
@SĐT varchar(30),
@DiaChi nvarchar(30)
as insert into NhanVien(MaNV, TenNV, SĐT, DiaChi) values(@MaNV, @TenNV, @SĐT, @DiaChi)
-- Tạo proc sưa nhân viên
create proc sp_UpdateNhanVien
@MaNV nvarchar(30),
@TenNV nvarchar(30),
@SĐT varchar(30),
@DiaChi nvarchar(30)
as Update NhanVien set MaNV = @MaNV, TenNV = @TenNV, SĐT = @SĐT, DiaChi = @DiaChi where MaNV = @MaNV
-- Tạo proc xoa nhân viên
create proc sp_DeleteNhanVien
@MaNV nvarchar(30)
as
Delete from NhanVien
where MaNV = @MaNV
-- Tạo proc tìm nhân viên theo mã nhân viên
create proc sp_TimMaNV
@MaNV nvarchar(30)
as begin select * from NhanVien where NhanVien.MaNV = @MaNV end 
---- Tạo proc tìm nhân viên theo tên nhân viên
create proc sp_TimTenNV
@TenNV nvarchar(30)
as
begin select * from NhanVien where NhanVien.TenNV = @TenNV
end 
go
-----THAO TAC KHÁCH HÀNG----
create table KhachHang -- Tạo bảng khách hàng
(MaKH varchar(50) not null,
TenKH nvarchar(50) not null,
CCCD nvarchar(20) not null,
DiaChi nvarchar(50) not null,
Sdt nvarchar(20) not null,
constraint pk_MaKH primary key (MaKH))

insert into KhachHang(MaKH, TenKH, CCCD, DiaChi, Sdt)
values
('KH01', N'Trần Thúy Kiều', '0701456', N'TPHCM', '12345'),
('KH02', N'Nguyễn Hoài An', '0794556', N'Lâm Đồng', '12456'),
('KH03', N'Võ Yến Nhi', '07456168', N'Đồng Nai', '0489779'),
('KH04', N'Trần Hoài My', '07936455', N'Long An', '0112545'),
('KH05', N'Chu Gia Kiệt', '07914556', N'TPHCM', '0414898'),
('KH06', N'Nguyễn Kiều Loan', '07925885', N'Cần Thơ', '0169844'),
('KH07', N'Trần Quốc Huy', '07945236', N'Đà Nẵng', '0167895'),
('KH08', N'Bùi Quỳnh Diệp', '0136889', N'TPHCM', '0135895'),
('KH09', N'Tô Hoài Nam', '0488566', N'Bình Dương', '0168165'),
('KH10', N'Trần Phương Trang', '0795496', N'Nha Trang', '0189559')
-- Tạo procedure lấy thông tin khách hàng
create proc sp_GetAllKhachHang 
as select * from KhachHang
-- Tạo proc thêm KHACH HANG
create proc sp_InsertKhachHang 
@MaKH varchar(50),
@TenKH nvarchar(50),
@CCCD nvarchar(20),
@DiaChi nvarchar(50),
@Sdt nvarchar(20) 
as insert into KhachHang(MaKH, TenKH, CCCD, DiaChi, Sdt) values(@MaKH, @TenKH, @CCCD, @DiaChi,  @Sdt)
-- Tạo proc sưa KHACH HANG
create proc sp_UpdateKhachHang 
@MaKH varchar(50),
@TenKH nvarchar(50),
@CCCD nvarchar(20),
@DiaChi nvarchar(50),
@Sdt nvarchar(20) 
as Update KhachHang set MaKH = @MaKH, TenKH = @TenKH, CCCD = @CCCD, DiaChi = @DiaChi, Sdt= @Sdt where MaKH= @MaKH
-- Tạo proc xoa KHACH HANG
create proc sp_DeleteKhachHang
@MaKH varchar(50)
as Delete from KhachHang where MaKH = @MaKH
-- Tạo proc tìm khach hang theo mã KH
create proc sp_TimMaKH 
@MaKH varchar(50)
as begin select * from KhachHang where KhachHang.MaKH = @MaKH end 
--Tạo pro tìm khách hàng theo tên
CREATE PROCEDURE sp_TimTenKH
    @TenKH nvarchar(50)
AS BEGIN
    SET NOCOUNT ON;
    SELECT * 
    FROM KhachHang 
    WHERE TenKH LIKE '%' + @TenKH + '%'; 
END
--TAB PHONG
create table Phong (
	MaPhong nvarchar(50) not null,
	SoPhong nvarchar(20) not null,
	LoaiPhong nvarchar(30) not null,
	TinhTrangPhong nvarchar(50) not null,
	GiaPhong float not null,
	constraint pk_MaPhong primary key (MaPhong))
insert into Phong(MaPhong, SoPhong, LoaiPhong, TinhTrangPhong, GiaPhong)
values
('P1','101', N'Thương gia', N'Trống', '1000000'),
('P2','102', N'Phòng thường', N'Trống', '500000'),
('P3','103', N'Thương gia', N'Sửa chữa', '1100000'),
('P4','104', N'Phòng thường', N'Trống', '400000'),
('P5','105', N'Cao cấp', N'Trống', '800000'),
('P6','106', N'Phòng thường', N'Đã thuê', '450000'),
('P7','107', N'Thương gia', N'Đã thuê', '900000'),
('P8','108', N'Cao cấp', N'Trống', '850000'),
('P9','109', N'Phòng thường', N'Trống', '500000'),
('P10','110', N'Thương gia', N'Đã thuê', '950000')
go

--TAO PROCEDURE lấy thông tin phòng
create proc sp_GetAllPhong
as select * from Phong
-- Tạo proc thêm Phong
create proc sp_InsertPhong
@MaPhong nvarchar(50),
@SoPhong nvarchar(20), 
@LoaiPhong nvarchar(30),
@TinhTrangPhong nvarchar(50),
@GiaPhong float 
as insert into Phong(MaPhong, SoPhong, LoaiPhong, TinhTrangPhong, GiaPhong) 
values(@MaPhong, @SoPhong, @LoaiPhong, @TinhTrangPhong, @GiaPhong)
-- Tạo proc sưa PHONG
create proc sp_UpdatePhong
@MaPhong nvarchar(50),
@SoPhong nvarchar(20), 
@LoaiPhong nvarchar(30),
@TinhTrangPhong nvarchar(50),
@GiaPhong float
as Update Phong
set MaPhong= @MaPhong, SoPhong = @SoPhong, LoaiPhong = @LoaiPhong, TinhTrangPhong= @TinhTrangPhong, GiaPhong = @GiaPhong 
where MaPhong= @MaPhong
-- Tạo proc xoa PHONG
create proc sp_DeletePhong
@MaPhong nvarchar(50)
as Delete from Phong where MaPhong= @MaPhong
-- Tạo proc tìm phong theo mã PHONG
create proc sp_TimMaPhong
@MaPhong nvarchar(50)
as begin select * from Phong where Phong.MaPhong = @MaPhong
end 
-- Tạo proc tìm phong theo số PHONG
create proc sp_TimSoPhong
@SoPhong nvarchar(20)
as begin select * from Phong where Phong.SoPhong = @SoPhong
end 
--Tab lập phiếu đặt phòng
create Table PhieuDatPhong
(
	MaDP nvarchar(50) not null,
	MaPhong nvarchar(50) not null,
	MaKH varchar(50) not null,
	MaNV nvarchar(30) not null,
	NgayThue date not null,
	NgayTra date not null,
	constraint pk_MaDP primary key (MaDP),
	constraint fk_MaPhong1 foreign key (MaPhong) references Phong(MaPhong),
	constraint fk_MaKH1 foreign key (MaKH) references KhachHang(MaKH),
	constraint fk_MaNV1 foreign key (MaNV) references NhanVien(MaNV),
	constraint ch_Ngay check (NgayTra >= NgayThue)
)
insert into PhieuDatPhong(MaDP, MaPhong, MaKH, MaNV, NgayThue, NgayTra)
VALUES 
('DP01', 'P1', 'KH01', 'NV01', '2024-01-23', '2024-01-25'),
('DP02', 'P2', 'KH02', 'NV02', '2024-02-24', '2024-02-26')

-- Tạo proc lấy thông tin phiếu đặt phòng
CREATE PROCEDURE sp_GetAllPhieuDP
AS
BEGIN
    SELECT PhieuDatPhong.MaDP, KhachHang.TenKH, Phong.MaPhong, PhieuDatPhong.MaKH, PhieuDatPhong.MaNV, 
	PhieuDatPhong.NgayThue, PhieuDatPhong.NgayTra
    FROM PhieuDatPhong
    INNER JOIN KhachHang ON PhieuDatPhong.MaKH = KhachHang.MaKH
    INNER JOIN Phong ON PhieuDatPhong.MaPhong = Phong.MaPhong; 
	END
	
-- Tạo proc tìm đặt phòng
CREATE PROCEDURE sp_TimKiemDatPhong
@MaDP nvarchar(50)
AS BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM PhieuDatPhong
    WHERE MaDP = @MaDP;
END
--Tạo proc tìm kiếm phòng trống
CREATE PROCEDURE sp_TimKiemPhongTrong
AS BEGIN
    SELECT * FROM Phong WHERE MaPhong NOT IN (SELECT MaPhong FROM PhieuDatPhong);
-- Tạo proc thêm PHIEU DAT PHONG
CREATE PROC sp_InsertPhieuDatPhong
@MaDP nvarchar(50),
@MaPhong nvarchar(50),
@MaKH varchar(50),
@MaNV nvarchar(30),
@NgayThue date,
@NgayTra date
AS INSERT INTO PhieuDatPhong (MaDP, MaPhong, MaKH, MaNV, NgayThue, NgayTra) 
VALUES (@MaDP, @MaPhong, @MaKH, @MaNV, @NgayThue, @NgayTra)
--Tạo proc sửa phiếu đặt phòng
create proc sp_UpdatePhieuDatPhong
@MaDP nvarchar(50),
@MaPhong nvarchar(50),
@MaKH varchar(50),
@MaNV nvarchar(30),
@NgayThue date,
@NgayTra date
as Update PhieuDatPhong set MaPhong = @MaPhong, MaKH = @MaKH, MaNV = @MaNV, NgayThue = @NgayThue, NgayTra = @NgayTra 
Where MaDP = @MaDP
--Tạo bảng hóa đơn
create table HoaDon
(
	MaHD nvarchar(10) not null,
	MaDP nvarchar(50) not null,
	MaNV nvarchar(30) not null,
	MaKH varchar(50) not null,
	LoaiPhatSinh nvarchar(50) not null,
	ChiPhiPhatSinh float not null,
	ThanhTien float not null,
	constraint pk_MaHD primary key(MaHD),
	constraint fk_MaDP2 foreign key (MaDP) references PhieuDatPhong(MaDP),
	constraint fk_MaNV2 foreign key (MaNV) references NhanVien(MaNV),
	constraint fk_MaKH2 foreign key (MaKH) references KhachHang(MaKH)
)

--Thêm cột GiaPhong vào bảng HoaDon
ALTER TABLE HoaDon
ADD GiaPhong float;
--Cập nhật dữ liệu cho cột GiaPhong
UPDATE HoaDon
SET HoaDon.GiaPhong = Phong.GiaPhong
FROM HoaDon
INNER JOIN PhieuDatPhong ON HoaDon.MaDP = PhieuDatPhong.MaDP
INNER JOIN Phong ON PhieuDatPhong.MaPhong = Phong.MaPhong;

INSERT INTO HoaDon(MaHD, MaDP, LoaiPhatSinh, ChiPhiPhatSinh, GiaPhong, ThanhTien)
Values
('HD01', 'DP01', N'Hư bóng đèn',30000, 1000000, 1030000)

--Tạo proc lấy thông tin hóa đơn
CREATE PROC sp_GetAllHoaDon
AS BEGIN SELECT HoaDon.MaHD, HoaDon.MaDP, HoaDon.MaNV, HoaDon.MaKH,HoaDon.LoaiPhatSinh, HoaDon.ChiPhiPhatSinh, HoaDon.GiaPhong,
	HoaDon.ThanhTien
    FROM HoaDon INNER JOIN PhieuDatPhong ON HoaDon.MaDP = PhieuDatPhong.MaDP
END
--lấy mã phòng dựa trên mã phiếu đặt phòng
CREATE PROCEDURE sp_GetMaPhongByMaDP
    @MaDP NVARCHAR(50)
AS BEGIN
    SELECT MaPhong FROM PhieuDatPhong WHERE MaDP = @MaDP;
END
--Lấy giá phòng dựa trên mã phòng
CREATE PROCEDURE sp_GetGiaPhongByMaPhong
    @MaPhong NVARCHAR(50)
AS BEGIN
    SELECT GiaPhong FROM Phong WHERE MaPhong = @MaPhong;
END
--Thêm Hóa đơn
create proc sp_ThemHD
@MaHD nvarchar(10),
@MaDP nvarchar(50),
@MaNV nvarchar(30),
@MaKH varchar(50),
@LoaiPhatSinh nvarchar(50),
@ChiPhiPhatSinh float,
@GiaPhong float,
@ThanhTien float
as insert into HoaDon(MaHD, MaDP, MaNV, MaKH,LoaiPhatSinh, ChiPhiPhatSinh, GiaPhong, ThanhTien)
Values(@MaHD, @MaDP, @MaNV, @MaKH,@LoaiPhatSinh, @ChiPhiPhatSinh, @GiaPhong, @ThanhTien)
--Tạo proc sửa hóa đơn
create proc sp_UpdateHoaDon
@MaHD nvarchar(10),
@MaDP nvarchar(50),
@MaNV nvarchar(30),
@MaKH varchar(50),
@LoaiPhatSinh nvarchar(50),
@ChiPhiPhatSinh float,
@GiaPhong float,
@ThanhTien float
as Update HoaDon
set MaHD = @MaHD, MaDP= @MaDP, MaNV = @MaNV, MaKH = @MaKH, LoaiPhatSinh = @LoaiPhatSinh, 
	ChiPhiPhatSinh = @ChiPhiPhatSinh, GiaPhong = @GiaPhong,ThanhTien=@ThanhTien
Where MaHD = @MaHD
