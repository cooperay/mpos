using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPOS.view;
using MPOS.SERVICE.DB;
using System.Data;

namespace MPOS.presenter
{
    public class LockFormPresenter
    {
        private LockForm view;
        private CashierService service;
        public LockFormPresenter(LockForm view)
        {
            this.view = view;
            service = new CashierService();
        }

        public void DoLogin()
        {
            String code = SystemInfo.getConfig(SystemInfo.CASHIER_CODE).ToString();
            String pwd = view.pwdInput.Text;
            DataRow row = service.CheckCashier(code, pwd);
            if (row != null)
            {
                view.Close();
            }
            else
            {
                view.messageLabel.Text = "密码错误";
            }
           
        }


    }
}
