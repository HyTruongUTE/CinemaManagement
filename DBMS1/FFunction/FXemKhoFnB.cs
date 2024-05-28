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

namespace DBMS1.FFunction
{
    public partial class FXemKhoFnB : Form
    {
        FnBDAO fnbDao = new FnBDAO();
        public FXemKhoFnB()
        {
            InitializeComponent();
        }

        private void HienThiDanhSach()
        {
            this.dgvKhoFnB.DataSource = fnbDao.HienThiFnB();
            this.StartPosition = FormStartPosition.CenterParent;
        }
        private void FXemKhoFnB_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }
        private void dgvKhoFnB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvKhoFnB.CurrentRow.Index;
            txtMaFnB.Text = dgvKhoFnB.Rows[i].Cells[0].Value.ToString();
            txtTenFnB.Text = dgvKhoFnB.Rows[i].Cells[1].Value.ToString();
            txtGiaFnB.Text = dgvKhoFnB.Rows[i].Cells[2].Value.ToString();
            txtSoLuongKho.Text = dgvKhoFnB.Rows[i].Cells[3].Value.ToString();
        }

        private void btnThemFnB_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("ThemFnB", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaFnB", txtMaFnB.Text);
            command.Parameters.AddWithValue("@TenFnB", txtTenFnB.Text);
            command.Parameters.AddWithValue("@GiaFnB", txtGiaFnB.Text);
            command.Parameters.AddWithValue("@SLKho", txtSoLuongKho.Text);
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

        private void btnXoaFnB_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("XoaFnB", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaFnB", txtMaFnB.Text);
            dbconn.openConnection();
            int rowsAffected = command.ExecuteNonQuery();
            // Check the result
            if (rowsAffected > 0)
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại!");
            }
            dbconn.closeConnection();
            HienThiDanhSach();
        }

        private void btnUpdateFnB_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("CapNhatFnB", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaFnB", txtMaFnB.Text);
            command.Parameters.AddWithValue("@TenFnB", txtTenFnB.Text);
            command.Parameters.AddWithValue("@GiaFnB", txtGiaFnB.Text);
            command.Parameters.AddWithValue("@SLKho", txtSoLuongKho.Text);
            dbconn.openConnection();
            int rowsAffected = command.ExecuteNonQuery();
            // Check the result
            if (rowsAffected > 0)
            {
                MessageBox.Show("Cập nhật thành công.");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.");
            }
            dbconn.closeConnection();
            HienThiDanhSach();
        }
    }
}
