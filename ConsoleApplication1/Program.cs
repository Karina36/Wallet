using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Wallet wal = new Wallet();
            wal.addMoney("RUB", 300);
            Console.Read();
        }
    }
}
