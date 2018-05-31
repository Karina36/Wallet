using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Bank
    {
        private const int rand = 9;
        private Dictionary<string, double> course;
        public IEnumerable<string> currency
        {
            get { return course.Keys; }
        }

        public Bank()
        {
            course = new Dictionary<string, double>();
            course.Add("USD", 1);
            course.Add("RUB", 1 / 62.0);
            course.Add("EURO", 1.18);
        }

        public virtual int convert(int money, string from, string to)
        {
            from = from.ToUpper();
            to = to.ToUpper();

            if (money <= 0) throw new ArgumentException();
            if (!currency.Contains(from) || !currency.Contains(to)) throw new NotImplementedException();

            var d_value = course[from] * money;
            var fluctuation = (int)(d_value * 0.2);
            var randomBetween = new Random(rand).Next(-fluctuation, fluctuation);
            d_value += randomBetween;

            return (int)Math.Abs(d_value / course[to]);

        }
    }
}
