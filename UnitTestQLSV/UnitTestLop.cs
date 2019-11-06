using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLSV;

namespace UnitTestQLSV
{
    [TestClass]
    public class UnitTestLop
    {
        [TestMethod]
        public void Checksisosai()
        {
            Phancong ph = new Phancong();
            var r = ph.Checksiso(45);
            Assert.IsFalse(r);
        }

        [TestMethod]
        public void Checksisodung()
        {
            Phancong ph = new Phancong();
            var r = ph.Checksiso(40);
            Assert.IsTrue(r);
        }

    }
}
