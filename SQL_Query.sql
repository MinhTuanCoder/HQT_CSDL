create database QLSieuThiDienMay;
/*On(Name = HTQLBH_data,
filename = 'D:\Nam ba\HK1_2\HQTCSDL\BTL\HTQLBH_data.mdf',
size = 10MB,
MaxSize =50MB,
filegrowth = 2MB)
Log on
(Name = HTQLBH_Log,
Filename = 'D:\Nam ba\HK1_2\HQTCSDL\BTL\HTQLBH_Log.ldf',
size =5MB,
Maxsize = 20MB,
filegrowth = 1MB)*/

create table tblNhanVien
(
	sMaNV varchar(6) not null primary key,
	sTenNV Nvarchar(30) not null,
	sGioiTinh Nvarchar (3) not null check (sGioiTinh='Nam' or sGioiTinh=N'Nữ' ),
	sDiaChi Nvarchar(50),
	sDienThoai varchar(12) not null,
	dNgaySinh date,
	dNgayVaoLam date,
	fLuongCoBan float,
	fHSL float,
	fPhuCap float
)
insert into tblnhanvien (sMaNV,sTenNV,sGioiTinh,sDiaChi,sDienThoai,dNgaySinh,dNgayVaoLam,fLuongCoBan,fHSL,fPhuCap) values
						('NV01',N'Nhân Viên Một', N'Nam',N'Hà Nội',		'0123457896','01/12/1998','11/13/2018',3000000,5,1000000),
						('NV02',N'Nhân Viên Hai', N'Nữ', N'Hải Phòng',	'0123978895','03/05/1999','11/13/2018',2000000,2,1000000),
						('NV03',N'Nhân Viên Ba',  N'Nam',N'Hà Nội',		'0154563565','04/09/2002','03/05/2017',6000000,4,1000000),
						('NV04',N'Nhân Viên Bốn', N'Nam',N'Thái Bình',	'0123578945','05/10/1997','09/12/2016',9000000,6,1000000),
						('NV05',N'Nhân Viên Năm', N'Nam',N'Hòa Bình',	'0145647895','09/12/2003','11/13/2016',4000000,8,1000000),
						('NV06',N'Nhân Viên Sáu', N'Nữ', N'Thanh Hóa',	'0125652156','10/19/1998','11/13/2017',6000000,1,1000000),
						('NV07',N'Nhân Viên Bảy', N'Nam',N'Ninh Bình',	'0178931295','12/23/2001','12/23/2019',5000000,7,1000000),
						('NV08',N'Nhân Viên Tám', N'Nữ', N'Thái Nguyên','0144555890','02/28/2000','03/05/2016',8000000,6,1000000),
						('NV09',N'Nhân Viên Chín',N'Nam',N'Hà Nội',		'0127877899','09/17/1999','11/13/2018',3000000,4,1000000),
						('NV10',N'Nhân Viên Mười',N'Nữ', N'Hà Nội',		'0127877899','10/06/1998','09/17/2016',3000000,3,1000000)



create table tblKhachHang
(
	sMaKH Varchar(6) not null primary key,
	sTenKH Nvarchar(30) not null,
	sGioiTinh nvarchar(3)  check (sGioiTinh='Nam' or sGioiTinh=N'Nữ' ),
	sDiaChi nvarchar(50) not null,
	sDienThoai varchar(12) not null
)
insert into tblKhachHang (	sMaKH,sTenKH,sGioiTinh,sDiaChi,sDienThoai) values 
						('KH01',N'Khách hàng Một',	N'Nam',	N'Hà Nội',		'0123457325'),
						('KH02',N'Khách hàng Hai',	N'Nữ',	N'Hải Phòng',	'0123978124'),
						('KH03',N'Khách hàng Ba',	N'Nam',	N'Hà Nội',		'0154563437'),
						('KH04',N'Khách hàng Bốn',	N'Nam',	N'Thái Bình',	'0123533448'),
						('KH05',N'Khách hàng Năm',	N'Nam',	N'Hòa Bình',	'0145643249'),
						('KH06',N'Khách hàng Sáu',	N'Nữ',	N'Thanh Hóa',	'0125654392'),
						('KH07',N'Khách hàng Bảy',	N'Nam',	N'Ninh Bình',	'0178938765'),
						('KH08',N'Khách hàng Tám',	N'Nữ',	N'Thái Nguyên',	'0144553427'),
						('KH09',N'Khách hàng Chín',	N'Nam',	N'Hà Nội',		'0125656558'),
						('KH10',N'Khách hàng Mười',	N'Nữ',	N'Hà Nội',		'0127877669')

select *from tblKhachHang
create table tblNhaCungCap
(
	sMaNCC varchar(6) not null primary key,
	sTenNCC nvarchar(20) not null,
	sDiaChi Nvarchar(50)  not null,
	sDienThoai varchar(12) not null,
)
insert into tblNhaCungCap(sMaNCC,sTenNCC ,sDiaChi,sDienThoai) values
						('NCC1',N'Nhà Cung Cấp Một',N'Hà Nội',	 '012345732'), -- cung cap man hinh, chuot
						('NCC2',N'Nhà Cung Cấp Hai',N'Hải Phòng','012397812'), -- cung cap bàn phim, chuot
						('NCC3',N'Nhà Cung Cấp Ba',	N'Hà Nội',	 '015456343'), -- cung cap laptop
						('NCC4',N'Nhà Cung Cấp Bốn',N'Thái Bình','012353344'), -- cung cap man hinh ban phim
						('NCC5',N'Nhà Cung Cấp Năm',N'Hòa Bình', '014564324') -- cung cap ban phim, laptop

select *from tblNhaCungCap

create table tblLoaiHang
(
	sMaLH varchar(6) not null primary key,
	sTenLH nvarchar(30) not null
)
insert into tblLoaiHang(smalh,stenlh) values
						('LH01',N'Màn hình'),
						('LH02',N'Bàn phím'),
						('LH03',N'Chuột'),
						('LH04',N'Laptop')
select *from tblLoaiHang

create table  tblMatHang
(
	sMaMH varchar(6) not null primary key,
	sTenMH nvarchar(20) not null,
	sMaNCC varchar(6) not null,
	sMaLH varchar(6) not null,
	sDonViTinh Nvarchar(10) not null,
	iSoluong int,
	fGiaTien float,
	foreign key (sMaNCC) references tblnhacungcap(smancc),
	foreign key (sMaLH) references tblloaihang(smalh)
)
insert into tblMatHang (sMaMH,sTenMH,sMaNCC,sMaLH,sDonViTinh,isoluong,fGiatien) values 
						('MH01',N'Màn hình 1','NCC1','LH01',N'Chiếc',20,190000),
						('MH02',N'Màn hình 2','NCC1','LH01',N'Chiếc',12,180000),
						('MH03',N'Màn hình 3','NCC4','LH01',N'Chiếc',20,160000),
						('MH04',N'Màn hình 4','NCC4','LH01',N'Chiếc',11,180000),
						('MH05',N'Bàn phím 1','NCC2','LH02',N'Chiếc',12,110000),
						('MH06',N'Bàn phím 2','NCC2','LH02',N'Chiếc',14,90000),
						('MH07',N'Bàn phím 3','NCC5','LH02',N'Chiếc',16,30000),
						('MH08',N'Bàn phím 4','NCC5','LH02',N'Chiếc',18,60000),
						('MH09',N'Chuột 1'	 ,'NCC1','LH03',N'Chiếc',24,70000),
						('MH10',N'Chuột 2'	 ,'NCC1','LH03',N'Chiếc',28,90000),
						('MH11',N'Chuột 3'	 ,'NCC2','LH03',N'Chiếc',23,100000),
						('MH12',N'Chuột 4'	 ,'NCC2','LH03',N'Chiếc',21,500000),
						('MH13',N'Laptop 1'	 ,'NCC3','LH04',N'Chiếc',40,270000),
						('MH14',N'Laptop 2'	 ,'NCC3','LH04',N'Chiếc',16,180000),
						('MH15',N'Laptop 3'	 ,'NCC5','LH04',N'Chiếc',35,350000),
						('MH16',N'Laptop 4'	 ,'NCC5','LH04',N'Chiếc',31,780000) 



create table tblPhieuNhap
(
	sMaPN varchar(6) not null primary key,
	sMaNV varchar(6) not null,
	dNgayNhap date,
	foreign key (sMaNV) references tblNhanVien(sMaNV)
)
insert into tblPhieuNhap (smapn, sMaNV,dNgayNhap) values
						('NP1','NV02','01/05/2019')



create table tblChiTietPhieuNhap
(
	sMaPN varchar(6) not null,
	sMaMH varchar(6) not null,
	fGiaNhap float,
	iSoluongNhap int,
	primary key (smapn,smamh),
	foreign key (sMaPN) references tblPhieuNhap(smapn),
	foreign key (sMaMH) references tblMatHang(smaMH)
)
insert into tblChiTietPhieuNhap(sMaPN,sMaMH,fGiaNhap,iSoluongNhap) values
								()




create table tblHoaDon
(
	sMaHD varchar(6) not null primary key,
	sMaNV varchar(6) not null,
	sMaKH varchar(6) not null,
	dNgayBan date,
	foreign key (sManv) references tblnhanvien(smanv),
	foreign key (sMaKH) references tblkhachhang(sMaKH)
)
insert into tblHoaDon(sMaHD,sMaNV,sMaKH,dNgayBan) values
					()






create table tblChiTietHoaDon
(
	sMaHD varchar(6) not null,
	sMaMH varchar(6) not null,
	fGiaBan float not null,
	iSoLuongBan int ,
	fMucGiamGia float,
	primary key (smahd, smamh),
	foreign key (sMaHD) references tblHoadon(sMaHD),
	foreign key (sMaMH) references tblMatHang(smaMH)
)
insert into tblChiTietHoaDon(sMaHD,sMaMH,fGiaBan,iSoLuongBan,fMucGiamGia) values 
							()
	
