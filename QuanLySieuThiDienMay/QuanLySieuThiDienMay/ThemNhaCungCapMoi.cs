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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLySieuThiDienMay
{
    public partial class ThemNhaCungCapMoi : Form
    {
        public ThemNhaCungCapMoi()
        {
            InitializeComponent();
        }
        public static SqlConnection sqlcon = new SqlConnection(QuanLySieuThiDienMay.Properties.Settings.Default.strConnect);

        private void btn_update_supplier_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_add_supplier_Click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed) sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Insert into tblNhaCungCap values (N'" + tb_Ten_NCC.Text +"',N'"+tb_DiaChi_NCC.Text+"',N'"+tb_SDT_NCC.Text+ "',1)", sqlcon);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Đã thêm thành công nhà cung cấp mới");
            this.Close();
        }
    }
}
