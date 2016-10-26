using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace MLMPOS.Service.DB
{
    public enum SALE_ORDER_STSTE
    {
        NEW = -1,
        SALED = 0,
        SYNCD = 1
    }
    public class SaleOrderService
    {
        /**
         * 得到所有售卖列表
         * */
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
                        dt = sh.Select("select * from SaleOrder");
                       
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

        /**
         * 根据售卖列表id得到售卖单据信息
         * */
        public DataRow getOrderById(String id)
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
                        dt = sh.Select("select * from SaleOrder where id = @id",dicParameters);
                    }
                    catch (Exception ex)
                    {
                        dt = new DataTable();
                        dt.Columns.Add("Error");
                        dt.Rows.Add(ex.ToString());
                    }

                    conn.Close();
                    return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                }
            }
        }

        /**
         * 创建售卖单据，并返回，初始状态为新增
         * 
         * */
        public DataRow createOrder(Dictionary<String,Object> row) 
        {
            if (row == null)
            {
                row = new Dictionary<string, object>();
            }
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
                        row["id"] = Guid.NewGuid().ToString("N");
                        row["state"] = SALE_ORDER_STSTE.NEW;
                        DateTime now = DateTime.Now;
                        row["createdate"] = now;
                        row["updatedate"] = now;
                        row["ordercode"] = config.SHOP_CODE + config.POS_CODE+ now.ToString("yyMMddHHmmss") + getSeq().ToString().PadLeft(4,'0') ;

                        sh.Insert("SaleOrder", row);
                        dt = sh.Select("select * from SaleOrder where id =" + "'"+row["id"] + "'");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Create exception"); 
                        return null;
                    }
                    conn.Close();
                    return dt.Rows[0];
                }
            }

        }

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
                        Object countObj = sh.ExecuteScalar("select seq from OrderSequence where date = '" + dateStr + "'");
                        Console.WriteLine(countObj);
                        if (countObj == null)
                        {
                            Dictionary<String, Object> row = new Dictionary<string, object>();
                            row["date"] = dateStr;
                            row["seq"] = 1;
                            sh.Insert("OrderSequence", row);
                        }
                        else
                        {
                            i = Int32.Parse(countObj.ToString()) +1;
                            Dictionary<String, Object> row = new Dictionary<string, object>();
                            row["seq"] = i;
                            sh.Update("OrderSequence", row, "date", dateStr);
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


        //根据售卖单据号获取售卖明细
        public DataTable getOrderListByOrderCode(String ordercode)
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
                        dicParameters.Add("@ordercode", ordercode);
                        dt = sh.Select("select * from SaleOrderList where ordercode = @ordercode", dicParameters);
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

        /**
         * 创建一条售卖记录，如果商品条码在售卖信息中存在则数量加1
         * */
        public DataTable createList(Dictionary<String,Object> row )
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
                        Dictionary<String, Object> cond = new Dictionary<string, object>();
                        cond["@barcode"] = row["barcode"];
                        cond["@ordercode"] = row["ordercode"];
                        DataTable lt = sh.Select("select * from SaleOrderList where barcode = @barcode and ordercode = @ordercode",cond);
                        if(lt!=null && lt.Rows.Count > 0)
                        {
                            DataRow dr = lt.Rows[0];
                            return updateListCount(dr["ordercode"].ToString(),dr["barcode"].ToString(),1,true);
                        }
                        else
                        {
                             sh.Insert("SaleOrderList", row);
                            return updateListCount(row["ordercode"].ToString(), row["barcode"].ToString(), 0,true);
                        }
                    }
                    catch (Exception ex)
                    {
                        
                        return null;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

        }


        /**
         * 删除一条售卖记录，不判断数量
         * */
        public void deleteList(String id)
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
                        sh.Execute("delete from SaleOrderList where id = '" + id + "'");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

        }

        /**
         * 根据售卖单号和条码修改数量 newCount 为指定数量，isSumCount 是否叠加数量 
         * */
        public DataTable updateListCount(String ordercode,String barcode,Decimal newCount,Boolean isSumCount)
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
                        Dictionary<String, Object> cond = new Dictionary<string, object>();
                        cond["@barcode"] = barcode;
                        cond["@ordercode"] = ordercode;
                        DataTable lt = sh.Select("select * from SaleOrderList where barcode = @barcode and ordercode = @ordercode", cond);
                        if (lt != null && lt.Rows.Count > 0)
                        {
                            Dictionary<String, Object> dic = new Dictionary<string, object>();
                            Decimal oldCount = Decimal.Parse(lt.Rows[0]["count"].ToString());
                            Decimal price = Decimal.Parse(lt.Rows[0]["price"].ToString());
                            Decimal discount = Decimal.Parse(lt.Rows[0]["discount"].ToString());
                            Decimal disprice = discount / 100 * price;

                            Decimal count = 0;
                            if (isSumCount)
                            {
                                count = oldCount + newCount;
                            }
                            else
                            {
                                count = newCount;
                            }
                            Decimal amount = count * disprice;
                            Decimal disamount = count * price - count * disprice;

                            dic["count"] = count;
                            dic["amount"] = amount;
                            dic["disamount"] = disamount;
                            dic["disprice"] = disprice;
                            sh.Update("SaleOrderList", dic, "id", lt.Rows[0]["id"]);
                        }
                       
                        dt = getOrderListByOrderCode(ordercode);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    conn.Close();
                    return dt;
                }
            }

        }



        //根据单据id汇总指定的售卖单据信息
        public DataRow gatherSaleOrder(String orderid)
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
                        Dictionary<String, Object> cond = new Dictionary<string, object>();
                        cond["orderid"] = orderid;

                        String amountObj = sh.ExecuteScalar("select sum(amount) from SaleOrderList where  orderid = @orderid",cond).ToString();
                        String countObj = sh.ExecuteScalar("select sum(count) from SaleOrderList where  orderid = @orderid", cond).ToString();
                        String disamountObj = sh.ExecuteScalar("select sum(disamount) from SaleOrderList where  orderid = @orderid", cond).ToString();
                        
                        
                        Console.WriteLine(amountObj);
                        Dictionary<String, Object> dic = new Dictionary<string, object>();
                        dic["count"] = countObj == "" ? "0" : countObj;
                        dic["amount"] = amountObj == "" ? "0.00" : amountObj;
                        dic["disamount"] = disamountObj == "" ? "0.00" : disamountObj;
                        Dictionary<String, Object> cond2 = new Dictionary<string, object>();
                        cond2["id"] = orderid;
                        sh.Update("SaleOrder", dic, cond2);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    finally
                    {
                        conn.Close();
                    }
                     return getOrderById(orderid);
                }
            }

        }

        /**
         * 根据售卖单据id修改某一个属性
         * */
        public void update(String id,String col,Object value)
        {
            Dictionary<String, Object> cond = new Dictionary<string, object>();
            cond[col] = value;
            update(cond, "id", id);
        }

        /**
        * 根据售卖单据号修改某一个属性
        * */
        public void updateByCode(String code, String col, Object value)
        {
            Dictionary<String, Object> cond = new Dictionary<string, object>();
            cond[col] = value;
            update(cond, "code",code);
        }

        /**
       * 修改指定属性
       * */
        public void update(Dictionary<String,Object> cond , String col , Object value)
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
                        sh.Update("SaleOrder", cond, col, value);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);

                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

        }


    }
}
