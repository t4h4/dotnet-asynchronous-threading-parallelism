using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ForEachParallelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch(); // kronometre
            sw.Start(); // kronometre basladi.

            string picturesPath = @"C:\Users\tahay\Desktop\Asynchronous-Threading\ForEachParallelApp\pictures\";
            var files = Directory.GetFiles(picturesPath);

            Parallel.ForEach(files, (item) => {
            Console.WriteLine("thread no: " + Thread.CurrentThread.ManagedThreadId);
            Image img = new Bitmap(item);

            var thumbnail = img.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);

            thumbnail.Save(Path.Combine(picturesPath, "thumbnail", Path.GetFileName(item)));
            });

            sw.Stop(); // kronometre bitti. 
            Console.WriteLine("işlem bitti. bu kadar milisaniye sürdü: " + sw.ElapsedMilliseconds);
        }
    }
}
