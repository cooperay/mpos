using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace MLMPOS.Service.DB
{
    public class PayTypeService
    {
        public DataTable getTable()
        {
            using (SQLiteConnection conn = new SQLiteConnection(config.DB_FILE))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    SQLiteHelper sh = new SQLiteHelper(cmd);
                    DataTable dt = null;
                    try
                    {
                        dt = sh.Select("select * from PayType where isenable =1");
                    }
                    catch (Exception ex)
                    {
                        dt = new DataTable();
                        dt.Columns.Add("Error");
                        dt.Rows.Add(ex.ToString());
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return dt;
                }
            }
        }

        public DataRow getRow(String code)
        {
            using (SQLiteConnection conn = new SQLiteConnection(config.DB_FILE))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    SQLiteHelper sh = new SQLiteHelper(cmd);
                    DataTable dt = null;
                    try
                    {
                        dt = sh.Select("select * from PayType where code = '"+code+"'");
                    }
                    catch (Exception ex)
                    {
                        dt = new DataTable();
                        dt.Columns.Add("Error");
                        dt.Rows.Add(ex.ToString());
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                }
            }
        }
    }
}
