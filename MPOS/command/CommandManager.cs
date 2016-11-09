using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MPOS.command
{
    public static class CommandManager
    {
        //主界面命令
        public static String COMMAND_PAY = "pay";
        public static String COMMAND_MEMBER = "member";
        public static String COMMAND_SINGLE_DEL = "single_del";
        public static String HOLD_ORDER　=　"hold_order";

        public static String PAY_COMMAND_M = "pay_mcard";
        public static String PAY_COMMAND_WX = "pay_wx";
        public static String PAY_COMMAND_ALIPAY = "pay_alipay";
        public static String PAY_COMMAND_YL = "pay_yl";
        public static String PAY_COMMAND_CASH = "pay_cash";
        //支付列表命令
        public static String PAY_COMMAND = "pay_command";

        private static Dictionary<String, BaseCommand> commands = initCommands() ;
        
        static Dictionary<String, BaseCommand> initCommands()
        {
            
           Dictionary<String, BaseCommand> commands = new Dictionary<String, BaseCommand>();
           commands.Add(COMMAND_MEMBER, new MemberEnterCommand());
            commands.Add(COMMAND_SINGLE_DEL, new RemoveOrderDetailCommand());
            commands.Add(HOLD_ORDER, new HoldOrderCommand());


            commands.Add(COMMAND_PAY, new PayListCommand());
            commands.Add(PAY_COMMAND_CASH, new PayListCommand(true, "1"));  //现金
            commands.Add(PAY_COMMAND_YL, new PayListCommand(true, "2"));    //银联支付
            commands.Add(PAY_COMMAND_WX, new PayListCommand(true, "4"));    //银联支付
            commands.Add(PAY_COMMAND_M, new PayListCommand(true, "3"));    //银联支付
           commands.Add(PAY_COMMAND_ALIPAY, new PayListCommand(true,"5")); //支付宝支付

            commands.Add(PAY_COMMAND, new PayCommand());
            return commands;
        }
        /// <summary>
        /// 执行指定commandKey的命令 
        /// </summary>
        /// <param name="commandKey">要执行命令的key</param>
        /// <param name="hander">执行命令需要传入的form实体（指定命令在哪个窗体执行）</param>
        public static void Exec(String commandKey,Form hander)
        {
            if (commandKey == null)
            {
                throw new Exception("未指定命令");
            }
            if(hander == null)
            {
                throw new Exception("未指定hander");
            }
            commands[commandKey].execute(hander);
        }

    }
}
