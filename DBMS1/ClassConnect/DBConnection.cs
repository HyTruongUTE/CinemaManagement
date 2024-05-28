using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using DBMS1.ClassConnect;
using System.Drawing;
using DBMS1.Class;

namespace DBMS1
{
    internal class DBConnection
    {
        private SqlConnection conn;
        private DataTable dt;
        private SqlCommand cmd;
        public static string strAdmin = "Data Source = (localdb)\\mssqllocaldb; Initial Catalog = DOAN1; Integrated Security = True";
        public static string strcon = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=DOAN1;User ID=" + GLOBAL.Username + ";Password=" + GLOBAL.Password + ";";

        SqlConnection dbConn = new SqlConnection(strcon);
        SqlConnection dbConnAdmin = new SqlConnection(strAdmin);
        public SqlConnection getConnection
        {

            get
            {
                openConnection();
                return dbConn;
            }
        }

        public SqlConnection getConnectionAdmin
        {
            get
            {
                return dbConnAdmin;
            }
        }

        public void openConnection()
        {
            strcon = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=DOAN1;User ID=" + GLOBAL.Username + ";Password=" + GLOBAL.Password + ";";
            dbConn = new SqlConnection(strcon);
           // if (dbConn.State == ConnectionState.Closed)
            {
                dbConn.Open();
            }
        }

        public void openConnectionAdmin()
        {
            if (dbConnAdmin.State == ConnectionState.Closed)
            {
                dbConnAdmin.Open();
            }
        }


        public void closeConnection()
        {
            if (dbConn.State == ConnectionState.Open)
            {
                dbConn.Close();
            }
        }
        public void closeConnectionAdmin()
        {
            if (dbConnAdmin.State == ConnectionState.Open)
            {
                dbConnAdmin.Close();
            }
        }


        public DataTable LayDanhSach(string sqlStr)
        {
            DataTable dtds = new DataTable();
            try
            {
                dbConn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, dbConn);
                adapter.Fill(dtds);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                dbConn.Close();
            }
            return dtds;
        }

        public void ThucThi(string sqlStr)
        {
            try
            {
                dbConn.Open();

                SqlCommand cmd = new SqlCommand(sqlStr, dbConn);

                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Thành Công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất Bại!" + ex);
            }
            finally
            {
                dbConn.Close();
            }
        }


        public DataTable SelectData(string sql, List<CustomParameter> lstpara)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                cmd = new SqlCommand(sql, conn);
                if (lstpara != null)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var para in lstpara)
                    {
                        cmd.Parameters.AddWithValue(para.key, para.value);
                    }
                }
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi load Data " + ex.Message);
                return null;
            }
            finally
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

        }

        public DataTable LoadData(string tukhoa, string lenh)
        {

            List<CustomParameter> lstpara = new List<CustomParameter>();
            if (tukhoa != "load")
            {
                lstpara.Add(new CustomParameter()
                {
                    key = "@tukhoa",
                    value = tukhoa
                });
            }
            else lstpara = null;
            return LayDanhSach(lenh);
        }

        public DataRow Select(string sql)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                cmd = new SqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt.Rows[0];
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Loi load thong tin chi tiet " + ex.Message);
                return null;
            }
            finally
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        public int Excute(string sql, List<CustomParameter> lstpara)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var p in lstpara)
                {
                    cmd.Parameters.AddWithValue(p.key, p.value);
                }
                var rs = cmd.ExecuteNonQuery();
                return (int)rs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi thuc thi cau lenh " + ex.Message);
                return -100;
            }
            finally
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

    }
}
