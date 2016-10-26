using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMPOS.view;
using MLMPOS.Service.DB;

namespace MLMPOS.presenter
{
    public class PayFormPresenter
    {
        private PayForm view;
        private AccountService accountService;
        public PayFormPresenter(PayForm view)
        {
            this.view = view;
            accountService = new AccountService();
            init();
        }

        public void init()
        {
            view.realCashLabel.Text = SystemInfo.CurrentOrderMinus.ToString();
            view.textBox2.Text = SystemInfo.CurrentOrderMinus.ToString();
        }

        //回车收款
        public void enterPress()
        {
            if (view.doneAmount == 0)
            {
                view.message.Text = "金额不能小于0";
                return;
            }

            if (("0".Equals(view.paytype["isearn"])) && view.doneAmount > view.orderamount) //不可溢收
            {
                view.message.Text = "当前支付方式不可溢收";
                view.textBox2.Text = SystemInfo.CurrentOrderMinus.ToString();
                return;
            }

            String type = view.paytype["code"].ToString();
            switch (type){
                case "2":  //银联支付
                    break;
                case "3":  //M支付
                    break;
                case "4":  //微信支付
                    break;
                case "5":  //支付宝支付
                    break;
            }

            Dictionary<String, Object> row = new Dictionary<string, object>();
            row["id"] = Guid.NewGuid().ToString("N");
            row["ordercode"] = SystemInfo.CurrentOrderCode;
            row["orderid"] = SystemInfo.CurrentOrderId;
            row["sum"] = view.doneAmount;
            row["type"] = view.payTypeTitleLable.Text;
            row["date"] = DateTime.Now;
            accountService.add(row);

            if(view.doneAmount > view.orderamount)
            {
                Dictionary<String, Object> row2 = new Dictionary<string, object>();
                row["id"] = Guid.NewGuid().ToString("N");
                row["ordercode"] = SystemInfo.CurrentOrderCode;
                row["orderid"] = SystemInfo.CurrentOrderId;
                row["sum"] = view.orderamount - view.doneAmount;
                row["type"] = "找零";
                row["date"] = DateTime.Now;
                accountService.add(row);

            }

            view.Close();
        }
    }
}
