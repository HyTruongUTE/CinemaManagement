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
    }
}
