using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Wallet
    {
        private Dictionary<string, int> wallet = new Dictionary<string, int>();
        private Bank bank;
        private MoneyPrinter printer = new MoneyPrinter();

        public Wallet() { }

        public Wallet(Bank bank, MoneyPrinter printer)
        {
            this.printer = printer;
            this.bank = bank;
        }

        public void addMoney(string currency, int money)
        {
            printer.print("Внесение", currency, money);

            if (wallet.Keys.Contains(currency)) wallet[currency] += money;
               
            else wallet.Add(currency, money);
        }
        public void removeMoney(string currency, int money)
        {
            printer.print("Снятие", currency, money);
            if (wallet.Keys.Contains(currency))
            {
                int wallet_money = wallet[currency];

                if (money > wallet_money) throw new ArgumentException();

                else if (money == wallet_money) wallet.Remove(currency);

                else wallet[currency] -= money;
            }
            else throw new ArgumentException();
        }

        public int CountCurrency()
        {
            return wallet.Keys.Count;
        }

        public int CountMoney(string currency)
        {
            if (wallet.Keys.Contains(currency))
                return wallet[currency];
            else return 0;
        }

    }
}
