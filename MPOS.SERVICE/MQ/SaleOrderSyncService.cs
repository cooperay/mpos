using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MLMPOS.Service.DB;
using System.Data;
using Newtonsoft.Json;
using MLMPOS.Service.Entity;
namespace MPOS.SERVICE.MQ
{
    public class SaleOrderSyncService
    {
        private static SaleOrderSyncService instance;
        private SaleOrderService saleOrderService;
        private SaleOrderSyncService()
        {
            saleOrderService = new SaleOrderService();
        }

        public static SaleOrderSyncService getInstance()
        {
            if(instance == null)
            {
                instance = new SaleOrderSyncService();
            }
            return instance;
        }



        /// <summary>
        /// 执行一次同步补偿方法，查询未同步单据 每条单据发送一次消息
        /// </summary>
        public void CallSync()
        {

        }

        /// <summary>
        /// 幂等方法
        /// 异步执行 
        /// 同步指定id的单据信息，如果单据信息为已同步不执行任何操作
        /// </summary>
        /// <param name="codeId">要同步的单据id</param>
        public void SyncOrderById(String codeId)
        {
            DataRow dr = saleOrderService.getOrderById(codeId);
            if(dr!=null || dr["state"].ToString() == "5")
            {
                ParameterizedThreadStart ParStart = new ParameterizedThreadStart(ThreadMethod);
                Thread t = new Thread(ParStart);
                t.Start(codeId);
            }
          

        }


        /// <summary>
        /// 真正执行同步的消息发送的方法
        /// </summary>
        /// <param name="codeId"></param>
        private void ThreadMethod(object codeId)
        {
            String id = (String)codeId;
            SaleOrder so = saleOrderService.getOrderEntityById(id);
            String str = JsonConvert.SerializeObject(so);
            MQHelper.getInstance().sendMessage(str);
        }

    }
}
