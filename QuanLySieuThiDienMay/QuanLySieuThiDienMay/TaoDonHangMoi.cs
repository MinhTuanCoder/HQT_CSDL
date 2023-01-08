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
    public partial class TaoDonHangMoi : Form
    {
        public TaoDonHangMoi()
        {
            InitializeComponent();
        }
        int index;
        DataTable dtEmployee,dtCategory, dtCustomer, dtProduct;
        SqlDataAdapter daCustomer = new SqlDataAdapter();
        SqlDataAdapter daProduct = new SqlDataAdapter();
        SqlDataAdapter daEmployee = new SqlDataAdapter();
        SqlDataAdapter daCategory = new SqlDataAdapter();
        DataTable dtBill= new DataTable();

        private void cbb_Category_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                daProduct = new SqlDataAdapter("select imamh as [Mã mặt hàng],stenmh as [Thông tin] from tblMatHang where iMaLH=" + cbb_Category.SelectedValue.ToString(), sqlcon);
                dtProduct = new DataTable();
                daProduct.Fill(dtProduct);
                cbb_Product.DataSource = dtProduct;
                cbb_Product.DisplayMember = "Thông tin";
                cbb_Product.ValueMember = "Mã mặt hàng";
                
            }
            catch
            {
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                
                ThemKhachHang newCusomer = new ThemKhachHang();
      
                newCusomer.ShowDialog();
                radioButton2.Checked = true;
                this.TaoDonHangMoi_Load(sender,e);

            }
            
        }
        public int checkCart(string mahd)
        {
            int size = dgv_bill_detail.Rows.Count;
            for (int i = 0;i < size;i++)
            {
                if (dgv_bill_detail.Rows[i].Cells[0].Value.ToString() == mahd)
                    return i;
            }
            return -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Nhấn nút chốt đơn, dữ liệu lưu từng dòng chi tiết hóa đơn
            //Tạo hóa đơn
            SqlCommand cmd = new SqlCommand("insert into tblHoaDon values (" + cbb_Employee.SelectedValue.ToString() + "," + cbb_Customer.SelectedValue.ToString() + ",'" + DateTime.Now.ToString("MM/dd/yyyy") + "')", sqlcon);
            cmd.ExecuteNonQuery();
            SqlDataAdapter daMaHD = new SqlDataAdapter("select top(1) imahd from tblHoaDon order by iMaHD desc", sqlcon);
            DataTable dtmahd = new DataTable();
            daMaHD.Fill(dtmahd);
            string mahd = dtmahd.Rows[0][0].ToString(); //Lưu mã hóa đơn vừa tạo
            //Thêm dữ liệu vào chi tiết hóa đơn\
           for(int i = 0; i < dgv_bill_detail.Rows.Count; i++)
            {
                string mahang = dtBill.Rows[i][0].ToString();
                string soluong= dtBill.Rows[i][2].ToString();
                string giaban = dtBill.Rows[i][3].ToString();
                string mucgiamgia = dtBill.Rows[i][4].ToString();
                SqlCommand insert = new SqlCommand("insert into tblChiTietHoaDOn values (" + mahd + "," + mahang + "," + giaban + "," + soluong + "," + mucgiamgia + ")", sqlcon);
                insert.ExecuteNonQuery();
            }
            //Đóng form
          
            this.Close();
        }

        private void dgv_bill_detail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             index = e.RowIndex;
            //Hiển thị
            try
            {
                cbb_Product.SelectedValue = dgv_bill_detail.Rows[index].Cells[0].Value.ToString();
                numericUpDown1.Value =  Convert.ToInt32(dgv_bill_detail.Rows[index].Cells[2].Value);
                numericUpDown3.Value = Convert.ToInt32(dgv_bill_detail.Rows[index].Cells[4].Value);
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dtBill.Rows[index].Delete();
            Double sum = 0;
            for (int i = 0; i < dgv_bill_detail.Rows.Count; i++)
            {
                sum += Convert.ToDouble(dtBill.Rows[i][5]);
            }
            tb_sum_bill.Text = sum.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            dtBill.Rows[index][2] = Convert.ToInt32(numericUpDown1.Value);
            //Cập nhật lại thành tiền
            dtBill.Rows[index][5] = Convert.ToInt32(dtBill.Rows[index][2]) * Convert.ToInt32(dtBill.Rows[index][3]) * (1 - Convert.ToInt32(dtBill.Rows[index][4]));
            Double sum = 0;
            for (int i = 0; i < dgv_bill_detail.Rows.Count; i++)
            {
                sum += Convert.ToDouble(dtBill.Rows[i][5]);
            }
            tb_sum_bill.Text = sum.ToString();
        }

       

        private void dgv_bill_detail_CellValueChanged_1(object sender, DataGridViewCellValueEventArgs e)
        {
            Double sum = 0;
            for (int i = 0; i < dgv_bill_detail.Rows.Count; i++)
            {
                sum += Convert.ToDouble(dtBill.Rows[i][5]);
            }
            tb_sum_bill.Text = sum.ToString();
        }

        private void cbb_Product_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                
                //Mỗi khi chọn mặt hàng sẽ hiển thị giá bán của mặt hàng đó
                SqlDataAdapter daGia = new SqlDataAdapter("select fgiatien  from tblMatHang where imamh=" + cbb_Product.SelectedValue.ToString(), sqlcon);
                DataTable dtGia = new DataTable();
                daGia.Fill(dtGia);
                tb_gia.Text = dtGia.Rows[0][0].ToString();
            }
            catch { }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkCart(cbb_Product.SelectedValue.ToString()) != -1 ) //nếu đã tồn tại mặt hàng này
            {
                int i = checkCart(cbb_Product.SelectedValue.ToString());
                //Tăng số lượng

                dtBill.Rows[i][2] = Convert.ToInt32(numericUpDown1.Value) + Convert.ToInt32(dtBill.Rows[i][2]);
                //Cập nhật lại thành tiền
                dtBill.Rows[i][5] = Convert.ToInt32(dtBill.Rows[i][2]) * Convert.ToInt32(dtBill.Rows[i][3]) * (1 - Convert.ToInt32(dtBill.Rows[i][4]));
            }
            else
            {
                Double sl, gia, giamgia;
                sl = Convert.ToInt32(numericUpDown1.Value);
                gia = Convert.ToDouble(tb_gia.Text);
                giamgia = Convert.ToDouble(numericUpDown3.Value);
                dtBill.Rows.Add(cbb_Product.SelectedValue.ToString(),cbb_Product.Text,sl,gia,giamgia,sl*gia*(1-giamgia));
            }
            Double sum = 0;
            for (int i = 0; i < dgv_bill_detail.Rows.Count; i++)
            {
                sum += Convert.ToDouble(dtBill.Rows[i][5]);
            }
            tb_sum_bill.Text = sum.ToString();

        }

        public static SqlConnection sqlcon = new SqlConnection(QuanLySieuThiDienMay.Properties.Settings.Default.strConnect);
        private void TaoDonHangMoi_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            try
            {
                if (sqlcon.State != ConnectionState.Open) sqlcon.Open();
                
                daCustomer = new SqlDataAdapter("select imaKh as [Mã khách hàng], stenkh+' - '+sDienThoai as [Thông tin] from tblKhachHang", sqlcon);
                dtCustomer = new DataTable();
                daCustomer.Fill(dtCustomer);
                //
                daEmployee = new SqlDataAdapter("select imanv as [Mã nhân viên] from tblNhanvien", sqlcon);
                dtEmployee = new DataTable();
                daEmployee.Fill(dtEmployee);
                //
                daCategory = new SqlDataAdapter("select imalh as [Mã loại hàng], sTenLH as [Thông tin] from tblLoaiHang", sqlcon);
                dtCategory = new DataTable();
                daCategory.Fill(dtCategory);
                //
                cbb_Customer.DataSource = dtCustomer;
                cbb_Customer.DisplayMember = "Thông tin";
                cbb_Customer.ValueMember = "Mã khách hàng";
                //
                cbb_Employee.DataSource = dtEmployee;
                cbb_Employee.DisplayMember = "Mã nhân viên";
                cbb_Employee.ValueMember = "Mã nhân viên";
                //

                cbb_Category.DataSource = dtCategory;
                cbb_Category.DisplayMember = "Thông tin";
                cbb_Category.ValueMember = "Mã loại hàng";
                
                //
                dtBill.Columns.Add("Mã mặt hàng");
                dtBill.Columns.Add("Tên mặt hàng");
                dtBill.Columns.Add("Số lượng");
                dtBill.Columns.Add("Giá tiền");
                dtBill.Columns.Add("Giảm giá");
                dtBill.Columns.Add("Thành tiền");
                dgv_bill_detail.DataSource = dtBill;
            }
            
            catch
            {

            }



        }
    }
}
