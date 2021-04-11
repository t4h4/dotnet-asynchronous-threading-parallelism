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

            var mytask = new HttpClient().GetStringAsync("https://www.google.com");
               
            Console.WriteLine("arada yapilacak isler");

            var data = await mytask;
            Console.WriteLine("data uzunluk: " + data.Length);
        }
    }
}
