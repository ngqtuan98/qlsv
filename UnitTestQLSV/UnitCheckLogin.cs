using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLSV;

namespace UnitTestQLSV
{
    [TestClass]
    public class UnitCheckLogin
    {
        [TestMethod]
        public void CheckAccRight()
        {

            Login lg = new Login();
            var r = lg.CheckAcc("tuan2798");
            Assert.IsTrue(r);

        }

        [TestMethod]
        public void CheckAccLessThan6()
        {
            Login lg = new Login();
            var r = lg.CheckAcc("12345");
            Assert.IsFalse(r);
        }


        [TestMethod]
        public void CheckAccMoreThan15()
        {
            Login lg = new Login();
            var r = lg.CheckAcc("aaaaaaaaaaaaaaaa");
            Assert.IsFalse(r);
        }


        [TestMethod]
        public void CheckKhoangTrangRight()
        {
            Login lg = new Login();
            var r = lg.KhoangTrang("Trideptrai");
            Assert.IsFalse(r);
        }
        [TestMethod]
        public void CheckKhoangTrangWrong()
        {
            Login lg = new Login();
            var r = lg.KhoangTrang("fvf fvff");
            Assert.IsTrue(r);
        }        

        [TestMethod]
        public void CheckAccSoODauWrong()
        {
            Login lg = new Login();
            var r = lg.CheckStartWithNumber("123trideptrai");
            Assert.IsFalse(r);
        }
        //
        [TestMethod]
        public void CheckAccSoODauRight()
        {
            Login lg = new Login();
            var r = lg.CheckStartWithNumber("trideptrai");
            Assert.IsTrue(r);
        }

        [TestMethod]
        public void CheckKiTuDacBietODauWrong()
        {
            Login lg = new Login();
            var r = lg.CheckStartWithSpecial("#trideptrai");
            Assert.IsFalse(r);
        }

        [TestMethod]
        public void CheckKiTuDacBietODauRight()
        {
            Login lg = new Login();
            var r = lg.CheckStartWithSpecial("trideptrai#");
            Assert.IsTrue(r);
        }

        [TestMethod]
        public void CheckPassLessThan8()
        {

            Login lg = new Login();
            var r = lg.CheckPassLength("aB!1");
            Assert.IsFalse(r);

        }

        public void CheckPassMoreThan20()
        {

            Login lg = new Login();
            var r = lg.CheckPassLength("A1@aaaaaaaaaaaaaaaaaaaaaa");
            Assert.IsFalse(r);

        }


        [TestMethod]
        public void CheckPassLengthRight()
        {
            Login lg = new Login();
            var r = lg.CheckPassLength("123ABCabc!@#");
            Assert.IsTrue(r);
        }

        [TestMethod]
        public void CheckPassRight()
        {
            Login lg = new Login();
            var r = lg.CheckPassNumber_Special_Upper("123ABCabc!@#");
            Assert.IsTrue(r);
        }

        [TestMethod]
        public void CheckPassNoNumber()
        {
            Login lg = new Login();
            var r = lg.CheckPassNumber_Special_Upper("abcsdfaw@#ABC");
            Assert.IsFalse(r);
        }


        [TestMethod]
        public void CheckPassNoSpecialCharacter()
        {
            Login lg = new Login();
            var r = lg.CheckPassNumber_Special_Upper("abcsdfaw123ABC");
            Assert.IsFalse(r);
        }

        [TestMethod]
        public void CheckPassNoUpperLetter()
        {
            Login lg = new Login();
            var r = lg.CheckPassNumber_Special_Upper("abcsdfaw123!@#");
            Assert.IsFalse(r);
        }

        
    }
}
