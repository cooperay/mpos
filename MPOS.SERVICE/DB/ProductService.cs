using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Configuration;
using System.Data;

namespace MPOS.SERVICE.DB
{
    public class ProductService
    {

        public DataTable getList()
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
                        dt = sh.Select("select * from product");
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

        public void add()
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
                        Dictionary<String, Object> dc = new Dictionary<string, object>();
                        dc.Add("name", "康师傅冰红茶500ml");
                        dc.Add("price", 20.5);
                        sh.Insert("product", dc);
                    }
                    catch (Exception ex)
                    {
                       
                    }
                    conn.Close();
                }
            }
        }

        public DataTable getByBarCode(String barcode)
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
                        dt = sh.Select("select * from product where barcode like '%"+barcode+"%'");
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

    }
}
