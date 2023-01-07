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
    public partial class ThemKhachHang : Form
    {
        public ThemKhachHang()
        {
            InitializeComponent();
        }





        public static SqlConnection sqlcon = new SqlConnection(QuanLySieuThiDienMay.Properties.Settings.Default.strConnect);


        private void ThemKhachHang_Load(object sender, EventArgs e)
        {
            if (sqlcon.State != ConnectionState.Open) sqlcon.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string gioitinh = "Nam";
                if (checkNu_KH.Checked == true) gioitinh = "Nữ";
                SqlCommand cmd = new SqlCommand("Insert into tblKhachHang values(N'" + tb_HoTen_KH.Text + "',N'" + gioitinh + "',N'" + tb_DiaChi.Text + "','" + tb_SDT_KH.Text + "',0)", sqlcon);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã thêm thành công khách hàng");

                this.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
