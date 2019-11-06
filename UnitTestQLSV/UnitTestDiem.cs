using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLSV;

namespace UnitTestQLSV
{
    [TestClass]
    public class UnitTestDiem
    {
        [TestMethod]
        public void Checkdiemchuandung()
        {
            MainWindow dc = new MainWindow();
            var r = dc.checkdiemchuan(15);
            Assert.IsTrue(r);
        }
        [TestMethod]
        public void Checkdiemchuansai()
        {
            MainWindow dc = new MainWindow();
            var r = dc.checkdiemchuan(14);
            Assert.IsFalse(r);
        }

        [TestMethod]
        public void Checkdiemthisai()
        {
            MainWindow dc = new MainWindow();
            var r = dc.checkdiemthi(45);
            Assert.IsFalse(r);
        }
        [TestMethod]
        public void Checkdiemthidung()
        {
            MainWindow dc = new MainWindow();
            var r = dc.checkdiemthi(14);
            Assert.IsTrue(r);
        }
    }
}
