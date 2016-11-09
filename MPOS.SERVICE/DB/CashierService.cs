using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace MPOS.SERVICE.DB
{
    public class CashierService
    {
        public DataRow CheckCashier(String code,String pwd)
        {
            DataTable dt = null;
            using (SQLiteConnection conn = new SQLiteConnection(config.DB_FILE))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    SQLiteHelper sh = new SQLiteHelper(cmd);
                    dt = sh.Select("select * from Cashier where code = '" + code + "'");
                    DataRow dr = dt.Rows.Count > 0 ? dt.Rows[0] : null;
                    conn.Close();
                    if (dr == null || !pwd.Equals(dr["pwd"]))
                        return null;
                    return dr;
                }
            }
        }

    }
}
