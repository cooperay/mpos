using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MPOS.component
{
    public partial class BaseGrid : DataGridView
    {
        public BaseGrid()
        {
            InitializeComponent();
            
        }

        public BaseGrid(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void this_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
            e.RowBounds.Location.Y,
            this.RowHeadersWidth - 4,
            e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            this.RowHeadersDefaultCellStyle.Font,
            rectangle,
            this.RowHeadersDefaultCellStyle.ForeColor,
            TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
    }
}
