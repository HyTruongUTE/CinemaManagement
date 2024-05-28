using DBMS1.Class;
using DBMS1.ClassConnect;
using DBMS1.ClassDAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS1.FCRUD
{
    public partial class FThemLichChieu : Form
    {
        LichChieuDAO lcDao = new LichChieuDAO();
        PhongChieuDAO pcDao = new PhongChieuDAO();
        private string MaLichChieu;
        public FThemLichChieu()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

        }

        private void LoadFThemLichChieu()
        {
            cbBoxMaPC.DataSource = pcDao.LoadCbbMaPC();
        }
        private void FThemLichChieu_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MaLichChieu))
            {
                this.Text = "Thêm mới Lịch Chiếu";
                LoadFThemLichChieu();
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LichChieu lc = new LichChieu(txtMaLichChieu.Text,txtMaBoPhim.Text, txtMaBoPhim.Text, dateThoiGianChieu.Value, txtTrangThai.Text);
            lcDao.ThemLichChieu(lc);
            this.Dispose();
        }
    }
}
