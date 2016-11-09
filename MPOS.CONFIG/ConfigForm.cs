using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MPOS.CONFIG.presenter;
using MPOS.SERVICE.HTTP;
using System.Configuration;
using MPOS.SERVICE.DB;
namespace MPOS.CONFIG
{
    public partial class ConfigForm : Form
    {
        private ConfigFormPresenter presenter;
        public ConfigForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            DBStatus.init();
            presenter = new ConfigFormPresenter(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            presenter.testConn();

        }

        private void serverAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            presenter.register();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            presenter.saveRegisterInfo();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            presenter.init();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine(e);
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}
