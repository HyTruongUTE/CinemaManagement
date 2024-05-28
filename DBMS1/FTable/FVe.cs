using DBMS1.ClassDAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS1.FTable
{
    public partial class FVe : Form
    {
        AddClass addClass = new AddClass();
        VeDAO veDao = new VeDAO();

        DBConnection conn = new DBConnection();
        public FVe()
        {
            InitializeComponent();
        }

        private void HienThiDanhSach()
        {
            this.dgvLoaiVe.DataSource = veDao.HienThiLoaiVe();
            this.dgvVe.DataSource = veDao.HienThiVe();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void FVe_Load(object sender, EventArgs e)
        {
            //Combobox MaLoaiVe
            cbbMaLoaiVe.DataSource = veDao.LoadCbbMaLoaiVe();
            cbbMaLoaiVe.DisplayMember = "maLV";
            cbbMaLoaiVe.ValueMember = "maLV";
            cbbMaLoaiVe.SelectedIndex = -1;

            //Combobox MaGheNgoi
            cbbMaGheNgoi.DataSource = veDao.LoadCbbMaGheNgoi();
            cbbMaGheNgoi.DisplayMember = "maGN";
            cbbMaGheNgoi.ValueMember = "maGN";
            cbbMaGheNgoi.SelectedIndex = -1;
            
            //Combobox ThoiGianChieu
            cbbGioChieu.DataSource = veDao.LoadCbbThoiGianChieu();
            cbbGioChieu.DisplayMember = "ThoiGianChieu";
            cbbGioChieu.ValueMember = "ThoiGianChieu";
            cbbGioChieu.SelectedIndex = -1;
            HienThiDanhSach();
        }

        private void dgvLoaiVe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvLoaiVe.CurrentRow.Index;
            txtMaLoaiVe.Text = dgvLoaiVe.Rows[i].Cells[0].Value.ToString();
            txtTenLoaiVe.Text = dgvLoaiVe.Rows[i].Cells[1].Value.ToString();
            txtGiaVe.Text = dgvLoaiVe.Rows[i].Cells[2].Value.ToString();
        }

        private void btnThemLoaiVe_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("ThemLoaiVe", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaLV", txtMaLoaiVe.Text);
            command.Parameters.AddWithValue("@TenLoaiVe", txtTenLoaiVe.Text);
            command.Parameters.AddWithValue("@GiaVe", txtGiaVe.Text);
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

        private void btnXoaLoaiVe_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("XoaLoaiVe", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaLV", txtMaLoaiVe.Text);
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

        private void btnUpdateLoaiVe_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("CapNhatLoaiVe", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaLV", txtMaLoaiVe.Text);
            command.Parameters.AddWithValue("@TenLoaiVe", txtTenLoaiVe.Text);
            command.Parameters.AddWithValue("@GiaVe", txtGiaVe.Text);
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


        private void dgvVe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvVe.CurrentRow.Index;
            txtMaVe.Text = dgvVe.Rows[i].Cells[0].Value.ToString();
            txtGiaVeVe.Text = dgvVe.Rows[i].Cells[1].Value.ToString();
            cbbMaLoaiVe.Text = dgvVe.Rows[i].Cells[2].Value.ToString();
            cbbMaGheNgoi.Text = dgvVe.Rows[i].Cells[3].Value.ToString();
            txtThoiLuong.Text = dgvVe.Rows[i].Cells[4].Value.ToString();
            datetimeNgayChieu.Value = DateTime.Parse(dgvVe.Rows[i].Cells[5].Value.ToString());
            datetimeNgayChieu.Format = DateTimePickerFormat.Custom;
            datetimeNgayChieu.CustomFormat = "dd/MM/yyyy";
            cbbGioChieu.Text = dgvVe.Rows[i].Cells[6].Value.ToString();

        }

        private void btnThemVe_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("ThemVe", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaVe", txtMaVe.Text);
            command.Parameters.AddWithValue("@GiaVe", txtGiaVeVe.Text);
            command.Parameters.AddWithValue("@MaLV", cbbMaLoaiVe.Text);
            command.Parameters.AddWithValue("@MaGN", cbbMaGheNgoi.Text);
            command.Parameters.AddWithValue("@ThoiLuong", txtThoiLuong.Text);
            command.Parameters.AddWithValue("@NgayChieu", datetimeNgayChieu.Value);
            command.Parameters.AddWithValue("@GioChieu", cbbGioChieu.Text);
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
        private void btnXoaVe_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("XoaVe", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaVe", txtMaVe.Text);
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

        private void btnUpdateVe_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("CapNhatVe", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;            command.Parameters.AddWithValue("@MaVe", txtMaVe.Text);
            command.Parameters.AddWithValue("@GiaVe", txtGiaVeVe.Text);
            command.Parameters.AddWithValue("@MaLV", cbbMaLoaiVe.Text);
            command.Parameters.AddWithValue("@MaGN", cbbMaGheNgoi.Text);
            command.Parameters.AddWithValue("@ThoiLuong", txtThoiLuong.Text);
            command.Parameters.AddWithValue("@NgayChieu", datetimeNgayChieu.Value);
            command.Parameters.AddWithValue("@GioChieu", cbbGioChieu.Text);
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

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
