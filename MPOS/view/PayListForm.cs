using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MLMPOS.command;
using MLMPOS.presenter;
namespace MLMPOS.view
{
    public partial class PayListForm : BaseDialogForm
    {
        public PayListFormPresenter presenter;
        public Boolean showPayDialog = false;
        public PayListForm(Boolean showPayDialog = false)
        {
            InitializeComponent();
            this.showPayDialog = showPayDialog;
            presenter = new PayListFormPresenter(this);
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                presenter.pay(true);
            }
           
        }


        private void PayListForm_Shown(object sender, EventArgs e)
        {
            presenter.pay(showPayDialog);
        }
    }
}
