using DBMS1.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS1.ClassDAO
{
    internal class FnBDAO
    {
        DBConnection dbconn = new DBConnection();
        public DataTable HienThi()
        {
            String sqlStr = "select * from V_FnB";
            return dbconn.LayDanhSach(sqlStr);
        }

        public void Them(FnB fnb)
        {
            {
                string sqlStr = string.Format("INSERT INTO FnB (MaFnB, TenFnB, GiaFnB, SLKho) VALUES ('{0}', '{1}', '{2}', '{3}", fnb.MaFnB, fnb.TenFnB, fnb.GiaFnB, fnb.SLKho);
                dbconn.ThucThi(sqlStr);
            }
        }
    }
}
