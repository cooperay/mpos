using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MLMPOS.view;
using MLMPOS.utils;
namespace MLMPOS.command
{
    class PayListCommand : BaseCommand
    {
        private Boolean showPayDialog = false;
        private String typeCode = "1";
        public PayListCommand():this(false,"1")
        {
           
        }
        public PayListCommand(Boolean showPayDialog, String typeCode)
        {
            this.showPayDialog = showPayDialog;
            this.typeCode = typeCode;
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
                mf.presenter.init();
            }
            if (mf != null)
            {
                mf.barcodeInput.Text = "";
            }
            
        }

    }
}
