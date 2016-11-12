using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using Newtonsoft.Json.Linq;
using MPOS.SERVICE.Entity;
using Newtonsoft.Json;

namespace MPOS.SERVICE.DB
{
   
    public class SaleOrderService
    {
        private AccountService accountService;

        public SaleOrderService()
        {
            accountService = new AccountService();
        }

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

        /// <summary>
        /// 根据未同步订单列表
        /// </summary>
        /// <param name="cond"></param>
        /// <returns></returns>
        public DataTable getUnSyncTable()
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
                        dt = sh.Select("select * from SaleOrder where state ='Payed' OR state ='Dirty'");

                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                        //dt.Rows.Add(ex.ToString());
                    }
                    conn.Close();
                    return dt;
                }
            }
        }

        /// <summary>
        /// 得到所有为同步的单据实体信息，包含明细
        /// </summary>
        /// <returns></returns>
        public List<SaleOrder> getUnSyncList()
        {
            List<SaleOrder> list = new List<SaleOrder>();
            DataTable dt = getUnSyncTable();
            if (dt != null)
            {
                for(int i = 0; i <dt.Rows.Count; i++)
                {
                    String orderid = dt.Rows[i]["orderid"].ToString();
                    list.Add(getOrderEntityById(orderid));
                }
            }
            return list;
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
                        dt = sh.Select("select * from SaleOrder where orderid = @id",dicParameters);
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

        public SaleOrder getOrderEntityById(String id)
        {
            SaleOrder order = new SaleOrder();
            DataRow dr =  getOrderById(id);
            order.orderid = dr["orderid"].ToString();
            order.ordercode = dr["ordercode"].ToString();
            order.shopcode = dr["shopcode"].ToString();
            order.poscode = dr["poscode"].ToString();
            order.cashier = dr["cashier"].ToString();
            order.amount = dr["amount"].ToString();
            order.count = dr["count"].ToString();
            order.disamount = dr["disamount"].ToString();
            order.createdate = dr["createdate"].ToString();
            order.updatedate = dr["updatedate"].ToString();
            order.state = dr["state"].ToString();
            order.list = getOrderListByOrderId(id);
            order.accountlist = accountService.getTable(id);
            return order;
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
                        row["orderid"] = Guid.NewGuid().ToString("N");
                        row["state"] = OrderState.New.ToString();
                        DateTime now = DateTime.Now;
                        row["createdate"] = now.ToString("yyyy-MM-dd HH:mm:ss");
                        row["updatedate"] = now.ToString("yyyy-MM-dd HH:mm:ss");
                        row["ordercode"] = row["shopcode"].ToString() + row["poscode"].ToString() + now.ToString("yyMMddHHmmss") + getSeq().ToString().PadLeft(4, '0');

                        sh.Insert("SaleOrder", row);
                        dt = sh.Select("select * from SaleOrder where orderid =" + "'"+row["orderid"] + "'");
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
        public DataTable getOrderListByOrderId(String orderId)
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
                        dicParameters.Add("@orderid", orderId);
                        dt = sh.Select("select * from SaleOrderList where orderid = @orderid", dicParameters);
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
                        cond["@orderid"] = row["orderid"];
                        DataTable lt = sh.Select("select * from SaleOrderList where barcode = @barcode and orderid = @orderid",cond);
                        if(lt!=null && lt.Rows.Count > 0)
                        {
                            DataRow dr = lt.Rows[0];
                            return updateListCount(dr["orderid"].ToString(),dr["barcode"].ToString(),1,true);
                        }
                        else
                        {
                             sh.Insert("SaleOrderList", row);
                            return updateListCount(row["orderid"].ToString(), row["barcode"].ToString(), 0,true);
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
                        sh.Execute("delete from SaleOrderList where orderlistid = '" + id + "'");
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
        public DataTable updateListCount(String orderid,String barcode,Decimal newCount,Boolean isSumCount)
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
                        cond["@orderid"] = orderid;
                        DataTable lt = sh.Select("select * from SaleOrderList where barcode = @barcode and orderid = @orderid", cond);
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
                            sh.Update("SaleOrderList", dic, "orderlistid", lt.Rows[0]["orderlistid"]);
                           
                        }
                       
                        dt = getOrderListByOrderId(orderid);
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
                        cond2["orderid"] = orderid;
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
        /// <summary>
        /// 修改指定id的单据状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="state"></param>
        public void updateState(String orderId,String state)
        {
            update(orderId, "state", state);
        }

        /**
         * 根据售卖单据id修改某一个属性
         * */
        public void update(String id,String col,Object value)
        {
            Dictionary<String, Object> cond = new Dictionary<string, object>();
            cond[col] = value;
            update(cond, "orderid", id);
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

        /// <summary>
        /// 修改指定的属性
        /// </summary>
        /// <param name="cond">条件参数</param>
        /// <param name="col"></param>
        /// <param name="value"></param>
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
