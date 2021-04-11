using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaskConsoleApp
{
    class Program
    {
        public static void calis(Task<string> data)
        {
            // 100 satirlik kod diyelim. ayrı method olusturularak okunabilirlik daha da artti.
            Console.WriteLine("data uzunluk: " + data.Result.Length); // task oldugu icin resul ile sonuc aldik mecburen. 
        }
        private async static Task Main(string[] args) // donus tipi asenkron oldugundan void degil task. 
        {
            Console.WriteLine("Hello World!");

            var mytask = new HttpClient().GetStringAsync("https://www.google.com").ContinueWith(calis);
               
            Console.WriteLine("arada yapilacak isler");

            await mytask;
            
        }
    }
}
