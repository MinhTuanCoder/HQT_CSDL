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
                this.Hide();
                newCusomer.ShowDialog();

            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            dtBill.Rows.Add(cbb_Product.SelectedValue.ToString(),cbb_Product.Text,numericUpDown1.Value.ToString());
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
                dgv_bill_detail.DataSource = dtBill;
            }
            
            catch
            {

            }



        }
    }
}
