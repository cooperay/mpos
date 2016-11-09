using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPOS.view;
using System.Windows.Forms;
namespace MPOS.command
{
    public interface BaseCommand
    {
        void execute(Form hander);
    }
}
