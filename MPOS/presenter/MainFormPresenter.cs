using MPOS.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MPOS.SERVICE.DB;
using MPOS.SERVICE.Entity;
using MPOS.SERVICE;
using MPOS.command;
using System.Windows.Forms;
using MPOS.SERVICE.MQ;
using System.Threading;
using System.Net;
using MPOS.utils;
namespace MPOS.presenter
{
    public class MainFormPresenter
    {
        private MainForm view;
        private SaleOrderService orderService;
        private ProductService productService;
        private KeyBoardService keyBoardService;

        public MainFormPresenter(MainForm view)
        {
            this.view = view;
            this.orderService = new SaleOrderService();
            this.productService = new ProductService();
            this.keyBoardService = new KeyBoardService();
            init();
            view.ipAddressLabel.Text = "IP:" + GetAddressIP();
            SyncBackUtil.getInstance().startSyncThread(1 * 60 * 1000); //启动后台同步进程
            MessageListener.getInstance().startListener(); //启动mq队列监听
            NetCheckUtil.getInstance().startNetCheck(this);
        }

        public void init()
        {
            initNewOrder();     //初始化当前订单
            setCurrentProduct(null);  //设置当前商品为空
            setCurrentOrder();       //设置当前订单
            setLastOrder();          //设置上一单
        }
        /// <summary>
        /// 初始化新订单
        /// </summary>
        public void initNewOrder()
        {
            Dictionary<string, object> row = new Dictionary<string, object>();
            row["shopcode"] = SystemInfo.getConfig(SystemInfo.SHOP_CODE);
            row["cashier"] = SystemInfo.getConfig(SystemInfo.CASHIER_CODE);
            row["count"] = 100;
            row["poscode"] = SystemInfo.getConfig(SystemInfo.POS_CODE);
            row["amount"] = 0.0;
            row["count"] = 0;
            row["disamount"] = 0;


            DataRow dr = orderService.createOrder(row);
            DateTime now = DateTime.Now;
            view.dateLabel.Text = now.ToLongDateString().ToString();
            view.orderCodeLabel.Text = dr["ordercode"].ToString();
            view.shopCodeLabel.Text = SystemInfo.getConfig(SystemInfo.SHOP_CODE).ToString();
            view.cashierLabel.Text = SystemInfo.getConfig(SystemInfo.CASHIER_NAME).ToString();
            view.dataGridView1.DataSource = null;
            SystemInfo.CurrentOrderId = dr["orderid"].ToString();
            SystemInfo.CurrentOrderCode = dr["ordercode"].ToString();
          
        }

        /// <summary>
        /// 扫描事件处理，响应barcodeInput的回车事件
        /// 如果barcode为空执行现金支付命令
        /// 如果不为空根据barcode模糊查询商品信息，
        /// 返回结果为空设置当前商品界面信息为未找到商品
        /// 返回结果为一条记录直接添加到当前售卖单据明细
        /// 返回结果为多条弹出商品选择界面
        /// </summary>
        public void scanCode()
        {
           // MQHelper.getInstance().sendMessage("");
            string barcode = view.barcodeInput.Text;
            if(barcode == "")
            {
                CommandManager.Exec(CommandManager.PAY_COMMAND_CASH, view);
                return;
            }
            DataTable dt = productService.getByBarCode(barcode);
            DataRow dr = null;
           
            if (dt.Rows.Count <= 0)
            {
                setCurrentProduct(dr);
                return;   
            }else if(dt.Rows.Count == 1)
            {
                //一条记录
                dr = dt.Rows[0];
                Dictionary<String, Object> row = new Dictionary<string, object>();
                row["orderlistid"] = Guid.NewGuid().ToString("N");
                row["orderid"] = SystemInfo.CurrentOrderId;
                row["ordercode"] = SystemInfo.CurrentOrderCode;
                row["productid"] = dr["id"];
                row["barcode"] = dr["barcode"];
                row["name"] = dr["name"];
                row["spec"] = dr["spec"];
                row["unit"] = dr["unit"];
                row["tintype"] = dr["tintype"];
                row["midtype"] = dr["midtype"];
                row["bigtype"] = dr["bigtype"];
                row["classtype"] = dr["classtype"];
                row["barcode"] = dr["barcode"];
                row["depttype"] = dr["depttype"];
                row["price"] = dr["price"];
                row["count"] = 1;
                row["discount"] = 90;
                view.dataGridView1.AutoGenerateColumns = false;
                view.dataGridView1.DataSource = orderService.createList(row);
                
            }
            else
            {
                //多条记录
                ProductChosseForm pcf = new ProductChosseForm();
                pcf.dataGridView1.AutoGenerateColumns = false;
                pcf.dataGridView1.DataSource = dt;
                DialogResult dr1 = pcf.ShowDialog();
                if(dr1 == DialogResult.OK)
                {
                   DataRowView drv =(DataRowView)pcf.CurrentRow.DataBoundItem;
                    Dictionary<String, Object> row = new Dictionary<string, object>();
                    row["orderlistid"] = Guid.NewGuid().ToString("N");
                    row["orderid"] = SystemInfo.CurrentOrderId;
                    row["ordercode"] = SystemInfo.CurrentOrderCode;
                    row["productid"] = drv["id"];
                    row["barcode"] = drv["barcode"];
                    row["name"] = drv["name"];
                    row["spec"] = drv["spec"];
                    row["unit"] = drv["unit"];
                    row["tintype"] = drv["tintype"];
                    row["midtype"] = drv["midtype"];
                    row["bigtype"] = drv["bigtype"];
                    row["classtype"] = drv["classtype"];
                    row["barcode"] = drv["barcode"];
                    row["depttype"] = drv["depttype"];
                    row["price"] = drv["price"];
                    row["count"] = 1;
                    row["discount"] = 90;
                    view.dataGridView1.AutoGenerateColumns = false;
                    view.dataGridView1.DataSource = orderService.createList(row);
                }

            }
            setCurrentProduct(dr);
            setCurrentOrder();
            selectLastRow();
        }

        /// <summary>
        /// 选中主界面商品表格最后一行
        /// </summary>
        public void selectLastRow()
        {
            int last = view.dataGridView1.Rows.Count;
            if (last > 1)
            {
                view.dataGridView1.CurrentCell = view.dataGridView1.Rows[last - 1].Cells[0];
            }

        }

       /// <summary>
       /// 根据全局变量查询并设置上一单界面信息
       /// </summary>
        private void setLastOrder()
        {
            DataRow row = orderService.getOrderById(SystemInfo.LastOrderId);
            if (row == null) return;
            view.lastAmountLabel.Text = row["amount"].ToString();
            view.lastCountLabel.Text = row["count"].ToString();
            view.lastDisAmountLabel.Text = row["disamount"].ToString();
            //view.lastDoneAmountLabel.Text = row["disamount"].ToString();
            //SystemInfo.CurrentOrderAmount = Decimal.Parse(row["amount"].ToString());
        }

        /// <summary>
        /// 根据全局变量查询当前订单并设置界面显示信息
        /// </summary>
        public void setCurrentOrder()
        {
            DataRow row = orderService.gatherSaleOrder(SystemInfo.CurrentOrderId);
           
            String amountStr = row["amount"].ToString();
            view.amountLabel.Text = amountStr;
            view.countLabel.Text = row["count"].ToString();
            view.disamountLabel.Text = row["disamount"].ToString();
            SystemInfo.CurrentOrderAmount = Decimal.Parse(row["amount"].ToString());
        }

        /// <summary>
        /// 根据DataRow设置主界面当前商品显示信息
        /// </summary>
        /// <param name="row"></param>
        public void setCurrentProduct(DataRow row)
        {
            view.barcodeInput.Text = "";
            view.barcodeInput.Focus();
            String currentProductName = "条码不存在";
            String currentProductPrice = "0.00";
            String currentProductUnit = "";
            if (row != null)
            {
                currentProductName = row["name"].ToString();
                currentProductPrice = row["price"].ToString();
                currentProductUnit = row["unit"].ToString();
            }
            view.currentProductNameLabel.Text = currentProductName;
            view.currentProductPriceLabel.Text = currentProductPrice;
            view.currentProductUnit.Text = currentProductUnit;
        }

        /// <summary>
        /// 处理主界面键盘事件，根据键盘事件对象组合出keyCode并通过数据库查询是否存在keyCode对应的commandKey
        /// 如果存在 执行命令，如果不存在不执行任何操作
        /// 键盘上下键不纳入到commandkey中，上下键为系统预留键位
        /// </summary>
        /// <param name="e"></param>
        public void keyPress(KeyEventArgs e)
        {
            #region 键盘上下键处理，选中相应的商品明细行
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) 
            {
                DataGridView d = view.dataGridView1;
                if (d.RowCount == 0)
                {
                    return;
                }
                int currentRowIndex = view.dataGridView1.CurrentCell.RowIndex;
                int moveRow = 0;
                if(currentRowIndex == 0 && e.KeyCode == Keys.Up )
                {
                    moveRow = 0;
                }
                else if(currentRowIndex == d.RowCount -1 && e.KeyCode == Keys.Down)
                {
                    moveRow = d.RowCount - 1;
                }
                else
                {
                    moveRow = e.KeyCode == Keys.Up ? currentRowIndex-1 : currentRowIndex+1;
                }
                view.dataGridView1.CurrentCell = view.dataGridView1.Rows[moveRow].Cells[0];
               
                e.Handled = true;
                return;
            }
            #endregion
            String keyCode = e.Control ? Keys.Control + "+" : "";
            keyCode += e.KeyCode;
            DataRow dr = keyBoardService.getRow(keyCode);
            if(dr == null)return;
            String commandKey = dr["commandkey"].ToString();
            try
            {
                CommandManager.Exec(commandKey, view);
                e.Handled = true;
            }catch(KeyNotFoundException keyE)
            {
                Console.WriteLine(keyE);
            }

        }

        public void changeNetWork(Boolean isalive)
        {
            if (isalive)
            {
                view.netStateImage.Image = global::MPOS.Properties.Resources.netstate_alive;
            }else
            {
                view.netStateImage.Image = global::MPOS.Properties.Resources.netstate_error;
            }
        }

        /// </summary>
       private String GetAddressIP()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }


    }
}
