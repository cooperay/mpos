using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MPOS.view;
using MPOS.utils;
using MPOS.SERVICE.MQ;
using MPOS.SERVICE.DB;
using MPOS.SERVICE.Entity; 
namespace MPOS.command
{
    class PayListCommand : BaseCommand
    {
        private Boolean showPayDialog = false;
        private String typeCode = "1";
        private SaleOrderService saleOrderService;
        public PayListCommand():this(false,"1")
        {
           
        }
        public PayListCommand(Boolean showPayDialog, String typeCode)
        {
            this.showPayDialog = showPayDialog;
            this.typeCode = typeCode;
            saleOrderService = new SaleOrderService();
        }
        public void execute(Form hander)
        {
            MainForm mf = hander as MainForm;
            if (ViewUtil.IsEmptyOrder(mf))
            {
                return;
            }
           
            PayListForm form = new PayListForm(showPayDialog);
            form.listBox1.SelectedValue = typeCode;
            DialogResult dr =  form.ShowDialog();
            if (dr == DialogResult.Cancel)  //非正常关闭不做任何处理
            {
                
            }
            else
            {
                SystemInfo.LastOrderId = SystemInfo.CurrentOrderId;
                saleOrderService.updateState(SystemInfo.CurrentOrderId, "5");
                SaleOrder order = saleOrderService.getOrderEntityById(SystemInfo.CurrentOrderId);
                MQHelper mqhelper = MQHelper.getInstance(SystemInfo.getConfig(SystemInfo.SHOP_CODE).ToString(), SystemInfo.getConfig(SystemInfo.POS_CODE).ToString(), SystemInfo.getConfig(SystemInfo.MQ_ADDRESS).ToString(), SystemInfo.getConfig(SystemInfo.ORDER_QUEUE).ToString());
                mqhelper.asyncSendMessage(order);
                mf.presenter.init();
            }
            if (mf != null)
            {
                mf.barcodeInput.Text = "";
            }
            
        }

    }
}
