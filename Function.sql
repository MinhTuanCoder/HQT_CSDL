--Function
--Tạo hàm trả về bảng chứa thông tin chi tiết của 1 phiếu nhập , đầu vào là 1 mã phiếu nhập
Create function func_view_detail_Import (@MaPN int)
Returns table as
Return(
	Select ctpn.iMaMH as [Mã mặt hàng], sTenMH as [Tên mặt hàng], fGiaNhap as [Giá nhập], iSoluongNhap as [Số lượng nhập], fGiaNhap * iSoluongNhap as [Thành tiền] 
	from tblChiTietPhieuNhap ctpn, tblMatHang mh where ctpn.iMaMH = mh.iMaMH  and ctpn.iMaPN = @MaPN)


select * from dbo.function_1(2)
select *from view_all_Bill