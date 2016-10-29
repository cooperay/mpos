using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLMPOS.Service.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMPOS.Service.DB;
namespace MLMPOS.Service.DB.Tests
{
    [TestClass()]
    public class AccountServiceTests
    {
        AccountService accountService = new AccountService();
        [TestMethod()]
        public void getTableTest()
        {
            DBStatus.init();
            DataTable dt = accountService.getTable("s");
            int i = dt.Rows.Count;
            int j = 0;
            Assert.AreEqual(i, j);
           // Assert.Fail();
        }
    }
}