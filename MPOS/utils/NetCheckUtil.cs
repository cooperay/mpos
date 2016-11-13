
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPOS.presenter;
using System.Threading;
using MPOS.SERVICE;
using JumpKick.HttpLib;
using MPOS.SERVICE.Entity;
using Newtonsoft.Json;

namespace MPOS.utils
{

    public class NetCheckUtil
    {
        private MainFormPresenter presenter;
        private static NetCheckUtil instance;
        private log4net.ILog logger = log4net.LogManager.GetLogger(typeof(NetCheckUtil));
        public static Boolean isExit = false;
        Thread thread = null;
        private NetCheckUtil()
        {

        }

        public static NetCheckUtil getInstance()
        {
            if(instance == null)
            {
                instance = new NetCheckUtil();
            }
            return instance;
        }

        public void startNetCheck(MainFormPresenter presenter)
        {
            if (presenter == null)
            {
                return;
            }
            this.presenter = presenter;
            thread = new Thread(ThreadMethed);
            thread.Start();
        }

        public void ThreadMethed()
        {
            while (true)
            {
                if (isExit) return;
                heartbeat();
                Thread.Sleep(15*1000);
               
            }

        }

        public void heartbeat()
        {

            logger.Debug("Server heartbeat");
            String address = SystemInfo.getConfig(SystemInfo.SERVER_ADDRESS).ToString();
            String posid = SystemInfo.getConfig(SystemInfo.POS_ID).ToString();
            Http.Get("http://" + address + "/server/heartbeat.do?posid="+posid).OnSuccess(result =>
            {
                ResultMessage resultMessage = null;
                try
                {
                    resultMessage = JsonConvert.DeserializeObject<ResultMessage>(result);
                }
                catch (JsonReaderException e)
                {
                    logger.Debug("心跳结果解析错误：" + result);
                    logger.Error(e);
                }
                if (resultMessage == null || "failed".Equals(resultMessage.result))
                {
                    SystemInfo.SERVER_STATE = false;
                    logger.Debug("Server heartbeat failed");
                }
                else
                {
                    SystemInfo.SERVER_STATE = true;
                }
                presenter.changeNetWork(SystemInfo.SERVER_STATE && SystemInfo.MQ_STATE);
            }).OnFail(ex =>
            {
                SystemInfo.SERVER_STATE = false;
                presenter.changeNetWork(false);
                logger.Debug("Server heartbeat net error");
            }).Go();
        }

   

    }
}
