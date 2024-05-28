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
    public partial class FXemGheNgoi : Form
    {
        GheNgoiDAO gnDao = new GheNgoiDAO();
        DBConnection conn = new DBConnection();
        public FXemGheNgoi()
        {
            InitializeComponent();
        }

        private void HienThiDanhSach()
        {
            this.dgvXemGheNgoi.DataSource = gnDao.HienThiGheNgoi();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void FXemGheNgoi_Load(object sender, EventArgs e)
        {
            //Combobox ThoiGianChieu
            cbbMaPhongChieu.DataSource = gnDao.LoadCbbMaPhongChieu();
            cbbMaPhongChieu.DisplayMember = "MaPC";
            cbbMaPhongChieu.ValueMember = "MaPC";
            cbbMaPhongChieu.SelectedIndex = -1;

            HienThiDanhSach();
        }

        private void dgvXemGheNgoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvXemGheNgoi.CurrentRow.Index;
            txtMaGheNgoi.Text = dgvXemGheNgoi.Rows[i].Cells[0].Value.ToString();
            cbbMaPhongChieu.Text = dgvXemGheNgoi.Rows[i].Cells[1].Value.ToString();
            cbbKhuVucGhe.Text = dgvXemGheNgoi.Rows[i].Cells[2].Value.ToString();
            txtGiaGhe.Text = dgvXemGheNgoi.Rows[i].Cells[3].Value.ToString();
            cbbTrangThai.Text = dgvXemGheNgoi.Rows[i].Cells[4].Value.ToString();
        }

        private void btnThemGheNgoi_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("ThemGheNgoi", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaGN", txtMaGheNgoi.Text);
            command.Parameters.AddWithValue("@MaPC", cbbMaPhongChieu.Text);
            command.Parameters.AddWithValue("@KhuVucGhe", cbbKhuVucGhe.Text);
            command.Parameters.AddWithValue("@TrangThai", cbbTrangThai.Text);
            command.Parameters.AddWithValue("@GiaGhe", txtGiaGhe.Text);
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

        private void btnXoaGheNgoi_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("XoaGheNgoi", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@MaGN", txtMaGheNgoi.Text);
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

        private void btnUpdateGheNgoi_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("CapNhatGheNgoi", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaGN", txtMaGheNgoi.Text);
            command.Parameters.AddWithValue("@MaPC", cbbMaPhongChieu.Text);
            command.Parameters.AddWithValue("@KhuVucGhe", cbbKhuVucGhe.Text);
            command.Parameters.AddWithValue("@TrangThai", cbbTrangThai.Text);
            command.Parameters.AddWithValue("@GiaGhe", txtGiaGhe.Text);
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
