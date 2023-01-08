
create database QuanLySieuThiDienMay
On(
Name = HTQLBH_data,
filename = 'E:\BE_STUDYING\He_Quan_Tri_CSDL\Project\DataApp\QuanLySieuThiDienMay_data.mdf',
size = 10MB,
filegrowth = 2MB)
Log on
(
Name = HTQLBH_Log,
Filename = 'E:\BE_STUDYING\He_Quan_Tri_CSDL\Project\DataApp\QuanLySieuThiDienMay_Log.ldf',
size =5MB,
filegrowth = 1MB);

create table tblNhanVien
(
	iMaNV int identity(1,1) not null primary key,
	sTenNV Nvarchar(30) not null,
	sGioiTinh Nvarchar (3) not null check (sGioiTinh='Nam' or sGioiTinh=N'Nữ' ),
	sDiaChi Nvarchar(50),
	sDienThoai varchar(12) not null ,
	dNgaySinh date,
	dNgayVaoLam date,
	fLuongCoBan float,
	fHSL float,
	fPhuCap float,
	bTinhTrang BIT default(1)
	Unique(sDienThoai)
);
select*from tblNhanVien;
insert into tblnhanvien (sTenNV,sGioiTinh,sDiaChi,sDienThoai,dNgaySinh,dNgayVaoLam,fLuongCoBan,fHSL,fPhuCap) values
						(N'Nhân Viên Một', N'Nam',N'Hà Nội',		'0123457896','01/12/1998','11/13/2018',3000000,5,1000000),
						(N'Nhân Viên Hai', N'Nữ', N'Hải Phòng',	'0123978895','03/05/1999','11/13/2018',2000000,2,1000000),
						(N'Nhân Viên Ba',  N'Nam',N'Hà Nội',		'0154563565','04/09/2002','03/05/2017',6000000,4,1000000),
						(N'Nhân Viên Bốn', N'Nam',N'Thái Bình',	'0123578945','05/10/1997','09/12/2016',9000000,6,1000000),
						(N'Nhân Viên Năm', N'Nam',N'Hòa Bình',	'0145647895','09/12/2003','11/13/2016',4000000,8,1000000),
						(N'Nhân Viên Sáu', N'Nữ', N'Thanh Hóa',	'0125652156','10/19/1998','11/13/2017',6000000,1,1000000),
						(N'Nhân Viên Bảy', N'Nam',N'Ninh Bình',	'0178931295','12/23/2001','12/23/2019',5000000,7,1000000),
						(N'Nhân Viên Tám', N'Nữ', N'Thái Nguyên','0144555890','02/28/2000','03/05/2016',8000000,6,1000000),
						(N'Nhân Viên Chín',N'Nam',N'Hà Nội',		'0127877893','09/17/1999','11/13/2018',3000000,4,1000000),
						(N'Nhân Viên Mười',N'Nữ', N'Hà Nội',		'0127877899','10/06/1998','09/17/2016',3000000,3,1000000);
-- nv kho: 03 05 06
-- nv thu ngan : 01 02 04 07


create table tblKhachHang
(
	iMaKH int identity(1,1) not null primary key,
	sTenKH Nvarchar(30) not null,
	sGioiTinh nvarchar(3)  check (sGioiTinh='Nam' or sGioiTinh=N'Nữ' ),
	sDiaChi nvarchar(50) not null,
	sDienThoai varchar(12) not null Unique
	iSoLanMua int;
)
select *from tblKhachHang;
insert into tblKhachHang (sTenKH,sGioiTinh,sDiaChi,sDienThoai) values 
						(N'Khách hàng Một',	N'Nam',	N'Hà Nội',		'0123457325'),
						(N'Khách hàng Hai',	N'Nữ',	N'Hải Phòng',	'0123978124'),
						(N'Khách hàng Ba',	N'Nam',	N'Hà Nội',		'0154563437'),
						(N'Khách hàng Bốn',	N'Nam',	N'Thái Bình',	'0123533448'),
						(N'Khách hàng Năm',	N'Nam',	N'Hòa Bình',	'0145643249'),
						(N'Khách hàng Sáu',	N'Nữ',	N'Thanh Hóa',	'0125654392'),
						(N'Khách hàng Bảy',	N'Nam',	N'Ninh Bình',	'0178938765'),
						(N'Khách hàng Tám',	N'Nữ',	N'Thái Nguyên',	'0144553427'),
						(N'Khách hàng Chín',	N'Nam',	N'Hà Nội',		'0125656558'),
						(N'Khách hàng Mười',	N'Nữ',	N'Hà Nội',		'0127877669')

select *from tblKhachHang
create table tblNhaCungCap
(
	iMaNCC int identity(1,1) not null primary key,
	sTenNCC nvarchar(20) not null,
	sDiaChi Nvarchar(50)  not null,
	sDienThoai varchar(12) not null Unique

)
insert into tblNhaCungCap(sTenNCC ,sDiaChi,sDienThoai) values
						(N'Nhà Cung Cấp Một',N'Hà Nội',	 '012345732'), -- cung cap man hinh, chuot
						(N'Nhà Cung Cấp Hai',N'Hải Phòng','012397812'), -- cung cap bàn phim, chuot
						(N'Nhà Cung Cấp Ba',	N'Hà Nội',	 '015456343'), -- cung cap laptop
						(N'Nhà Cung Cấp Bốn',N'Thái Bình','012353344'), -- cung cap man hinh ban phim
						(N'Nhà Cung Cấp Năm',N'Hòa Bình', '014564324');-- cung cap ban phim, laptop

select *from tblNhaCungCap

create table tblLoaiHang
(
	iMaLH int identity(1,1) not null primary key,
	sTenLH nvarchar(30) not null
)
insert into tblLoaiHang(stenlh) values
						(N'Màn hình'),
						(N'Bàn phím'),
						(N'Chuột'),
						(N'Laptop');
select *from tblLoaiHang ;

create table  tblMatHang
(
	iMaMH int identity(1,1) not null primary key,
	sTenMH nvarchar(20) not null,
	iMaNCC int not null,
	iMaLH int not null,
	sDonViTinh Nvarchar(10) not null,
	iSoluong int,
	fGiaTien float,
	foreign key (iMaNCC) references tblnhacungcap(imancc),
	foreign key (iMaLH) references tblloaihang(imalh)
);
insert into tblMatHang (sTenMH,iMaNCC,iMaLH,sDonViTinh,isoluong,fGiatien) values 
						(N'Màn hình 1',1,1,N'Chiếc',20,190000),
						(N'Màn hình 2',1,1,N'Chiếc',12,180000),
						(N'Màn hình 3',4,1,N'Chiếc',20,160000),
						(N'Màn hình 4',4,1,N'Chiếc',11,180000),
						(N'Bàn phím 1',2,2,N'Chiếc',12,110000),
						(N'Bàn phím 2',2,2,N'Chiếc',14,90000),
						(N'Bàn phím 3',5,2,N'Chiếc',16,30000),
						(N'Bàn phím 4',5, 2,N'Chiếc',18,60000),
						(N'Chuột 1'	 ,1,3,N'Chiếc',24,70000),
						(N'Chuột 2'	 ,1,3,N'Chiếc',28,90000),
						(N'Chuột 3'	 ,2,3,N'Chiếc',23,100000),
						(N'Chuột 4'	 ,2,3,N'Chiếc',21,500000),
						(N'Laptop 1'	 ,3,4,N'Chiếc',40,270000),
						(N'Laptop 2'	 ,3,4,N'Chiếc',16,180000),
						(N'Laptop 3'	 ,5,4,N'Chiếc',35,350000),
						(N'Laptop 4'	 ,5,4,N'Chiếc',12,780000) ;



create table tblPhieuNhap
(
	iMaPN int identity(1,1) not null primary key,
	iMaNV int not null,
	dNgayNhap date,
	foreign key (iMaNV) references tblNhanVien(iMaNV)
);
select *from tblPhieuNhap;
insert into tblPhieuNhap (iMaNV,dNgayNhap) values
						(11,'01/05/2019'),
						(13,'04/05/2020'),
						(13,'08/05/2021'),
						(19,'01/05/2022');

						
create table tblChiTietPhieuNhap
(
	iMaPN int not null,
	iMaMH int not null,
	fGiaNhap float,
	iSoluongNhap int,
	primary key (imapn,imamh),
	foreign key (iMaPN) references tblPhieuNhap(imapn),
	foreign key (iMaMH) references tblMatHang(imaMH)
);
insert into tblChiTietPhieuNhap(iMaPN,iMaMH,fGiaNhap,iSoluongNhap) values
								(2,3,150000,24),
								(2,4,170000,20),
								(2,11,	60000,22),
								(2,12,	90000,26),
								
								(3,5,100000,26),
								(3,6,	80000,28),
								(3,13,260000,50),
								(3,14,160000,26),

								(4,2,170000,25),
								(4,4,170000,24),
								(4,8,	50000,22),
								(4,9,	60000,22),
								(4,15,340000,46),
								(4,16,760000,18);

create table tblHoaDon
(
	iMaHD int identity(1,1) not null primary key,
	iMaNV int not null,
	iMaKH int not null,
	dNgayBan date,
	foreign key (iManv) references tblnhanvien(imanv),
	foreign key (iMaKH) references tblkhachhang(iMaKH)
);
select *from tblHoaDon;
insert into tblHoaDon(iMaNV,iMaKH,dNgayBan) values
					(12,1,'12/14/2018'),
					(14,2,'02/18/2019'),
					(14,3,'04/14/2019'),
					(15,4,'06/08/2019'),
					(15,6,'08/12/2019'),
					(11,7,'12/19/2019'),
					(13,9,'02/24/2020'),
					(15,10,'08/30/2020'),
					(11,7,'12/14/2020'),
					(19,5,'01/12/2021'),
					(18,4,'04/19/2021'),
					(18,5,'11/24/2021'),
					(19,6,'02/12/2022'),
					(17,10,'07/24/2022'),
					(17,2,'11/13/2022');

create table tblChiTietHoaDon
(
	iMaHD int not null,
	iMaMH int not null,
	fGiaBan float not null,
	iSoLuongBan int ,
	fMucGiamGia float,
	primary key (imahd, imamh),
	foreign key (iMaHD) references tblHoadon(iMaHD),
	foreign key (iMaMH) references tblMatHang(imaMH)
);
insert into tblChiTietHoaDon(iMaHD,iMaMH,fGiaBan,iSoLuongBan,fMucGiamGia) values 
							(1,1,190000,1, 0.2),
							(1,5,110000,1, 0.1),
							(1,9, 70000,1, 0.2),

							(2,2,180000,4, 0.2),
							(2,4,180000,2, 0.1),

							(3,3,160000,1, 0.3),
							(3,5,110000,2, 0.1),

							(4,14,180000,4, 0.2),
							(4,12,500000,2, 0.1),
							(4,2,180000,4, 0.2),
							(4,4,180000,2, 0.4),

							(5,5,110000,2, 0.1),
							(5,9, 70000,1, 0.1),
							(5,6, 90000,1, 0.1),
							(5,1,190000,2, 0.2),

							(6,10, 90000,2, 0.2),
							(6,2,180000,4, 0.1),

							(7,4,180000,2, 0.4),
							(7,2,180000,1, 0.1),
							(7,5,110000,1, 0.1),
							(7,6, 90000,1, 0.0),

							(8,1,190000,3, 0.1),
							(8,2,180000,1, 0.1),
							(8,5,110000,1, 0.1),
							(8,7, 30000,2, 0.1),

							(9,15,350000,1, 0.4),

							(10,16,780000,1, 0.4),

							(12,10, 90000,2, 0.2),
							(12,2,180000,1, 0.1),
							(12,5,110000,1, 0.1),
							(12,6, 90000,1, 0.0),
							(12,16,780000,1, 0.0),
							(12,13,270000,2, 0.1),

							(13,1,110000,1, 0.1),
							(13,2,180000,1, 0.1),
							(13,16,780000,1, 0.0),
							(13,4,190000,3, 0.1),

							(14,16,780000,1, 0.2),

							(15,8, 60000,1, 0.4),
							(15,1,100000,1, 0.4),
							(15,12,500000,10,0.4),
							(15,6, 90000,9, 0.2),
							(15,13,270000,2, 0.2),
							(15,3,160000,2, 0.1);

	



	

