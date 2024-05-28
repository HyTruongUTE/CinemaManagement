using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBMS1
{
    internal class PhongChieuDAO
    {
        DBConnection dbconn = new DBConnection();


        public DataTable HienThi()
        {
            String sqlStr = "select * from V_PhongChieu";
            return dbconn.LayDanhSach(sqlStr);
        }

    
        public DataTable LoadCbbMaPC()
        {
            return dbconn.LayDanhSach("Select MaPC from PHONGCHIEU");
        }
    }

}
