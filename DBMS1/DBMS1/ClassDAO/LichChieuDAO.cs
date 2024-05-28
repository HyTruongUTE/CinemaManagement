using DBMS1.Class;
using DBMS1.ClassConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DBMS1.ClassDAO
{
    internal class LichChieuDAO
    {
        DBConnection dbconn = new DBConnection();


        public DataTable LayDanhSachLichChieu()
        {
            String sqlStr = "select * from V_LichChieu";
            return dbconn.LayDanhSach(sqlStr);
        }

        public void ThemLichChieu(LichChieu lc)
        {
            String sqlStr = string.Format("INSERT INTO LICHCHIEU (MaLC, MaBP, MaPC, ThoiGianChieu, TrangThai) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", lc.MaLC, lc.MaBP, lc.MaPC, lc.ThoiGianChieu, lc.TrangThai);
            dbconn.ThucThi(sqlStr);
        }

        public bool ThemLichChieuHy(LichChieu lc)
        {
            SqlCommand command = new SqlCommand("InsertMovieScheduleHyTest", dbconn.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaLC", SqlDbType.NChar).Value = lc.MaLC;
            command.Parameters.Add("@MaBP", SqlDbType.NChar).Value = lc.MaBP;
            command.Parameters.Add("@MaPC", SqlDbType.NChar).Value = lc.MaPC;
            command.Parameters.Add("@ThoiGianChieu", SqlDbType.Time).Value = lc.ThoiGianChieu;
            command.Parameters.Add("@TinhTrang", SqlDbType.NChar).Value = lc.TrangThai;
            return true;
            //if (command.ExecuteNonQuery() > 0)
            //{
               
            //    return true;
            //}
            //else
            //{
          
            // return false;
            // }

        }

    }
}
