using DBMS1.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS1.ClassDAO
{
    internal class BoPhimDAO
    {
        DBConnection dbconn = new DBConnection();
        public DataTable HienThi()
        {
            String sqlStr = "select * from V_BoPhim";
            return dbconn.LayDanhSach(sqlStr);
        }
    }
}
