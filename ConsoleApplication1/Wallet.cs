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
        private Bank bank = new Bank();
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

        public int getCurrency()
        {
            return wallet.Keys.Count;
        }

        public int getMoney(string currency)
        {
            if (wallet.Keys.Contains(currency))
                return wallet[currency];
            else return 0;
        }
        public string toString()
        {
            return "{ " + String.Join(", ", wallet.Select(x => x.Value + " " + x.Key)) + " }";
        }
        public int getTotalMoney(string currency)
        {
            return wallet.Sum(x => bank.convert(x.Value, x.Key, currency));
        }
    }
}
