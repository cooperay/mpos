using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace MLMPOS.Service.DB
{
   public class AccountService
    {

        public DataTable getTable(String orderid)
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
                        dt = sh.Select("select * from Account where orderid = '"+orderid+"' ");
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

        public void add(Dictionary<String,Object> row)
        {
            using (SQLiteConnection conn = new SQLiteConnection(config.DB_FILE))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;

                    SQLiteHelper sh = new SQLiteHelper(cmd);
                    try
                    {
                        sh.Insert("Account", row);
                    }
                    catch (Exception ex)
                    {

                    }
                    conn.Close();
                }
            }
        }


        public Decimal gatherDoneAmmount(String orderid)
        {
            using (SQLiteConnection conn = new SQLiteConnection(config.DB_FILE))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;

                    SQLiteHelper sh = new SQLiteHelper(cmd);
                    Decimal done = 0;
                    try
                    {
                        String o = sh.ExecuteScalar("select sum(sum) from Account where orderid = '" + orderid + "' ").ToString();
                        done = Decimal.Parse(o == "" ? "0.00" : o);
                    
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return done;
                }
            }
        }

    }
}
