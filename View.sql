--View

--Tạo view hiển  thị tất cả các hóa đơn
select hd.iMaHD, nv.sTenNV,kh.sTenKH,mh.sTenMH  
from 
tblChiTietHoaDon cthd inner join  tblHoaDon hd on cthd.iMaHD=hd.iMaHD
inner join tblMatHang mh on cthd.iMaMH = mh.iMaMH
inner join tblNhanVien nv on nv.iMaNV = hd.iMaNV
inner join tblKhachHang kh on kh.iMaKH=hd.iMaKH;

--PHẦN TRONG BÁO CÁO
--Tạo view cho biết số lượng hàng đã bán được của từng loại hàng
create view cv_B41_SoLuongHangDaBan
as
	select sTenLH as [Tên loại hàng], count(iSoLuong) as [Số lượng đã bán]
	from tblLoaiHang, tblMatHang, tblChiTietHoaDon
	where tblLoaiHang.iMaLH = tblMatHang.iMaLH
	and tblMatHang.iMaMH = tblChiTietHoaDon.iMaMH
	group by sTenLH 
go

select * from cv_B41_SoLuongHangDaBan;
go
--

--Tạo view thống kê tổng hợp theo từng hóa đơn, gồm: Số hóa đơn, Ngày bán, Tổng số tiền, Tổng số mặt hàng
create view vv_B42_TongHopDonDat (iMaHD, dNgayBan, fTongSoTien , fTongSoMatHang) as
select tblChiTietHoaDon.iMaHD,dNgayBan, sum((fGiaBan * iSoLuongBan) *(1-fMucGiamGia)) as fTongSoTien , count(iMaMH) as fTongSoMatHang
from tblHoaDon, tblChiTietHoaDon
where tblHoaDon.iMaHD = tblChiTietHoaDon.iMaHD
group by tblChiTietHoaDon.iMaHD, dNgayBan
go

select * from vv_B42_TongHopDonDat
go
select stenKH + ' - '+ sDienThoai from tblKhachHang
--Tạo view liệt kê các nhân viên có phụ cấp
create view vv_B43_NVPhuCap as
select *
from tblNhanVien
where fPhuCap >0
go

select * from vv_B43_NVPhuCap
go

--Tạo View tính tổng tiền hàng và tổng số mặt hàng của từng đơn nhập hàng
create view cv_B44_Tong_TienHang_MatHang_Theo_DonNhapHang
as
	select iMaPN, Count(iMaMH) as [Tổng số mặt hàng], SUM(iSoLuongNhap*fGiaNhap) as [Tổng tiền hàng]
	from tblChiTietPhieuNhap 
	group by iMaPN
go

select * from cv_B44_Tong_TienHang_MatHang_Theo_DonNhapHang;
go

--Tạo view cho biết trong năm 2022 những mặt hàng nào chỉ được nhập mua đúng 1 lần 
create view cv_B45_MatHangNhap1Lan
as 
	select tblMatHang.sMaMH, tblMatHang.sTenMH, count (tblChiTietPhieuNhap.sMaPN) as [Số lần đặt]
	from tblChiTietPhieuNhap, tblMatHang, tblPhieuNhap
	where tblChiTietPhieuNhap.sMaMH = tblMatHang.sMaMH
	and tblPhieuNhap.sMaPN= tblChiTietPhieuNhap.sMaPN
	and Year(dNgayNhap) = 2022
	group by tblMatHang.sMaMH, tblMatHang.sTenMH
	having count (tblChiTietPhieuNhap.sMaPN) = 1;
go

select * from cv_B45_MatHangNhap1Lan;
go



--Tạo view cho biết tên mặt hàng đã bán được > 10 triệu tiền hàng trong năm 2021
create view vv_B49_TKeMatHangBan2021_10tr as
select tblChiTietHoaDon.sMaMH, sum((tblChiTietHoaDon.fGiaBan * iSoLuongBan)*(1-fMucGiamGia)) as TongTienBanDuoc_2021
from tblMatHang, tblChiTietHoaDon, tblHoaDon
where tblMatHang.sMaMH = tblChiTietHoaDon.sMaMH
and tblChiTietHoaDon.sMaHD = tblHoaDon.sMaHD
and year(tblHoaDon.dNgayBan)=2021
group by tblChiTietHoaDon.sMaMH
having sum(tblChiTietHoaDon.fGiaBan) > 10000000
go

select * from vv_B49_TKeMatHangBan2021_10tr
go

--Tạo view cho xem danh sách mặt hàng và giá bán trung bình của từng mặt hàng
create view vw_B410_TbGiaMatHang as
select sTenMH, AVG(tblChiTietHoaDon.fGiaBan) as N'Trung bình giá' 
from tblMatHang, tblChiTietHoaDon 
where tblMatHang.iMaMH = tblChiTietHoaDon.iMaMH
group by sTenMH 
go

select * from vw_B410_TbGiaMatHang
go

--Tạo view cho biết tổng số tiền đã bán của từng nhân viên trong năm 2022
create view cv_B411_TongTienBan_NhanVien_2022
as
  select sTenNV, isnull(sum(fGiaBan * iSoLuongBan - fMucGiamGia * fGiaBan * iSoLuongBan),0) AS[Tổng tiền hàng] 
  from tblNhanVien
  left join tblHoaDon on tblNhanVien.iMaNV = tblHoaDon.iMaNV
  left join tblChiTietHoaDon  on tblHoaDon.iMaHD= tblChiTietHoaDon.iMaHD
  AND year(dNgayBan) = 2022
  group by sTenNV
go

select * from cv_B411_TongTienBan_NhanVien_2022;
go

--Tạo view lấy danh sách các khách hàng Nam và tổng tiền hóa đơn của mỗi người 
create view cv_B412_TongTienHoaDon_KHNam
as 
	select hd.sMaKH, kh.sTenKH, SUM((ct.fGiaBan * ct.iSoLuongBan)-(ct.fGiaBan*ct.iSoLuongBan*ct.fMucGiamGia/100)) as [Tổng tiền hóa đơn]
	from tblKhachHang kh , tblHoaDon hd, tblChiTietHoaDon ct
	where kh.sMaKH = hd.sMaKH
	and hd.sMaHD = ct.sMaHD
	and kh.sGioiTinh = N'Nam'
	group by hd.sMaKH, kh.sTenKH
go

select * from cv_B412_TongTienHoaDon_KHNam; 
go

--Tạo view thống kê số lượng khách hàng theo giới tính
create view cv_B413_TKe_GioiTinh
AS 
	select [Giới tính] = case sGioiTinh when N'Nam' then N'Nam' else N'Nữ' end, count(iMaKH) as [Số lượng khách] 
	from tblKhachHang 
	group by sGioiTinh 
go

select * from cv_B413_TKe_GioiTinh;
go
 
--Tạo view cho xem danh sách 3 khách hàng mua hàng nhiều lần nhất 
create view cv_B414_3_KH_muaNN
as
	select top (3) tblKhachHang.iMaKH, sTenKH, count(iMaHD) as [Số lần mua ] 
	from tblKhachHang, tblHoaDon
	where tblKhachHang.iMaKH = tblHoaDon.iMaKH
	group by tblKhachHang.iMaKH, sTenKH
	order by count(iMaHD) DESC
go

select * from cv_B414_3_KH_muaNN;
go

--Tạo view chứa các nhân viên có thâm niên làm việc trên 5 năm
create view vw_B416_NhanVien_ThamNien_tren5nam (sMaNV, sTenNV, Namkinhnghiem)
as
select iMaNV, sTenNV, (year(getdate())-year(tblNhanVien.dNgayVaolam))
from tblNhanVien
where (datediff(day, dNgayVaoLam, getdate())/365) >= 5
go

select * from vw_B416_NhanVien_ThamNien_tren5nam;
go
 
--Tạo view chuyển tiền bán được sang USD (đô la Mĩ)
create view vw_B417_HoaDon_theo_USD (sMaHD, sMaMH, fGiaBan_USD, iSoLuongBan, fMucGiamGia)
as
select iMaHD, iMaMH, fGiaBan*0.00004, iSoLuongBan, fMucGiamGia
from tblChiTietHoaDon
go

select * from vw_B417_HoaDon_theo_USD
go
 
--Tạo view thêm thông tin tên hàng vào chi tiết phiếu nhập
create view vw_B418_ThongTinTenHang_CTPhieuNhap
as
select iMaPN, tblChiTietPhieuNhap.iMaMH, fGiaNhap, iSoLuongNhap, sTenMH
from tblChiTietPhieuNhap, tblMatHang
where tblChiTietPhieuNhap.iMaMH = tblMatHang.iMaMH
go

select * from vw_B418_ThongTinTenHang_CTPhieuNhap
go
 

 

 

 -------------

 create view view_all_Bill -- view nhìn bảng 
 as
 select hd.iMaHD as [Mã hóa đơn], kh.sTenKH as [Tên khách hàng], nv.sTenNV as [Tên nhân viên], mh.sTenMH as [Tên mặt hàng], cthd.iSoLuongBan as [Số lượng mua],
	cthd.fGiaBan as [Giá bán], cthd.fMucGiamGia as [Mức giảm giá], cthd.fGiaBan*cthd.iSoLuongBan*(1-cthd.fMucGiamGia) as [Thành tiền]
 from tblChiTietHoaDon cthd inner join tblHoaDon hd on cthd.iMaHD=hd.iMaHD
 inner join tblKhachHang kh on kh.iMaKH=hd.iMaKH
 inner join tblNhanVien nv on nv.iMaNV=hd.iMaNV
 inner join tblMatHang mh on mh.iMaMH =cthd.iMaMH;
 select *from view_all_Bill

 --view hiển thị hóa đơn kèm tổng tiền của hóa đơn đấy
 create view view_Bill_with_totalMoney
as
select tblChiTietHoaDon.iMaHD as [Mã hóa đơn],dNgayBan as [Ngày tạo hóa đơn] , count(iMaMH) as [Tổng số mặt hàng], sum((fGiaBan * iSoLuongBan) *(1-fMucGiamGia)) as [Tổng tiền] 
from tblHoaDon, tblChiTietHoaDon
where tblHoaDon.iMaHD = tblChiTietHoaDon.iMaHD
group by tblChiTietHoaDon.iMaHD, dNgayBan;

select *from view_Bill_with_totalMoney 
select imaKh as [Mã khách hàng], stenkh+' - '+sDienThoai as [Thông tin] from tblKhachHang;
select imamh as [Mã mặt hàng],stenmh as [Thông tin] from tblMatHang where iMaLH=1
select imalh as [Mã loại hàng], sTenLH as [Thông tin] from tblLoaiHang