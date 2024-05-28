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
    public partial class FVe : Form
    {
        VeDAO veDao = new VeDAO();
        DBConnection conn = new DBConnection();
        public FVe()
        {
            InitializeComponent();
        }

        private void HienThiDanhSach()
        {
            this.dgvVe.DataSource = veDao.HienThi();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void FVe_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }
    }
}
