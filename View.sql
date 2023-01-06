--View

--Tạo view hiển  thị tất cả các hóa đơn
select hd.iMaHD, nv.sTenNV,kh.sTenKH,mh.sTenMH  
from 
tblChiTietHoaDon cthd inner join  tblHoaDon hd on cthd.iMaHD=hd.iMaHD
inner join tblMatHang mh on cthd.iMaMH = mh.iMaMH
inner join tblNhanVien nv on nv.iMaNV = hd.iMaNV
inner join tblKhachHang kh on kh.iMaKH=hd.iMaKH;


abc123