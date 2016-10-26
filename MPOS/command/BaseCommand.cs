using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMPOS.view;
using System.Windows.Forms;
namespace MLMPOS.command
{
    public interface BaseCommand
    {
        void execute(Form hander);
    }
}
