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
    public partial class TaoPhieuNhap : Form
    {
        public TaoPhieuNhap()
        {
            InitializeComponent();
        }
        int index;
        DataTable dtEmployee, dtCategory, dtProduct,dtImport;
        SqlDataAdapter daProduct = new SqlDataAdapter();
        SqlDataAdapter daEmployee = new SqlDataAdapter();
        SqlDataAdapter daCategory = new SqlDataAdapter();
        public int checkCart(string mamh)
        {
            int size = dgv_import_detail.Rows.Count;
            for (int i = 0; i < size; i++)
            {
                if (dgv_import_detail.Rows[i].Cells[0].Value.ToString() == mamh)
                    return i;
            }
            return -1;
        }


        private void cbb_Category_SelectedValueChanged(object sender, EventArgs e)
        {   //Load thông tin mặt hàng lên combobox
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

        private void dgv_bill_detail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            //Hiển thị
            try
            {
                cbb_Product.SelectedValue = dgv_import_detail.Rows[index].Cells[0].Value.ToString();
                numericUpDown1.Value = Convert.ToInt32(dgv_import_detail.Rows[index].Cells[2].Value);
                tb_giaNhap.Text = dgv_import_detail.Rows[index].Cells[3].Value.ToString();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_add_cart_Click(object sender, EventArgs e)
        {

            if (checkCart(cbb_Product.SelectedValue.ToString()) == -1) //Nếu chưa có trong giỏ hàng thì thêm
            {
                Double sl, gia;
                sl = Convert.ToInt32(numericUpDown1.Value);
                gia = Convert.ToDouble(tb_giaNhap.Text);

                dtImport.Rows.Add(cbb_Product.SelectedValue.ToString(), cbb_Product.Text, sl, gia, sl * gia);
            }
            else
            {
                int i = checkCart(cbb_Product.SelectedValue.ToString());
                //Tăng số lượng
                dtImport.Rows[i][2] = Convert.ToInt32(numericUpDown1.Value) + Convert.ToInt32(dtImport.Rows[i][2]);
                //Cập nhật lại thành tiền
                dtImport.Rows[i][4] = Convert.ToInt32(dtImport.Rows[i][2]) * Convert.ToInt32(dtImport.Rows[i][3]);
            }
            Double sum = 0;
            for (int i = 0; i < dgv_import_detail.Rows.Count; i++)
            {
                sum += Convert.ToDouble(dtImport.Rows[i][4]);
            }
            tb_sum_bill.Text = sum.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                ThemMatHangMoi newmh = new ThemMatHangMoi();
                newmh.ShowDialog();
                this.TaoPhieuNhap_Load(sender, e);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dtImport.Rows[index].Delete();
            Double sum = 0;
            for (int i = 0; i < dgv_import_detail.Rows.Count; i++)
            {
                sum += Convert.ToDouble(dtImport.Rows[i][4]);
            }
            tb_sum_bill.Text = sum.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dtImport.Rows[index][2] = Convert.ToInt32(numericUpDown1.Value);
            dtImport.Rows[index][3] = Convert.ToInt32(tb_giaNhap.Text);
            //Cập nhật lại thành tiền
            dtImport.Rows[index][4] = Convert.ToInt32(dtImport.Rows[index][2]) * Convert.ToInt32(dtImport.Rows[index][3]);
            Double sum = 0;
            for (int i = 0; i < dgv_import_detail.Rows.Count; i++)
            {
                sum += Convert.ToDouble(dtImport.Rows[i][4]);
            }
            tb_sum_bill.Text = sum.ToString();
        }

        private void btn_ChotPN_Click(object sender, EventArgs e)
        {
            try
            {
                //Tạo phiếu nhập
                SqlCommand cmd = new SqlCommand("insert into tblPhieuNhap values (" + cbb_Employee.SelectedValue.ToString() +",'" + DateTime.Now.ToString("MM/dd/yyyy") + "')", sqlcon);
                cmd.ExecuteNonQuery();

                //
                SqlDataAdapter daMapn = new SqlDataAdapter("select top(1) imapn from tblPhieuNhap order by iMapn desc", sqlcon);
                DataTable dtmapn = new DataTable();
                daMapn.Fill(dtmapn);
                string mapn = dtmapn.Rows[0][0].ToString(); //Lưu mã hóa đơn vừa tạo

                for (int i = 0; i < dgv_import_detail.Rows.Count; i++)
                {
                    string mahang = dtImport.Rows[i][0].ToString();
                    string soluong = dtImport.Rows[i][2].ToString();
                    string gianhap = dtImport.Rows[i][3].ToString();
                    SqlCommand insert = new SqlCommand("insert into tblChiTietPhieunhap values (" + mapn + "," + mahang + "," + gianhap + "," + soluong  + ")", sqlcon);
                    insert.ExecuteNonQuery();
                }
                //Đóng form

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static SqlConnection sqlcon = new SqlConnection(QuanLySieuThiDienMay.Properties.Settings.Default.strConnect);


        private void TaoPhieuNhap_Load(object sender, EventArgs e)
        {
            
            try
            {
                radioButton1.Checked = false;
                if (sqlcon.State != ConnectionState.Open) sqlcon.Open();

                
                //
                daEmployee = new SqlDataAdapter("select imanv as [Mã nhân viên] from tblNhanvien", sqlcon);
                dtEmployee = new DataTable();
                daEmployee.Fill(dtEmployee);
                //
                daCategory = new SqlDataAdapter("select imalh as [Mã loại hàng], sTenLH as [Thông tin] from tblLoaiHang", sqlcon);
                dtCategory = new DataTable();
                daCategory.Fill(dtCategory);
          
                //
                cbb_Employee.DataSource = dtEmployee;
                cbb_Employee.DisplayMember = "Mã nhân viên";
                cbb_Employee.ValueMember = "Mã nhân viên";
                //

                cbb_Category.DataSource = dtCategory;
                cbb_Category.DisplayMember = "Thông tin";
                cbb_Category.ValueMember = "Mã loại hàng";
                //
                dtImport = new DataTable();
                dtImport.Columns.Add("Mã mặt hàng");
                dtImport.Columns.Add("Tên mặt hàng");
                dtImport.Columns.Add("Số lượng");
                dtImport.Columns.Add("Giá tiền");
                dtImport.Columns.Add("Thành tiền");
                dgv_import_detail.DataSource = dtImport;
            }

            catch
            {

            }
        }
    }
}
