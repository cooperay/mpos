using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MPOS.SERVICE.DB;
using MPOS.presenter;
using MPOS.command;
using System.Threading;
using MPOS.SERVICE;
using System.Data.SQLite;
using MPOS.SERVICE.MQ;
using MPOS.utils;
namespace MPOS.view
{
    public partial class MainForm : Form
    {
        public MainFormPresenter presenter;
        public MainForm()
        {
            InitializeComponent();
            DBStatus.init();
            presenter = new MainFormPresenter(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
          // pictureBox1.Image = global::MPOS.Properties.Resources.netstate_error;
        }

       
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SyncBackUtil.isExit = true;
            NetCheckUtil.isExit = true;
           Application.Exit();
        }

       

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
            e.RowBounds.Location.Y,
            dataGridView1.RowHeadersWidth - 4,
            e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            dataGridView1.RowHeadersDefaultCellStyle.Font,
            rectangle,
            dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
            TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            presenter.keyPress( e);
        }

        private void barcodeInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                presenter.scanCode();
                e.Handled = true;
            }
        }

        private void logo_Click(object sender, EventArgs e)
        {

        }
    }
}
