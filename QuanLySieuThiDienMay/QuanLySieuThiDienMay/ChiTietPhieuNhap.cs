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
    public partial class ChiTietPhieuNhap : Form
    {
        public ChiTietPhieuNhap()
        {
            InitializeComponent();
        }
        public string mapn = QuanLySieuThiDienMay.Properties.Settings.Default.mapn.ToString();
        public static SqlConnection sqlcon = new SqlConnection(QuanLySieuThiDienMay.Properties.Settings.Default.strConnect);

        private void ChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed) sqlcon.Open();
            SqlDataAdapter daImportdetail = new SqlDataAdapter("select * from dbo.func_view_detail_Import( " + mapn + ")", sqlcon);
            DataTable dtImportdetail = new DataTable();
            daImportdetail.Fill(dtImportdetail);
            dgv_detail_Import.DataSource = dtImportdetail;
            try
            {
                SqlDataAdapter danv = new SqlDataAdapter("select [Mã nhân viên] from view_all_Import where [Mã phiếu nhập]=" + mapn, sqlcon);
                DataTable dtnv = new DataTable();
                danv.Fill(dtnv);


                SqlDataAdapter dangay = new SqlDataAdapter(" select dngaynhap from tblPhieuNhap where imapn=" + mapn, sqlcon);
                DataTable dtngay = new DataTable();
                dangay.Fill(dtngay);
                textBox1.Text = mapn;
                textBox2.Text = dtnv.Rows[0][0].ToString();
                label5.Text = "Ngày nhập hàng: " + Convert.ToDateTime(dtngay.Rows[0][0]).ToString("MM/dd/yyyy");
                Double sum = 0;
                for (int i = 0; i < dgv_detail_Import.Rows.Count; i++)
                {
                    sum += Convert.ToDouble(dtImportdetail.Rows[i][4]);
                }
                textBox4.Text = sum.ToString();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
