﻿--Trigger
--PHẦN TRONG BÁO CÁO (Phần trong comment là để test)


--Viết trigger cho bảng tblChiTietHoaDon để sao cho khi sửa tblChitietHoaDon.fGiaBan chỉ chấp nhận giá mới lớn hơn hoặc bằng giá ban đầu
create trigger tg_B62_KiemTraGiaGV
on tblChiTietHoaDon
for update
as
begin 
	Declare @giamoi float
	Declare @giacu float
	select @giamoi=fGiaBan from inserted
	select @giacu=fGiaBan from deleted
	if(@giamoi<@giacu)
	begin
		Raiserror(N'Giá mặt hàng mới không thể nhỏ hơn giá cũ',16,1)
		rollback tran
	end
	else print N'Cập nhập thành công'
end
go
/*select * from tblChiTietHoaDon
go
update tblChiTietHoaDon
set fGiaBan = 1000000
where sMaHD = 'HD01'
and sMaMH = 'MH01'
go*/
 
--Viết trigger cho bảng tblNhanVien sao cho khi thêm 1 nhân viên mới nhân viên đấy phải trên 18 tuổi
create trigger trg_B63_Kiemtratuoi
on tblNhanVien
for insert 
as
begin
	Declare @tuoi int
	select @tuoi=DATEDIFF(day,dNgaySinh,dNgayvaolam)/365 from inserted
	if(@tuoi<18)
	begin
		Raiserror(N'Chưa đủ 18 tuổi',16,1)
		rollback tran
	end
	else 
	print N'Thêm nhân viên thành công'
end
/*insert into tblNhanVien(sMaNV,sTenNV,sGioitinh,sDiachi,sDienThoai,dNgaySinh,dNgayvaolam,fLuongCoBan,fHSL,fPhuCap)
values  ('NV20',N'Nguyễn Thị Mỹ',N'Nữ',N'Hà Nội','0364780146','19981201','20151201',3000000,5,600000)
go*/
 

--Tạo trigger để kiểm soát ngày vào làm của nhân viên chỉ được phép <= thời gian hiện tại
create trigger trg_B64_Kiem_Soat_dNgayVaoLam
on tblNhanVien
for insert
as
begin
	declare @NgayVaoLam datetime
	select @NgayVaoLam = dNgayvaolam from inserted
	if(DATEDIFF(day,@NgayVaoLam,getdate())<0)
		begin
		raiserror(N'Ngày bạn nhập không hợp lệ',16,10)
		rollback tran
	end
	else
		print N'insert thành công'
end
go
/*--Test với năm là 2030
insert into tblNhanVien(sMaNV,sTenNV,sGioitinh,sDiachi,sDienThoai,dNgaySinh,dNgayvaolam,fLuongCoBan,fHSL,fPhuCap)
values  ('NV21',N'Nguyễn Quang Anh',N'Nam',N'Hà Nội','0364780147','19981201','20301201',3000000,5,600000)
go
--Xem nhân viên đã được thêm chưa
select * from tblNhanVien
go*/

--Tạo trigger không cho phép sửa mã nhân viên

--Tạo trigger để kiểm tra một loại hàng có tồn tại hay không trước khi thêm một mặt hàng mới
select * from tblMatHang
select * from tblLoaiHang
go

create trigger trg_B66_Check_LoaiHang_MatHang
ON tblMatHang
instead of insert
as
begin
   declare @smalh nchar(9)
   select @smalh = sMaLH from inserted
   if (@smalh not in (select sMaLH from tblLoaiHang where sMaLH = @smalh))
	Raiserror('Ma loai hang nhap khong ton tai',16,10)
end
go
/*--Test (báo sai)
insert tblMatHang values
('MH33', N'USB 1', 'NCC3', 'LH04', N'Chiếc', 50, 200000)
Go
--Test (đúng)
insert tblMatHang values
('MH33', N'USB 1', 'NCC3', 'LH03', N'Chiếc', 50, 200000)
Go
--Kiểm tra
select * from tblMatHang
go*/

--Tạo trigger để khi xóa một nhân viên thì xóa hóa đơn tương ứng
create trigger trg_B67_XoaNV_HD
on tblNhanVien
after Delete
as
begin
    declare  @MaNV nvarchar(9)
    select  @MaNV = sMaNV from deleted
    if  exists( select  *  from tblHoaDon where sMaNV = @MaNV)
	delete from tblHoaDon 
	where sMaNV = @MaNV
end
go

--Thêm cột iSoLanMua (Số lần mua) vào bảng khách hàng not null, mặc định 0. Tạo trigger sao cho mỗi khi thêm một hóa đơn mới thì số lần mua tăng lên tương ứng
alter table tblKhachHang 
add iSoLanMua int not null default (0.0)
go

create trigger trg_TangSoLanMua
on tblHoaDon
after insert
as
begin
	declare @sMaKH nvarchar(6)
	declare @sTenKH nvarchar(30)
	declare @sMaHD nvarchar(6)
	declare @iSoLanMua int
	select @sMaKH = sMaKH, @sMaHD = sMaHD from inserted
	select @iSoLanMua = count(sMaKH) from tblHoaDon where @sMaHD = sMaHD
	update tblKhachHang
		set tblKhachHang.iSoLanMua += @iSoLanMua where @sMaKH = sMaKH
end;
go

select * from tblKhachHang
/*-- Đã test
insert into tblHoaDon values
('HD68', 'NV08', 'KH01', '20220604')
Go
--Test
insert into tblHoaDon values
('HD69', 'NV08', 'KH01', '20220604')
go*/
 
--Tạo trigger sao cho mỗi khi bán đi một mặt hàng nào đó thì số lượng trong kho giảm đi tương ứng
create trigger trg_GiamSoLuongMH
on tblChiTietHoaDon
after insert
as
begin
	declare @sMaHD varchar(6)
	declare @sMaMH varchar(6)
	declare @iSoLuongBan int
	select @sMaHD = sMaHD, @sMaMH = sMaMH from inserted
	select @iSoLuongBan = iSoLuongBan from tblChiTietHoaDon
	update tblMatHang
		set iSoLuong -= @iSoLuongBan where @sMaMH = sMaMH
end;
go
/*--Xem đơn hàng số 68
select * from tblHoaDon
go
--Xem mặt hàng, tìm MH27 - Chuột 7 - iSoLuong
select * from tblMatHang
where sMaMH = 'MH27'
go
--Xem tblChiTietHoaDon
select * from tblChiTietHoaDon
go
--Test
select sMaMH, iSoLuong from tblMatHang
where sMaMH = 'MH27'
go
--Đã Test
insert into tblChiTietHoaDon values
('HD68','MH27',500000,50,0)
Go
--Test lại
select sMaMH, iSoLuong from tblMatHang
where sMaMH = 'MH27'
go
insert into tblChiTietHoaDon values
('HD69','MH27',500000,50,0)
go*/

--Tạo trigger sao cho khi nhập thêm một mặt hàng nào đó thì số lượng mặt hàng đó trong kho tăng lên
create trigger trg_TangSoLuongMatHang
on tblChiTietPhieuNhap
after insert
as
begin
	declare @sMaPN varchar(6)
	declare @sMaMH varchar(6)
	declare @iSoLuongNhap int
	select @sMaPN = sMaPN, @sMaMH = sMaMH from inserted
	select @iSoLuongNhap = iSoLuongNhap from tblChiTietPhieuNhap
	update tblMatHang
		set iSoLuong += @iSoLuongNhap where @sMaMH = sMaMH
end;
go
/*--Xem bảng mặt hàng - MH20 - Màn hình 10 - iSoLuong
select * from tblMatHang
where sMaMH = 'MH20'
go
--Xem bảng phiếu nhập
select * from tblPhieuNhap
go
--Xem chi tiết phiếu nhập
select * from tblChiTietPhieuNhap
go
--Thêm thông tin phiếu nhập
insert tblPhieuNhap values
('PN610', 'NV11', '20220505')
go
--Test
insert tblChiTietPhieuNhap values
('PN610','MH20',10000000,40)
Go
--Quay trở lại giá trị ban đầu để test lại
delete from tblChiTietPhieuNhap
where sMaPN = 'PN610'
go
update tblMatHang
set iSoLuong = 10
where sMaMH = 'MH20'
go
--Xem thay đổi của mặt hàng
select sMaMH,iSoLuong
from tblMatHang
where sMaMH = 'MH20'
go*/

select *from tblHoaDon;
insert into tblHoaDon values (12,1,'12/14/2018')
select top(1) imahd from tblHoaDon order by iMaHD desc;
select *from inserted

--Tạo trigger xóa 1 hóa đơn trong bảng hóa đơn (tblHoaDon) sẽ xóa toàn bộ thông tin của hóa đơn đó trong bảng chi tiết hóa đơn
create trigger trig_delete_Bill
on tblHoaDon 
instead of delete 
as begin tran
	declare @mahd int;
	select @mahd = imahd from deleted;
	delete from tblChiTietHoaDon where imahd = @mahd;
	delete from tblHoaDon where imahd=@mahd;
commit tran;
--Tạo trigger xóa 1 phiếu nhập sẽ xóa toàn bộ thông tin trong bảng tblChiTietPhieuNhap
create trigger trig_delete_Import
on tblPhieuNhap
instead of delete 
as begin tran
	declare @mapn int;
	select @mapn = imapn from deleted;
	delete from tblChiTietPhieuNhap where imapn = @mapn;
	delete from tblPhieuNhap where imapn = @mapn;
commit tran;

insert into tblLoaiHang values(N'Tuấn đz');
insert into tblMatHang values (N'test hàng',1,1,N'cái',0,0);
select *from tblMatHang