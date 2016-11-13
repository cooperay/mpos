using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MPOS.view;

namespace MPOS.command
{
    public class LockCommand : BaseCommand
    {
        public void execute(Form hander)
        {
            MainForm mf = hander as MainForm;
            if (mf != null)
            {
                LockForm lockForm = new LockForm();
                lockForm.ShowDialog();
                mf.barcodeInput.Text = "";
            }
        }
    }
}
