--Procedure

create proc view_all_Employee --thủ tục hiển thị toàn bộ nhân viên
as
select iMaNV as N'Mã Nhân viên', sTenNV as N'Họ tên', sGioiTinh as N'Giới Tính' ,
                sDiaChi as N'Địa Chỉ' , sDienThoai as N'SĐT', dNgaySinh as N'Ngày Sinh', dNgayVaoLam as N'Ngày vào làm',
                fLuongCoBan as N'Lương cơ bản', fHSL as N'Hệ số lương', fPhuCap as N'Phụ cấp' from tblNhanVien order by iMaNv;
     
exec view_all_Employee;

create procedure find_Employee  --Hiển thị toàn bộ nhân viên có điểm gì đó trùng  với ký tự cần tìm
@findX nvarchar(50) 
as
select iMaNV as N'Mã Nhân viên', sTenNV as N'Họ tên', sGioiTinh as N'Giới Tính' ,
                sDiaChi as N'Địa Chỉ' , sDienThoai as N'SĐT', dNgaySinh as N'Ngày Sinh', dNgayVaoLam as N'Ngày vào làm',
                fLuongCoBan as N'Lương cơ bản', fHSL as N'Hệ số lương', fPhuCap as N'Phụ cấp' from tblNhanVien where 
                imanv  like '%' + @findX + '%' or sTenNv like N'%' +@findX + '%' or sGioiTinh like N'%' + @findX + '%' or sDiaChi like N'%' + @findX + '%' or sDienThoai like '%' + @findX + '%'
                or dNgaySinh like '%' + @findX + '%' or dNgayVaoLam like '%' + @findX + '%' or fLuongcoban like '%' + @findX + '%' or fHSL like '%' + @findX + '%'
                or fphucap like '%' + @findX + '%' order by iMaNv;
exec find_Employee '';


create proc view_all_customer
as
select iMaKh as N'Mã khách hàng' , sTenKH as N'Họ tên' , sGioiTinh as N'Giới tính', sDiaChi as N'Địa chỉ' , sDienThoai as N'SĐT' ,iSolanMua as N'Số lần mua hàng' 
from tblKhachHang order by iMaKH;
exec view_all_customer;

create proc find_Customer
@findX nvarchar(50)
as
select iMaKh as N'Mã khách hàng' , sTenKH as N'Họ tên' , sGioiTinh as N'Giới tính', sDiaChi as N'Địa chỉ' , sDienThoai as N'SĐT' ,iSolanMua as N'Số lần mua hàng' 
from tblKhachHang 
where iMaKH like '%'+@findX+'%' or sTenKH like '%'+@findX+'%' or sGioiTinh like '%'+@findX+'%' 
or sDiaChi like '%'+@findX+'%' or sDienThoai like '%'+@findX+'%' or iSolanMua like '%'+@findX+'%'
order by iMaKH;
exec find_Customer '1';

--
create proc view_all_Supplier
as
select iMaNCC as N'Mã nhà cung cấp', sTenNCC as N'Tên nhà cung cấp' , sDiaChi as N'Địa chỉ', sDienThoai as N'Số điện thoại' 
from tblNhaCungCap 
order by iMaNCC;
exec view_all_Supplier;

create proc find_Supplier
@findX nvarchar(50)
as
select 
iMaNCC as N'Mã nhà cung cấp', sTenNCC as N'Tên nhà cung cấp' , sDiaChi as N'Địa chỉ', sDienThoai as N'Số điện thoại' 
from tblNhaCungCap 
where iMaNCC like '%'+@findX+'%' or sTenNCC like '%'+@findX+'%' or sDiaChi like '%'+@findX+'%' or sDiaChi like '%'+@findX+'%'
order by iMaNCC;

create proc view_all_Category
as
select 
iMaLH as N'Mã loại hàng', sTenLH as N'Tên loại hàng'
from tblLoaiHang;
exec view_all_Category;

create proc find_Category
@findX nvarchar(50)
as
select 
iMaLH as N'Mã loại hàng', sTenLH as N'Tên loại hàng'
from tblLoaiHang 
where iMaLH like '%'+@findX+'%' or sTenLH like N'%'+@findX+'%'
order by iMaLH;

--PHẦN TRONG BÁO CÁO
--Tạo thủ tục chèn thêm một khách hàng mới (kiểm tra điều kiện thỏa mãn)
create proc sp_B51_ThemKhachHang
 @sMaKH varchar(6),
 @sTenKH nvarchar(30),
 @sDiaChi nvarchar(50),
 @sDienThoai nvarchar(12),
 @sGioiTinh nvarchar(3)
as
 begin
 if exists (select *
	from tblKhachHang
	where tblKhachHang.sMaKH = @sMaKH)
	print N'Khách hàng đã tồn tại'
 else
 insert tblKhachHang(sMaKH,sTenKH,sDiaChi,sDienThoai,sGioiTinh) values(@sMaKH, @sTenKH, @sDiaChi, @sDienThoai, @sGioiTinh)
end
go

exec sp_B51_ThemKhachHang @sMaKH = 'KH08', @sTenKH = N'Khách hàng Tám', @sDiaChi = N'Hà Nội', @sDienThoai = '098765411', @sGioiTinh = N'Nữ'
go
 
--Tạo thủ tục thêm một mặt hàng mới (kiểm tra điều kiện thỏa mãn)
create proc sp_B52_ThemMatHang 
 @sMaMH varchar(10),
 @sTenHang nvarchar(30),
 @sMaNCC varchar(6),
 @sMaLoaiHang char(10),
 @iSoLuong int,
 @fGiaBan float,
 @sDonViTinh varchar(10)
as
begin
 if exists (select *
	from tblMatHang
	where tblMatHang.sMaMH = @sMaMH)
	print N'Mặt hàng đã tồn tại'
 else if not exists (select tblMatHang.sMaNCC
	from tblMatHang,tblNhaCungCap
	where tblMatHang.sMaNCC = tblNhaCungCap.sMaNCC)
	print N'Mã Nhà Cung Cấp Không Tồn Tại'
 else
 insert tblMatHang (sMaMH, sTenMH, sMaNCC, sMaLH, iSoLuong, fGiaTien, sDonViTinh) values(@sMaMH, @sTenHang, @sMaNCC, @sMaLoaiHang, @iSoLuong, @fGiaBan, @sDonViTinh)
end
go

exec sp_B52_ThemMatHang @sMaMH='MH31', @sTenHang=N'Chuột 11', @sMaNCC='NCC3',
@sMaLoaiHang='LH03', @iSoLuong=100, @fGiaBan=200000, @sDonViTinh= N'Chiếc'
Go
 
--Tạo thủ tục chèn thêm một hoá đơn mới (kiểm tra điều kiện thỏa mãn)
create proc sp_B53_ThemHoaDon 
 @sMaHD varchar(6),
 @sMaNV varchar(6),
 @sMaKH varchar(6),
 @dNgayBan datetime
as
begin
 if exists (select *
	from tblHoaDon
	where tblHoaDon.sMaHD = @sMaHD)
	print N'Đơn đặt hàng đã tồn tại'
 else
 insert tblHoaDon(sMaHD, sMaNV, sMaKH, dNgayBan) values(@sMaHD, @sMaNV, @sMaKH, @dNgayBan)
 end
go

exec sp_B53_ThemHoaDon  @sMaHD='HD11', @sMaNV='NV10', @sMaKH='KH07', @dNgayBan='20220503'
go
 
--Tạo thủ tục cho danh sách các mặt hàng của một loại hàng nào đó theo Tên Loại Hàng
create proc sp_B54_ThongkeSoLuongHang @sTenLoaiHang nvarchar(30)
as
begin
select *
from tblMatHang,tblLoaiHang
where tblMatHang.sMaLH = tblloaiHang.sMaLH
and tblLoaiHang.sTenLH=@sTenLoaiHang
end
go

exec sp_B54_ThongkeSoLuongHang @sTenLoaiHang = N'Máy Tính Xách Tay'
go
 
--Tạo thủ tục cho danh sách các mặt hàng được bán trong năm nào đó, với năm là tham số truyền vào
create proc pro_B55_MatHangDuocBan @iNam int 
as
begin
select *
from tblMatHang
where sMaMH IN
(select sMaMH
 from tblChiTietHoaDon, tblHoaDon
 where tblChiTietHoaDon.sMaHD = tblHoaDon.sMaHD
 and YEAR(dNgayBan) = @iNam)
end
go

exec pro_B55_MatHangDuocBan 2022 
go
 
--Tạo thủ tục thực hiện tăng lương gấp rưỡi cho các nhân viên đã bán hàng với số lượng hàng nhiều hơn số lượng hàng được truyền vào,
--số lượng hàng là tham số truyền vào 
create proc pro_B56_TangLuongNhanVien @iSoLuong int
as
begin
update tblNhanVien 
set fLuongCoBan = fLuongCoBan * 1.5 
where tblNhanVien.sMaNV in
(select sMaNV from tblHoaDon, tblChiTietHoaDon 
where tblHoaDon.sMaHD = tblChiTietHoaDon.sMaHD
group by tblHoaDon.sMaNV 
having SUM(iSoLuongBan) > @iSoLuong 
)
end
go

exec pro_B56_TangLuongNhanVien @iSoLuong = 30
go

select * from tblNhanVien
go
 
--Tạo thủ tục cho biết tên các thông tin gồm: tên mặt hàng, số lượng, đơn giá thành tiền, của các mặt hàng trong một hoá đơn nào đó theo mã hoá đơn
create proc pro_B57_ThongTinHoaDon @sMaHD varchar(6)
as
begin
select tblMatHang.sTenMH, tblChiTietHoaDon.sMaMH,tblMatHang.iSoLuong,tblMatHang.fGiaTien,tblChiTietHoaDon.fGiaBan
from tblMatHang,tblChiTietHoaDon
where tblMatHang.sMaMH=tblChiTietHoaDon.sMaMH
and tblChiTietHoaDon.sMaHD = @sMaHD
end
go

exec pro_B57_ThongTinHoaDon @sMaHD = 'HD05'
go
 
--Tạo thủ tục cho biết tên khách hàng đã mua hàng trong một tháng - một năm nào đó
create proc pro_B58_ThongTinKhachHangMuaHang @iThang int, @iNam int
as
begin
select tblKhachHang.sTenKH
from tblKhachHang,tblHoaDon
where tblKhachHang.sMaKH=tblHoaDon.sMaKH
and Month(tblHoaDon.dNgayBan) = @iThang
and Year(tblHoaDon.dNgayBan) = @iNam
end
go

exec pro_B58_ThongTinKhachHangMuaHang @iThang = 6, @iNam = 2022
go
 
--Tạo thủ tục cho biết tên, tổng số lượnng đã bán, tổng tiền đã bán của các mặt hàng trong một năm nào đó
create proc pro_B59_TongKetMatHang @iNam int
as
begin
	select sTenMH, sum(iSoLuongBan) as N'Số Lượng Bán', sum((tblChiTietHoaDon.fGiaBan * tblChiTietHoaDon.iSoLuongBan) * (1-tblChiTietHoaDon.fMucGiamGia)) as N'Tổng Tiên'
	from tblHoaDon, tblChiTietHoaDon, tblMatHang
	where tblMatHang.sMaMH = tblChiTietHoaDon.sMaMH
	and tblHoaDon.sMaHD = tblChiTietHoaDon.sMaHD
	and Year(dNgayBan)= @iNam
	group by sTenMH, iSoLuongBan, tblChiTietHoaDon.fGiaBan, fMucGiamGia
end
go

exec pro_B59_TongKetMatHang @iNam='2022'
go
 
--Tạo thủ tục cho tên các khách hàng đã đến mua hàng với số tiền lớn hơn một số nào đó
create proc sp_B510_TKetMuaHang @TienMin float
as
begin
	select sTenKH
	from tblKhachHang, tblChiTietHoaDon, tblHoaDon
	where tblKhachHang.sMaKH=tblHoaDon.sMaKH
	and tblHoaDon.sMaHD = tblChiTietHoaDon.sMaHD
	group by sTenKH
	having sum((tblChiTietHoaDon.fGiaBan * tblChiTietHoaDon.iSoLuongBan) * (1-tblChiTietHoaDon.fMucGiamGia)) > @TienMin
end
go

exec sp_B510_TKetMuaHang @TienMin = 15000000
go

select * from tblChiTietHoaDon
go
 
--Tạo thủ tục thêm nhân viên (kiểm tra điều kiện thỏa mãn)
create proc sp_B511_ThemNV
(@manv varchar(10), @tennv nvarchar(30), @gioitinh nvarchar(3), @diachi nvarchar(30),
 @sdt varchar(10), @ngaysinh datetime, @ngayvaolam datetime, @luongcb float,  @hsl float, @phucap float )
as
 begin
 if exists (select *
	from tblNhanVien
	where tblNhanVien.sMaNV = @manv)
	print N'Nhân viên đã tồn tại'
 else
	insert into dbo.tblNhanVien
	(sMaNV, sTenNV, sGioiTinh, sDiaChi, sDienThoai, dNgaySinh, dNgayVaoLam, fLuongCoBan, fHSL, fPhuCap)
	values 
	(@manv, @tennv, @gioitinh, @diachi, @sdt, @ngaysinh, @ngayvaolam, @luongcb, @hsl, @phucap)
end 
go

exec sp_B511_ThemNV @manv = 'NV11', @tennv = N'Nhân Viên Mười Một', @gioitinh = N'Nữ', @diachi = N'Hà Nội',
 @sdt ='0987654311', @ngaysinh = '20030517', @ngayvaolam = '20221011' , @luongcb= '1500000' ,  @hsl = 1.5, @phucap = 100000
go

select * from tblNhanVien;
go
 
--Tạo thủ tục có tham số truyền vào là năm cho biết các mặt hàng không nhập được trong năm đó 
select * from tblMatHang;
go

create proc sp_B512_MatHangKhongDuocBan (@nam int)
as
begin 
	select tblMatHang.sMaMH, sTenMH, year(dNgayBan) as [Năm nhập]
	from tblMatHang, tblHoaDon, tblChiTietHoaDon
	where tblChiTietHoaDon.sMaMH = tblMatHang.sMaMH
	and tblChiTietHoaDon.sMaHD = tblHoaDon.sMaHD
	and year(dNgayBan) != @nam
end 
go

exec sp_B512_MatHangKhongDuocBan 2020
go
 
--Tạo thủ tục thống kê tổng số lượng hàng nhập được của một mặt hàng có mã hàng là tham số truyền vào
create proc sp_B513_TKeLuongHang_MaHang (@mahang varchar(20))
as
begin 
	select sMaMH, sum(iSoLuongNhap) as [tổng SL nhập]
	from tblChiTietPhieuNhap
	where sMaMH = @mahang
	group by sMaMH
end 
go

exec sp_B513_TKeLuongHang_MaHang 'MH27';
go

select * from tblChiTietPhieuNhap;
go
 
--Tạo thủ tục update số điện thoại của khách hàng có mã được truyền vào
create proc sp_B514_upadate_Sdt (@makh varchar(20), @sdt varchar(20))
as
begin
	update tblKhachHang
	set sDienThoai = @sdt
	where sMaKH = @makh
end 
go

exec sp_B514_upadate_Sdt @makh = N'KH01', @sdt = N'0112345789';
go

select * from tblKhachHang;
go
 
--Tạo thủ tục xóa dữ liệu nhân viên theo mã truyền vào
create proc sp_B515_Delete_NV (@manv varchar(20))
as
begin 
	delete tblNhanVien
	where sMaNV = @manv
end 
go

exec sp_B515_Delete_NV @manv = N'NV10';
go

select * from tblNhanVien;
go
 
--Tạo thủ tục truy vấn thông tin mặt hàng có ngày nhập phiếu nhỏ hơn ngày truyền vào
create proc sp_B516_NgayNhap_trc (@ngaynhap datetime)
as
begin 
	select * 
	from tblMatHang
	where sMaMH IN 
		( select sMaMH 
		  from tblPhieuNhap, tblChiTietPhieuNhap
		  where tblPhieuNhap.sMaPN = tblChiTietPhieuNhap.sMaPN
		  and datediff(day, dNgayNhap, @ngaynhap) < 0)
end 
go

exec sp_B516_NgayNhap_trc @ngaynhap = '20220504';
go

select * from tblPhieuNhap;
select * from tblChiTietPhieuNhap;
go
 
--Tạo thủ tục cho biết danh sách tên các mặt hàng đã được nhập từ 1 NCC và 1 năm được nhập 
create proc sp_B517_MatHang_NCC_NamNhap (@tenNCC nvarchar(20), @nam int)
as
begin 
	select distinct sTenMH
	from tblMatHang, tblNhaCungCap, tblHoaDon, tblChiTietHoaDon
	where tblMatHang.sMaNCC = tblNhaCungCap.sMaNCC
	and tblHoaDon.sMaHD = tblChiTietHoaDon.sMaHD
	and tblMatHang.sMaMH = tblChiTietHoaDon.sMaMH
	and sTenNCC = @tenNCC
	and year(dNgayBan) = @nam 
end 
go

exec sp_B517_MatHang_NCC_NamNhap @tenNCC = N'Nhà Cung Cấp Hai', @nam = 2021 ;
go
 

--Tạo thủ tục in số lượng mặt hàng của phiếu đó:
create proc sp_B518_SoLuongMatHang_Theo_PN (@MaPN nvarchar(20))
as
begin 
	declare @Soluong smallint 
	select @Soluong = count(*)
	from tblChiTietPhieuNhap
	where sMaPN = @MaPN
	print N'Số lượng mặt hàng = '+ cast(@Soluong as nvarchar(20))
end 
go

execute sp_B518_SoLuongMatHang_Theo_PN N'PN2';
go
 
--Tạo thủ tục sắp xếp các mặt hàng theo số lượng nhập của phiếu nhập nào đó với mã phiếu nhập là tham số truyền vào
create proc sp_B519_SX_MatHang_SoLuongNhap_PhieuNhap @sMaPN varchar(6)
as
begin
	select sMaPN, iSoLuongNhap
	from tblChiTietPhieuNhap
	where sMaPN = @sMaPN
	order by iSoLuongNhap
end
go

exec sp_B519_SX_MatHang_SoLuongNhap_PhieuNhap @sMaPN = 'PN1';
go
 
--Tạo thủ tục: tham số truyền vào: mã hoá đơn
--Khi chạy, kết quả đưa ra: tổng tiền theo số lượng bán của hóa đơn đó
create proc sp_B520_MaHD_TongTien  (@Mahd varchar(20))
as
begin 
	select sum(fGiaBan * iSoLuongBan) as [Tổng tiền số lượng bán]
	from tblChiTietHoaDon 
	where sMaHD = @Mahd
end 
go

execute sp_B520_MaHD_TongTien 'HD01';
go

 
