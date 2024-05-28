using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS1.ClassDAO
{
    internal class KhachHangDAO
    {
        DBConnection dbconn = new DBConnection();
        public DataTable HienThiKhachHang()
        {
            String sqlStr = "select * from V_KhachHang";
            return dbconn.LayDanhSach(sqlStr);
        }
        public DataTable HienThiLoaiKhachHang()
        {
            String sqlStr = "select * from V_LoaiKhachHang";
            return dbconn.LayDanhSach(sqlStr);
        }
        public DataTable LoadCbbMaLoaiKH()
        {
            return dbconn.LoadData("load", "Select *from LoaiKhachHang");
        }
    }
}
