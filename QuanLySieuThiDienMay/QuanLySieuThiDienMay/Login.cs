using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace QuanLySieuThiDienMay
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
              Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            /*System.Data.Sql.SqlDataSourceEnumerator instance = System.Data.Sql.SqlDataSourceEnumerator.Instance;
            System.Data.DataTable table = instance.GetDataSources();

            cbb_serverName.DataSource = table;
            cbb_serverName.DisplayMember = "ServerName";
            */
            cbb_serverName.Text = "DESKTOP-GLT40E1";


        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string strConnect = "";
            try
            {
                strConnect = "Server=" + cbb_serverName.Text + ";Database=Test;User Id=" + tb_userName.Text + ";Password=" + tb_passWord.Text + ";";
                SqlConnection sqlCon = new SqlConnection(strConnect);
                sqlCon.Open();
                if (sqlCon.State == ConnectionState.Open)
                {
                   QuanLySieuThiDienMay.Properties.Settings.Default.strConnect = strConnect;
                   QuanLySieuThiDienMay.Properties.Settings.Default.Save();
                    this.Hide();
                    FormChuongTrinh quanly = new FormChuongTrinh();
                    quanly.ShowDialog();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Thông tin đăng nhập sai");
            }
            
            
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
             Application.Exit();
        }
    }
}
