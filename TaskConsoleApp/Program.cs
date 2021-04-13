using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TaskConsoleApp
{
    

    internal class Program
    {
        public static string CacheData { get; set; }

        private async static Task Main(string[] args)
        {
            CacheData = await GetDataAsync();
            Console.WriteLine(CacheData);
        }    

        public static Task<string> GetDataAsync()
        {
            if(String.IsNullOrEmpty(CacheData))
            {
                return File.ReadAllTextAsync("C:/Users/tahay/Desktop/AsynchronousMulti-Threading/TaskConsoleApp/dosya.txt");
            }
            else
            {
                return Task.FromResult<string>(CacheData);
            }
            
        }
    }
}