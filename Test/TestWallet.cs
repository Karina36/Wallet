using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;
using Moq;

namespace Test
{
    [TestClass]
    public class TestWallet
    {
        Wallet wal;

        [TestInitialize]
        public void TestInitialize()
        {
            var bank = new Mock<Bank>();
            bank.Setup(x => x.convert(It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<String>())).Returns(2);
            var printer = new Mock<MoneyPrinter>();
            printer.Setup(x => x.print(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()));
            wal = new Wallet(bank.Object, printer.Object);
        }

        [TestMethod]
        public void TestCreate()
        {
            Assert.AreEqual(0, wal.getCurrency());
        }

        [TestMethod]
        public void TestAddMoney()
        {
            wal.addMoney("RUB", 300);
            wal.addMoney("RUB", 500);
            Assert.AreEqual(1, wal.getCurrency());
            Assert.AreEqual(800, wal.getMoney("RUB"));
            wal.addMoney("USD", 300);
            Assert.AreEqual(2, wal.getCurrency());
            Assert.AreEqual(800, wal.getMoney("RUB"));
            Assert.AreEqual(300, wal.getMoney("USD"));
        }

        [TestMethod]
        public void TestRemoveMoney()
        {
            wal.addMoney("RUB", 300);
            wal.removeMoney("RUB", 100);
            wal.addMoney("USD", 500);
            wal.removeMoney("USD", 100);
            wal.addMoney("EURO", 300);
            wal.removeMoney("EURO", 300);
            Assert.AreEqual(2, wal.getCurrency());
            Assert.AreEqual(200, wal.getMoney("RUB"));
            Assert.AreEqual(400, wal.getMoney("USD"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveMoneyExp()
        {
            wal.addMoney("RUB", 300);
            wal.removeMoney("RUB", 500);
            Assert.Fail();
        }

        [TestMethod]
        public void TestGetMoney()
        {
            Assert.AreEqual(0, wal.getMoney("RUB"));
        }

        [TestMethod]
        public void TestGetCurrency()
        {
            Assert.AreEqual(0, wal.getMoney("RUB"));
        }

        [TestMethod]
        public void TestToString()
        {
            wal.addMoney("RUB", 200);
            wal.addMoney("EURO", 500);
            Assert.AreEqual("{ 200 RUB, 500 EURO }", wal.toString());
        }

        [TestMethod]
        public void TestGetTotalMoney()
        {
            wal.addMoney("RUB", 150);
            wal.addMoney("EURO", 300);
            Assert.AreEqual(4, wal.getTotalMoney("RUB"));
        }
    }
}
