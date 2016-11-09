using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MPOS.view;
using MPOS.SERVICE.DB;
using MPOS.utils;

namespace MPOS.command
{
    /**
     * 挂单执行命令
     * */
    public class HoldOrderCommand : BaseCommand
    {
        private SaleOrderService saleOrderService;
        public HoldOrderCommand()
        {
            saleOrderService = new SaleOrderService();
        }
       
        public void execute(Form hander)
        {
            MainForm mf = hander as MainForm;
            if (ViewUtil.IsEmptyOrder(mf))
            {
                return;
            }
            if (mf != null)
            {
                ConfirmForm cf = new ConfirmForm("确认挂单？");
                DialogResult dr = cf.ShowDialog();
                if(dr == DialogResult.OK)
                {
                    saleOrderService.update(SystemInfo.CurrentOrderId, "state", "5");
                    mf.presenter.init();
                }
                
            }
        }
    }
}
