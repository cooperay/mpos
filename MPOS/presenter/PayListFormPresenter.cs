using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMPOS.view;
using MLMPOS.Service.DB;
using System.Data;
using MLMPOS.command;
using System.Windows.Forms;

namespace MLMPOS.presenter
{
    public class PayListFormPresenter
    {
        public PayListForm view;
        private PayTypeService payTypeService;
        private AccountService accountService;
        public PayListFormPresenter(PayListForm view)
        {
            this.view = view;
            payTypeService = new PayTypeService();
            accountService = new AccountService();
            init();
        }

        public void init()
        {
            DataTable dt = payTypeService.getTable();
            view.listBox1.DataSource = dt;
            view.listBox1.DisplayMember = "name";
            view.listBox1.ValueMember = "code";
            view.realCashLabel.Text = SystemInfo.CurrentOrderAmount.ToString();
            getTable();
        }

        

        //选中支付方式并回车
       

        public void pay(Boolean showPayDialog)
        {
            if (SystemInfo.CurrentOrderMinus > 0)
            {
                if (showPayDialog)
                    CommandManager.Exec(CommandManager.PAY_COMMAND, view);
            }
            else
            {
                view.DialogResult = DialogResult.OK;
                view.Close();
            }
        }

        public void getTable()
        {
            view.dataGridView1.AutoGenerateColumns = false;
            view.dataGridView1.DataSource = accountService.getTable(SystemInfo.CurrentOrderId);
            Decimal done = accountService.gatherDoneAmmount(SystemInfo.CurrentOrderId);
            Decimal minus = SystemInfo.CurrentOrderAmount - done;
            SystemInfo.CurrentOrderMinus = minus;
            view.doneCashLabel.Text = done.ToString();
            view.minusLabel.Text = minus.ToString();
        }

    }
}
