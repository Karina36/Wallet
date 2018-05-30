using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;
//using Moq;

namespace Test
{
    [TestClass]
    public class TestWallet
    {
        [TestMethod]
        public void TestCreate()
        {
            Wallet wal = new Wallet();
            Assert.AreEqual(0, wal.CountCurrency());
        }

        [TestMethod]
        public void TestAddMoney()
        {
            Wallet wal = new Wallet();
            wal.addMoney("RUB", 300);
            wal.addMoney("RUB", 500);
            Assert.AreEqual(1, wal.CountCurrency());
            Assert.AreEqual(800, wal.CountMoney("RUB"));
            wal.addMoney("USD", 300);
            Assert.AreEqual(2, wal.CountCurrency());
            Assert.AreEqual(800, wal.CountMoney("RUB"));
            Assert.AreEqual(300, wal.CountMoney("USD"));
        }

        [TestMethod]
        public void TestRemoveMoney()
        {
            Wallet wal = new Wallet();
            wal.addMoney("RUB", 300);
            wal.removeMoney("RUB", 100);
            wal.addMoney("USD", 500);
            wal.removeMoney("USD", 100);
            wal.addMoney("EURO", 300);
            wal.removeMoney("EURO", 300);
            Assert.AreEqual(2, wal.CountCurrency());
            Assert.AreEqual(200, wal.CountMoney("RUB"));
            Assert.AreEqual(400, wal.CountMoney("USD"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveMoneyExp()
        {
            Wallet wal = new Wallet();
            wal.addMoney("RUB", 300);
            wal.removeMoney("RUB", 500);
            Assert.Fail();
        }

        [TestMethod]
        public void TestCountMoney()
        {
            Wallet wall = new Wallet();
            Assert.AreEqual(0, wall.CountMoney("RUB"));
        }

        [TestMethod]
        public void TestCountCurrency()
        {
            Wallet wall = new Wallet();
            Assert.AreEqual(0, wall.CountMoney("RUB"));
        }                                                                                      
    }
}
