using DBMS1.Class;
using DBMS1.ClassConnect;
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

        public List<CustomParameter> LoadDataBoPhim(string maBP, string tenBP, string theLoai, string thoiLuong, string daoDien, string dienVien, string tomTat)
        {
            List<CustomParameter> lstpara = new List<CustomParameter>();
            lstpara.Add(new CustomParameter()
            {
                key = "@MaBP",
                value = maBP
            });
            lstpara.Add(new CustomParameter()
            {
                key = "@TenBP",
                value = tenBP
            });

            lstpara.Add(new CustomParameter()
            {
                key = "@TheLoai",
                value = theLoai
            });

            lstpara.Add(new CustomParameter()
            {
                key = "@ThoiLuong",
                value = thoiLuong

            }) ;

            lstpara.Add(new CustomParameter()
            {
                key = "@DaoDien",
                value = daoDien
            });
            lstpara.Add(new CustomParameter()
            {
                key = "@DienVien",
                value = dienVien
            });
            lstpara.Add(new CustomParameter()
            {
                key = "@TomTat",
                value = tomTat
            });
            return lstpara;
        }
        public int InsertBoPhim(List<CustomParameter> lstpara)
        {
            return dbconn.Excute("ThemBoPhim", lstpara);
        }
    }
}
