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
