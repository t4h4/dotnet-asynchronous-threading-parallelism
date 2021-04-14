using System;
using System.Diagnostics;
using System.Linq;

namespace PLINQApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch(); // kronometre
            sw.Start(); // kronometre basladi.
            var array = Enumerable.Range(1, 50000).ToList();

            var newArray = array.AsParallel().Where(x => x % 2 == 0);

            newArray.ToList().ForEach(x =>
            {
                Console.WriteLine(x);
            });
            sw.Stop(); // kronometre bitti. 
            Console.WriteLine("işlem bitti. bu kadar milisaniye sürdü: " + sw.ElapsedMilliseconds);
        }
    }
}
