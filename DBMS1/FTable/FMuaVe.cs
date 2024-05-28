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
    public partial class FMuaVe : Form
    {
        FnBDAO fnbDAO = new FnBDAO();
        MuaVeDAO muaVeDAO = new MuaVeDAO();
        public FMuaVe()
        {
            InitializeComponent();
        }

        private void HienThiDanhSach()
        {
            this.dgvMuaFnB.DataSource = fnbDAO.HienThiFnBConTrongKho();
            this.dgvMuaVe.DataSource = muaVeDAO.HienThiVeBoPhimGheNgoi();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void FMuaVe_Load(object sender, EventArgs e)
        {
            //load combobox maFnB
            cbbMaFnB.DataSource = muaVeDAO.LoadCbbMaFnB();
            cbbMaFnB.DisplayMember = "MaFnB";
            cbbMaFnB.ValueMember = "MaFnB";
            cbbMaFnB.SelectedIndex = -1;

            //load combobox tenbophim
            cbbTenBoPhim.DataSource = muaVeDAO.LoadCbbTenBoPhim();
            cbbTenBoPhim.DisplayMember = "TenBP";
            cbbTenBoPhim.ValueMember = "TenBP";
            cbbTenBoPhim.SelectedIndex = -1;

            //load combobox khuvucghe
            cbbKhuVucGhe.DataSource = muaVeDAO.LoadCbbKhuVucGhe();
            cbbKhuVucGhe.DisplayMember = "KhuVucGhe";
            cbbKhuVucGhe.ValueMember = "KhuVucGhe";
            cbbKhuVucGhe.SelectedIndex = -1;
            HienThiDanhSach();
        }

        private void dgvMuaFnB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvMuaFnB.CurrentRow.Index;
            cbbMaFnB.Text = dgvMuaFnB.Rows[i].Cells[0].Value.ToString();
            txtSLKho.Text = dgvMuaFnB.Rows[i].Cells[3].Value.ToString();
        }

        private void btnMuaFnB_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("Proc_MuaFnB", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaFnB", cbbMaFnB.Text);
            command.Parameters.AddWithValue("@SLKho", txtSLKho.Text);
            command.Parameters.AddWithValue("@SoLuongMua", numSoLuongMua.Text);
            dbconn.openConnection();
            int rowsAffected = command.ExecuteNonQuery();
            // Check the result
            if (rowsAffected > 0)
            {
                MessageBox.Show("Mua thành công.");
            }
            else
            {
                MessageBox.Show("Mua thất bại.");
            }
            dbconn.closeConnection();
            HienThiDanhSach();
        }

        private void dgvMuaVe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvMuaFnB.CurrentRow.Index;
            txtMaVe.Text = dgvMuaVe.Rows[i].Cells[0].Value.ToString();
            cbbTenBoPhim.Text = dgvMuaVe.Rows[i].Cells[1].Value.ToString();
            datetimeThoiGianChieu.Text = dgvMuaVe.Rows[i].Cells[2].Value.ToString();
            cbbKhuVucGhe.Text = dgvMuaVe.Rows[i].Cells[3].Value.ToString();
            txtGiaVe.Text = dgvMuaVe.Rows[i].Cells[4].Value.ToString();
        }

        private void btnTimTheoMaBPvaThoiGianChieu_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            dbconn.openConnection();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[TimKiemVeBoPhim](@TenBP, @KhuVucGhe)", dbconn.getConnection))
            {
                cmd.Parameters.AddWithValue("@TenBP", cbbTenBoPhim.Text);
                cmd.Parameters.AddWithValue("@KhuVucGhe", cbbKhuVucGhe.Text);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvMuaVe.DataSource = dt;
                }
            }
            dbconn.closeConnection();
        }

        private void btnMuaVe_Click(object sender, EventArgs e)
        {
            DBConnection dbconn = new DBConnection();
            SqlCommand command = new SqlCommand("MuaVe", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MaVe", txtMaVe.Text);
            dbconn.openConnection();
            int rowsAffected = command.ExecuteNonQuery();
            // Check the result
            if (rowsAffected > 0)
            {
                MessageBox.Show("Mua thành công.");
            }
            else
            {
                MessageBox.Show("Mua thành công");
            }
            dbconn.closeConnection();
            HienThiDanhSach();
        }
    }
}
