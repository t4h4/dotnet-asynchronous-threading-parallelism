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
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.facebook.com",
                "https://www.oracle.com",
                "https://www.t4h4.net"
            };

            List<Task<Content>> taskList = new List<Task<Content>>();

            urlsList.ToList().ForEach(x =>
            {
                taskList.Add(GetContentAsync(x));
            });

            var contents = Task.WhenAll(taskList.ToArray()); // WhenAll methodu parametre olarak task array alir, array icindeki task'lerin hepsi tamamlayincaya kadar bekler. 

            Console.WriteLine("WhenAll method sonrasi baska isler yapildi.");

            var data = await contents;

            data.ToList().ForEach(x =>
            {
                Console.WriteLine($"{x.Site} boyut:{x.Len}");
            });
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