using DBMS1.Class;
using DBMS1.ClassDAO;
using DBMS1.FCRUD;
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
            HienThiDanhSach();
        }
        private void btnThemLC_Click(object sender, EventArgs e)
        {
            new FThemLichChieu().ShowDialog();
            HienThiDanhSach();

        }
    }
}
