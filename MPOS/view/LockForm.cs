using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MPOS.presenter;

namespace MPOS.view
{
    public partial class LockForm : BaseDialogForm
    {
        private DateTime createTime = DateTime.Now;
        private int minute = 0;
        private int hour = 0;
        private long second;
        private LockFormPresenter presenter;
        public LockForm()
        {
            InitializeComponent();
            base.KeyDown -= new System.Windows.Forms.KeyEventHandler(base.BaseDialogForm_KeyDown);
            presenter = new LockFormPresenter(this);
        }

        
        protected new void BaseDialogForm_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            long d = DateTime.Now.Ticks - createTime.Ticks;
            second = d / 10000000 - minute*60 - hour*60*60;
            
            if (second >= 60)
            {
                minute += 1;
                second = 0;
            }
            if (minute >= 60)
            {
                hour += 1;
                minute = 0;
                second = 0;
            }
            timerLabel.Text = hour.ToString("00") + ":" + minute.ToString("00") + ":" + second.ToString("00");
         }

        private void LockForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                presenter.DoLogin();
            }
        }
    }
}
