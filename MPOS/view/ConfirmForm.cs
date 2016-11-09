using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MPOS.view
{
    public partial class ConfirmForm : BaseDialogForm
    {
        private String message;
        public ConfirmForm():this("")
        {
           
        }

        public ConfirmForm(String message)
        {
            this.message = message;
            InitializeComponent();
        }

        private void ConfirmForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ConfirmForm_Load(object sender, EventArgs e)
        {
            this.messageLabel.Text = message;
        }
    }
}
