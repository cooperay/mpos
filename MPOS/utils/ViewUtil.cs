using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPOS.view;

namespace MPOS.utils
{
    public class ViewUtil
    {
        //

        /// <summary>
        /// 检查当前订单是不是空订单，
        /// 如果是空订单弹出信息提示窗口并返回true 
        /// 如果不是 返回false
        /// </summary>
        /// <param name="mf">主窗体</param>
        /// <returns></returns>
        public static Boolean IsEmptyOrder(MainForm mf)
        {
            if (mf == null)
            {
                return false;
            }
            if (SystemInfo.CurrentOrderAmount == 0 && mf.dataGridView1.RowCount == 0)
            {
                ConfirmForm cf = new ConfirmForm("订单未添加商品，请先添加商品。");
                cf.ShowDialog();
                mf.barcodeInput.Text = "";
                return true;
            }
            return false;
        }
    }
}
