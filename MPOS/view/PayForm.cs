using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MPOS.presenter;

namespace MPOS.view
{
    public partial class PayForm : BaseDialogForm
    {
        public PayFormPresenter presenter;
        public Decimal doneAmount = 0;
        public Decimal orderamount = 0;
        public DataRowView paytype = null;
       

        public PayForm(DataRowView payType)
        {
            InitializeComponent();
            this.paytype = payType;
            payTypeTitleLable.Text = payType["name"].ToString();
            presenter = new PayFormPresenter(this);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            orderamount = SystemInfo.CurrentOrderMinus;
            if (textBox2.Text != "")
            {
                doneAmount = Decimal.Parse(textBox2.Text);
            }
            else
            {
                doneAmount = 0;
            }
            chargeLabel.Text = (doneAmount- orderamount).ToString();
        }

        /**
         * 金额输入框验证 只能数据数字
         * */
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            const char Enter = (char)13;
            if(e.KeyChar == Enter && textBox2.Text!=null)
            {
                e.Handled = true;
                presenter.enterPress();
                return;
            }
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9') && e.KeyChar != Delete && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
