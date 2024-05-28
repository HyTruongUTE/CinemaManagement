using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS1.ClassDAO
{
    internal class VeDAO
    {
        DBConnection dbconn = new DBConnection();


        public DataTable HienThiVe()
        {
            String sqlStr = "select * from V_Ve";
            return dbconn.LayDanhSach(sqlStr);
        }

        public DataTable HienThiLoaiVe()
        {
            String sqlStr = "select * from V_LoaiVe";
            return dbconn.LayDanhSach(sqlStr);
        }
        public DataTable LoadCbbMaLoaiVe()
        {
            return dbconn.LoadData("load", "Select *from LOAIVE");
        }
        public DataTable LoadCbbMaGheNgoi()
        {
            return dbconn.LoadData("load", "Select *from GHENGOI");
        }
        public DataTable LoadCbbThoiGianChieu()
        {
            return dbconn.LoadData("load", "Select *from LICHCHIEU");
        }
    }
}
