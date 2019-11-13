using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLSV;

namespace UnitTestQLSV
{
    [TestClass]
    public class UnitTestMaSV
    {
        [TestMethod]
        public void Masvdung()
        {
            MainWindow msv = new MainWindow();
            var r = msv.checkmasv("16DH110904");
            Assert.IsTrue(r);
        }
        [TestMethod]
        public void Masvsai()
        {
            MainWindow msv = new MainWindow();
            var r = msv.checkmasv("16DH1109");
            Assert.IsFalse(r);
        }
    }
}
