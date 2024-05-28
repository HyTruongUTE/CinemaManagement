using DBMS1.Class;
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

namespace DBMS1
{
    public partial class FLogin : Form
    {
        DBConnection dbconn = new DBConnection();
        public FLogin()
        {
            InitializeComponent();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btn_Login_Click(object sender, EventArgs e)
        {
            GLOBAL.Username = txtUserName.Text;
            GLOBAL.Password = txtPassWord.Text;

                if (checkLogin(GLOBAL.Username, GLOBAL.Password))
                {
                MessageBox.Show("Đăng nhập thành công!");
                var f = new FMain();
                    f.Show();
                }
                else MessageBox.Show("Sai Username/ Password!");

        }

        private bool checkLogin(string username, string password)
        {
            SqlCommand cmd = new SqlCommand("SELECT [dbo].[checkLogin] (@username , @password)", dbconn.getConnectionAdmin);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            dbconn.openConnectionAdmin();
            bool count = (bool)cmd.ExecuteScalar();
            dbconn.closeConnectionAdmin();
            return count;
        }


    }
}
