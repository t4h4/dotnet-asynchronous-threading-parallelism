using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelForApp
{
    class Program
    {
        static void Main(string[] args)
        {
            long totalByte = 0;
            var files = Directory.GetFiles(@"C:\Users\tahay\Desktop\Asynchronous-Threading\ForEachParallelApp\pictures\");

            Parallel.For(0, files.Length, (index) =>
            {
                var file = new FileInfo(files[index]);
                Interlocked.Add(ref totalByte, file.Length);
            });

            Console.WriteLine(totalByte);
        }
    }
}
