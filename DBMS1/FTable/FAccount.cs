using DBMS1.ClassDAO;
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

namespace DBMS1.FTable
{
    public partial class FAccount : Form
    {
        AccountDAO accountDAO = new AccountDAO();

        public FAccount()
        {
            InitializeComponent();
        }

        private void HienThiDanhSach()
        {
            this.dgvAccount.DataSource = accountDAO.HienThi();
            this.StartPosition = FormStartPosition.CenterParent;
        }
        private void FAccount_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }

        private void btnThemAccount_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("ThemAccount", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserName", txtUserName.Text);
            command.Parameters.AddWithValue("@PassWord", txtPassword.Text);
            command.Parameters.AddWithValue("@IsAdmin", cbbIsAdmin.Text);
            dbconn.openConnection();
            int rowsAffected = command.ExecuteNonQuery();
            // Check the result
            if (rowsAffected > 0)
            {
                MessageBox.Show("Thêm thành công.");
            }
            else
            {
                MessageBox.Show("Thêm thất bại.");
            }
            dbconn.closeConnection();
            HienThiDanhSach();
        }

        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvAccount.CurrentRow.Index;
            txtUserName.Text = dgvAccount.Rows[i].Cells[0].Value.ToString();
            txtPassword.Text = dgvAccount.Rows[i].Cells[1].Value.ToString();
            cbbIsAdmin.Text = dgvAccount.Rows[i].Cells[2].Value.ToString();
        }

        private void btnXoaAccount_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("XoaAccount", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserName", txtUserName.Text);
            dbconn.openConnection();
            int rowsAffected = command.ExecuteNonQuery();
            // Check the result
            if (rowsAffected > 0)
            {
                MessageBox.Show("Xóa thành công.");
            }
            else
            {
                MessageBox.Show("Xóa thất bại.");
            }
            dbconn.closeConnection();
            HienThiDanhSach();
        }
    }
}
