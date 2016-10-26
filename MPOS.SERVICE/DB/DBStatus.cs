using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;


namespace MLMPOS.Service.DB
{
   public class DBStatus
    {
        public static void init()
        {
            using (SQLiteConnection conn = new SQLiteConnection(config.DB_FILE))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    SQLiteHelper sh = new SQLiteHelper(cmd);

                    //系统信息表
                    SQLiteTable SystemConfig = new SQLiteTable("SystemConfig");
                    SystemConfig.Columns.Add(new SQLiteColumn("shopcode", ColType.Text));
                    SystemConfig.Columns.Add(new SQLiteColumn("poscode", ColType.Text));
                    SystemConfig.Columns.Add(new SQLiteColumn("regcode", ColType.Text)); //注册码 根据注册码加载pos信息
                                                                                         //操作员表
                    //收银员表
                    SQLiteTable cashier = new SQLiteTable("Cashier");
                    cashier.Columns.Add(new SQLiteColumn("id", ColType.Text));
                    cashier.Columns.Add(new SQLiteColumn("name", ColType.Text));
                    cashier.Columns.Add(new SQLiteColumn("code", ColType.Text));
                    cashier.Columns.Add(new SQLiteColumn("pwd", ColType.Text));

                    //键盘配置表
                    SQLiteTable keyboard = new SQLiteTable("KeyBoard");
                    keyboard.Columns.Add(new SQLiteColumn("commandkey", ColType.Text));
                    keyboard.Columns.Add(new SQLiteColumn("commandname", ColType.Text));
                    keyboard.Columns.Add(new SQLiteColumn("keycode", ColType.Text));

                    //支付方式表
                    SQLiteTable paytype = new SQLiteTable("PayType");
                    paytype.Columns.Add(new SQLiteColumn("code", ColType.Text));
                    paytype.Columns.Add(new SQLiteColumn("name", ColType.Text));
                    paytype.Columns.Add(new SQLiteColumn("isenable", ColType.Text));
                    paytype.Columns.Add(new SQLiteColumn("isearn", ColType.Text));

                    //售卖单据流水号
                    SQLiteTable sequence = new SQLiteTable("OrderSequence");
                    sequence.Columns.Add(new SQLiteColumn("date", ColType.DateTime));
                    sequence.Columns.Add(new SQLiteColumn("seq", ColType.Integer));

                    //商品档案表
                    SQLiteTable product = new SQLiteTable("Product");
                    product.Columns.Add(new SQLiteColumn("id",ColType.Integer,true,false,true,""));
                    product.Columns.Add(new SQLiteColumn("barcode",ColType.Text));
                    product.Columns.Add(new SQLiteColumn("name",ColType.Text));
                    product.Columns.Add(new SQLiteColumn("spec",ColType.Text));
                    product.Columns.Add(new SQLiteColumn("unit", ColType.Text));
                    product.Columns.Add(new SQLiteColumn("tintype", ColType.Text));
                    product.Columns.Add(new SQLiteColumn("midtype", ColType.Text));
                    product.Columns.Add(new SQLiteColumn("bigtype", ColType.Text));
                    product.Columns.Add(new SQLiteColumn("classtype", ColType.Text));
                    product.Columns.Add(new SQLiteColumn("depttype", ColType.Text));
                    product.Columns.Add(new SQLiteColumn("price",ColType.Decimal));

                    //售卖单据
                    SQLiteTable saleorder = new SQLiteTable("SaleOrder");
                    saleorder.Columns.Add(new SQLiteColumn("id", ColType.Text, true, false, true, null));
                    saleorder.Columns.Add(new SQLiteColumn("ordercode"));
                    saleorder.Columns.Add(new SQLiteColumn("shopcode"));
                    saleorder.Columns.Add(new SQLiteColumn("poscode"));
                    saleorder.Columns.Add(new SQLiteColumn("cashier"));
                    saleorder.Columns.Add(new SQLiteColumn("amount"));
                    saleorder.Columns.Add(new SQLiteColumn("count"));
                    saleorder.Columns.Add(new SQLiteColumn("disamount"));
                    saleorder.Columns.Add(new SQLiteColumn("createdate"));
                    saleorder.Columns.Add(new SQLiteColumn("updatedate"));
                    saleorder.Columns.Add(new SQLiteColumn("state"));

                    //售卖明细
                    SQLiteTable saleorderList = new SQLiteTable("SaleOrderList");
                    saleorderList.Columns.Add(new SQLiteColumn("id", ColType.Text, true, false, true, null));
                    saleorderList.Columns.Add(new SQLiteColumn("ordercode"));
                    saleorderList.Columns.Add(new SQLiteColumn("orderid"));
                    saleorderList.Columns.Add(new SQLiteColumn("productid"));
                    saleorderList.Columns.Add(new SQLiteColumn("barcode"));
                    saleorderList.Columns.Add(new SQLiteColumn("name"));
                    saleorderList.Columns.Add(new SQLiteColumn("spec"));
                    saleorderList.Columns.Add(new SQLiteColumn("unit"));
                    saleorderList.Columns.Add(new SQLiteColumn("tintype"));
                    saleorderList.Columns.Add(new SQLiteColumn("midtype"));
                    saleorderList.Columns.Add(new SQLiteColumn("bigtype"));
                    saleorderList.Columns.Add(new SQLiteColumn("classtype"));
                    saleorderList.Columns.Add(new SQLiteColumn("depttype"));
                    saleorderList.Columns.Add(new SQLiteColumn("price"));
                    saleorderList.Columns.Add(new SQLiteColumn("count"));
                    saleorderList.Columns.Add(new SQLiteColumn("discount"));
                    saleorderList.Columns.Add(new SQLiteColumn("disprice"));
                    saleorderList.Columns.Add(new SQLiteColumn("amount"));
                    saleorderList.Columns.Add(new SQLiteColumn("disamount"));

                    //收银流水表
                    SQLiteTable account = new SQLiteTable("Account");
                    account.Columns.Add(new SQLiteColumn("id", ColType.Text, true, false, true, null));
                    account.Columns.Add(new SQLiteColumn("ordercode", ColType.Text));
                    account.Columns.Add(new SQLiteColumn("orderid", ColType.Text));
                    account.Columns.Add(new SQLiteColumn("sum", ColType.Text));
                    account.Columns.Add(new SQLiteColumn("type", ColType.Text));
                    account.Columns.Add(new SQLiteColumn("date", ColType.DateTime));

                   

                    sh.BeginTransaction();
                    try
                    {
                        sh.CreateTable(SystemConfig);
                        sh.CreateTable(cashier);
                        sh.CreateTable(keyboard);
                        sh.CreateTable(paytype);
                        sh.CreateTable(sequence);
                        sh.CreateTable(product);
                        sh.CreateTable(saleorder);
                        sh.CreateTable(saleorderList);
                        sh.CreateTable(account);
                        sh.Commit();
                    }
                    catch(Exception e)
                    {
                        System.Console.WriteLine(e);
                        sh.Rollback();
                    }
                    finally
                    {
                        conn.Close();
                    }
                    initData();
                }
            }
        }



        public static void initData()
        {
            using (SQLiteConnection conn = new SQLiteConnection(config.DB_FILE))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    SQLiteHelper sh = new SQLiteHelper(cmd);
                    try
                    {
                        Object o = sh.ExecuteScalar("select count(*) from KeyBoard");
                        Int32 i = Int32.Parse(o.ToString());
                        sh.BeginTransaction();
                        if (i== 0)
                        {
                            //键盘命令初始化
                            sh.Execute("insert into KeyBoard values('pay','结算','Space')");
                            sh.Execute("insert into KeyBoard values('member','查询会员','H')");
                            sh.Execute("insert into KeyBoard values('pay_alipay','支付宝结算','A')");
                            sh.Execute("insert into KeyBoard values('pay_yl','银联结算','Y')");
                            sh.Execute("insert into KeyBoard values('pay_cash','现金结算','X')");
                            sh.Execute("insert into KeyBoard values('pay_wx','微信结算','W')");
                            sh.Execute("insert into KeyBoard values('pay_mcard','M卡结算','M')");
                        }
                        o = sh.ExecuteScalar("select count(*) from PayType");
                        i = Int32.Parse(o.ToString());
                        if (i == 0)
                        {
                            //支付方式初始化
                            sh.Execute("insert into PayType values('1','现金','1','1')");
                            sh.Execute("insert into PayType values('2','银联','1','0')");
                            sh.Execute("insert into PayType values('3','M卡','1','0')");
                            sh.Execute("insert into PayType values('4','微信','1','0')");
                            sh.Execute("insert into PayType values('5','支付宝','1','0')");
                            sh.Execute("insert into PayType values('6','自定义','1', '1')");
                        }

                       
                        sh.Commit();
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine(e);
                        sh.Rollback();
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
