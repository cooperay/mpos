using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPOS.SERVICE.DB;
using System.Data;
using System.Data.SQLite;

namespace MPOS.SERVICE.DB
{
    public class KeyBoardService
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
                        dt = sh.Select("select * from KeyBoard");
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

        public DataRow getRow(String keycode)
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
                        dt = sh.Select("select * from KeyBoard where keycode = '"+ keycode + "'");
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
                    if (dt.Rows.Count <= 0)
                    {
                        return null;
                    }
                    return dt.Rows[0];
                }
            }
        }
    }
}
