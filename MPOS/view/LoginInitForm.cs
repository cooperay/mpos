using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MLMPOS.presenter;

namespace MLMPOS.view
{
    public partial class LoginInitForm : Form
    {
        private LoginPresenter presenter;
        public LoginInitForm()
        {
            InitializeComponent();
            presenter = new LoginPresenter(this);
        }

        private void LoginInitForm_Load(object sender, EventArgs e)
        {
            presenter.SystemInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            presenter.DoLogin();
        }
    }
}
