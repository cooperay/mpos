using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace MPOS.SERVICE.DB
{
    public class SystemConfigService
    {
        public String getConfigById(String id)
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
                        Dictionary<string, object> dicParameters = new Dictionary<string, object>();
                        dicParameters.Add("@id", id);
                        dt = sh.Select("select * from SystemConfig where configid = @id", dicParameters);
                    }
                    catch (Exception ex)
                    {
                        dt = new DataTable();
                        dt.Columns.Add("Error");
                        dt.Rows.Add(ex.ToString());
                    }

                    conn.Close();
                    return dt.Rows.Count > 0 ? dt.Rows[0]["value"].ToString() : null;
                }
            }
        }

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
                        dt = sh.Select("select * from SystemConfig");

                    }
                    catch (Exception ex)
                    {
                        dt = new DataTable();
                        dt.Columns.Add("Error");
                        dt.Rows.Add(ex.ToString());
                    }

                    conn.Close();
                    return dt;
                }
            }
        }

        public void insertOrUpdateConfig(Dictionary<String, Object> row)
        {
            using (SQLiteConnection conn = new SQLiteConnection(config.DB_FILE))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    String id = row["configid"].ToString();
                    SQLiteHelper sh = new SQLiteHelper(cmd);
                    DataTable dt = null;
                    try
                    {
                        dt = sh.Select("select * from SystemConfig where configid='"+id+"'");
                        if(dt!=null && dt.Rows.Count > 0)
                        {
                            Dictionary<String, Object> cond = new Dictionary<string, object>();
                            cond.Add("configid", id);
                            sh.Update("SystemConfig", row, cond);
                        }
                        else
                        {
                            sh.Insert("SystemConfig", row);
                        }
                    }
                    catch (Exception ex)
                    {
                        return ;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

        }


        public Dictionary<String,Object> getConfigs()
        {
            Dictionary<String, Object> configs = new Dictionary<String,Object>();
            DataTable dt = getTable();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                configs[row["configid"].ToString()] = row["value"].ToString();
            }
            return configs;
        }

    }
}
