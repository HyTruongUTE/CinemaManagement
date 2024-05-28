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
    public partial class FKhachHang : Form
    {
        KhachHangDAO khDao = new KhachHangDAO();
        DBConnection conn = new DBConnection();
       

        private void HienThiDanhSach()
        {
            this.dgvKhachHang.DataSource = khDao.HienThiKhachHang();
            this.dgvLoaiKhachHang.DataSource = khDao.HienThiLoaiKhachHang();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        public FKhachHang()
        {
            InitializeComponent();
        }

        private void FKhachHangcs_Load(object sender, EventArgs e)
        {
            //load data cho 2 cbb
            cbbTenLoaiKhachHang.DataSource = khDao.LoadCbbMaLoaiKH();
            cbbTenLoaiKhachHang.DisplayMember = "maLoaiKH";
            cbbTenLoaiKhachHang.ValueMember = "maLoaiKH";
            cbbTenLoaiKhachHang.SelectedIndex = -1;
            HienThiDanhSach();
        }


        private void dgvLoaiKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvLoaiKhachHang.CurrentRow.Index;
            txtMaLoaiKhachHang.Text = dgvLoaiKhachHang.Rows[i].Cells[0].Value.ToString();
            txtTenLoaiKhachHang.Text = dgvLoaiKhachHang.Rows[i].Cells[1].Value.ToString();
        }

        private void btnThemLoaiKhachHang_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("ThemLoaiKH", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaLoaiKH", txtMaLoaiKhachHang.Text);
            command.Parameters.AddWithValue("@TenLoaiKH", txtTenLoaiKhachHang.Text);
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
        private void btnXoaLoaiKhachHang_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("XoaLoaiKH", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaLoaiKH", txtMaLoaiKhachHang.Text);
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

        private void btnUpdateLoaiKhachHang_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("CapNhatLoaiKH", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaLoaiKH", txtMaLoaiKhachHang.Text);
            command.Parameters.AddWithValue("@TenLoaiKH", txtTenLoaiKhachHang.Text);
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

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvKhachHang.CurrentRow.Index;
            txtMaKhachHang.Text = dgvKhachHang.Rows[i].Cells[0].Value.ToString();
            txtHoTen.Text = dgvKhachHang.Rows[i].Cells[2].Value.ToString();
            txtSDT.Text = dgvKhachHang.Rows[i].Cells[3].Value.ToString();
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("ThemKhachHang", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@MaKH", txtMaKhachHang.Text);
            command.Parameters.AddWithValue("@MaLoaiKH", cbbTenLoaiKhachHang.Text);
            command.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
            command.Parameters.AddWithValue("@SoDT", txtSDT.Text);
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

        private void btnXoaKhachHang_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("XoaKhachHang", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@MaKH", txtMaKhachHang.Text);
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

        private void txtUpdateKhachHang_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("CapNhatKhachHang", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@MaKH", txtMaKhachHang.Text);
            command.Parameters.AddWithValue("@MaLoaiKH", cbbTenLoaiKhachHang.Text);
            command.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
            command.Parameters.AddWithValue("@SoDT", txtSDT.Text);
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
