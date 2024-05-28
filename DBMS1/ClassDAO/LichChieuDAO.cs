using DBMS1.Class;
using DBMS1.ClassConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DBMS1.ClassDAO
{
    internal class LichChieuDAO
    {
        DBConnection dbconn = new DBConnection();


        public DataTable LayDanhSachLichChieu()
        {
            String sqlStr = "select * from V_LichChieu";
            return dbconn.LayDanhSach(sqlStr);
        }

        public DataTable LoadCbbMaPhongChieu()
        {
            return dbconn.LoadData("load", "Select *from PHONGCHIEU");
        }

        public DataTable LoadCbbMaBoPhim()
        {
            return dbconn.LoadData("load", "Select *from BOPHIM");
        }

        

    }
        
}
