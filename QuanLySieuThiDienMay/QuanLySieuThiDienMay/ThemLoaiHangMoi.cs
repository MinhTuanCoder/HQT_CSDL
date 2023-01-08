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
    public partial class ThemLoaiHangMoi : Form
    {
        public ThemLoaiHangMoi()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static SqlConnection sqlcon = new SqlConnection(QuanLySieuThiDienMay.Properties.Settings.Default.strConnect);

        private void button1_Click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed) sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Insert into tblLoaiHang values (N'" + textBox1.Text + "')", sqlcon);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Đã thêm thành công loại hàng mới");
            this.Close();
        }

       
    }
}
