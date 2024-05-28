using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS1.Class
{
    internal class HoaDonDAO
    {
        DBConnection dbconn = new DBConnection();
        public DataTable HienThiHoaDon()
        {
            String sqlStr = "select * from V_HoaDon";
            return dbconn.LayDanhSach(sqlStr);
        }
        public DataTable LoadCbbMaKhachHang()
        {
            return dbconn.LoadData("load", "Select *from KHACHHANG");
        }
        
    }
}
