using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLSV;

namespace UnitTestQLSV
{
    [TestClass]
    public class UnitCheckLogin
    {
        [TestMethod]
        public void CheckAcc()
        {

            Login lg = new Login();
            var r = lg.CheckAcc("tuan2798");
            Assert.IsTrue(r);

        }

        [TestMethod]
        public void CheckKhoangTrang()
        {

            Login lg = new Login();
            var r = lg.KhoangTrang(" ");
            Assert.IsTrue(r);

           

        }

        [TestMethod]
        public void CheckAccMoreThan6()
        {

            Login lg = new Login();
            var r = lg.CheckAcc("12345");
            Assert.IsFalse(r);

        }

        [TestMethod]
        public void CheckPass()
        {

            Login lg = new Login();
            var r = lg.CheckPass("123456789");
            Assert.IsTrue(r);

        }
        [TestMethod]
        public void checkCharacter()
        {

            Login lg = new Login();
            var r = lg.hasSpecialChar("tuan2798");
            Assert.IsFalse(r);

        }
    }
}
