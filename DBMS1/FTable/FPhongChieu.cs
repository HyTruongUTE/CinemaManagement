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
    public partial class FPhongChieu : Form
    {
        PhongChieuDAO pcDao = new PhongChieuDAO();
        DBConnection conn = new DBConnection();
        public FPhongChieu()
        {
            InitializeComponent();
        }

        private void HienThiDanhSach()
        {
            this.dgvPhongChieu.DataSource = pcDao.HienThi();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void FPhongChieu_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();  
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            dbconn.openConnection();
            SqlCommand command = new SqlCommand("ThemPhongChieu", dbconn.getConnection);
            try
            {
                
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaPC", txtMaPhongChieu.Text);
                command.Parameters.AddWithValue("@TenPC", txtTenPhongChieu.Text);
                command.Parameters.AddWithValue("@TrangThai", txtTrangThai.Text);
                int rowsAffected = command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbconn.closeConnection();
            }
            HienThiDanhSach();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("XoaPhongChieu", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaPC", txtMaPhongChieu.Text);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("CapNhatPhongChieu", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaPC", txtMaPhongChieu.Text);
            command.Parameters.AddWithValue("@TenPC", txtTenPhongChieu.Text);
            command.Parameters.AddWithValue("@TrangThai", txtTrangThai.Text);
            dbconn.openConnection();
            int rowsAffected = command.ExecuteNonQuery();
            // Check the result
            if (rowsAffected > 0)
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
            dbconn.closeConnection();
            HienThiDanhSach();
        }

        private void dgvPhongChieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvPhongChieu.CurrentRow.Index;
            txtMaPhongChieu.Text = dgvPhongChieu.Rows[i].Cells[0].Value.ToString();
            txtTenPhongChieu.Text = dgvPhongChieu.Rows[i].Cells[1].Value.ToString();
            txtTrangThai.Text = dgvPhongChieu.Rows[i].Cells[2].Value.ToString();
        }
    }
}
