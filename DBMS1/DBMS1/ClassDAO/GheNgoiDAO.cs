﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS1.ClassDAO
{
    internal class GheNgoiDAO
    {
        DBConnection dbconn = new DBConnection();

        public DataTable HienThi()
        {
            String sqlStr = "select * from V_XemGheNgoi";
            return dbconn.LayDanhSach(sqlStr);
        }
    }
}
