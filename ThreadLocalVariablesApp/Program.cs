using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadLocalVariablesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = 0;

            // subtotal o anki thread'in kendi icerisinde hesaplayacagi deger. 
            // () => 0 lokal baslangic degeri 0
            // loop donguyu temsil ediyor. 
            Parallel.ForEach(Enumerable.Range(1, 100).ToList(), () => 0, (x, loop, subtotal) =>
              {
                  subtotal += x;
                  return subtotal;
              }, (y) => Interlocked.Add(ref total, y));

            Console.WriteLine(total);
        }
    }
}
