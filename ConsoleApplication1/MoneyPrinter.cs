using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class MoneyPrinter
    {
        public virtual void print(string operation, string currency, int money)
        {
            Console.Write(operation + " " + currency + " " + money);
        }
    }
}
