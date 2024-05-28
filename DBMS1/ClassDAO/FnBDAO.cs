using DBMS1.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS1.ClassDAO
{
    internal class FnBDAO
    {
        DBConnection dbconn = new DBConnection();
        public DataTable HienThiFnB()
        {
            String sqlStr = "select * from V_FnB";
            return dbconn.LayDanhSach(sqlStr);
        }

        public DataTable HienThiFnBConTrongKho()
        {
            String sqlStr = "SELECT * FROM func_DanhSachFnBCoTrongKho()";
            return dbconn.LayDanhSach(sqlStr);
        }
            
        public DataTable HienThiLoaiFnB()
        {
            String sqlStr = "select * from LOAIFnB";
            return dbconn.LayDanhSach(sqlStr);
        }
    }
}
