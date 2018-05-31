using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;

namespace Test
{
    [TestClass]
    public class TestBank
    {
        [TestMethod]
        public void TestConvert()
        {
            Bank bank = new Bank();
            Assert.AreEqual(3, bank.convert(200, "rub", "usd"));
            Assert.AreEqual(246, bank.convert(300, "usd", "euro"));
            Assert.AreEqual(35526, bank.convert(500, "euro", "rub"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConvertExp1()
        {
            Bank bank = new Bank();
            int money = bank.convert(-200, "rub", "usd");
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConvertExp2()
        {
            Bank bank = new Bank();
            int money = bank.convert(0, "rub", "usd");
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestConvertExp3()
        {
            Bank bank = new Bank();
            int money = bank.convert(200, "rub", "yen");
            Assert.Fail();
        }
    }
}
