using DBMS1.Class;
using DBMS1.ClassDAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS1.FTable
{
    public partial class FFnB : Form
    {
        FnBDAO fnbDao = new FnBDAO();
        DBConnection conn = new DBConnection();
        public FFnB()
        {
            InitializeComponent();
        }

        private void HienThiDanhSach()
        {
            this.dgvFnB.DataSource = fnbDao.HienThi();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void FFnB_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }

        

private void btnThem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtGiaFnB.Text, out int giaFnB) && int.TryParse(txtSLkho.Text, out int soLuongKho))
            {
                FnB fnb = new FnB(txtMaFnB.Text, txtTeFnB.Text, giaFnB, soLuongKho);
                fnbDao.Them(fnb);
                HienThiDanhSach();
            }
            else
            {
                MessageBox.Show("Lỗi: Vui lòng nhập giá trị hợp lệ cho Giá và Số lượng kho.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //FnB fnb = new FnB(txtMaFnB.Text, txtTeFnB.Text, txtGiaFnB.Text, txtSLkho.Text);
            //fnbDao.Them(fnb);
            //HienThiDanhSach();
        }

        private void dgvFnB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvFnB.CurrentRow.Index;
            txtMaFnB.Text = dgvFnB.Rows[i].Cells[0].Value.ToString();
            txtTeFnB.Text = dgvFnB.Rows[i].Cells[1].Value.ToString();
            txtGiaFnB.Text = dgvFnB.Rows[i].Cells[2].Value.ToString();
        }
    }
}
