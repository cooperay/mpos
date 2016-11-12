using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPOS.SERVICE.HTTP;
using MPOS.SERVICE.DB;
using MPOS.SERVICE.Entity;
using JumpKick.HttpLib;
using Newtonsoft.Json;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace MPOS.CONFIG.presenter
{
    public class ConfigFormPresenter
    {
        private ConfigForm view;
        private SystemConfigService configService;
        private log4net.ILog logger = null;
        DataTable dt;
        public ConfigFormPresenter(ConfigForm view)
        {
            logger = log4net.LogManager.GetLogger(typeof(ConfigFormPresenter));
            this.view = view;
            this.configService = new SystemConfigService();
            init();
        }

        public void init()
        {
            String value = configService.getConfigById("ServerAddress");
            if (value != null)
                view.serverAddressInput.Text = value;
            String code = configService.getConfigById("initcode");
            if (code != null)
                view.registerCodeInput.Text = code;
            dt = configService.getTable();
            view.dataGridView1.DataSource = dt;
        }


        /// <summary>
        /// 服务器地址初始化设置，请求心跳接口并返回正确的ResultMessage则视为成功，
        /// 将服务器地址保存到配置数据库中
        /// </summary>
        /// <param name="address"></param>
        public void testConn()
        {
            String address = view.serverAddressInput.Text;
            view.message.Text = "正在连接服务器.....";
            view.saveButton.Enabled = false;
            Http.Get("http://" + address + "/server/heartbeat.do").OnSuccess(result =>
            {
                ResultMessage resultMessage = null;
                try
                {
                    resultMessage = JsonConvert.DeserializeObject<ResultMessage>(result);
                }
                catch (Exception e)
                {
                    logger.Debug("心跳结果解析错误：" + result);
                    logger.Error(e);
                }
                if (resultMessage == null || "failed".Equals(resultMessage.result))
                {
                    view.message.Text = "地址错误";
                    view.saveButton.Enabled = true;
                }
                else
                {
                    Dictionary<String, Object> row = new Dictionary<string, object>();
                    row["configid"] = "ServerAddress";
                    row["value"] = address;
                    row["remark"] = "服务器地址";
                    configService.insertOrUpdateConfig(row);
                    view.message.Text = "成功";
                    view.saveButton.Enabled = true;
                }
            }).OnFail(ex =>
            {
                view.message.Text = "地址错误";
                view.saveButton.Enabled = true;
            }).Go();

        }

        public void register()
        {
            String address = view.serverAddressInput.Text;
            String regCode = view.registerCodeInput.Text;
            DataTable dt = (DataTable)view.dataGridView1.DataSource;
            if (dt.Rows != null && dt.Rows.Count > 1)
            {
                dt.Rows.Clear();
            }

            Http.Get("http://" + address + "/server/register.do?code="+regCode)
                .OnSuccess(result =>
                {
                    ResultMessage resultMessage = null;
                    try
                    {
                        resultMessage = JsonConvert.DeserializeObject<ResultMessage>(result);
                    }
                    catch (Exception e)
                    {
                        logger.Debug("注册返回值错误可能是服务器地址输入有误：" + result);
                        logger.Error(e);
                    }
                    if (resultMessage == null || "failed".Equals(resultMessage.result))
                    {
                        view.registerMessage.Text = "注册码错误";
                    }
                    else
                    {
                        try
                        {
                            Dictionary<String,String> pos = JsonConvert.DeserializeObject<Dictionary<String,String>>(resultMessage.content);
                            dt.Rows.Add(new object[] { "poscode", pos["poscode"], "POS编号" });
                            dt.Rows.Add(new object[] { "posname", pos["posname"], "POS名称" });
                            dt.Rows.Add(new object[] { "shopcode", pos["shopcode"], "门店编号" });
                            dt.Rows.Add(new object[] { "shopname", pos["shopname"], "门店名称" });
                            dt.Rows.Add(new object[] { "isenable", pos["isenable"] + "", "是否启用" });
                            dt.Rows.Add(new object[] { "posid", pos["posid"], "POSID" });
                            dt.Rows.Add(new object[] { "ipaddr", pos["ipaddr"], "IP地址" });
                            dt.Rows.Add(new object[] { "initcode", pos["initcode"], "注册码" });
                            dt.Rows.Add(new object[] { "id", pos["id"] + "", "全局标识" });
                            dt.Rows.Add(new object[] { "mqaddr", pos["mqaddr"], "MQ地址" });
                            dt.Rows.Add(new object[] { "orderqueue", pos["orderqueue"] + "", "上传队列名" });
                            view.registerMessage.Text = "成功";
                        }
                        catch (KeyNotFoundException ex)
                        {
                            if (dt.Rows != null && dt.Rows.Count > 1)
                            {
                                dt.Rows.Clear();
                            }
                            logger.Debug("pos信息不完整：" + result);
                            logger.Error(ex);
                            view.registerMessage.Text = "POS信息不完整";
                        }
                        catch(Exception e)
                        {
                            logger.Error(e);
                        }
                    }
                }).OnFail(ex =>
                {
                    view.registerMessage.Text = "加载失败";
                }).Go();

        }


        public void saveRegisterInfo()
        {
            int count = view.dataGridView1.RowCount;
            if (count <= 0)
            {
                MessageBox.Show("未正确加载MPOS信息！");
                return;
            }
            for (int i = 0; i < count; i++)
            {
                DataGridViewRow row = view.dataGridView1.Rows[i];
                Dictionary<String, Object> dataRow = new Dictionary<string, object>();
                dataRow["configid"] = row.Cells[0].Value.ToString();
                dataRow["value"] = row.Cells[1].Value;
                dataRow["remark"] = row.Cells[2].Value;
                configService.insertOrUpdateConfig(dataRow);
            }
            MessageBox.Show("MPOS初始化成功！");
            init();
        }

    }
}
