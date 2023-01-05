using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySieuThiDienMay
{
    public partial class FormChuongTrinh : Form
    {
        public FormChuongTrinh()
        {
            InitializeComponent();
        }
        int index;
        DataTable dtEmployee ,dtCustomer,dtSupplier,dtCategory, dtProduct;
        SqlDataAdapter daEmployee = new SqlDataAdapter();
        SqlDataAdapter daCustomer = new SqlDataAdapter();
        SqlDataAdapter daSupplier = new SqlDataAdapter();
        SqlDataAdapter daCategory  =new SqlDataAdapter();
        SqlDataAdapter daProduct = new SqlDataAdapter();
        public static SqlConnection sqlcon = new SqlConnection(QuanLySieuThiDienMay.Properties.Settings.Default.strConnect);
        
        private void FormChuongTrinh_Load(object sender, EventArgs e)
        {
            sqlcon.Open();
            daEmployee = new SqlDataAdapter("exec view_all_Employee", sqlcon) ;
            dtEmployee = new DataTable();
            daEmployee.Fill(dtEmployee);
            dgv_employee.DataSource= dtEmployee;
            // 
            
            daCustomer = new SqlDataAdapter("exec view_all_Customer", sqlcon);
            dtCustomer = new DataTable();
            daCustomer.Fill(dtCustomer);
            dgv_customer.DataSource = dtCustomer;
            //

            daSupplier = new SqlDataAdapter("exec view_all_Supplier", sqlcon);
            dtSupplier = new DataTable();
            daSupplier.Fill(dtSupplier);
            dgv_Supplier.DataSource = dtSupplier;
            //
            daCategory = new SqlDataAdapter("exec view_all_Category", sqlcon);
            dtCategory = new DataTable();
            daCategory.Fill(dtCategory);
            dgv_Category.DataSource = dtCategory;
            //
            daProduct = new SqlDataAdapter("exec view_all_Product", sqlcon);
            dtProduct = new DataTable();
            daProduct.Fill(dtProduct);
            dgv_Product.DataSource = dtProduct;
            //Load dữ liệu lên combobox nhà cung cấp
            cbb_Supplier.DataSource = dtSupplier;
            cbb_Supplier.DisplayMember = "Tên nhà cung cấp";
            cbb_Supplier.ValueMember = "Mã nhà cung cấp";
            //Load dữ liệu lên combobox Loại hàng
            cbb_Category.DataSource = dtCategory;
            cbb_Category.DisplayMember = "Tên loại hàng";
            cbb_Category.ValueMember = "Mã loại hàng";

        }


        private void FormChuongTrinh_FormClosing(object sender, FormClosingEventArgs e)
        {
             Application.Exit();
         
        }

        private void dgv_employee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            try
            {
                
                tb_MaNV.Text = dgv_employee.Rows[index].Cells[0].Value.ToString();
                tb_HoTen.Text = dgv_employee.Rows[index].Cells[1].Value.ToString();
                tb_SDT_NV.Text = dgv_employee.Rows[index].Cells[4].Value.ToString();
                tb_HSL.Text = dgv_employee.Rows[index].Cells[8].Value.ToString();
                tb_LuongCoBan.Text = dgv_employee.Rows[index].Cells[7].Value.ToString();
                tb_PhuCap.Text = dgv_employee.Rows[index].Cells[9].Value.ToString();
                tb_DiaChi.Text = dgv_employee.Rows[index].Cells[3].Value.ToString();
                birthDay.Text = dgv_employee.Rows[index].Cells[5].Value.ToString();
                startwork.Text = dgv_employee.Rows[index].Cells[6].Value.ToString();
                if (dgv_employee.Rows[index].Cells[2].Value.ToString() == "Nam")
                {
                    checkNam.Checked = true;
                    checkNu.Checked = false;
                }
                else
                {
                    checkNam.Checked = false ;
                    checkNu.Checked = true;
                }
                    

            }
            catch
            {

            }
        }

        private void btn_timKiem_Click(object sender, EventArgs e)
        {
            
            string findX = tb_TimKiem.Text;
            string sql_efind = "";
            sql_efind = "exec find_Employee '" + findX + "'";
            daEmployee = new SqlDataAdapter(sql_efind, sqlcon);
            dtEmployee.Rows.Clear();
            daEmployee.Fill(dtEmployee);
            dgv_employee.DataSource = dtEmployee;   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            string gioiTinh = "Nam";
            if (checkNam.Checked == false)
                gioiTinh = "Nữ";
            string cmd_Insert = "insert into tblNhanVien values(N'" + tb_HoTen.Text + "'," + "N'" + gioiTinh + "',N'" + tb_DiaChi.Text + "', '" + tb_SDT_NV.Text + "','" + birthDay.Value.Date.ToString("MM/dd/yyyy") + "', '" + startwork.Value.Date.ToString("MM/dd/yyyy") + "'," + tb_LuongCoBan.Text + "," + tb_HSL.Text + "," + tb_PhuCap.Text + ")";
            SqlCommand cmd = new SqlCommand(cmd_Insert, sqlcon);
            try
            {
                cmd.ExecuteNonQuery();
                dtEmployee.Rows.Clear();
                daEmployee.Fill(dtEmployee);
                dgv_employee.DataSource = dtEmployee;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string gioiTinh = "Nam";
            if (checkNam.Checked == false) gioiTinh = "Nữ";
            string sql_cmd = "update  tblNhanVien set sTenNV = N'" + tb_HoTen.Text + "',sDiaChi=N'" + tb_DiaChi.Text + "', sDienThoai='" + tb_SDT_NV.Text + "',fHSL=" + tb_HSL.Text + ",fLuongCoban=" + tb_LuongCoBan.Text+
                ",fPhucap="+tb_PhuCap.Text+",dNgaySinh='"+birthDay.Value.Date.ToString("MM/dd/yyyy")+"',dNgayVaoLam='"+startwork.Value.Date.ToString("MM/dd/yyyy")+ "',sGioiTinh=N'"+gioiTinh+
                "' where iManv = " + tb_MaNV.Text;
            SqlCommand cmd = new SqlCommand(sql_cmd, sqlcon);
            try
            {
                cmd.ExecuteNonQuery();
                dtEmployee.Rows.Clear();
                daEmployee.Fill(dtEmployee);
                dgv_employee.DataSource = dtEmployee;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            string sql_cmd = "delete from tblNhanVien where iManv = " + tb_MaNV.Text;
            SqlCommand cmd = new SqlCommand(sql_cmd, sqlcon);
            try
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa Nhân viên có mã " + tb_maKH.Text, "Nhắc nhở", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    cmd.ExecuteNonQuery();
                    dtEmployee.Rows.Clear();
                    daEmployee.Fill(dtEmployee);
                    dgv_employee.DataSource = dtEmployee;
                    MessageBox.Show("Đã xóa thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }


        //========================Khách Hàng=================================

        private void dgv_customer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            try
            {
                tb_maKH.Text = dgv_customer.Rows[index].Cells[0].Value.ToString();
                tb_HoTen_KH.Text = dgv_customer.Rows[index].Cells[1].Value.ToString();
                tb_DiaChi_KH.Text = dgv_employee.Rows[index].Cells[3].Value.ToString();
                tb_SDT_KH.Text = dgv_customer.Rows[index].Cells[4].Value.ToString();
                tb_solanmua.Text= dgv_customer.Rows[index].Cells[5].Value.ToString();
                if (dgv_customer.Rows[index].Cells[2].Value.ToString() == "Nam")
                {
                    checkNam_KH.Checked = true;
                    checkNu_KH.Checked = false;
                }
                else
                {
                    checkNam_KH.Checked = false;
                    checkNu_KH.Checked = true;
                }
            }
            catch { }
        }

        
        private void btn_add_customer_Click(object sender, EventArgs e)
        {
            string gioiTinh = "Nam";
            if (checkNam.Checked == false)
                gioiTinh = "Nữ";
            string cmd_Insert = "insert into tblKhachHang values(N'" + tb_HoTen_KH.Text + "'," + "N'" + gioiTinh + "',N'" + tb_DiaChi_KH.Text + "', '" + tb_SDT_KH.Text + "',Null)";
            SqlCommand cmd = new SqlCommand(cmd_Insert, sqlcon);
            try
            {
                cmd.ExecuteNonQuery();
                dtCustomer.Rows.Clear();
                daCustomer.Fill(dtCustomer);
                dgv_customer.DataSource = dtCustomer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_update_customer_Click(object sender, EventArgs e)
        {
            string gioiTinh = "Nam";
            if (checkNam.Checked == false) gioiTinh = "Nữ";
            string sql_cmd = "update  tblKhachHang set sTenKH = N'" + tb_HoTen_KH.Text + "',sDiaChi=N'" + tb_DiaChi_KH.Text + "', sDienThoai='" + tb_SDT_KH.Text +
                 "',sGioiTinh=N'" + gioiTinh + "'where iMaKH = " + tb_maKH.Text;
            SqlCommand cmd = new SqlCommand(sql_cmd, sqlcon);
            try
            {
             
                cmd.ExecuteNonQuery();
                dtCustomer.Rows.Clear();
                daCustomer.Fill(dtCustomer);
                dgv_customer.DataSource = dtCustomer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_delete_customer_Click(object sender, EventArgs e)
        {
            string sql_cmd = "delete from tblKhachHang where iMaKH = " + tb_maKH.Text;
            SqlCommand cmd = new SqlCommand(sql_cmd, sqlcon);
            try
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa Khách hàng có mã " + tb_maKH.Text, "Nhắc nhở", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    cmd.ExecuteNonQuery();
                    dtCustomer.Rows.Clear();
                    daCustomer.Fill(dtCustomer);
                    dgv_customer.DataSource = dtCustomer;
                    MessageBox.Show("Đã xóa thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void btn_find_customer_Click(object sender, EventArgs e)
        {
            string findX = tb_TimKiem_KH.Text;
            string sql_efind = "";
            sql_efind = "exec find_Customer '" + findX + "'";
            daCustomer = new SqlDataAdapter(sql_efind, sqlcon);
            dtCustomer.Rows.Clear();
            daCustomer.Fill(dtCustomer);
            dgv_customer.DataSource = dtCustomer;
        }

        //===================Nhà cung cấp ==================

        private void dgv_Supplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            try
            {
                
                tb_Ma_NCC.Text = dgv_Supplier.Rows[index].Cells[0].Value.ToString();
                tb_Ten_NCC.Text = dgv_Supplier.Rows[index].Cells[1].Value.ToString();
                tb_DiaChi_NCC.Text = dgv_Supplier.Rows[index].Cells[2].Value.ToString();
                tb_SDT_NCC.Text = dgv_Supplier.Rows[index].Cells[3].Value.ToString();
            }
            catch { }
        }

        private void btn_delete_supplier_Click(object sender, EventArgs e)
        {
            string sql_cmd = "delete from tblNhaCungCap where iMaNCC = " + tb_Ma_NCC.Text;
            SqlCommand cmd = new SqlCommand(sql_cmd, sqlcon);
            try
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa Khách hàng có mã " + tb_Ma_NCC.Text, "Nhắc nhở", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    cmd.ExecuteNonQuery();
                    dtSupplier.Rows.Clear();
                    daSupplier.Fill(dtSupplier);
                    dgv_Supplier.DataSource = dtSupplier;
                    MessageBox.Show("Đã xóa thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        

        private void btn_add_supplier_Click(object sender, EventArgs e)
        {
            string cmd_Insert = "insert into tblNhaCungCap values(N'" + tb_Ten_NCC.Text + "'," + "N'"+ tb_DiaChi_NCC.Text + "', '" + tb_SDT_NCC.Text + "')";
            SqlCommand cmd = new SqlCommand(cmd_Insert, sqlcon);
            try
            {
                cmd.ExecuteNonQuery();
                dtSupplier.Rows.Clear();
                daSupplier.Fill(dtSupplier);
                dgv_Supplier.DataSource = dtSupplier;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void btn_update_supplier_Click(object sender, EventArgs e)
        {
            string sql_cmd = "update tblNhaCungCap set sTenNCC = N'" + tb_Ten_NCC
                .Text + "', sDiaChi=N'" + tb_DiaChi_NCC.Text + "', sDienThoai='" + tb_SDT_NCC.Text + "' where iMaNCC = " + tb_Ma_NCC.Text;

            SqlCommand cmd = new SqlCommand(sql_cmd, sqlcon);
            try
            {
                
                cmd.ExecuteNonQuery();
                dtSupplier.Rows.Clear();
                daSupplier.Fill(dtSupplier);
                dgv_Supplier.DataSource = dtSupplier;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void btn_find_supplier_Click(object sender, EventArgs e)
        {
            string findX = tb_TimKiem_NCC.Text;
            string sql_efind = "";
            sql_efind = "exec find_Supplier '" + findX + "'";
            daSupplier = new SqlDataAdapter(sql_efind, sqlcon);
            dtSupplier.Rows.Clear();
            daSupplier.Fill(dtSupplier);
            dgv_Supplier.DataSource = dtSupplier;
        }

        



        //==========================Loại hàng ================
        private void dgv_Category_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            try
            {

                tb_Ma_LH.Text = dgv_Category.Rows[index].Cells[0].Value.ToString();
                tb_Ten_LH.Text = dgv_Category.Rows[index].Cells[1].Value.ToString();
                
            }
            catch { }
        }

        

        private void btn_add_category_Click(object sender, EventArgs e)
        {
            string cmd_Insert = "insert into tblLoaiHang values(N'" + tb_Ten_LH.Text + "')";
            SqlCommand cmd = new SqlCommand(cmd_Insert, sqlcon);
            try
            {
                cmd.ExecuteNonQuery();
                dtCategory.Rows.Clear();
                daCategory.Fill(dtCategory);
                dgv_Category.DataSource = dtCategory;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void btn_update_category_Click(object sender, EventArgs e)
        {
            string sql_cmd = "update tblLoaiHang set sTenLH = N'" + tb_Ten_LH.Text+
              "' where iMaLH = " + tb_Ma_LH.Text;

            SqlCommand cmd = new SqlCommand(sql_cmd, sqlcon);
            try
            {

                cmd.ExecuteNonQuery();
                dtCategory.Rows.Clear();
                daCategory.Fill(dtCategory);
                dgv_Category.DataSource = dtCategory;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void btn_find_category_Click(object sender, EventArgs e)
        {
            string findX = tb_TimKiem_LH.Text;
            string sql_efind = "";
            sql_efind = "exec find_Category '" + findX + "'";
            daCategory = new SqlDataAdapter(sql_efind, sqlcon);
            dtCategory.Rows.Clear();
            daCategory.Fill(dtCategory);
            dgv_Category.DataSource = dtCategory;
        }

        private void btn_delete_category_Click(object sender, EventArgs e)
        {
            string sql_cmd = "delete from tblLoaiHang where iMaLH = " + tb_Ma_LH.Text;
            SqlCommand cmd = new SqlCommand(sql_cmd, sqlcon);
            try
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa Mặt hàng có mã " + tb_Ma_LH.Text, "Nhắc nhở", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    cmd.ExecuteNonQuery();
                    dtCategory.Rows.Clear();
                    daCategory.Fill(dtCategory);
                    dgv_Category.DataSource = dtCategory;
                    MessageBox.Show("Đã xóa thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        //++++++++++++++++++Mặt hàng+++++++++++++++++++++
        private void dgv_Product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            try
            {
                
                tb_Ma_MH.Text = dgv_Product.Rows[index].Cells[0].Value.ToString();
                tb_Ten_MH.Text = dgv_Product.Rows[index].Cells[1].Value.ToString();
                num_GiaTien.Text = dgv_Product.Rows[index].Cells[6].Value.ToString();
                num_SoLuong.Text = dgv_Product.Rows[index].Cells[5].Value.ToString();
                tb_DonViTinh.Text = dgv_Product.Rows[index].Cells[4].Value.ToString();

                cbb_Supplier.SelectedValue = Int32.Parse(dgv_Product.Rows[index].Cells[2].Value.ToString());
                cbb_Category.SelectedValue = Int32.Parse(dgv_Product.Rows[index].Cells[3].Value.ToString());

            }
            catch { }
        }

        private void btn_add_product_Click(object sender, EventArgs e)
        {
            string cmd_Insert = "insert into tblMatHang values(N'" + tb_Ten_MH.Text +"',"+cbb_Supplier.SelectedValue.ToString()+","+cbb_Category.SelectedValue.ToString()+",N'"+ tb_DonViTinh.Text+"',"+num_SoLuong.Value.ToString()+","+num_GiaTien.Value.ToString()+")";
            SqlCommand cmd = new SqlCommand(cmd_Insert, sqlcon);
            try
            {
                cmd.ExecuteNonQuery();
                dtProduct.Rows.Clear();
                daProduct.Fill(dtProduct);
                dgv_Product.DataSource = dtProduct;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_update_product_Click(object sender, EventArgs e)
        {
            string sql_cmd = "update tblMatHang set sTenMh = N'" + tb_Ten_MH.Text +
                "',imancc = "+cbb_Supplier.SelectedValue.ToString()+",imalh="+
                cbb_Category.SelectedValue.ToString()+",sDonvitinh=N'"+
                tb_DonViTinh.Text+"',isoluong="+num_SoLuong.Value.ToString()+
                ",fGiatien="+num_GiaTien.Value.ToString()+" where iMaMH = " + tb_Ma_MH.Text;

            SqlCommand cmd = new SqlCommand(sql_cmd, sqlcon);
            try
            {
                
                cmd.ExecuteNonQuery();
                dtProduct.Rows.Clear();
                daProduct.Fill(dtProduct);
                dgv_Product.DataSource = dtProduct;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_delete_product_Click(object sender, EventArgs e)
        {
            string sql_cmd = "delete from tblMatHang where iMaMH = " + tb_Ma_MH.Text;
            SqlCommand cmd = new SqlCommand(sql_cmd, sqlcon);
            try
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa Mặt hàng có mã " + tb_Ma_MH.Text, "Nhắc nhở", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    
                    cmd.ExecuteNonQuery();
                    dtProduct.Rows.Clear();
                    daProduct.Fill(dtProduct);
                    dgv_Product.DataSource = dtProduct;
                    MessageBox.Show("Đã xóa thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }




    }
}
