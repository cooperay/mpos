using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MPOS.view;
using System.Data;
namespace MPOS.command
{
    class PayCommand : BaseCommand
    {
        public void execute(Form hander)
        {
            PayListForm mf = hander as PayListForm;
            if (mf != null){
                DataRowView dr = mf.listBox1.SelectedItem as DataRowView;
                if (dr == null) return; //指定的支付类型不在列表之中不显示输入框
                PayForm form = new PayForm(dr);
                form.ShowDialog();
                mf.presenter.getTable();
            }
            
        }
    }
}
