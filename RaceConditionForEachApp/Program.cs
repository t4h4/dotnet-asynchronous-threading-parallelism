using System;
using System.Linq;
using System.Threading.Tasks;

namespace RaceConditionForEachApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int deger = 0;

            Parallel.ForEach(Enumerable.Range(1, 10000000).ToList(), (x) =>
            {
                deger = x;
            });

            Console.WriteLine(deger);
        }
    }
}
