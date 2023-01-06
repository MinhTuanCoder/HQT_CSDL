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
	where tblLoaiHang.sMaLH = tblMatHang.sMaLH
	and tblMatHang.sMaMH = tblChiTietHoaDon.sMaMH
	group by sTenLH 
go

select * from cv_B41_SoLuongHangDaBan;
go

--Tạo view thống kê tổng hợp theo từng hóa đơn, gồm: Số hóa đơn, Ngày bán, Tổng số tiền, Tổng số mặt hàng
create view vv_B42_TongHopDonDat (sMaHD, dNgayBan, fTongSoTien , fTongSoMatHang) as
select tblChiTietHoaDon.sMaHD,dNgayBan, sum((fGiaBan * iSoLuongBan) *(1-fMucGiamGia)) as fTongSoTien , count(sMaMH) as fTongSoMatHang
from tblHoaDon, tblChiTietHoaDon
where tblHoaDon.sMaHD = tblChiTietHoaDon.sMaHD
group by tblChiTietHoaDon.sMaHD, dNgayBan
go

select * from vv_B42_TongHopDonDat
go

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
	select sMaPN, Count(sMaMH) as [Tổng số mặt hàng], SUM(iSoLuongNhap*fGiaNhap) as [Tổng tiền hàng]
	from tblChiTietPhieuNhap 
	group by sMaPN
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

--Tạo view cho tên nhà cung cấp đã cung cấp những mặt hàng thuộc 1 loại hàng 'Máy tính xách tay’
create view cv_B46_NCC_MayTinhXachTay
as
	select sTenNCC, tblLoaiHang.sMaLH, sTenLH, sTenMH
	from tblNhaCungCap, tblMatHang, tblLoaiHang
	where tblNhaCungCap.sMaNCC = tblMatHang.sMaNCC
	and tblLoaiHang.sMaLH = tblMatHang.sMaLH
	and tblLoaiHang.sMaLH = N'LH01'
go

select * from cv_B46_NCC_MayTinhXachTay; 
go

--Tạo view cho biết số lượng đã nhập của từng loại hàng trong năm 2022 
create view cv_B47_LoaiHangNhap_2022
as
	 select tblMatHang.sMaLH, sum(iSoLuongNhap) as [Số lượng nhập]
	 from tblPhieuNhap, tblChiTietPhieuNhap, tblMatHang
	 where tblPhieuNhap.sMaPN = tblChiTietPhieuNhap.sMaPN
	 and tblChiTietPhieuNhap.sMaMH = tblMatHang.sMaMH
	 and year(dNgayNhap) = 2022 
	 group by tblMatHang.sMaLH
go

select * FROM cv_B47_LoaiHangNhap_2022; 
go

--Tạo view cho biết số lượng và tổng tiền đã bán của từng mặt hàng trong năm 2021
create view vv_B48_TKeMatHangBan2021 (sMaHang, fSoLuongBan , fTongTienBan2021) as
select tblChiTietHoaDon.sMaMH ,count(tblChiTietHoaDon.sMaMH) as fSoLuongBan,sum((tblChiTietHoaDon.fGiaBan * iSoLuongBan)*(1-fMucGiamGia)) as fTongTienBan2021
from tblMatHang,tblChiTietHoaDon,tblHoaDon
where tbLMatHang.sMaMH = tblChiTietHoaDon.sMaMH
and tblChiTietHoaDon.sMaHD = tblHoaDon.sMaHD
and year(tblHoaDon.dNgayBan)=2021
group by tblChiTietHoaDon.sMaMH
go

select * from vv_B48_TKeMatHangBan2021
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
where tblMatHang.sMaMH = tblChiTietHoaDon.sMaMH
group by sTenMH 
go

select * from vw_B410_TbGiaMatHang
go

--Tạo view cho biết tổng số tiền đã bán của từng nhân viên trong năm 2022
create view cv_B411_TongTienBan_NhanVien_2022
as
  select sTenNV, isnull(sum(fGiaBan * iSoLuongBan - fMucGiamGia * fGiaBan * iSoLuongBan),0) AS[Tổng tiền hàng] 
  from tblNhanVien
  left join tblHoaDon on tblNhanVien.sMaNV = tblHoaDon.sMaNV
  left join tblChiTietHoaDon  on tblHoaDon.sMaHD= tblChiTietHoaDon.sMaHD
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
	select [Giới tính] = case sGioiTinh when N'Nam' then N'Nam' else N'Nữ' end, count(sMaKH) as [Số lượng khách] 
	from tblKhachHang 
	group by sGioiTinh 
go

select * from cv_B413_TKe_GioiTinh;
go
 
--Tạo view cho xem danh sách 3 khách hàng mua hàng nhiều lần nhất 
create view cv_B414_3_KH_muaNN
as
	select top (3) tblKhachHang.sMaKH, sTenKH, count(sMaHD) as [Số lần mua ] 
	from tblKhachHang, tblHoaDon
	where tblKhachHang.sMaKH = tblHoaDon.sMaKH
	group by tblKhachHang.sMaKH, sTenKH
	order by count(sMaHD) DESC
go

select * from cv_B414_3_KH_muaNN;
go

--Tạo view thực hiện cập nhật giá bán (tblMatHang.fGiaHang) theo quy tắc:
--Giá bán 1 mặt hàng = Giá mua lớn nhất trong vòng 30 ngày của mặt hàng đó + 10% 
--Tìm giá nhập về max của mỗi mặt hàng theo gom nhóm mã hàng 
--Với 1 ngày đặt về xác định so sánh trừ đi các ngày nhập gần đấy nhất bé hơn 30 ngày thì lấy ra giá mã
create view cv_B415_CapNhatGiaBan
as
	select sMaMH, max(fGiaBan) as [Max 30 day]
	from tblChiTietHoaDon, tblHoaDon
	where tblChiTietHoaDon.sMaHD = tblHoaDon.sMaHD
	and (datediff(day, dNgayBan, getdate())) <= 30
	group by sMaMH
go

select * from cv_B415_CapNhatGiaBan;
go

update tblMatHang 
set fGiaTien = cv_B415_CapNhatGiaBan.[Max 30 day] + 0.1 * cv_B415_CapNhatGiaBan.[Max 30 day]
from cv_B415_CapNhatGiaBan
where tblMatHang.sMaMH = cv_B415_CapNhatGiaBan.sMaMH
go

insert into tblHoaDon values 
('HD11','NV05','KH05', '20221104')
go

insert into tblChiTietHoaDon values 
('HD11','MH06', 21000000, 1, 0)
Go
 
--Tạo view chứa các nhân viên có thâm niên làm việc trên 5 năm
create view vw_B416_NhanVien_ThamNien_tren5nam (sMaNV, sTenNV, Namkinhnghiem)
as
select sMaNV, sTenNV, (year(getdate())-year(tblNhanVien.dNgayVaolam))
from tblNhanVien
where (datediff(day, dNgayVaoLam, getdate())/365) >= 5
go

select * from vw_B416_NhanVien_ThamNien_tren5nam;
go
 
--Tạo view chuyển tiền bán được sang USD (đô la Mĩ)
create view vw_B417_HoaDon_theo_USD (sMaHD, sMaMH, fGiaBan_USD, iSoLuongBan, fMucGiamGia)
as
select sMaHD, sMaMH, fGiaBan*0.00004, iSoLuongBan, fMucGiamGia
from tblChiTietHoaDon
go

select * from vw_B417_HoaDon_theo_USD
go
 
--Tạo view thêm thông tin tên hàng vào chi tiết phiếu nhập
create view vw_B418_ThongTinTenHang_CTPhieuNhap
as
select sMaPN, tblChiTietPhieuNhap.sMaMH, fGiaNhap, iSoLuongNhap, sTenMH
from tblChiTietPhieuNhap, tblMatHang
where tblChiTietPhieuNhap.sMaMH = tblMatHang.sMaMH
go

select * from vw_B418_ThongTinTenHang_CTPhieuNhap
go
 
--Tạo view cho biết những mặt hàng nào được mua bởi những khách hàng ở Hà Nội
create view vw_B419_MatHang_KHHaNoi
as
select tblMatHang.sMaMH, tblMatHang.sTenMH, tblKhachHang.sMaKH, tblKhachHang.sTenKH, tblKhachHang.sDiaChi
from tblMatHang, tblKhachHang, tblHoaDon, tblChiTietHoaDon
where tblMatHang.sMaMH = tblChiTietHoaDon.sMaMH
and tblHoaDon.sMaHD = tblChiTietHoaDon.sMaHD
and tblHoaDon.sMaKH = tblKhachHang.sMaKH
and tblKhachHang.sDiaChi = N'Hà Nội'
go

select * from vw_B419_MatHang_KHHaNoi
go
 
--Tạo view cho biết số lượng mặt hàng được mua bởi các khách hàng ở Hà Nội
create view vw_B420_MatHang_KHHaNoi_SoLuongMua
as
select sMaKH, count(sMaMH) as [Số lượng mua HN]
from vw_B419_MatHang_KHHaNoi
group by sMaKH
go

select * from vw_B420_MatHang_KHHaNoi_SoLuongMua
go
