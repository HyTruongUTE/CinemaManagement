using DBMS1.Class;
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
    public partial class FHoaDon : Form
    {
        HoaDonDAO hdDao = new HoaDonDAO();
        public FHoaDon()
        {
            InitializeComponent();
        }
        private void HienThiDanhSach()
        {
            this.dgvHoaDon.DataSource = hdDao.HienThiHoaDon();
            this.StartPosition = FormStartPosition.CenterParent;
        }
        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvHoaDon.CurrentRow.Index;
            txtMaHoaDon.Text = dgvHoaDon.Rows[i].Cells[0].Value.ToString();
            cbbMaKhachHang.Text = dgvHoaDon.Rows[i].Cells[1].Value.ToString();
            txtTriGiaHoaDon.Text = dgvHoaDon.Rows[i].Cells[2].Value.ToString();
            txtTrangThaiHoaDon.Text = dgvHoaDon.Rows[i].Cells[3].Value.ToString();
            dateTimeNgayXuatHD.Value = DateTime.Parse(dgvHoaDon.Rows[i].Cells[4].Value.ToString());
            dateTimeNgayXuatHD.Format = DateTimePickerFormat.Custom;
            dateTimeNgayXuatHD.CustomFormat = "dd/MM/yyyy";
        }

        private void FHoaDon_Load(object sender, EventArgs e)
        {
            //Combobox ThoiGianChieu
            cbbMaKhachHang.DataSource = hdDao.LoadCbbMaKhachHang();
            cbbMaKhachHang.DisplayMember = "MaKH";
            cbbMaKhachHang.ValueMember = "MaKH";
            cbbMaKhachHang.SelectedIndex = -1;

            HienThiDanhSach();
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("ThemHoaDon", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaHD", txtMaHoaDon.Text);
            command.Parameters.AddWithValue("@MaKH", cbbMaKhachHang.Text);
            command.Parameters.AddWithValue("@TriGiaHD", txtTriGiaHoaDon.Text);
            command.Parameters.AddWithValue("@TrangThai", txtTrangThaiHoaDon.Text);
            command.Parameters.AddWithValue("@NgayXuatHD", dateTimeNgayXuatHD.Value);
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

        private void btnXoaHoaDon_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("XoaHoaDon", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@MaHD", txtMaHoaDon.Text);
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

        private void btnUpdateHoaDon_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("CapNhatHoaDon", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@MaHD", txtMaHoaDon.Text);
            command.Parameters.AddWithValue("@MaKH", cbbMaKhachHang.Text);
            command.Parameters.AddWithValue("@TriGiaHD", txtTriGiaHoaDon.Text);
            command.Parameters.AddWithValue("@TrangThai", txtTrangThaiHoaDon.Text);
            command.Parameters.AddWithValue("@NgayXuatHD", dateTimeNgayXuatHD.Value);
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

        private void btnTinhTriGiaHoaDon_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            dbconn.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT [dbo].[func_tinhTongTriGiaHoaDonTheoThang](@Thang)", dbconn.getConnection);
            DateTime selectedMonth = dateTimeThangTinhTGHD.Value;
            cmd.Parameters.AddWithValue("@Thang", selectedMonth.Month);
            object result = cmd.ExecuteScalar();
            string Thang = selectedMonth.Month.ToString();
            if (result != null && result != DBNull.Value)
            {
                string tonghoadonString = result.ToString();
                lblTriGiaHoaDon.Text = "Trị giá HĐ theo tháng " + Thang  + " là: " + tonghoadonString + " VND"; 
            }
            else
            {
                lblTriGiaHoaDon.Text = "Trị giá HĐ theo tháng " + Thang + " là: 0 VND";
            }

            dbconn.closeConnection();
        }
    }
}
