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
    public partial class FBoPhim : Form
    {
        BoPhimDAO bpDao = new BoPhimDAO();
        DBConnection conn = new DBConnection();
        public FBoPhim()
        {
            InitializeComponent();
        }

        private void HienThiDanhSach()
        {
            this.dgvBoPhim.DataSource = bpDao.HienThi();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void FBoPhim_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }
            private void btnThem_Click(object sender, EventArgs e)
            {
                DBConnection dbconn = new DBConnection();
                SqlCommand command = new SqlCommand("ThemBoPhim", dbconn.getConnection);
                command.CommandType = CommandType.StoredProcedure;
                // Add parameters for the DonNhapHang table
                command.Parameters.AddWithValue("@MaBP", txtMaBoPhim.Text);
                command.Parameters.AddWithValue("@TenBP", txtTenBoPhim.Text);
                command.Parameters.AddWithValue("@TheLoai", txtTheLoai.Text);
                command.Parameters.AddWithValue("@ThoiLuong", txtThoiLuong.Text);
                command.Parameters.AddWithValue("@DaoDien", txtDaoDien.Text);
                command.Parameters.AddWithValue("@DienVien", txtDienVien.Text);
                command.Parameters.AddWithValue("@TomTat", txtTomTat.Text);
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

            string maBP;
            private void dgvBoPhim_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                int i;
                i = dgvBoPhim.CurrentRow.Index;
                txtMaBoPhim.Text = dgvBoPhim.Rows[i].Cells[0].Value.ToString();
                txtTenBoPhim.Text = dgvBoPhim.Rows[i].Cells[1].Value.ToString();
                txtTheLoai.Text = dgvBoPhim.Rows[i].Cells[2].Value.ToString();
                txtThoiLuong.Text = dgvBoPhim.Rows[i].Cells[3].Value.ToString();
                txtDaoDien.Text = dgvBoPhim.Rows[i].Cells[4].Value.ToString();
                txtDienVien.Text = dgvBoPhim.Rows[i].Cells[5].Value.ToString();
                txtTomTat.Text = dgvBoPhim.Rows[i].Cells[6].Value.ToString();
            }

            private void btnUpdate_Click(object sender, EventArgs e)
            {
                DBConnection dbconn = new DBConnection();
                SqlCommand command = new SqlCommand("CapNhatBoPhim", dbconn.getConnection);
                command.CommandType = CommandType.StoredProcedure;
                // Add parameters for the DonNhapHang table
                command.Parameters.AddWithValue("@MaBP", txtMaBoPhim.Text);
                command.Parameters.AddWithValue("@TenBP", txtTenBoPhim.Text);
                command.Parameters.AddWithValue("@TheLoai", txtTheLoai.Text);
                command.Parameters.AddWithValue("@ThoiLuong", txtThoiLuong.Text);
                command.Parameters.AddWithValue("@DaoDien", txtDaoDien.Text);
                command.Parameters.AddWithValue("@DienVien", txtDienVien.Text);
                command.Parameters.AddWithValue("@TomTat", txtTomTat.Text);
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

            private void btnXoa_Click(object sender, EventArgs e)
            {
                DBConnection dbconn = new DBConnection();
                SqlCommand command = new SqlCommand("XoaBoPhim", dbconn.getConnection);
                command.CommandType = CommandType.StoredProcedure;
                // Add parameters for the DonNhapHang table
                command.Parameters.AddWithValue("@MaBP", txtMaBoPhim.Text);
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
    }

    }
