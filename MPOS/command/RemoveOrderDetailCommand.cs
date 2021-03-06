﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MPOS.view;
using System.Data;
using MPOS.SERVICE.DB;
namespace MPOS.command
{
    //删除单品命令
    public class RemoveOrderDetailCommand : BaseCommand
    {
        private SaleOrderService saleOrderService;
        public RemoveOrderDetailCommand()
        {
            saleOrderService = new SaleOrderService();
        }
        public void execute(Form hander)
        {

            MainForm mf = hander as MainForm;
            if (mf != null && mf.dataGridView1.RowCount > 0)
            {
                
               int i =  mf.dataGridView1.CurrentRow.Index;
               DataRowView drv = (DataRowView)mf.dataGridView1.Rows[i].DataBoundItem;
                String id = drv["orderlistid"].ToString();
                saleOrderService.deleteList(id);
                mf.dataGridView1.DataSource = saleOrderService.getOrderListByOrderId(SystemInfo.CurrentOrderId);
                mf.presenter.setCurrentOrder();
                mf.presenter.selectLastRow();
            }


        }
    }
}
