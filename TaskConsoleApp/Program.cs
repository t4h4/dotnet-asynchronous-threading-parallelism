using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TaskConsoleApp
{
    public class Content
    {
        public string Site { get; set; }
        public int Len { get; set; }
    }

    internal class Program
    {
        private async static Task Main(string[] args)
        {
            Console.WriteLine("Main thread: " + Thread.CurrentThread.ManagedThreadId);
            List<string> urlsList = new List<string>()
            {
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.facebook.com",
                "https://www.oracle.com",
                "https://www.google.com",
                "https://www.t4h4.net"
            };

            List<Task<Content>> taskList = new List<Task<Content>>();

            urlsList.ToList().ForEach(x =>
            {
                taskList.Add(GetContentAsync(x));
            });

            Console.WriteLine("WaitAll methodundan once");
            // WhenAll'dan farki bu method ana thread'i bloklar. senkron gibi calisir. surede belirtildigi kadar gorevler calisir. surede tamamlanirsa true, tamamlanmazsa false'da donebilir.    
            bool result = Task.WaitAll(taskList.ToArray(), 3000); // sure istersek kullanmayiz. Task.WaitAll(taskList.ToArray()); seklinde kullanabilirdik.
            Console.WriteLine("300 ms'de geldi mi?: " + result);
            Console.WriteLine("WaitAll methodundan sonra");



        }

        public static async Task<Content> GetContentAsync(string url) // asenkron methodlar geriye task doner. donenin tipi Content.
        {
            Content c = new Content();
            var data = await new HttpClient().GetStringAsync(url);

            c.Site = url;
            c.Len = data.Length;

            Console.WriteLine("GetContentAsync thread: " + Thread.CurrentThread.ManagedThreadId); // o an calisan thread id'si yazdiriliyor.

            return c;
        }
    }
}