using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaskResultConsoleApp
{
    class Program
    {
        private async static Task Main(string[] args)
        {
            Task mytask = Task.Run(() =>
            {
                throw new ArgumentException("bir hata geldi.");
            });

            await mytask;

            Console.WriteLine("islem bitti");
          
        }

    }
}
