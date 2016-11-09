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
    public partial class AppForm : Form
    {
        public AppForm()
        {
            InitializeComponent();
         
        }

        private void AppForm_Load(object sender, EventArgs e)
        {
            LoginInitForm login = new LoginInitForm();
            login.MdiParent = this;
            login.Show();
        }
    }
}
