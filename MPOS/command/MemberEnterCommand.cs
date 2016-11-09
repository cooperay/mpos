using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MPOS.view;

namespace MPOS.command
{
    public class MemberEnterCommand : BaseCommand
    {
        public void execute(Form hander)
        {
            MainForm mf = hander as MainForm;
            MemberEnterForm form = new MemberEnterForm();
            form.ShowDialog();
            if (mf != null)
            {
                mf.barcodeInput.Text = "";
                
            }
        }
    }
}
