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
    public partial class ChiTietHoaDon : Form
    {
        public ChiTietHoaDon()
        {
            InitializeComponent();
        }
        public string mahd = QuanLySieuThiDienMay.Properties.Settings.Default.mahd.ToString();
        public static SqlConnection sqlcon = new SqlConnection(QuanLySieuThiDienMay.Properties.Settings.Default.strConnect);
        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            SqlDataAdapter daBilldetail = new SqlDataAdapter("exec view_Bill_detail_X '" +mahd  + "'", sqlcon);
             DataTable dtBilldetail = new DataTable();
            daBilldetail.Fill(dtBilldetail);
            dgv_detail_Bill.DataSource = dtBilldetail;
            //
            try
            {
                SqlDataAdapter danv = new SqlDataAdapter("select [Tên nhân viên] from view_all_Bill where [Mã hóa đơn]=" + mahd, sqlcon);
                DataTable dtnv = new DataTable();
                danv.Fill(dtnv);

                SqlDataAdapter dakh = new SqlDataAdapter("select [Tên khách hàng] from view_all_Bill where [Mã hóa đơn]=" + mahd, sqlcon);
                DataTable dtkh = new DataTable();
                dakh.Fill(dtkh);

                SqlDataAdapter dangay = new SqlDataAdapter(" select dngayban from tblHoaDon where imahd=" + mahd, sqlcon);
                DataTable dtngay = new DataTable();
                dangay.Fill(dtngay);
                textBox1.Text = mahd;
                textBox2.Text = dtnv.Rows[0][0].ToString();
                textBox3.Text = dtkh.Rows[0][0].ToString();
                label5.Text = "Ngày tạo hóa đơn: "+ Convert.ToDateTime(dtngay.Rows[0][0]).ToString("MM/dd/yyyy");
                Double sum = 0;
                for(int i = 0; i < dgv_detail_Bill.Rows.Count; i++)
                {
                    sum+= Convert.ToDouble(dtBilldetail.Rows[i][4]);
                }
                textBox4.Text =sum.ToString();
            }
            catch { }
            
        }
    }
}
