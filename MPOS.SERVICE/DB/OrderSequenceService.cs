using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace MPOS.SERVICE.DB
{
    public class OrderSequenceService
    {

        public int getSeq()
        {
            using (SQLiteConnection conn = new SQLiteConnection(config.DB_FILE))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    SQLiteHelper sh = new SQLiteHelper(cmd);
                   int i = 1;
                    try
                    {
                        String dateStr = DateTime.Now.ToString("yyyyMMdd");
                        Object countObj =sh.ExecuteScalar("select seq from OrderSequence where date = '"+dateStr+"'");
                        if (countObj == null)
                        {
                            Dictionary<String, Object> row = new Dictionary<string, object>();
                            row["date"] = dateStr;
                            row["seq"] = 1;
                            sh.Insert("OrderSequence", row);
                        }
                        else
                        {
                            i = (int)countObj + 1;
                            Dictionary<String, Object> row = new Dictionary<string, object>();
                            row["date"] = dateStr;
                            row["seq"] = i;
                            sh.Update("OrderSeqence", row, "date", dateStr);
                        }
                    }
                    catch (Exception ex)
                    {
                       
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return i;
                }
            }
        }

    }
}
