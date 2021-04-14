using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace InterlockedParallelForEachApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // dosyalarin boyutunu alacagiz ve ekleye ekleye asagidaki degiskene atayacagiz. 

            long FilesByte = 0;

            string picturesPath = @"C:\Users\tahay\Desktop\Asynchronous-Threading\ForEachParallelApp\pictures\";
            var files = Directory.GetFiles(picturesPath);

            Parallel.ForEach(files, (item) => {
                Console.WriteLine("thread no: " + Thread.CurrentThread.ManagedThreadId);

                FileInfo f = new FileInfo(item);

                Interlocked.Add(ref FilesByte, f.Length); // race condition engelliyor, kilitliyor. 
                
            });

            Console.WriteLine("Dosyalarin toplam boyutu: " + FilesByte);
        }
    }
}
