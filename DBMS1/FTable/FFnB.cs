using DBMS1.Class;
using DBMS1.ClassDAO;
using DBMS1.FFunction;
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
    public partial class FFnB : Form
    {
        AddClass addClass = new AddClass();
        FnBDAO fnbDao = new FnBDAO();
        DBConnection conn = new DBConnection();
        public FFnB()
        {
            InitializeComponent();
        }

        private void HienThiDanhSach()
        {
            this.dgvFnB.DataSource = fnbDao.HienThiFnBConTrongKho();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void FFnB_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }
    }
}
