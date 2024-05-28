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
    public partial class FLichChieu : Form
    {
        LichChieuDAO lcDao = new LichChieuDAO();
        DBConnection conn = new DBConnection();
        private string maLichChieu;
        public FLichChieu()
        {
            InitializeComponent();
        }

        private void HienThiDanhSach()
        {
            this.dgvLichChieu.DataSource = lcDao.LayDanhSachLichChieu();
            this.StartPosition = FormStartPosition.CenterParent;
        }
        private void FLichChieu_Load(object sender, EventArgs e)
        {
            //load combobox mapc
            cbbMaPhongChieu.DataSource = lcDao.LoadCbbMaPhongChieu();
            cbbMaPhongChieu.DisplayMember = "maPC";
            cbbMaPhongChieu.ValueMember = "maPC";
            cbbMaPhongChieu.SelectedIndex = -1;

            //load combobox mabophim
            cbbMaBoPhim.DataSource = lcDao.LoadCbbMaBoPhim();
            cbbMaBoPhim.DisplayMember = "maBP";
            cbbMaBoPhim.ValueMember = "maBP";
            cbbMaBoPhim.SelectedIndex = -1;

            //load combobox mabophimtimlichchieu
            cbbMaBPTimLichChieu.DataSource = lcDao.LoadCbbMaBoPhim();
            cbbMaBPTimLichChieu.DisplayMember = "maBP";
            cbbMaBPTimLichChieu.ValueMember = "maBP";
            cbbMaBPTimLichChieu.SelectedIndex = -1;

            HienThiDanhSach();
        }

        private void dgvLichChieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvLichChieu.CurrentRow.Index;
            txtMaLichChieu.Text = dgvLichChieu.Rows[i].Cells[0].Value.ToString();
            cbbMaPhongChieu.Text = dgvLichChieu.Rows[i].Cells[1].Value.ToString();
            cbbMaBoPhim.Text = dgvLichChieu.Rows[i].Cells[2].Value.ToString();
            dateTimeThoiGianChieu.Value = DateTime.Parse(dgvLichChieu.Rows[i].Cells[3].Value.ToString());
            dateTimeThoiGianChieu.Format = DateTimePickerFormat.Custom;
            dateTimeThoiGianChieu.CustomFormat = "HH:mm:ss";
            cbbTrangThai.Text = dgvLichChieu.Rows[i].Cells[4].Value.ToString();
        }

       
        private void btnTimLcTheoMaBP_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            dbconn.openConnection();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[func_TimKiemLichChieuTheoMaBP](@MaBP)", dbconn.getConnection))
            {
                cmd.Parameters.AddWithValue("@MaBP", cbbMaBPTimLichChieu.Text);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvLichChieuHomNay.DataSource = dt;
                }
            }
            dbconn.closeConnection();
        }

        private void cbbMaBPTimLichChieu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateLichChieu_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("CapNhatLichChieu", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaLC", txtMaLichChieu.Text);
            command.Parameters.AddWithValue("@MaPC", cbbMaPhongChieu.Text);
            command.Parameters.AddWithValue("@MaBP", cbbMaBoPhim.Text);
            command.Parameters.AddWithValue("@ThoiGianChieu", dateTimeThoiGianChieu.Value);
            command.Parameters.AddWithValue("@TrangThai", cbbTrangThai.Text);
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

        private void btnThemLichChieu_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("ThemLichChieu", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaLC", txtMaLichChieu.Text);
            command.Parameters.AddWithValue("@MaPC", cbbMaPhongChieu.Text);
            command.Parameters.AddWithValue("@MaBP", cbbMaBoPhim.Text);
            command.Parameters.AddWithValue("@ThoiGianChieu", dateTimeThoiGianChieu.Value);
            command.Parameters.AddWithValue("@TrangThai", cbbTrangThai.Text);
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

        private void btnXoaLichChieu_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("XoaLichChieu", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaLC", txtMaLichChieu.Text);
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
