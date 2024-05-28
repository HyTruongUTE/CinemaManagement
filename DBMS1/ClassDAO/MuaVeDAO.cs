using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS1.ClassDAO
{
    internal class MuaVeDAO
    {
        DBConnection dbconn = new DBConnection();
        public DataTable HienThiVeBoPhimGheNgoi()
        {
            String sqlStr = "select * from ViewVeBoPhimGheNgoi";
            return dbconn.LayDanhSach(sqlStr);
        }
        public DataTable LoadCbbMaFnB()
        {
            return dbconn.LoadData("load", "Select *from FnB");
        }
        public DataTable LoadCbbTenBoPhim()
        {
            return dbconn.LoadData("load", "Select *from BOPHIM");
        }
        public DataTable LoadCbbKhuVucGhe()
        { 
            return dbconn.LoadData("load", "Select *from GHENGOI");
        }
        
    }
}
