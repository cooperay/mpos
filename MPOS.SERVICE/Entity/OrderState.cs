using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPOS.SERVICE.Entity
{
    public enum OrderState
    {
        Dirty,  //作废
        New,     //新建
        Payed,   //支付完成
        Holding, //挂单
        Synced   //同步完成
    }
}
