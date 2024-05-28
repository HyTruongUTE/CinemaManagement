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

namespace DBMS1
{
    internal class DBConnection
    {
        private SqlConnection conn;
        private DataTable dt;
        private SqlCommand cmd;

        SqlConnection dbConn = new SqlConnection(Properties.Settings.Default.conn);
        public SqlConnection getConnection
        {
            get
            {
                return conn;
            }
        }
        public void openConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
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
                //sql = "exec  SelectAllSinhVien";
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
                //dt.Dispose();
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
            return SelectData(lenh, lstpara);
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
