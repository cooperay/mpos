using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPOS.view;
using System.Data;
using MPOS.presenter;
using MPOS.SERVICE.DB;
using MPOS.utils;
namespace MPOS.presenter
{
   public class LoginPresenter
    {
        private LoginInitForm view;
        private CashierService service;
        private SystemConfigService configService;
        public LoginPresenter(LoginInitForm view)
        {
            this.view = view;
            this.service = new CashierService();
            this.configService = new SystemConfigService();
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
                SystemInfo.setConfig(SystemInfo.CASHIER_NAME,  row["name"].ToString());
                SystemInfo.setConfig(SystemInfo.CASHIER_CODE, row["code"].ToString());
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
