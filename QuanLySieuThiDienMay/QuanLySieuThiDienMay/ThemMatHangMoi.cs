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
    public partial class ThemMatHangMoi : Form
    {
        public ThemMatHangMoi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        public static SqlConnection sqlcon = new SqlConnection(QuanLySieuThiDienMay.Properties.Settings.Default.strConnect);

        private void ThemMatHangMoi_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            if (sqlcon.State == ConnectionState.Closed) sqlcon.Open();
           SqlDataAdapter daSupplier = new SqlDataAdapter("exec view_all_Supplier", sqlcon);
           DataTable dtSupplier = new DataTable();
            daSupplier.Fill(dtSupplier);

            //
            SqlDataAdapter daCategory = new SqlDataAdapter("exec view_all_Category", sqlcon);
            DataTable dtCategory = new DataTable();
            daCategory.Fill(dtCategory);
            
            //Load dữ liệu lên combobox nhà cung cấp
            cbb_Supplier.DataSource = dtSupplier;
            cbb_Supplier.DisplayMember = "Tên nhà cung cấp";
            cbb_Supplier.ValueMember = "Mã nhà cung cấp";
            //Load dữ liệu lên combobox Loại hàng
            cbb_Category.DataSource = dtCategory;
            cbb_Category.DisplayMember = "Tên loại hàng";
            cbb_Category.ValueMember = "Mã loại hàng";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                ThemLoaiHangMoi newlh = new ThemLoaiHangMoi();
                newlh.ShowDialog();
                this.ThemMatHangMoi_Load(sender, e);
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                ThemNhaCungCapMoi newncc = new ThemNhaCungCapMoi();
                newncc.ShowDialog();
                this.ThemMatHangMoi_Load(sender, e);
            }
            
        }

        private void btn_add_product_Click(object sender, EventArgs e)

        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into tblMatHang values (N'" + tb_Ten_MH.Text + "'," + cbb_Supplier.SelectedValue.ToString() + "," + cbb_Category.SelectedValue.ToString() + ",N'" + tb_DonViTinh.Text + "', 0," + num_GiaTien.Value.ToString() + ")", sqlcon);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bạn đã thêm thành công mặt hàng '" + tb_Ten_MH.Text + "' ");
                this.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
