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
    public partial class FGheNgoi : Form
    {
        GheNgoiDAO gnDao = new GheNgoiDAO();
        DBConnection conn = new DBConnection();
        public FGheNgoi()
        {
            InitializeComponent();
        }

        private void HienThiDanhSach()
        {
            this.dgvGheNgoi.DataSource = gnDao.HienThi();
            this.StartPosition = FormStartPosition.CenterParent;
        }
        private void FGheNgoi_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }
    }
}
