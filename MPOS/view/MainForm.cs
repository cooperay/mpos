using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MLMPOS.Service.DB;
using MLMPOS.presenter;
using MLMPOS.command;
using System.Threading;
using MLMPOS.Service;
using System.Data.SQLite;

namespace MLMPOS.view
{
    public partial class MainForm : Form
    {
        public MainFormPresenter presenter;
        public MainForm()
        {
            InitializeComponent();
            DBStatus.init();
            presenter = new MainFormPresenter(this);
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
          // pictureBox1.Image = global::MLMPOS.Properties.Resources.netstate_error;
        }

       
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void ThreadMethod()
        {
            while (true)
            {
                Console.WriteLine("insert");
                Thread.Sleep(60*1000);
                using (SQLiteConnection conn = new SQLiteConnection(config.DB_FILE))
                {
                    using (SQLiteCommand cmd = new SQLiteCommand())
                    {
                        conn.Open();
                        cmd.Connection = conn;

                        SQLiteHelper sh = new SQLiteHelper(cmd);
                        try
                        {
                            Dictionary<String, Object> dc = new Dictionary<string, object>();
                            dc.Add("name", "康师傅冰红茶500ml");
                            dc.Add("price", 20.5);
                            sh.Insert("product", dc);
                        }
                        catch (Exception ex)
                        {

                        }
                        conn.Close();
                    }
                }
            }
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
    }
}
