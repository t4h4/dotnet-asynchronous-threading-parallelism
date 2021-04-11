using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaskConsoleApp
{
    class Program
    {
        private async static Task Main(string[] args) // donus tipi asenkron oldugundan void degil task. 
        {
            Console.WriteLine("Hello World!");

            var mytask = new HttpClient().GetStringAsync("https://www.google.com").ContinueWith
                ((data) => // data google'dan gelen veri. 
            {
                Console.WriteLine("data uzunluk: " + data.Result.Length);
            });

            Console.WriteLine("arada yapilacak isler");

            await mytask;
        }
    }
}
