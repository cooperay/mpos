using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMPOS.view;
using System.Data;
using MLMPOS.presenter;
using MLMPOS.Service.DB;
namespace MLMPOS.presenter
{
   public class LoginPresenter
    {
        private LoginInitForm view;
        private CashierService service;
        public LoginPresenter(LoginInitForm view)
        {
            this.view = view;
            this.service = new CashierService();
        }

        public void SystemInit()
        {
            DBStatus.init();
        }

        public void DoLogin()
        {
            String code = view.codeInput.Text;
            String pwd = view.pwdInput.Text;
            DataRow row = service.CheckCashier(code, pwd);
            if (row != null)
            {
                SystemInfo.cashier = row["name"].ToString();
                SystemInfo.cashierCode = row["code"].ToString();
                MainForm main = new MainForm();
                main.Show();
                view.Hide();
            }
            else
            {
                view.infoLabel.Text = "工号或密码错误";
            }
        }
    }
}
