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
    public partial class ProductChosseForm : BaseDialogForm
    {
        public DataGridViewRow CurrentRow = null;
        public ProductChosseForm()
        {
            InitializeComponent();
        }

        private void ProductChosseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                CurrentRow = dataGridView1.CurrentRow;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
