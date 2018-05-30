using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;
using System.IO;

namespace Test
{
    [TestClass]
    public class TestMoneyPrinter
    {
        [TestInitialize]
        public void TestInitialize()
        {
            MoneyPrinter printer = new MoneyPrinter();
        }

        [TestMethod]
        public void TestPrint()
        {
            MoneyPrinter printer = new MoneyPrinter();
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                printer.print("Внесение", "RUB", 200);
                Assert.AreEqual<string>("Внесение RUB 200", sw.ToString());
            }
        }
    }
}
