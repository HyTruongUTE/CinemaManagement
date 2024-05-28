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
    }
}
